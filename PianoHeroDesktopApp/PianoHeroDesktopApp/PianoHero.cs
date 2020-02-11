using System;
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


        public PianoHero()
        {
            InitializeComponent();
            int defaultVolume = Convert.ToInt32(defaultVolumeStr);
            int defaultPlaySpeed = Convert.ToInt32(defaultPlaySpeedStr);

            defaultSave.Text = defaultSaveString;
       
        }


        //ConvertButton_Click()
        //Summary: This method calls the cloud conversion service to upload the wav file and download the converted midi file
        //Params: sender, e
        //Returns: none
        private void convertButton_Click(object sender, EventArgs e)
        {
            //1. Retreive filename of wav file to upload

            string shortnedFileName = Path.GetFileName(wavFile);

            string uriString = @"http://mockwav2midi.herokuapp.com/wav2midi/";
            WebClient cloudService = new WebClient();

            //2. Upload the wav file to the service
            convertButton.Enabled = false;
            byte[] response = cloudService.UploadFile(uriString, wavFile);

            //3. Download the converted file
            //4. Save that file to the default wav location
            File.WriteAllBytes(defaultSaveString + shortnedFileName + ".midi", response);


            convertButton.Enabled = true;

            respMessage.Text = "Your converted file is successfully saved at " + defaultSaveString + shortnedFileName + ".midi";
           
        }

        //PlayButton_Click()
        //Summary: This method calls the cloud conversion service to upload the wav file and download the converted midi file
        //Params: sender, e
        //Returns: none
        private void playButton_Click(object sender, EventArgs e)
        {
            //1. Call microcontroller program
            //2. Send midi file using the filename selected to the microcontroller
            //3. Play the song on the LED strip using microcontroller program and have player buttons for user to control their song with
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select WAV file";
            fdlg.InitialDirectory = @"C:\";
            fdlg.Filter = "WAV Files|*.wav";
            fdlg.RestoreDirectory = true;

            if (fdlg.ShowDialog()  == DialogResult.OK)
            {
                wavFile = fdlg.FileName;
                selectedFileText.Text = wavFile;
            }

        }

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
    }
}
