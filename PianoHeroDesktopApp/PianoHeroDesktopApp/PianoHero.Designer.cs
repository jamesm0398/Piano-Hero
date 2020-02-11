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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.KeyboardTab = new MetroFramework.Controls.MetroTabPage();
            this.playButton = new MetroFramework.Controls.MetroButton();
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
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
            this.metroTextBox7 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox6 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox5 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.defaultSave = new MetroFramework.Controls.MetroTextBox();
            this.defaultSpeed = new MetroFramework.Controls.MetroTrackBar();
            this.defaultVol = new MetroFramework.Controls.MetroTrackBar();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.BrowseSave = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1.SuspendLayout();
            this.KeyboardTab.SuspendLayout();
            this.midiCreationTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.KeyboardTab);
            this.metroTabControl1.Controls.Add(this.midiCreationTab);
            this.metroTabControl1.Controls.Add(this.SettingsTab);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.ItemSize = new System.Drawing.Size(168, 34);
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(5);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 2;
            this.metroTabControl1.Size = new System.Drawing.Size(767, 373);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // KeyboardTab
            // 
            this.KeyboardTab.Controls.Add(this.playButton);
            this.KeyboardTab.Controls.Add(this.metroListView1);
            this.KeyboardTab.Controls.Add(this.metroTextBox2);
            this.KeyboardTab.Controls.Add(this.metroComboBox1);
            this.KeyboardTab.Controls.Add(this.metroTextBox1);
            this.KeyboardTab.HorizontalScrollbarBarColor = true;
            this.KeyboardTab.HorizontalScrollbarHighlightOnWheel = false;
            this.KeyboardTab.HorizontalScrollbarSize = 20;
            this.KeyboardTab.Location = new System.Drawing.Point(4, 38);
            this.KeyboardTab.Name = "KeyboardTab";
            this.KeyboardTab.Padding = new System.Windows.Forms.Padding(200);
            this.KeyboardTab.Size = new System.Drawing.Size(759, 331);
            this.KeyboardTab.TabIndex = 0;
            this.KeyboardTab.Text = "Keyboard";
            this.KeyboardTab.VerticalScrollbarBarColor = true;
            this.KeyboardTab.VerticalScrollbarHighlightOnWheel = false;
            this.KeyboardTab.VerticalScrollbarSize = 10;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(569, 186);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(122, 56);
            this.playButton.TabIndex = 6;
            this.playButton.Text = "Play Song";
            this.playButton.UseSelectable = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // metroListView1
            // 
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.Location = new System.Drawing.Point(315, 58);
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(376, 97);
            this.metroListView1.TabIndex = 5;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBox2.Lines = new string[] {
        "Select a song:"};
            this.metroTextBox2.Location = new System.Drawing.Point(314, 16);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(122, 23);
            this.metroTextBox2.TabIndex = 4;
            this.metroTextBox2.Text = "Select a song:";
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.metroComboBox1.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 19;
            this.metroComboBox1.Location = new System.Drawing.Point(14, 46);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(142, 25);
            this.metroComboBox1.TabIndex = 3;
            this.metroComboBox1.UseSelectable = true;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(120, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBox1.Lines = new string[] {
        "Select a keyboard:"};
            this.metroTextBox1.Location = new System.Drawing.Point(14, 16);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(142, 23);
            this.metroTextBox1.TabIndex = 2;
            this.metroTextBox1.Text = "Select a keyboard:";
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            this.respMessage.Size = new System.Drawing.Size(86, 19);
            this.respMessage.TabIndex = 14;
            this.respMessage.Text = "metroLabel11";
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
            this.SettingsTab.Controls.Add(this.BrowseSave);
            this.SettingsTab.Controls.Add(this.metroTextBox7);
            this.SettingsTab.Controls.Add(this.metroLabel7);
            this.SettingsTab.Controls.Add(this.metroTextBox6);
            this.SettingsTab.Controls.Add(this.metroLabel6);
            this.SettingsTab.Controls.Add(this.metroTextBox5);
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
            // metroTextBox7
            // 
            // 
            // 
            // 
            this.metroTextBox7.CustomButton.Image = null;
            this.metroTextBox7.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.metroTextBox7.CustomButton.Name = "";
            this.metroTextBox7.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox7.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox7.CustomButton.TabIndex = 1;
            this.metroTextBox7.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox7.CustomButton.UseSelectable = true;
            this.metroTextBox7.CustomButton.Visible = false;
            this.metroTextBox7.Lines = new string[] {
        "Up Arrow Key"};
            this.metroTextBox7.Location = new System.Drawing.Point(179, 302);
            this.metroTextBox7.MaxLength = 32767;
            this.metroTextBox7.Name = "metroTextBox7";
            this.metroTextBox7.PasswordChar = '\0';
            this.metroTextBox7.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox7.SelectedText = "";
            this.metroTextBox7.SelectionLength = 0;
            this.metroTextBox7.SelectionStart = 0;
            this.metroTextBox7.ShortcutsEnabled = true;
            this.metroTextBox7.Size = new System.Drawing.Size(100, 23);
            this.metroTextBox7.TabIndex = 14;
            this.metroTextBox7.Text = "Up Arrow Key";
            this.metroTextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox7.UseSelectable = true;
            this.metroTextBox7.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox7.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            // metroTextBox6
            // 
            // 
            // 
            // 
            this.metroTextBox6.CustomButton.Image = null;
            this.metroTextBox6.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.metroTextBox6.CustomButton.Name = "";
            this.metroTextBox6.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox6.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox6.CustomButton.TabIndex = 1;
            this.metroTextBox6.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox6.CustomButton.UseSelectable = true;
            this.metroTextBox6.CustomButton.Visible = false;
            this.metroTextBox6.Lines = new string[] {
        "Down Arrow Key"};
            this.metroTextBox6.Location = new System.Drawing.Point(179, 260);
            this.metroTextBox6.MaxLength = 32767;
            this.metroTextBox6.Name = "metroTextBox6";
            this.metroTextBox6.PasswordChar = '\0';
            this.metroTextBox6.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox6.SelectedText = "";
            this.metroTextBox6.SelectionLength = 0;
            this.metroTextBox6.SelectionStart = 0;
            this.metroTextBox6.ShortcutsEnabled = true;
            this.metroTextBox6.Size = new System.Drawing.Size(100, 23);
            this.metroTextBox6.TabIndex = 12;
            this.metroTextBox6.Text = "Down Arrow Key";
            this.metroTextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox6.UseSelectable = true;
            this.metroTextBox6.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox6.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            // metroTextBox5
            // 
            // 
            // 
            // 
            this.metroTextBox5.CustomButton.Image = null;
            this.metroTextBox5.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.metroTextBox5.CustomButton.Name = "";
            this.metroTextBox5.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox5.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox5.CustomButton.TabIndex = 1;
            this.metroTextBox5.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox5.CustomButton.UseSelectable = true;
            this.metroTextBox5.CustomButton.Visible = false;
            this.metroTextBox5.Lines = new string[] {
        "SPACE"};
            this.metroTextBox5.Location = new System.Drawing.Point(179, 222);
            this.metroTextBox5.MaxLength = 32767;
            this.metroTextBox5.Name = "metroTextBox5";
            this.metroTextBox5.PasswordChar = '\0';
            this.metroTextBox5.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox5.SelectedText = "";
            this.metroTextBox5.SelectionLength = 0;
            this.metroTextBox5.SelectionStart = 0;
            this.metroTextBox5.ShortcutsEnabled = true;
            this.metroTextBox5.Size = new System.Drawing.Size(100, 23);
            this.metroTextBox5.TabIndex = 10;
            this.metroTextBox5.Text = "SPACE";
            this.metroTextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox5.UseSelectable = true;
            this.metroTextBox5.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox5.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            // 
            // defaultVol
            // 
            this.defaultVol.BackColor = System.Drawing.Color.Transparent;
            this.defaultVol.Location = new System.Drawing.Point(223, 119);
            this.defaultVol.Name = "defaultVol";
            this.defaultVol.Size = new System.Drawing.Size(153, 23);
            this.defaultVol.TabIndex = 5;
            this.defaultVol.Text = "metroTrackBar1";
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
            // PianoHero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 453);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "PianoHero";
            this.Text = "Piano Hero";
            this.metroTabControl1.ResumeLayout(false);
            this.KeyboardTab.ResumeLayout(false);
            this.midiCreationTab.ResumeLayout(false);
            this.midiCreationTab.PerformLayout();
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage KeyboardTab;
        private MetroFramework.Controls.MetroTabPage midiCreationTab;
        private MetroFramework.Controls.MetroTabPage SettingsTab;
        private MetroFramework.Controls.MetroListView metroListView1;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroButton playButton;
        private MetroFramework.Controls.MetroButton convertButton;
        private MetroFramework.Controls.MetroTextBox metroTextBox6;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox metroTextBox5;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox defaultSave;
        private MetroFramework.Controls.MetroTrackBar defaultSpeed;
        private MetroFramework.Controls.MetroTrackBar defaultVol;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox metroTextBox7;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel selectedFile;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroButton browseButton;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox selectedFileText;
        private MetroFramework.Controls.MetroLabel respMessage;
        private MetroFramework.Controls.MetroButton BrowseSave;
    }
}

