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
        string ctrlIpAddr = "192.168.137.131";//"192.168.0.100";//"127.0.0.1";//
        private const int BufferSize = 54;
        string state = "Stopped";
        const int WavFileSizeLimit = 50000;

        System.Windows.Forms.Timer animationTimer = new System.Windows.Forms.Timer
        {
            Interval = 10
        };

        void timer_Tick(object sender, EventArgs e)
        {

            int fadingSpeed = 0;
            currentSong.ForeColor = Color.FromArgb(currentSong.ForeColor.R - fadingSpeed, currentSong.ForeColor.G - fadingSpeed, currentSong.ForeColor.B - fadingSpeed);
            nowPlaying.ForeColor = Color.FromArgb(nowPlaying.ForeColor.R - fadingSpeed, nowPlaying.ForeColor.G - fadingSpeed, nowPlaying.ForeColor.B - fadingSpeed);


            if (currentSong.ForeColor.R < 5)
            {
                animationTimer.Stop();
            }

        }


        public PianoHero()
        {
       
       
            InitializeComponent();
           
            animationTimer.Tick += new EventHandler(timer_Tick);

            currentSong.ForeColor = Color.FromArgb(255, 255, 255);
            nowPlaying.ForeColor = Color.FromArgb(255, 255, 255);
          
            int defaultVolume = Convert.ToInt32(defaultVolumeStr);
            int defaultPlaySpeed = Convert.ToInt32(defaultPlaySpeedStr);

            defaultSave.Text = defaultSaveString;

            defaultSpeed.Value = defaultPlaySpeed;
            defaultVol.Value = defaultVolume;

          
            

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

            if(wavFile == "")
            {
                MessageBox.Show("No wav file selected, please select one");
                return;
            }

            string shortnedFileName = Path.GetFileName(wavFile);
            FileInfo fi = new FileInfo(wavFile);
            if (fi.Length == 0)
            {
                MessageBox.Show("WAV File is empty, cannot convert");
                return;
            }
            long fileSizeMB = (fi.Length / 1024);
            if(fileSizeMB > WavFileSizeLimit)
            {
                MessageBox.Show("WAV File is too large to convert, sorry");
                return;
            }

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

        /// <summary>
        /// SendHeader
        /// </summary>
        /// <param name="client"></param>
        /// <param name="portNum"></param>
        /// <param name="bodyLen"></param>
        /// <returns></returns>
        private int SendHeader(TcpClient client, int portNum, long bodyLen)
        {
            byte[] mybyt = BitConverter.GetBytes(bodyLen);
            
            List<byte> header = new List<byte>(13);
            header.Add(0xFF);
            header.Add(0x00);
            header.Add((byte)mybyt.Length);
            header.AddRange(BitConverter.GetBytes(bodyLen));
            header.Add(0xFF);
            header.Add(0x00);            

            client = new TcpClient(ctrlIpAddr, portNum);
            client.Client.SendBufferSize = header.Count;
            client.Client.Send(header.ToArray(), header.Count, SocketFlags.None);

            byte[] recv = new byte[4] { 0, 0, 0, 0 };
            client.Client.ReceiveTimeout = 300;
            client.Client.Receive(recv, 0, recv.Length, SocketFlags.None);
            UInt32 o = BitConverter.ToUInt32(recv, 0);
            if (recv[0] == 0xFF && recv[1] == 0xFF && recv[2] == 0xFF && recv[3] == 0xFF)
            {
                fileSendStatus.Text = "An error Occured";
                return 0;
            }
            client.Client.Close();

            return 1;
        }

        //PlayButton_Click()
        //Summary: This method sends a midi file to the microcontroller 
        //Params: sender, e
        //Returns: none
        private void loadButton_Click(object sender, EventArgs e)
        {

            if(midiFile == "")
            {
                MessageBox.Show("No midi file selected, please select one");
                return;
            }

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


                if (SendHeader(client, portNum, CurrentPacketLength) == 0)
                {
                    // microcontroller reported an error
                    return;
                }

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

                   if( SendHeader(client, portNum, CurrentPacketLength) == 0)
                    {
                        // microcontroller reported an error
                        return;
                    }

                   //**Previously used code**

              
                   // byte[] mybyt = BitConverter.GetBytes(Fs.Length);
                   //// byte[] header = { 0xFF, 0x00, (byte)mybyt.Length,0xFF, 0x00 };
                   // List<byte> header = new List<byte>(13);
                   //  header.Add(0xFF);
                   //  header.Add(0x00);
                   //  header.Add((byte)mybyt.Length);
                   //  header.AddRange(BitConverter.GetBytes(CurrentPacketLength));
                   //  header.Add(0xFF);
                   //  header.Add(0x00);
                   // //netstream.Write(header.ToArray(), 0, (int)header.Count());

                   // client = new TcpClient(ctrlIpAddr, portNum);
                   // client.Client.SendBufferSize = header.Count;                   
                   // client.Client.Send(header.ToArray(), header.Count, SocketFlags.None);
                    //byte[] recv = new byte[4] { 0, 0, 0, 0 };
                    //client.Client.Receive(recv, 0, recv.Length, SocketFlags.None);
                    //if (BitConverter.ToInt32(recv,0) == 0xFFFFFF)
                    //{
                    //    fileSendStatus.Text = "An error Occured";
                    //    return;
                    //}
                    //client.Client.Close();

                    SendingBuffer = new byte[CurrentPacketLength ];
                    client = new TcpClient(ctrlIpAddr, portNum);
                    client.Client.SendBufferSize = SendingBuffer.Length;
                    Fs.Read(SendingBuffer, 0, (int)CurrentPacketLength);
                    client.Client.Send(SendingBuffer, SendingBuffer.Length, SocketFlags.None);
                    byte[] recv = new byte[4] { 0,0,0,0};
                    client.Client.ReceiveTimeout = 150;
                    client.Client.Receive(recv,0, recv.Length, SocketFlags.None);
                    client.Client.Close();

                    //client.Client.
                    //    netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                   
                    fileSendProgress.PerformStep();
                }

                fileSendProgress.Value = 100;
                fileSendProgress.Text = "Sent file successfully";
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
                ConfigurationManager.RefreshSection("appSettings");
            }

        }

        //BrowseSongsClick
        //Summary: Keyboard browse button. User can select the midi file they want to play on the piano
        private void browseSongs_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog(); fdlg.Title = "Select MIDI file";
            fdlg.InitialDirectory = @"D:\";
            fdlg.Filter = "MIDI Files|*.midi";
            fdlg.RestoreDirectory = true;

            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                midiFile = fdlg.FileName;
                string shortFile = Path.GetFileName(midiFile);
                selectedSong.Text = midiFile;
                currentSong.Text = shortFile;
            }
        }

        //Icon made by https://www.flaticon.com/authors/those-icons"
        //Indicates that a song is now being played
        private void play_Click(object sender, EventArgs e)
        {
            if(midiFile == "")
            {
                MessageBox.Show("Please select a midi file before playing");
                return;
            }
      
            animationTimer.Start();

            state = "Playing";

            FileInfo fileInfo = new FileInfo(midiFile);

            songProgress.Maximum = Convert.ToInt32(fileInfo.Length);
            songProgress.Minimum = 1;
         
            
            songProgress.Show();

            //Start feedback application
            using (System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
            {
                pProcess.StartInfo.FileName = @"..\..\..\..\Usb2Serial\x64\x64\Cserial.exe"; //path to feedback application exe
                pProcess.StartInfo.Arguments = "4 8"; //argument option 4, comport 8
                pProcess.StartInfo.UseShellExecute = false;
                //pProcess.StartInfo.RedirectStandardOutput = true;
                //pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                try
                {
                    pProcess.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not start Cserial.exe. "+ ex.Message);                    
                }
                
               
            }

            

        }

        
        //PlayKey_KeyPress
        //Summary: Listen for a key press and assign it to the default play button
        //Params: key press event args
        //Returns: none
        private void playKey_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            playKey.Text = e.KeyChar.ToString();

            switch(e.KeyChar)
            {
                case (char)32:
                    playKey.Text = "SPACE";
                    break;


                case (char)37:
                    playKey.Text = "Left Arrow Key";
                    break;

            }

            Configuration config =
           ConfigurationManager.OpenExeConfiguration
           (ConfigurationUserLevel.None);

            config.AppSettings.Settings.Remove("PlayPauseButton");
            config.AppSettings.Settings.Add("PlayPauseButton", e.KeyChar.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            string keyTest = ConfigurationManager.AppSettings["PlayPauseButton"];
           


        }

        //SlowKey_KeyPress
        //Summary: Listen for a key press and assign it to the default slower playing speed button
        //Params: key press event args
        //Returns: none
        private void slowKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            slowKey.Text = e.KeyChar.ToString();

            if (e.KeyChar == 32)
            {
                slowKey.Text = "SPACE";
            }

            Configuration config =
           ConfigurationManager.OpenExeConfiguration
           (ConfigurationUserLevel.None);

            config.AppSettings.Settings.Remove("Slower");
            config.AppSettings.Settings.Add("Slower", e.KeyChar.ToString());

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }

        //FastKey_KeyPress
        //Summary: Listen for a key press and assign it to the default faster playing speed button
        //Params: key press event args
        //Returns: none
        private void fastKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            fastKey.Text = e.KeyChar.ToString();

            if (e.KeyChar == 32)
            {
                fastKey.Text = "SPACE";
            }

            Configuration config =
           ConfigurationManager.OpenExeConfiguration
           (ConfigurationUserLevel.None);

            config.AppSettings.Settings.Remove("Faster");
            config.AppSettings.Settings.Add("Faster", e.KeyChar.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }

        //PlayKey_KeyDown
        //Summary: Handle arrow key presses for assigning to play/pause key
        //Params: key down event args
        //Returns: none
        private void playKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                playKey.Text = "Up Arrow key";
            }

            if (e.KeyCode == Keys.Down)
            {
                playKey.Text = "Down Arrow key";
            }

            if (e.KeyCode == Keys.Left)
            {
                playKey.Text = "Left Arrow key";
            }

            if (e.KeyCode == Keys.Right)
            {
                playKey.Text = "Right Arrow key";
            }
        }

        //SlowKey_KeyDown
        //Summary: Handle arrow key presses for assigning to slower key
        //Params: key down event args
        //Returns: none
        private void slowKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                slowKey.Text = "Up Arrow key";
            }

            if (e.KeyCode == Keys.Down)
            {
                slowKey.Text = "Down Arrow key";
            }

            if (e.KeyCode == Keys.Left)
            {
                slowKey.Text = "Left Arrow key";
            }

            if (e.KeyCode == Keys.Right)
            {
                slowKey.Text = "Right Arrow key";
            }
        }

        //FastKey_KeyDown
        //Summary: Handle arrow key presses for assigning to faster key
        //Params: key down event args
        //Returns: none
        private void fastKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                fastKey.Text = "Up Arrow key";
            }

            if (e.KeyCode == Keys.Down)
            {
                fastKey.Text = "Down Arrow key";
            }

            if (e.KeyCode == Keys.Left)
            {
                fastKey.Text = "Left Arrow key";
            }

            if (e.KeyCode == Keys.Right)
            {
                fastKey.Text = "Right Arrow key";
            }
        }


        //DefaultSpeed_ValueChanged
        //Summary: Modify the default speed in config based on scrollbar value
        //Params: scrollbar event args
        //Returns: none
        private void defaultSpeed_ValueChanged(object sender, EventArgs e)
        {
            Configuration config =
          ConfigurationManager.OpenExeConfiguration
          (ConfigurationUserLevel.None);

            config.AppSettings.Settings.Remove("Speed");
            config.AppSettings.Settings.Add("Speed", defaultSpeed.Value.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            string speedTest = ConfigurationManager.AppSettings["Speed"];
            speedTxt.Text = speedTest;
        }

        //DefaultVol_ValueChanged
        //Summary: Modify the default volume in config based on scrollbar value
        //Params: scrollbar event args
        //Returns: none
        private void defaultVol_ValueChanged(object sender, EventArgs e)
        {
            Configuration config =
          ConfigurationManager.OpenExeConfiguration
          (ConfigurationUserLevel.None);

            config.AppSettings.Settings.Remove("Volume");
            config.AppSettings.Settings.Add("Volume", defaultVol.Value.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            string volTest = ConfigurationManager.AppSettings["Volume"];
            volTxt.Text = volTest;
        }

       

        public void SendToController(string text)
        {
            //Network setup
            string portNumStr = ConfigurationManager.AppSettings["Port"];
            int portNum = Int32.Parse(portNumStr);
            byte[] SendingBuffer = null;
            TcpClient client = null;


            NetworkStream netstream = null;

            try
            {
                if (SendHeader(client, portNum, 32) == 0)
                {
                    // microcontroller reported an error
                    return;
                }

                SendingBuffer = new byte[32];
                client = new TcpClient(ctrlIpAddr, portNum);
                client.Client.SendBufferSize = SendingBuffer.Length;
                SendingBuffer = Encoding.ASCII.GetBytes(text);
                client.Client.Send(SendingBuffer, SendingBuffer.Length, SocketFlags.None);
                byte[] recv = new byte[4] { 0, 0, 0, 0 };
                client.Client.ReceiveTimeout = 150;
                client.Client.Receive(recv, 0, recv.Length, SocketFlags.None);
                client.Client.Close();
            }

            catch (Exception ex)
            {
                fileSendStatus.Text = "Play error: " + ex.ToString();
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

        }

        private void PianoHero_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pauseplay = ConfigurationManager.AppSettings["PlayPauseButton"];
            int pausePlayChar = Convert.ToInt32(pauseplay);

            if (state == "Playing")
            {
                              if(pausePlayChar == e.KeyChar)
                {
                    SendToController("PAUSE");

                }
            }

            if (state == "Pause")
            {
               

                if (pausePlayChar == e.KeyChar)
                {
                    SendToController("PLAY");

                }
            }
        }

        private void songProgress_Click(object sender, EventArgs e)
        {

        }
    }






}
