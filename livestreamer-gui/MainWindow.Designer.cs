namespace livestreamer_gui
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
   this.tbInput = new System.Windows.Forms.TextBox();
   this.tbOutputUrl = new System.Windows.Forms.TextBox();
   this.cbQuality = new System.Windows.Forms.ComboBox();
   this.tcMainTabControl = new System.Windows.Forms.TabControl();
   this.tbOptionsPage = new System.Windows.Forms.TabPage();
   this.btnChooseLivestreamerPath = new System.Windows.Forms.Button();
   this.cbGenerateMetadataForVLC = new System.Windows.Forms.CheckBox();
   this.label4 = new System.Windows.Forms.Label();
   this.label3 = new System.Windows.Forms.Label();
   this.label2 = new System.Windows.Forms.Label();
   this.label1 = new System.Windows.Forms.Label();
   this.cbDontShowConsoleWindow = new System.Windows.Forms.CheckBox();
   this.cbTryRetry = new System.Windows.Forms.CheckBox();
   this.nupDelay = new System.Windows.Forms.NumericUpDown();
   this.nupAttempts = new System.Windows.Forms.NumericUpDown();
   this.cbLogLevel = new System.Windows.Forms.ComboBox();
   this.tbLivestreamerPath = new System.Windows.Forms.TextBox();
   this.button1 = new System.Windows.Forms.Button();
   this.tbOutput = new System.Windows.Forms.TextBox();
   this.btnAutoCompleteInfo = new System.Windows.Forms.Button();
   this.tcMainTabControl.SuspendLayout();
   this.tbOptionsPage.SuspendLayout();
   ((System.ComponentModel.ISupportInitialize)(this.nupDelay)).BeginInit();
   ((System.ComponentModel.ISupportInitialize)(this.nupAttempts)).BeginInit();
   this.SuspendLayout();
   // 
   // tbInput
   // 
   this.tbInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
   this.tbInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
   this.tbInput.Location = new System.Drawing.Point(13, 13);
   this.tbInput.Name = "tbInput";
   this.tbInput.Size = new System.Drawing.Size(375, 20);
   this.tbInput.TabIndex = 0;
   this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
   // 
   // tbOutputUrl
   // 
   this.tbOutputUrl.Location = new System.Drawing.Point(13, 39);
   this.tbOutputUrl.Name = "tbOutputUrl";
   this.tbOutputUrl.ReadOnly = true;
   this.tbOutputUrl.Size = new System.Drawing.Size(259, 20);
   this.tbOutputUrl.TabIndex = 1;
   // 
   // cbQuality
   // 
   this.cbQuality.FormattingEnabled = true;
   this.cbQuality.Location = new System.Drawing.Point(278, 38);
   this.cbQuality.Name = "cbQuality";
   this.cbQuality.Size = new System.Drawing.Size(72, 21);
   this.cbQuality.TabIndex = 2;
   // 
   // tcMainTabControl
   // 
   this.tcMainTabControl.Controls.Add(this.tbOptionsPage);
   this.tcMainTabControl.Location = new System.Drawing.Point(13, 65);
   this.tcMainTabControl.Name = "tcMainTabControl";
   this.tcMainTabControl.SelectedIndex = 0;
   this.tcMainTabControl.Size = new System.Drawing.Size(375, 271);
   this.tcMainTabControl.TabIndex = 3;
   // 
   // tbOptionsPage
   // 
   this.tbOptionsPage.Controls.Add(this.btnAutoCompleteInfo);
   this.tbOptionsPage.Controls.Add(this.btnChooseLivestreamerPath);
   this.tbOptionsPage.Controls.Add(this.cbGenerateMetadataForVLC);
   this.tbOptionsPage.Controls.Add(this.label4);
   this.tbOptionsPage.Controls.Add(this.label3);
   this.tbOptionsPage.Controls.Add(this.label2);
   this.tbOptionsPage.Controls.Add(this.label1);
   this.tbOptionsPage.Controls.Add(this.cbDontShowConsoleWindow);
   this.tbOptionsPage.Controls.Add(this.cbTryRetry);
   this.tbOptionsPage.Controls.Add(this.nupDelay);
   this.tbOptionsPage.Controls.Add(this.nupAttempts);
   this.tbOptionsPage.Controls.Add(this.cbLogLevel);
   this.tbOptionsPage.Controls.Add(this.tbLivestreamerPath);
   this.tbOptionsPage.Location = new System.Drawing.Point(4, 22);
   this.tbOptionsPage.Name = "tbOptionsPage";
   this.tbOptionsPage.Padding = new System.Windows.Forms.Padding(3);
   this.tbOptionsPage.Size = new System.Drawing.Size(367, 245);
   this.tbOptionsPage.TabIndex = 0;
   this.tbOptionsPage.Text = "Options";
   this.tbOptionsPage.UseVisualStyleBackColor = true;
   // 
   // btnChooseLivestreamerPath
   // 
   this.btnChooseLivestreamerPath.Location = new System.Drawing.Point(324, 6);
   this.btnChooseLivestreamerPath.Name = "btnChooseLivestreamerPath";
   this.btnChooseLivestreamerPath.Size = new System.Drawing.Size(37, 20);
   this.btnChooseLivestreamerPath.TabIndex = 11;
   this.btnChooseLivestreamerPath.Text = "...";
   this.btnChooseLivestreamerPath.UseVisualStyleBackColor = true;
   this.btnChooseLivestreamerPath.Click += new System.EventHandler(this.btnChooseLivestreamerPath_Click);
   // 
   // cbGenerateMetadataForVLC
   // 
   this.cbGenerateMetadataForVLC.AutoSize = true;
   this.cbGenerateMetadataForVLC.Checked = true;
   this.cbGenerateMetadataForVLC.CheckState = System.Windows.Forms.CheckState.Checked;
   this.cbGenerateMetadataForVLC.Location = new System.Drawing.Point(6, 158);
   this.cbGenerateMetadataForVLC.Name = "cbGenerateMetadataForVLC";
   this.cbGenerateMetadataForVLC.Size = new System.Drawing.Size(155, 17);
   this.cbGenerateMetadataForVLC.TabIndex = 10;
   this.cbGenerateMetadataForVLC.Text = "Generate metadata for VLC";
   this.cbGenerateMetadataForVLC.UseVisualStyleBackColor = true;
   // 
   // label4
   // 
   this.label4.AutoSize = true;
   this.label4.Location = new System.Drawing.Point(6, 111);
   this.label4.Name = "label4";
   this.label4.Size = new System.Drawing.Size(81, 13);
   this.label4.TabIndex = 9;
   this.label4.Text = "Delay between:";
   // 
   // label3
   // 
   this.label3.AutoSize = true;
   this.label3.Location = new System.Drawing.Point(6, 85);
   this.label3.Name = "label3";
   this.label3.Size = new System.Drawing.Size(102, 13);
   this.label3.TabIndex = 8;
   this.label3.Text = "Number of attempts:";
   // 
   // label2
   // 
   this.label2.AutoSize = true;
   this.label2.Location = new System.Drawing.Point(6, 36);
   this.label2.Name = "label2";
   this.label2.Size = new System.Drawing.Size(57, 13);
   this.label2.TabIndex = 7;
   this.label2.Text = "Log Level:";
   // 
   // label1
   // 
   this.label1.AutoSize = true;
   this.label1.Location = new System.Drawing.Point(6, 9);
   this.label1.Name = "label1";
   this.label1.Size = new System.Drawing.Size(103, 13);
   this.label1.TabIndex = 6;
   this.label1.Text = "Path to livestreamer:";
   // 
   // cbDontShowConsoleWindow
   // 
   this.cbDontShowConsoleWindow.AutoSize = true;
   this.cbDontShowConsoleWindow.Location = new System.Drawing.Point(6, 135);
   this.cbDontShowConsoleWindow.Name = "cbDontShowConsoleWindow";
   this.cbDontShowConsoleWindow.Size = new System.Drawing.Size(165, 17);
   this.cbDontShowConsoleWindow.TabIndex = 5;
   this.cbDontShowConsoleWindow.Text = "Do not show console window";
   this.cbDontShowConsoleWindow.UseVisualStyleBackColor = true;
   // 
   // cbTryRetry
   // 
   this.cbTryRetry.AutoSize = true;
   this.cbTryRetry.Checked = true;
   this.cbTryRetry.CheckState = System.Windows.Forms.CheckState.Checked;
   this.cbTryRetry.Location = new System.Drawing.Point(6, 60);
   this.cbTryRetry.Name = "cbTryRetry";
   this.cbTryRetry.Size = new System.Drawing.Size(76, 17);
   this.cbTryRetry.TabIndex = 4;
   this.cbTryRetry.Text = "Try to retry";
   this.cbTryRetry.UseVisualStyleBackColor = true;
   // 
   // nupDelay
   // 
   this.nupDelay.Location = new System.Drawing.Point(115, 109);
   this.nupDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
   this.nupDelay.Name = "nupDelay";
   this.nupDelay.Size = new System.Drawing.Size(246, 20);
   this.nupDelay.TabIndex = 3;
   this.nupDelay.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
   // 
   // nupAttempts
   // 
   this.nupAttempts.Location = new System.Drawing.Point(115, 83);
   this.nupAttempts.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
   this.nupAttempts.Name = "nupAttempts";
   this.nupAttempts.Size = new System.Drawing.Size(246, 20);
   this.nupAttempts.TabIndex = 2;
   this.nupAttempts.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
   // 
   // cbLogLevel
   // 
   this.cbLogLevel.Items.AddRange(new object[] {
            "none",
            "error",
            "warning",
            "info",
            "debug"});
   this.cbLogLevel.Location = new System.Drawing.Point(115, 33);
   this.cbLogLevel.Name = "cbLogLevel";
   this.cbLogLevel.Size = new System.Drawing.Size(246, 21);
   this.cbLogLevel.TabIndex = 1;
   // 
   // tbLivestreamerPath
   // 
   this.tbLivestreamerPath.Location = new System.Drawing.Point(115, 6);
   this.tbLivestreamerPath.Name = "tbLivestreamerPath";
   this.tbLivestreamerPath.Size = new System.Drawing.Size(203, 20);
   this.tbLivestreamerPath.TabIndex = 0;
   // 
   // button1
   // 
   this.button1.Location = new System.Drawing.Point(356, 39);
   this.button1.Name = "button1";
   this.button1.Size = new System.Drawing.Size(32, 20);
   this.button1.TabIndex = 4;
   this.button1.Text = ">";
   this.button1.UseVisualStyleBackColor = true;
   this.button1.Click += new System.EventHandler(this.button1_Click);
   // 
   // tbOutput
   // 
   this.tbOutput.Location = new System.Drawing.Point(13, 343);
   this.tbOutput.Multiline = true;
   this.tbOutput.Name = "tbOutput";
   this.tbOutput.ReadOnly = true;
   this.tbOutput.Size = new System.Drawing.Size(375, 114);
   this.tbOutput.TabIndex = 5;
   // 
   // btnAutoCompleteInfo
   // 
   this.btnAutoCompleteInfo.Location = new System.Drawing.Point(6, 181);
   this.btnAutoCompleteInfo.Name = "btnAutoCompleteInfo";
   this.btnAutoCompleteInfo.Size = new System.Drawing.Size(113, 23);
   this.btnAutoCompleteInfo.TabIndex = 12;
   this.btnAutoCompleteInfo.Text = "Auto Complete";
   this.btnAutoCompleteInfo.UseVisualStyleBackColor = true;
   this.btnAutoCompleteInfo.Click += new System.EventHandler(this.button2_Click);
   // 
   // MainWindow
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(400, 469);
   this.Controls.Add(this.tbOutput);
   this.Controls.Add(this.button1);
   this.Controls.Add(this.tcMainTabControl);
   this.Controls.Add(this.cbQuality);
   this.Controls.Add(this.tbOutputUrl);
   this.Controls.Add(this.tbInput);
   this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
   this.MaximizeBox = false;
   this.Name = "MainWindow";
   this.Text = "Livestreamer GUI";
   this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
   this.Load += new System.EventHandler(this.MainWindow_Load);
   this.tcMainTabControl.ResumeLayout(false);
   this.tbOptionsPage.ResumeLayout(false);
   this.tbOptionsPage.PerformLayout();
   ((System.ComponentModel.ISupportInitialize)(this.nupDelay)).EndInit();
   ((System.ComponentModel.ISupportInitialize)(this.nupAttempts)).EndInit();
   this.ResumeLayout(false);
   this.PerformLayout();

  }

  #endregion

  private System.Windows.Forms.TextBox tbInput;
  private System.Windows.Forms.TextBox tbOutputUrl;
  private System.Windows.Forms.ComboBox cbQuality;
  private System.Windows.Forms.TabControl tcMainTabControl;
  private System.Windows.Forms.TabPage tbOptionsPage;
  private System.Windows.Forms.TextBox tbLivestreamerPath;
  private System.Windows.Forms.ComboBox cbLogLevel;
  private System.Windows.Forms.NumericUpDown nupDelay;
  private System.Windows.Forms.NumericUpDown nupAttempts;
  private System.Windows.Forms.CheckBox cbTryRetry;
  private System.Windows.Forms.Label label4;
  private System.Windows.Forms.Label label3;
  private System.Windows.Forms.Label label2;
  private System.Windows.Forms.Label label1;
  private System.Windows.Forms.CheckBox cbDontShowConsoleWindow;
  private System.Windows.Forms.CheckBox cbGenerateMetadataForVLC;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.TextBox tbOutput;
  private System.Windows.Forms.Button btnChooseLivestreamerPath;
  private System.Windows.Forms.Button btnAutoCompleteInfo;
 }
}