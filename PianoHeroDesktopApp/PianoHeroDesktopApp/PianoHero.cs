﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Configuration;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Sockets;

//Program: PianoHeroDesktopApp
//Description: This tab control driven application enables the user to convert their own wav files to midi which will allow them to 
//             play/learn the song on a keyboard.
//Programmers: James Milne, John Hall
//Start Date: 19 Jan 2020

namespace PianoHeroDesktopApp
{


   

    public partial class PianoHero : MetroForm
    {

        string defaultSaveString = ConfigurationManager.AppSettings["SaveLoc"];
        string defaultVolumeStr = ConfigurationManager.AppSettings["Volume"];
        string defaultPlaySpeedStr = ConfigurationManager.AppSettings["Speed"];
        string wavFile = "";
        string midiFile = "";
        string ctrlIpAddr = "192.168.0.100";//"127.0.0.1";//
        private const int BufferSize = 54;







        public PianoHero()
        {
            InitializeComponent();
            int defaultVolume = Convert.ToInt32(defaultVolumeStr);
            int defaultPlaySpeed = Convert.ToInt32(defaultPlaySpeedStr);

            defaultSave.Text = defaultSaveString;

            //Listen for microcontrollers to be connected

            //*****TCP - currently using UDP - SEE ListenUDP method*****//



            //string portNumStr = ConfigurationManager.AppSettings["Port"];
            //int portNum = Int32.Parse(portNumStr);

            //Thread t = new Thread(delegate ()
            //{
            //    IPHostEntry host = Dns.GetHostEntry("localhost");
            //    IPAddress ipAddress = host.AddressList[0];

            //    Server server = new Server(ipAddress.ToString(), portNum);


            //});

            //t.Start();

          




        }

        public struct UdpState
        {
            public UdpClient u;
            public IPEndPoint e;
        }

        public static bool messageReceived = false;

        public static void ReceiveCallback(IAsyncResult ar)
        {
            UdpClient u = ((UdpState)(ar.AsyncState)).u;
            IPEndPoint e = ((UdpState)(ar.AsyncState)).e;

            byte[] receiveBytes = u.EndReceive(ar, ref e);
            string receiveString = Encoding.ASCII.GetString(receiveBytes);

            Console.WriteLine($"Received: {receiveString}");
            messageReceived = true;
        }

        public static void ReceiveMessages()
        {

            string portNumStr = ConfigurationManager.AppSettings["Port"];
            int portNum = Int32.Parse(portNumStr);

            // Receive a message 
            IPEndPoint e = new IPEndPoint(IPAddress.Any, portNum);
            UdpClient u = new UdpClient(e);

            UdpState s = new UdpState();
            s.e = e;
            s.u = u;
            
            u.BeginReceive(new AsyncCallback(ReceiveCallback), s);

          
            while (!messageReceived)
            {
                Thread.Sleep(100);
            }
        }


        //ConvertButton_Click()
        //Summary: This method calls the cloud conversion service to upload the wav file and download the converted midi file
        //Params: sender, e
        //Returns: none
        private void convertButton_Click(object sender, EventArgs e)
        {
            //1. Retreive filename of wav file to upload

            string shortnedFileName = Path.GetFileName(wavFile);

            string uriString = @"http://127.0.0.1:8000/wav2midi/";//@"http://mockwav2midi.herokuapp.com/wav2midi/";
            WebClient cloudService = new WebClient();

            //2. Upload the wav file to the service
            convertButton.Enabled = false;
            byte[] response = cloudService.UploadFile(uriString, wavFile);

            //3. Download the converted file
            //4. Save that file to the default wav location
            string path = Environment.ExpandEnvironmentVariables(defaultSaveString);
            File.WriteAllBytes(path + "\\" + shortnedFileName + ".midi", response);


            convertButton.Enabled = true;

            respMessage.Text = "Your converted file is successfully saved at " + defaultSaveString + "\\" + shortnedFileName + ".midi";
           
        }

        //PlayButton_Click()
        //Summary: This method calls the cloud conversion service to upload the wav file and download the converted midi file
        //Params: sender, e
        //Returns: none
        private void playButton_Click(object sender, EventArgs e)
        {
            fileSendProgress.Visible = true;
            fileSendStatus.Text = "Sending file to microcontroller, please wait...";

            string portNumStr = ConfigurationManager.AppSettings["Port"];
            int portNum = Int32.Parse(portNumStr);

            //Network setup
            byte[] SendingBuffer = null;
            TcpClient client = null;


            NetworkStream netstream = null;

            try
            {
               // client = new TcpClient(ctrlIpAddr, portNum);
               // netstream = client.GetStream();
                FileStream Fs = new FileStream(midiFile, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32
                (Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)));
                fileSendProgress.Maximum = NoOfPackets;

                long totalLength = Fs.Length, counter = 0;
                long CurrentPacketLength = Fs.Length;//0;
                //client.Client.SendBufferSize = BufferSize;
                
                int i = 0;
                for (i=0;i<NoOfPackets; i++)
                {
                    
                    if (totalLength > BufferSize)
                    {
                        CurrentPacketLength = BufferSize;
                        totalLength = totalLength - CurrentPacketLength;
                    }
                    else
                    {
                        CurrentPacketLength = (byte)totalLength;
                    }
                    
                    
                    byte[] mybyt = BitConverter.GetBytes(Fs.Length);
                   // byte[] header = { 0xFF, 0x00, (byte)mybyt.Length,0xFF, 0x00 };
                    List<byte> header = new List<byte>(13);
                     header.Add(0xFF);
                     header.Add(0x00);
                     header.Add((byte)mybyt.Length);
                     header.AddRange(BitConverter.GetBytes(CurrentPacketLength));
                     header.Add(0xFF);
                     header.Add(0x00);
                    //netstream.Write(header.ToArray(), 0, (int)header.Count());

                    client = new TcpClient(ctrlIpAddr, portNum);
                    client.Client.SendBufferSize = header.Count;                   
                    client.Client.Send(header.ToArray(), header.Count, SocketFlags.None);
                    byte[] recv = new byte[4] { 0, 0, 0, 0 };
                    client.Client.Receive(recv, 0, recv.Length, SocketFlags.None);
                    if (BitConverter.ToInt32(recv,0) == 0xFFFFFF)
                    {
                        fileSendStatus.Text = "An error Occured";
                        return;
                    }
                    client.Client.Close();

                    SendingBuffer = new byte[CurrentPacketLength ];
                    client = new TcpClient(ctrlIpAddr, portNum);
                    client.Client.SendBufferSize = SendingBuffer.Length;
                    Fs.Read(SendingBuffer, 0, (int)CurrentPacketLength);
                    client.Client.Send(SendingBuffer, SendingBuffer.Length, SocketFlags.None);
                    recv = new byte[4] { 0,0,0,0};
                    client.Client.Receive(recv,0, recv.Length, SocketFlags.None);


                    client.Client.Close();
                    //client.Client.
                    //    netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                    if (fileSendProgress.Value >= fileSendProgress.Maximum)
                        fileSendProgress.Value = fileSendProgress.Minimum;
                    fileSendProgress.PerformStep();
                }

                fileSendStatus.Text = "Sent file to microcontroller successfully";
                Fs.Close();
            }

            catch (Exception ex)
            {
                fileSendStatus.Text = "File send error: " + ex.ToString();
            }

            finally
            {
                if (netstream != null)
                {
                    netstream.Close();
                }
                if (client != null)
                {
                    client.Client.Close();
                }
               
            }

            //1. Call microcontroller program
            //2. Send midi file using the filename selected to the microcontroller
            //3. Play the song on the LED strip using microcontroller program and have player buttons for user to control their song with
        }

        //BrowseButtonClick
        //Summary: MIDI Creation browse button. User can select a wav file they want to convert to midi
        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();            fdlg.Title = "Select WAV file";
            fdlg.InitialDirectory = @"C:\";
            fdlg.Filter = "WAV Files|*.wav";
            fdlg.RestoreDirectory = true;

            if (fdlg.ShowDialog()  == DialogResult.OK)
            {
                wavFile = fdlg.FileName;
                selectedFileText.Text = wavFile;
            }

        }


       


        //BrowseSaveClick
        //Summary: Settings menu browse button. User can select the location where their midi files should be saved
        private void BrowseSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdlg = new FolderBrowserDialog();
            DialogResult result = fbdlg.ShowDialog();
            Configuration config =
            ConfigurationManager.OpenExeConfiguration
            (ConfigurationUserLevel.None);

        
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdlg.SelectedPath))
            {
                defaultSaveString = fbdlg.SelectedPath;
                defaultSave.Text = defaultSaveString;
                config.AppSettings.Settings.Remove("SaveLoc");
                config.AppSettings.Settings.Add("SaveLoc", defaultSaveString);
                config.Save(ConfigurationSaveMode.Modified);
            }

        }

        //BrowseSongsClick
        //Summary: Keyboard browse button. User can select the midi file they want to play on the piano
        private void browseSongs_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog(); fdlg.Title = "Select MIDI file";
            fdlg.InitialDirectory = @"D:\";
            //fdlg.Filter = "Text Files|*.txt|MiDI|*.midi";
            fdlg.RestoreDirectory = true;

            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                midiFile = fdlg.FileName;
                selectedSong.Text = midiFile;
            }
        }

        //Icon made by Those Icons from www.flaticon.com"
        //Send a packet to the microcontroller to begin playing the song on the microcontroller
        private void play_Click(object sender, EventArgs e)
        {
            string portNumStr = ConfigurationManager.AppSettings["Port"];
            int portNum = Int32.Parse(portNumStr);
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, portNum);

                Socket socket = new Socket(ipAddr.AddressFamily,
                  SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    socket.Connect(localEndPoint);
                    byte[] message = Encoding.ASCII.GetBytes("PLAY<EOF>");
                    int byteSent = socket.Send(message);

                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Socket error:" + ex.ToString());
                }


            }

            catch(Exception ex)
            {
                MessageBox.Show("Socket error:" + ex.ToString());
            }
        }
    }
}
