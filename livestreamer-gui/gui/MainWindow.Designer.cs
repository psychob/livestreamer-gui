namespace livestreamer_gui.gui
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tbInputUrl = new System.Windows.Forms.TextBox();
            this.tbOutputUrl = new System.Windows.Forms.TextBox();
            this.cbQualityBox = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChoosePlayerPath = new System.Windows.Forms.Button();
            this.btnChooseLivestreamerPath = new System.Windows.Forms.Button();
            this.btnConfigurationData = new System.Windows.Forms.Button();
            this.btnAutocompleteData = new System.Windows.Forms.Button();
            this.cbxAllowInternetApiAccess = new System.Windows.Forms.CheckBox();
            this.cbxVlcMetadata = new System.Windows.Forms.CheckBox();
            this.cbxHideConsole = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxRetryStream = new System.Windows.Forms.CheckBox();
            this.nudRetryDelay = new System.Windows.Forms.NumericUpDown();
            this.nudRetryAttempts = new System.Windows.Forms.NumericUpDown();
            this.cbLogLevel = new System.Windows.Forms.ComboBox();
            this.tbPlayerPath = new System.Windows.Forms.TextBox();
            this.tbLivestreamerPath = new System.Windows.Forms.TextBox();
            this.tbOutputCommand = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetryDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetryAttempts)).BeginInit();
            this.SuspendLayout();
            // 
            // tbInputUrl
            // 
            this.tbInputUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbInputUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbInputUrl.Location = new System.Drawing.Point(12, 12);
            this.tbInputUrl.Name = "tbInputUrl";
            this.tbInputUrl.Size = new System.Drawing.Size(409, 20);
            this.tbInputUrl.TabIndex = 0;
            this.tbInputUrl.TextChanged += new System.EventHandler(this.tbInputUrl_TextChanged);
            // 
            // tbOutputUrl
            // 
            this.tbOutputUrl.Location = new System.Drawing.Point(12, 38);
            this.tbOutputUrl.Name = "tbOutputUrl";
            this.tbOutputUrl.ReadOnly = true;
            this.tbOutputUrl.Size = new System.Drawing.Size(271, 20);
            this.tbOutputUrl.TabIndex = 1;
            // 
            // cbQualityBox
            // 
            this.cbQualityBox.FormattingEnabled = true;
            this.cbQualityBox.Items.AddRange(new object[] {
            "Best",
            "High",
            "Medium",
            "Low",
            "Worst"});
            this.cbQualityBox.Location = new System.Drawing.Point(289, 38);
            this.cbQualityBox.Name = "cbQualityBox";
            this.cbQualityBox.Size = new System.Drawing.Size(88, 21);
            this.cbQualityBox.TabIndex = 2;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(383, 38);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(38, 20);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = ">";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(409, 325);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnChoosePlayerPath);
            this.tabPage1.Controls.Add(this.btnChooseLivestreamerPath);
            this.tabPage1.Controls.Add(this.btnConfigurationData);
            this.tabPage1.Controls.Add(this.btnAutocompleteData);
            this.tabPage1.Controls.Add(this.cbxAllowInternetApiAccess);
            this.tabPage1.Controls.Add(this.cbxVlcMetadata);
            this.tabPage1.Controls.Add(this.cbxHideConsole);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.cbLogLevel);
            this.tabPage1.Controls.Add(this.tbPlayerPath);
            this.tabPage1.Controls.Add(this.tbLivestreamerPath);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(401, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Global";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Path To Player";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Log Level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Path to Livestreamer";
            // 
            // btnChoosePlayerPath
            // 
            this.btnChoosePlayerPath.Location = new System.Drawing.Point(350, 59);
            this.btnChoosePlayerPath.Name = "btnChoosePlayerPath";
            this.btnChoosePlayerPath.Size = new System.Drawing.Size(45, 20);
            this.btnChoosePlayerPath.TabIndex = 10;
            this.btnChoosePlayerPath.Text = "...";
            this.btnChoosePlayerPath.UseVisualStyleBackColor = true;
            this.btnChoosePlayerPath.Click += new System.EventHandler(this.btnChoosePlayerPath_Click);
            // 
            // btnChooseLivestreamerPath
            // 
            this.btnChooseLivestreamerPath.Location = new System.Drawing.Point(350, 6);
            this.btnChooseLivestreamerPath.Name = "btnChooseLivestreamerPath";
            this.btnChooseLivestreamerPath.Size = new System.Drawing.Size(45, 20);
            this.btnChooseLivestreamerPath.TabIndex = 9;
            this.btnChooseLivestreamerPath.Text = "...";
            this.btnChooseLivestreamerPath.UseVisualStyleBackColor = true;
            this.btnChooseLivestreamerPath.Click += new System.EventHandler(this.btnChooseLivestreamerPath_Click);
            // 
            // btnConfigurationData
            // 
            this.btnConfigurationData.Location = new System.Drawing.Point(209, 264);
            this.btnConfigurationData.Name = "btnConfigurationData";
            this.btnConfigurationData.Size = new System.Drawing.Size(186, 23);
            this.btnConfigurationData.TabIndex = 8;
            this.btnConfigurationData.Text = "Configuration Data";
            this.btnConfigurationData.UseVisualStyleBackColor = true;
            // 
            // btnAutocompleteData
            // 
            this.btnAutocompleteData.Location = new System.Drawing.Point(11, 264);
            this.btnAutocompleteData.Name = "btnAutocompleteData";
            this.btnAutocompleteData.Size = new System.Drawing.Size(192, 23);
            this.btnAutocompleteData.TabIndex = 7;
            this.btnAutocompleteData.Text = "Autocomplete Data";
            this.btnAutocompleteData.UseVisualStyleBackColor = true;
            // 
            // cbxAllowInternetApiAccess
            // 
            this.cbxAllowInternetApiAccess.AutoSize = true;
            this.cbxAllowInternetApiAccess.Location = new System.Drawing.Point(6, 241);
            this.cbxAllowInternetApiAccess.Name = "cbxAllowInternetApiAccess";
            this.cbxAllowInternetApiAccess.Size = new System.Drawing.Size(211, 17);
            this.cbxAllowInternetApiAccess.TabIndex = 6;
            this.cbxAllowInternetApiAccess.Text = "Allow Internet API Access for Metadata";
            this.cbxAllowInternetApiAccess.UseVisualStyleBackColor = true;
            this.cbxAllowInternetApiAccess.CheckedChanged += new System.EventHandler(this.cbxAllowInternetApiAccess_CheckedChanged);
            // 
            // cbxVlcMetadata
            // 
            this.cbxVlcMetadata.AutoSize = true;
            this.cbxVlcMetadata.Location = new System.Drawing.Point(6, 218);
            this.cbxVlcMetadata.Name = "cbxVlcMetadata";
            this.cbxVlcMetadata.Size = new System.Drawing.Size(141, 17);
            this.cbxVlcMetadata.TabIndex = 5;
            this.cbxVlcMetadata.Text = "Generate VLC Metadata";
            this.cbxVlcMetadata.UseVisualStyleBackColor = true;
            // 
            // cbxHideConsole
            // 
            this.cbxHideConsole.AutoSize = true;
            this.cbxHideConsole.Location = new System.Drawing.Point(6, 195);
            this.cbxHideConsole.Name = "cbxHideConsole";
            this.cbxHideConsole.Size = new System.Drawing.Size(89, 17);
            this.cbxHideConsole.TabIndex = 4;
            this.cbxHideConsole.Text = "Hide Console";
            this.cbxHideConsole.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxRetryStream);
            this.groupBox1.Controls.Add(this.nudRetryDelay);
            this.groupBox1.Controls.Add(this.nudRetryAttempts);
            this.groupBox1.Location = new System.Drawing.Point(6, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 94);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Retry Stream";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Delay inbetween";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Number of attempts";
            // 
            // cbxRetryStream
            // 
            this.cbxRetryStream.AutoSize = true;
            this.cbxRetryStream.Location = new System.Drawing.Point(16, 19);
            this.cbxRetryStream.Name = "cbxRetryStream";
            this.cbxRetryStream.Size = new System.Drawing.Size(57, 17);
            this.cbxRetryStream.TabIndex = 2;
            this.cbxRetryStream.Text = "Retry?";
            this.cbxRetryStream.UseVisualStyleBackColor = true;
            // 
            // nudRetryDelay
            // 
            this.nudRetryDelay.Location = new System.Drawing.Point(146, 61);
            this.nudRetryDelay.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudRetryDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRetryDelay.Name = "nudRetryDelay";
            this.nudRetryDelay.Size = new System.Drawing.Size(237, 20);
            this.nudRetryDelay.TabIndex = 1;
            this.nudRetryDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudRetryAttempts
            // 
            this.nudRetryAttempts.Location = new System.Drawing.Point(146, 35);
            this.nudRetryAttempts.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudRetryAttempts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRetryAttempts.Name = "nudRetryAttempts";
            this.nudRetryAttempts.Size = new System.Drawing.Size(237, 20);
            this.nudRetryAttempts.TabIndex = 0;
            this.nudRetryAttempts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbLogLevel
            // 
            this.cbLogLevel.FormattingEnabled = true;
            this.cbLogLevel.Items.AddRange(new object[] {
            "none",
            "error",
            "warning",
            "info",
            "debug"});
            this.cbLogLevel.Location = new System.Drawing.Point(152, 32);
            this.cbLogLevel.Name = "cbLogLevel";
            this.cbLogLevel.Size = new System.Drawing.Size(243, 21);
            this.cbLogLevel.TabIndex = 2;
            // 
            // tbPlayerPath
            // 
            this.tbPlayerPath.Location = new System.Drawing.Point(152, 59);
            this.tbPlayerPath.Name = "tbPlayerPath";
            this.tbPlayerPath.Size = new System.Drawing.Size(192, 20);
            this.tbPlayerPath.TabIndex = 1;
            // 
            // tbLivestreamerPath
            // 
            this.tbLivestreamerPath.Location = new System.Drawing.Point(152, 6);
            this.tbLivestreamerPath.Name = "tbLivestreamerPath";
            this.tbLivestreamerPath.Size = new System.Drawing.Size(192, 20);
            this.tbLivestreamerPath.TabIndex = 0;
            // 
            // tbOutputCommand
            // 
            this.tbOutputCommand.Location = new System.Drawing.Point(12, 395);
            this.tbOutputCommand.Multiline = true;
            this.tbOutputCommand.Name = "tbOutputCommand";
            this.tbOutputCommand.ReadOnly = true;
            this.tbOutputCommand.Size = new System.Drawing.Size(405, 135);
            this.tbOutputCommand.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 542);
            this.Controls.Add(this.tbOutputCommand);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.cbQualityBox);
            this.Controls.Add(this.tbOutputUrl);
            this.Controls.Add(this.tbInputUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Live Streamer GUI v3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetryDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetryAttempts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInputUrl;
        private System.Windows.Forms.TextBox tbOutputUrl;
        private System.Windows.Forms.ComboBox cbQualityBox;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbLogLevel;
        private System.Windows.Forms.TextBox tbPlayerPath;
        private System.Windows.Forms.TextBox tbLivestreamerPath;
        private System.Windows.Forms.Button btnConfigurationData;
        private System.Windows.Forms.Button btnAutocompleteData;
        private System.Windows.Forms.CheckBox cbxAllowInternetApiAccess;
        private System.Windows.Forms.CheckBox cbxVlcMetadata;
        private System.Windows.Forms.CheckBox cbxHideConsole;
        private System.Windows.Forms.CheckBox cbxRetryStream;
        private System.Windows.Forms.NumericUpDown nudRetryDelay;
        private System.Windows.Forms.NumericUpDown nudRetryAttempts;
        private System.Windows.Forms.TextBox tbOutputCommand;
        private System.Windows.Forms.Button btnChoosePlayerPath;
        private System.Windows.Forms.Button btnChooseLivestreamerPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}