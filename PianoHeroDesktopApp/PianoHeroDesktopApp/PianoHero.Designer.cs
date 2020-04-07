namespace PianoHeroDesktopApp
{
    partial class PianoHero
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PianoHero));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.KeyboardTab = new MetroFramework.Controls.MetroTabPage();
            this.currentSong = new MetroFramework.Controls.MetroLabel();
            this.nowPlaying = new MetroFramework.Controls.MetroLabel();
            this.songProgress = new MetroFramework.Controls.MetroProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.fileSendStatus = new MetroFramework.Controls.MetroLabel();
            this.fileSendProgress = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.selectedSong = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.browseSongs = new MetroFramework.Controls.MetroButton();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.loadButton = new MetroFramework.Controls.MetroButton();
            this.midiCreationTab = new MetroFramework.Controls.MetroTabPage();
            this.respMessage = new MetroFramework.Controls.MetroLabel();
            this.selectedFileText = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.selectedFile = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.browseButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.convertButton = new MetroFramework.Controls.MetroButton();
            this.SettingsTab = new MetroFramework.Controls.MetroTabPage();
            this.volTxt = new MetroFramework.Controls.MetroLabel();
            this.speedTxt = new MetroFramework.Controls.MetroLabel();
            this.BrowseSave = new MetroFramework.Controls.MetroButton();
            this.fastKey = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.slowKey = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.playKey = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.defaultSave = new MetroFramework.Controls.MetroTextBox();
            this.defaultSpeed = new MetroFramework.Controls.MetroTrackBar();
            this.defaultVol = new MetroFramework.Controls.MetroTrackBar();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.About = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel26 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel25 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel24 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel23 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel21 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.metroTabControl1.SuspendLayout();
            this.KeyboardTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.midiCreationTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.About.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.KeyboardTab);
            this.metroTabControl1.Controls.Add(this.midiCreationTab);
            this.metroTabControl1.Controls.Add(this.SettingsTab);
            this.metroTabControl1.Controls.Add(this.About);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.ItemSize = new System.Drawing.Size(168, 34);
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(5);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(767, 373);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // KeyboardTab
            // 
            this.KeyboardTab.Controls.Add(this.currentSong);
            this.KeyboardTab.Controls.Add(this.nowPlaying);
            this.KeyboardTab.Controls.Add(this.songProgress);
            this.KeyboardTab.Controls.Add(this.pictureBox1);
            this.KeyboardTab.Controls.Add(this.metroLabel15);
            this.KeyboardTab.Controls.Add(this.fileSendStatus);
            this.KeyboardTab.Controls.Add(this.fileSendProgress);
            this.KeyboardTab.Controls.Add(this.metroLabel14);
            this.KeyboardTab.Controls.Add(this.selectedSong);
            this.KeyboardTab.Controls.Add(this.metroLabel13);
            this.KeyboardTab.Controls.Add(this.browseSongs);
            this.KeyboardTab.Controls.Add(this.metroLabel12);
            this.KeyboardTab.Controls.Add(this.loadButton);
            this.KeyboardTab.HorizontalScrollbarBarColor = true;
            this.KeyboardTab.HorizontalScrollbarHighlightOnWheel = false;
            this.KeyboardTab.HorizontalScrollbarSize = 20;
            this.KeyboardTab.Location = new System.Drawing.Point(4, 38);
            this.KeyboardTab.Name = "KeyboardTab";
            this.KeyboardTab.Padding = new System.Windows.Forms.Padding(200);
            this.KeyboardTab.Size = new System.Drawing.Size(759, 331);
            this.KeyboardTab.Style = MetroFramework.MetroColorStyle.Black;
            this.KeyboardTab.TabIndex = 0;
            this.KeyboardTab.Text = "Keyboard";
            this.KeyboardTab.VerticalScrollbarBarColor = true;
            this.KeyboardTab.VerticalScrollbarHighlightOnWheel = false;
            this.KeyboardTab.VerticalScrollbarSize = 10;
            // 
            // currentSong
            // 
            this.currentSong.AutoSize = true;
            this.currentSong.BackColor = System.Drawing.Color.Transparent;
            this.currentSong.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.currentSong.ForeColor = System.Drawing.Color.White;
            this.currentSong.Location = new System.Drawing.Point(323, 273);
            this.currentSong.Name = "currentSong";
            this.currentSong.Size = new System.Drawing.Size(0, 0);
            this.currentSong.TabIndex = 25;
            this.currentSong.UseCustomBackColor = true;
            this.currentSong.UseCustomForeColor = true;
            // 
            // nowPlaying
            // 
            this.nowPlaying.AutoSize = true;
            this.nowPlaying.BackColor = System.Drawing.Color.Transparent;
            this.nowPlaying.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.nowPlaying.ForeColor = System.Drawing.Color.White;
            this.nowPlaying.Location = new System.Drawing.Point(201, 273);
            this.nowPlaying.Name = "nowPlaying";
            this.nowPlaying.Size = new System.Drawing.Size(116, 25);
            this.nowPlaying.TabIndex = 24;
            this.nowPlaying.Text = "Now Playing: ";
            this.nowPlaying.UseCustomBackColor = true;
            this.nowPlaying.UseCustomForeColor = true;
            // 
            // songProgress
            // 
            this.songProgress.Location = new System.Drawing.Point(201, 317);
            this.songProgress.Name = "songProgress";
            this.songProgress.Size = new System.Drawing.Size(304, 11);
            this.songProgress.Style = MetroFramework.MetroColorStyle.Magenta;
            this.songProgress.TabIndex = 23;
            this.songProgress.Visible = false;
            this.songProgress.Click += new System.EventHandler(this.songProgress_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(398, 157);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 65);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.play_Click);
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(398, 130);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(169, 38);
            this.metroLabel15.TabIndex = 19;
            this.metroLabel15.Text = "4. Play song/Start feedback\r\n";
            // 
            // fileSendStatus
            // 
            this.fileSendStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fileSendStatus.AutoSize = true;
            this.fileSendStatus.Location = new System.Drawing.Point(230, 222);
            this.fileSendStatus.Name = "fileSendStatus";
            this.fileSendStatus.Size = new System.Drawing.Size(0, 0);
            this.fileSendStatus.TabIndex = 17;
            this.fileSendStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // fileSendProgress
            // 
            this.fileSendProgress.Location = new System.Drawing.Point(76, 222);
            this.fileSendProgress.Name = "fileSendProgress";
            this.fileSendProgress.Size = new System.Drawing.Size(230, 23);
            this.fileSendProgress.TabIndex = 16;
            this.fileSendProgress.Tag = "";
            this.fileSendProgress.Visible = false;
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(129, 130);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(84, 19);
            this.metroLabel14.TabIndex = 15;
            this.metroLabel14.Text = "3. Load song";
            // 
            // selectedSong
            // 
            // 
            // 
            // 
            this.selectedSong.CustomButton.Image = null;
            this.selectedSong.CustomButton.Location = new System.Drawing.Point(236, 1);
            this.selectedSong.CustomButton.Name = "";
            this.selectedSong.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.selectedSong.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.selectedSong.CustomButton.TabIndex = 1;
            this.selectedSong.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.selectedSong.CustomButton.UseSelectable = true;
            this.selectedSong.CustomButton.Visible = false;
            this.selectedSong.Lines = new string[0];
            this.selectedSong.Location = new System.Drawing.Point(398, 66);
            this.selectedSong.MaxLength = 32767;
            this.selectedSong.Name = "selectedSong";
            this.selectedSong.PasswordChar = '\0';
            this.selectedSong.ReadOnly = true;
            this.selectedSong.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.selectedSong.SelectedText = "";
            this.selectedSong.SelectionLength = 0;
            this.selectedSong.SelectionStart = 0;
            this.selectedSong.ShortcutsEnabled = true;
            this.selectedSong.Size = new System.Drawing.Size(258, 23);
            this.selectedSong.TabIndex = 14;
            this.selectedSong.UseSelectable = true;
            this.selectedSong.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.selectedSong.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(398, 30);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(107, 19);
            this.metroLabel13.TabIndex = 13;
            this.metroLabel13.Text = "2. Selected song:";
            // 
            // browseSongs
            // 
            this.browseSongs.Location = new System.Drawing.Point(129, 76);
            this.browseSongs.Name = "browseSongs";
            this.browseSongs.Size = new System.Drawing.Size(75, 23);
            this.browseSongs.TabIndex = 12;
            this.browseSongs.Text = "Browse";
            this.browseSongs.UseSelectable = true;
            this.browseSongs.Click += new System.EventHandler(this.browseSongs_Click);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(129, 30);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(87, 19);
            this.metroLabel12.TabIndex = 11;
            this.metroLabel12.Text = "1. Select song";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(129, 157);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(107, 43);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load Song";
            this.loadButton.UseSelectable = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // midiCreationTab
            // 
            this.midiCreationTab.Controls.Add(this.respMessage);
            this.midiCreationTab.Controls.Add(this.selectedFileText);
            this.midiCreationTab.Controls.Add(this.metroLabel10);
            this.midiCreationTab.Controls.Add(this.selectedFile);
            this.midiCreationTab.Controls.Add(this.metroLabel9);
            this.midiCreationTab.Controls.Add(this.browseButton);
            this.midiCreationTab.Controls.Add(this.metroLabel8);
            this.midiCreationTab.Controls.Add(this.convertButton);
            this.midiCreationTab.HorizontalScrollbarBarColor = true;
            this.midiCreationTab.HorizontalScrollbarHighlightOnWheel = false;
            this.midiCreationTab.HorizontalScrollbarSize = 10;
            this.midiCreationTab.Location = new System.Drawing.Point(4, 38);
            this.midiCreationTab.Name = "midiCreationTab";
            this.midiCreationTab.Size = new System.Drawing.Size(759, 331);
            this.midiCreationTab.TabIndex = 1;
            this.midiCreationTab.Text = "MIDI Creation";
            this.midiCreationTab.VerticalScrollbarBarColor = true;
            this.midiCreationTab.VerticalScrollbarHighlightOnWheel = false;
            this.midiCreationTab.VerticalScrollbarSize = 10;
            // 
            // respMessage
            // 
            this.respMessage.AutoSize = true;
            this.respMessage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.respMessage.ForeColor = System.Drawing.Color.Green;
            this.respMessage.Location = new System.Drawing.Point(42, 303);
            this.respMessage.Name = "respMessage";
            this.respMessage.Size = new System.Drawing.Size(0, 0);
            this.respMessage.TabIndex = 14;
            this.respMessage.UseCustomForeColor = true;
            // 
            // selectedFileText
            // 
            // 
            // 
            // 
            this.selectedFileText.CustomButton.Image = null;
            this.selectedFileText.CustomButton.Location = new System.Drawing.Point(442, 1);
            this.selectedFileText.CustomButton.Name = "";
            this.selectedFileText.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.selectedFileText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.selectedFileText.CustomButton.TabIndex = 1;
            this.selectedFileText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.selectedFileText.CustomButton.UseSelectable = true;
            this.selectedFileText.CustomButton.Visible = false;
            this.selectedFileText.Lines = new string[0];
            this.selectedFileText.Location = new System.Drawing.Point(42, 149);
            this.selectedFileText.MaxLength = 32767;
            this.selectedFileText.Name = "selectedFileText";
            this.selectedFileText.PasswordChar = '\0';
            this.selectedFileText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.selectedFileText.SelectedText = "";
            this.selectedFileText.SelectionLength = 0;
            this.selectedFileText.SelectionStart = 0;
            this.selectedFileText.ShortcutsEnabled = true;
            this.selectedFileText.Size = new System.Drawing.Size(464, 23);
            this.selectedFileText.TabIndex = 13;
            this.selectedFileText.UseSelectable = true;
            this.selectedFileText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.selectedFileText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(42, 201);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(19, 19);
            this.metroLabel10.TabIndex = 12;
            this.metroLabel10.Text = "3.";
            // 
            // selectedFile
            // 
            this.selectedFile.AutoSize = true;
            this.selectedFile.Location = new System.Drawing.Point(42, 149);
            this.selectedFile.Name = "selectedFile";
            this.selectedFile.Size = new System.Drawing.Size(0, 0);
            this.selectedFile.TabIndex = 11;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(42, 110);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(125, 19);
            this.metroLabel9.TabIndex = 10;
            this.metroLabel9.Text = "2. Your selected file:";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(42, 70);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 9;
            this.browseButton.Text = "Browse";
            this.browseButton.UseSelectable = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(42, 34);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(108, 19);
            this.metroLabel8.TabIndex = 8;
            this.metroLabel8.Text = "1. Select WAV file";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(42, 226);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(108, 61);
            this.convertButton.TabIndex = 7;
            this.convertButton.Text = "Convert to MIDI";
            this.convertButton.UseSelectable = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.volTxt);
            this.SettingsTab.Controls.Add(this.speedTxt);
            this.SettingsTab.Controls.Add(this.BrowseSave);
            this.SettingsTab.Controls.Add(this.fastKey);
            this.SettingsTab.Controls.Add(this.metroLabel7);
            this.SettingsTab.Controls.Add(this.slowKey);
            this.SettingsTab.Controls.Add(this.metroLabel6);
            this.SettingsTab.Controls.Add(this.playKey);
            this.SettingsTab.Controls.Add(this.metroLabel5);
            this.SettingsTab.Controls.Add(this.metroLabel4);
            this.SettingsTab.Controls.Add(this.defaultSave);
            this.SettingsTab.Controls.Add(this.defaultSpeed);
            this.SettingsTab.Controls.Add(this.defaultVol);
            this.SettingsTab.Controls.Add(this.metroLabel3);
            this.SettingsTab.Controls.Add(this.metroLabel2);
            this.SettingsTab.Controls.Add(this.metroLabel1);
            this.SettingsTab.HorizontalScrollbarBarColor = true;
            this.SettingsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SettingsTab.HorizontalScrollbarSize = 10;
            this.SettingsTab.Location = new System.Drawing.Point(4, 38);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(759, 331);
            this.SettingsTab.TabIndex = 2;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.VerticalScrollbarBarColor = true;
            this.SettingsTab.VerticalScrollbarHighlightOnWheel = false;
            this.SettingsTab.VerticalScrollbarSize = 10;
            // 
            // volTxt
            // 
            this.volTxt.AutoSize = true;
            this.volTxt.Location = new System.Drawing.Point(465, 122);
            this.volTxt.Name = "volTxt";
            this.volTxt.Size = new System.Drawing.Size(56, 19);
            this.volTxt.TabIndex = 18;
            this.volTxt.Text = "Volume:";
            // 
            // speedTxt
            // 
            this.speedTxt.AutoSize = true;
            this.speedTxt.Location = new System.Drawing.Point(465, 75);
            this.speedTxt.Name = "speedTxt";
            this.speedTxt.Size = new System.Drawing.Size(53, 19);
            this.speedTxt.TabIndex = 17;
            this.speedTxt.Text = "Speed: ";
            // 
            // BrowseSave
            // 
            this.BrowseSave.Location = new System.Drawing.Point(435, 29);
            this.BrowseSave.Name = "BrowseSave";
            this.BrowseSave.Size = new System.Drawing.Size(75, 23);
            this.BrowseSave.TabIndex = 15;
            this.BrowseSave.Text = "Browse";
            this.BrowseSave.UseSelectable = true;
            this.BrowseSave.Click += new System.EventHandler(this.BrowseSave_Click);
            // 
            // fastKey
            // 
            // 
            // 
            // 
            this.fastKey.CustomButton.Image = null;
            this.fastKey.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.fastKey.CustomButton.Name = "";
            this.fastKey.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.fastKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.fastKey.CustomButton.TabIndex = 1;
            this.fastKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.fastKey.CustomButton.UseSelectable = true;
            this.fastKey.CustomButton.Visible = false;
            this.fastKey.Lines = new string[] {
        "Up Arrow Key"};
            this.fastKey.Location = new System.Drawing.Point(179, 302);
            this.fastKey.MaxLength = 32767;
            this.fastKey.Name = "fastKey";
            this.fastKey.PasswordChar = '\0';
            this.fastKey.ReadOnly = true;
            this.fastKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.fastKey.SelectedText = "";
            this.fastKey.SelectionLength = 0;
            this.fastKey.SelectionStart = 0;
            this.fastKey.ShortcutsEnabled = true;
            this.fastKey.Size = new System.Drawing.Size(100, 23);
            this.fastKey.TabIndex = 14;
            this.fastKey.Text = "Up Arrow Key";
            this.fastKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fastKey.UseSelectable = true;
            this.fastKey.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.fastKey.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.fastKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fastKey_KeyDown);
            this.fastKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fastKey_KeyPress);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(28, 302);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(130, 19);
            this.metroLabel7.TabIndex = 13;
            this.metroLabel7.Text = "Faster Playing Speed";
            // 
            // slowKey
            // 
            // 
            // 
            // 
            this.slowKey.CustomButton.Image = null;
            this.slowKey.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.slowKey.CustomButton.Name = "";
            this.slowKey.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.slowKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.slowKey.CustomButton.TabIndex = 1;
            this.slowKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.slowKey.CustomButton.UseSelectable = true;
            this.slowKey.CustomButton.Visible = false;
            this.slowKey.Lines = new string[] {
        "Down Arrow Key"};
            this.slowKey.Location = new System.Drawing.Point(179, 260);
            this.slowKey.MaxLength = 32767;
            this.slowKey.Name = "slowKey";
            this.slowKey.PasswordChar = '\0';
            this.slowKey.ReadOnly = true;
            this.slowKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.slowKey.SelectedText = "";
            this.slowKey.SelectionLength = 0;
            this.slowKey.SelectionStart = 0;
            this.slowKey.ShortcutsEnabled = true;
            this.slowKey.Size = new System.Drawing.Size(100, 23);
            this.slowKey.TabIndex = 12;
            this.slowKey.Text = "Down Arrow Key";
            this.slowKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slowKey.UseSelectable = true;
            this.slowKey.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.slowKey.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.slowKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.slowKey_KeyDown);
            this.slowKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.slowKey_KeyPress);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(28, 260);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(135, 19);
            this.metroLabel6.TabIndex = 11;
            this.metroLabel6.Text = "Slower Playing Speed";
            // 
            // playKey
            // 
            // 
            // 
            // 
            this.playKey.CustomButton.Image = null;
            this.playKey.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.playKey.CustomButton.Name = "";
            this.playKey.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.playKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.playKey.CustomButton.TabIndex = 1;
            this.playKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.playKey.CustomButton.UseSelectable = true;
            this.playKey.CustomButton.Visible = false;
            this.playKey.Lines = new string[] {
        "SPACE"};
            this.playKey.Location = new System.Drawing.Point(179, 222);
            this.playKey.MaxLength = 32767;
            this.playKey.Name = "playKey";
            this.playKey.PasswordChar = '\0';
            this.playKey.ReadOnly = true;
            this.playKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.playKey.SelectedText = "";
            this.playKey.SelectionLength = 0;
            this.playKey.SelectionStart = 0;
            this.playKey.ShortcutsEnabled = true;
            this.playKey.Size = new System.Drawing.Size(100, 23);
            this.playKey.TabIndex = 10;
            this.playKey.Text = "SPACE";
            this.playKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playKey.UseSelectable = true;
            this.playKey.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.playKey.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.playKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playKey_KeyDown);
            this.playKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.playKey_KeyPress);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(28, 222);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(71, 19);
            this.metroLabel5.TabIndex = 9;
            this.metroLabel5.Text = "Play/Pause";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(28, 183);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(159, 25);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Keyboard Shortcuts";
            // 
            // defaultSave
            // 
            // 
            // 
            // 
            this.defaultSave.CustomButton.Image = null;
            this.defaultSave.CustomButton.Location = new System.Drawing.Point(158, 1);
            this.defaultSave.CustomButton.Name = "";
            this.defaultSave.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.defaultSave.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.defaultSave.CustomButton.TabIndex = 1;
            this.defaultSave.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.defaultSave.CustomButton.UseSelectable = true;
            this.defaultSave.CustomButton.Visible = false;
            this.defaultSave.Lines = new string[0];
            this.defaultSave.Location = new System.Drawing.Point(223, 29);
            this.defaultSave.MaxLength = 32767;
            this.defaultSave.Name = "defaultSave";
            this.defaultSave.PasswordChar = '\0';
            this.defaultSave.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.defaultSave.SelectedText = "";
            this.defaultSave.SelectionLength = 0;
            this.defaultSave.SelectionStart = 0;
            this.defaultSave.ShortcutsEnabled = true;
            this.defaultSave.Size = new System.Drawing.Size(180, 23);
            this.defaultSave.TabIndex = 7;
            this.defaultSave.UseSelectable = true;
            this.defaultSave.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.defaultSave.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // defaultSpeed
            // 
            this.defaultSpeed.BackColor = System.Drawing.Color.Transparent;
            this.defaultSpeed.Location = new System.Drawing.Point(223, 72);
            this.defaultSpeed.Name = "defaultSpeed";
            this.defaultSpeed.Size = new System.Drawing.Size(153, 23);
            this.defaultSpeed.TabIndex = 6;
            this.defaultSpeed.Text = "metroTrackBar1";
            this.defaultSpeed.ValueChanged += new System.EventHandler(this.defaultSpeed_ValueChanged);
            // 
            // defaultVol
            // 
            this.defaultVol.BackColor = System.Drawing.Color.Transparent;
            this.defaultVol.Location = new System.Drawing.Point(223, 119);
            this.defaultVol.Name = "defaultVol";
            this.defaultVol.Size = new System.Drawing.Size(153, 23);
            this.defaultVol.TabIndex = 5;
            this.defaultVol.Text = "metroTrackBar1";
            this.defaultVol.ValueChanged += new System.EventHandler(this.defaultVol_ValueChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(28, 123);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(100, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Default volume:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(28, 76);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(92, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Default speed:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(28, 29);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(163, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Default MIDI save location:";
            // 
            // About
            // 
            this.About.Controls.Add(this.metroLabel26);
            this.About.Controls.Add(this.metroLabel25);
            this.About.Controls.Add(this.metroLabel24);
            this.About.Controls.Add(this.metroLabel23);
            this.About.Controls.Add(this.metroLabel22);
            this.About.Controls.Add(this.metroLabel21);
            this.About.Controls.Add(this.metroLabel20);
            this.About.Controls.Add(this.metroLabel19);
            this.About.Controls.Add(this.metroLabel18);
            this.About.Controls.Add(this.metroLabel17);
            this.About.Controls.Add(this.metroTile1);
            this.About.Controls.Add(this.metroLabel16);
            this.About.HorizontalScrollbarBarColor = true;
            this.About.HorizontalScrollbarHighlightOnWheel = false;
            this.About.HorizontalScrollbarSize = 10;
            this.About.Location = new System.Drawing.Point(4, 38);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(759, 331);
            this.About.TabIndex = 3;
            this.About.Text = "About";
            this.About.VerticalScrollbarBarColor = true;
            this.About.VerticalScrollbarHighlightOnWheel = false;
            this.About.VerticalScrollbarSize = 10;
            // 
            // metroLabel26
            // 
            this.metroLabel26.AutoSize = true;
            this.metroLabel26.Location = new System.Drawing.Point(185, 211);
            this.metroLabel26.Name = "metroLabel26";
            this.metroLabel26.Size = new System.Drawing.Size(181, 19);
            this.metroLabel26.TabIndex = 13;
            this.metroLabel26.Text = "Created using LogoMakr.com";
            // 
            // metroLabel25
            // 
            this.metroLabel25.AutoSize = true;
            this.metroLabel25.BackColor = System.Drawing.Color.Magenta;
            this.metroLabel25.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel25.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel25.ForeColor = System.Drawing.Color.Magenta;
            this.metroLabel25.Location = new System.Drawing.Point(151, 211);
            this.metroLabel25.Name = "metroLabel25";
            this.metroLabel25.Size = new System.Drawing.Size(19, 25);
            this.metroLabel25.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroLabel25.TabIndex = 12;
            this.metroLabel25.Text = "-";
            // 
            // metroLabel24
            // 
            this.metroLabel24.AutoSize = true;
            this.metroLabel24.Location = new System.Drawing.Point(4, 211);
            this.metroLabel24.Name = "metroLabel24";
            this.metroLabel24.Size = new System.Drawing.Size(39, 19);
            this.metroLabel24.TabIndex = 11;
            this.metroLabel24.Text = "Logo";
            // 
            // metroLabel23
            // 
            this.metroLabel23.AutoSize = true;
            this.metroLabel23.Location = new System.Drawing.Point(185, 172);
            this.metroLabel23.Name = "metroLabel23";
            this.metroLabel23.Size = new System.Drawing.Size(57, 19);
            this.metroLabel23.TabIndex = 10;
            this.metroLabel23.Text = "Justin To";
            // 
            // metroLabel22
            // 
            this.metroLabel22.AutoSize = true;
            this.metroLabel22.BackColor = System.Drawing.Color.Magenta;
            this.metroLabel22.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel22.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel22.ForeColor = System.Drawing.Color.Magenta;
            this.metroLabel22.Location = new System.Drawing.Point(151, 166);
            this.metroLabel22.Name = "metroLabel22";
            this.metroLabel22.Size = new System.Drawing.Size(19, 25);
            this.metroLabel22.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroLabel22.TabIndex = 9;
            this.metroLabel22.Text = "-";
            // 
            // metroLabel21
            // 
            this.metroLabel21.AutoSize = true;
            this.metroLabel21.Location = new System.Drawing.Point(4, 172);
            this.metroLabel21.Name = "metroLabel21";
            this.metroLabel21.Size = new System.Drawing.Size(132, 19);
            this.metroLabel21.TabIndex = 8;
            this.metroLabel21.Text = "Hardware Assitstance";
            // 
            // metroLabel20
            // 
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.Location = new System.Drawing.Point(185, 138);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(141, 19);
            this.metroLabel20.TabIndex = 7;
            this.metroLabel20.Text = "John Hall, James Milne";
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.BackColor = System.Drawing.Color.Magenta;
            this.metroLabel19.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel19.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel19.ForeColor = System.Drawing.Color.Magenta;
            this.metroLabel19.Location = new System.Drawing.Point(151, 132);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(19, 25);
            this.metroLabel19.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroLabel19.TabIndex = 6;
            this.metroLabel19.Text = "-";
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.Location = new System.Drawing.Point(4, 138);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(74, 19);
            this.metroLabel18.TabIndex = 5;
            this.metroLabel18.Text = "Developers";
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel17.Location = new System.Drawing.Point(4, 96);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(64, 25);
            this.metroLabel17.TabIndex = 4;
            this.metroLabel17.Text = "Credits";
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.ForeColor = System.Drawing.Color.Magenta;
            this.metroTile1.Location = new System.Drawing.Point(3, 86);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(512, 3);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroTile1.TabIndex = 3;
            this.metroTile1.Text = "metroTile1";
            this.metroTile1.UseSelectable = true;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.Location = new System.Drawing.Point(-4, 20);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(330, 38);
            this.metroLabel16.TabIndex = 2;
            this.metroLabel16.Text = "Piano Hero is a self-teaching piano program designed \r\nand developed for a third " +
    "year capstone project";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(20, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(201, 50);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // PianoHero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackImage = global::PianoHeroDesktopApp.Properties.Resources.piano;
            this.ClientSize = new System.Drawing.Size(807, 453);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "PianoHero";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PianoHero_KeyPress);
            this.metroTabControl1.ResumeLayout(false);
            this.KeyboardTab.ResumeLayout(false);
            this.KeyboardTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.midiCreationTab.ResumeLayout(false);
            this.midiCreationTab.PerformLayout();
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            this.About.ResumeLayout(false);
            this.About.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage KeyboardTab;
        private MetroFramework.Controls.MetroTabPage midiCreationTab;
        private MetroFramework.Controls.MetroTabPage SettingsTab;
        private MetroFramework.Controls.MetroButton loadButton;
        private MetroFramework.Controls.MetroButton convertButton;
        private MetroFramework.Controls.MetroTextBox slowKey;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox playKey;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox defaultSave;
        private MetroFramework.Controls.MetroTrackBar defaultSpeed;
        private MetroFramework.Controls.MetroTrackBar defaultVol;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox fastKey;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel selectedFile;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroButton browseButton;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox selectedFileText;
        private MetroFramework.Controls.MetroLabel respMessage;
        private MetroFramework.Controls.MetroButton BrowseSave;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroTextBox selectedSong;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroButton browseSongs;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel fileSendStatus;
        private MetroFramework.Controls.MetroProgressBar fileSendProgress;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroLabel speedTxt;
        private MetroFramework.Controls.MetroLabel volTxt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroProgressBar songProgress;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroTabPage About;
        private MetroFramework.Controls.MetroLabel metroLabel26;
        private MetroFramework.Controls.MetroLabel metroLabel25;
        private MetroFramework.Controls.MetroLabel metroLabel24;
        private MetroFramework.Controls.MetroLabel metroLabel23;
        private MetroFramework.Controls.MetroLabel metroLabel22;
        private MetroFramework.Controls.MetroLabel metroLabel21;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroLabel currentSong;
        private MetroFramework.Controls.MetroLabel nowPlaying;
    }
}

