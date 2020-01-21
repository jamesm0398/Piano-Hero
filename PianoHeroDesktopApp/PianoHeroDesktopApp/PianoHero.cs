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
            //2. Upload the wav file to the service
            //3. Download the converted file
            //4. Save that file to the default wav location
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
    }
}
