namespace livestreamer_gui
{
 partial class Form1
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
   this.tb_userUrl = new System.Windows.Forms.TextBox();
   this.tb_genUrl = new System.Windows.Forms.TextBox();
   this.button1 = new System.Windows.Forms.Button();
   this.cb_quality = new System.Windows.Forms.ComboBox();
   this.tb_log = new System.Windows.Forms.TextBox();
   this.tb_livestreamer = new System.Windows.Forms.TabPage();
   this.num_livestreamer_attempts = new System.Windows.Forms.NumericUpDown();
   this.label11 = new System.Windows.Forms.Label();
   this.label10 = new System.Windows.Forms.Label();
   this.num_livestreamer_delay = new System.Windows.Forms.NumericUpDown();
   this.cbx_livestreamer_retry = new System.Windows.Forms.CheckBox();
   this.cb_livestreamer_loglevel = new System.Windows.Forms.ComboBox();
   this.label9 = new System.Windows.Forms.Label();
   this.tb_livestreamer_path = new System.Windows.Forms.TextBox();
   this.label8 = new System.Windows.Forms.Label();
   this.tabs = new System.Windows.Forms.TabControl();
   this.btnSearchForLivestreamer = new System.Windows.Forms.Button();
   this.cbxDontShowConsoleWindow = new System.Windows.Forms.CheckBox();
   this.tb_livestreamer.SuspendLayout();
   ((System.ComponentModel.ISupportInitialize)(this.num_livestreamer_attempts)).BeginInit();
   ((System.ComponentModel.ISupportInitialize)(this.num_livestreamer_delay)).BeginInit();
   this.tabs.SuspendLayout();
   this.SuspendLayout();
   // 
   // tb_userUrl
   // 
   this.tb_userUrl.Location = new System.Drawing.Point(12, 12);
   this.tb_userUrl.Name = "tb_userUrl";
   this.tb_userUrl.Size = new System.Drawing.Size(396, 20);
   this.tb_userUrl.TabIndex = 0;
   this.tb_userUrl.TextChanged += new System.EventHandler(this.tb_userUrl_TextChanged);
   // 
   // tb_genUrl
   // 
   this.tb_genUrl.Enabled = false;
   this.tb_genUrl.Location = new System.Drawing.Point(13, 39);
   this.tb_genUrl.Name = "tb_genUrl";
   this.tb_genUrl.Size = new System.Drawing.Size(305, 20);
   this.tb_genUrl.TabIndex = 1;
   // 
   // button1
   // 
   this.button1.Location = new System.Drawing.Point(385, 39);
   this.button1.Name = "button1";
   this.button1.Size = new System.Drawing.Size(23, 19);
   this.button1.TabIndex = 2;
   this.button1.Text = ">";
   this.button1.UseVisualStyleBackColor = true;
   this.button1.Click += new System.EventHandler(this.button1_Click);
   // 
   // cb_quality
   // 
   this.cb_quality.FormattingEnabled = true;
   this.cb_quality.Items.AddRange(new object[] {
            "best",
            "high",
            "medium",
            "low",
            "worst"});
   this.cb_quality.Location = new System.Drawing.Point(325, 39);
   this.cb_quality.Name = "cb_quality";
   this.cb_quality.Size = new System.Drawing.Size(54, 21);
   this.cb_quality.TabIndex = 4;
   // 
   // tb_log
   // 
   this.tb_log.Location = new System.Drawing.Point(13, 458);
   this.tb_log.Multiline = true;
   this.tb_log.Name = "tb_log";
   this.tb_log.ReadOnly = true;
   this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
   this.tb_log.Size = new System.Drawing.Size(395, 190);
   this.tb_log.TabIndex = 5;
   // 
   // tb_livestreamer
   // 
   this.tb_livestreamer.Controls.Add(this.cbxDontShowConsoleWindow);
   this.tb_livestreamer.Controls.Add(this.btnSearchForLivestreamer);
   this.tb_livestreamer.Controls.Add(this.num_livestreamer_attempts);
   this.tb_livestreamer.Controls.Add(this.label11);
   this.tb_livestreamer.Controls.Add(this.label10);
   this.tb_livestreamer.Controls.Add(this.num_livestreamer_delay);
   this.tb_livestreamer.Controls.Add(this.cbx_livestreamer_retry);
   this.tb_livestreamer.Controls.Add(this.cb_livestreamer_loglevel);
   this.tb_livestreamer.Controls.Add(this.label9);
   this.tb_livestreamer.Controls.Add(this.tb_livestreamer_path);
   this.tb_livestreamer.Controls.Add(this.label8);
   this.tb_livestreamer.Location = new System.Drawing.Point(4, 22);
   this.tb_livestreamer.Name = "tb_livestreamer";
   this.tb_livestreamer.Padding = new System.Windows.Forms.Padding(3);
   this.tb_livestreamer.Size = new System.Drawing.Size(388, 364);
   this.tb_livestreamer.TabIndex = 2;
   this.tb_livestreamer.Text = "Livestreamer";
   this.tb_livestreamer.UseVisualStyleBackColor = true;
   // 
   // num_livestreamer_attempts
   // 
   this.num_livestreamer_attempts.Location = new System.Drawing.Point(273, 60);
   this.num_livestreamer_attempts.Maximum = new decimal(new int[] {
            17000,
            0,
            0,
            0});
   this.num_livestreamer_attempts.Name = "num_livestreamer_attempts";
   this.num_livestreamer_attempts.Size = new System.Drawing.Size(109, 20);
   this.num_livestreamer_attempts.TabIndex = 8;
   this.num_livestreamer_attempts.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
   // 
   // label11
   // 
   this.label11.AutoSize = true;
   this.label11.Location = new System.Drawing.Point(216, 62);
   this.label11.Name = "label11";
   this.label11.Size = new System.Drawing.Size(51, 13);
   this.label11.TabIndex = 7;
   this.label11.Text = "Attempts:";
   // 
   // label10
   // 
   this.label10.AutoSize = true;
   this.label10.Location = new System.Drawing.Point(78, 62);
   this.label10.Name = "label10";
   this.label10.Size = new System.Drawing.Size(34, 13);
   this.label10.TabIndex = 6;
   this.label10.Text = "Delay";
   // 
   // num_livestreamer_delay
   // 
   this.num_livestreamer_delay.Location = new System.Drawing.Point(118, 60);
   this.num_livestreamer_delay.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
   this.num_livestreamer_delay.Name = "num_livestreamer_delay";
   this.num_livestreamer_delay.Size = new System.Drawing.Size(92, 20);
   this.num_livestreamer_delay.TabIndex = 5;
   this.num_livestreamer_delay.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
   // 
   // cbx_livestreamer_retry
   // 
   this.cbx_livestreamer_retry.AutoSize = true;
   this.cbx_livestreamer_retry.Checked = true;
   this.cbx_livestreamer_retry.CheckState = System.Windows.Forms.CheckState.Checked;
   this.cbx_livestreamer_retry.Location = new System.Drawing.Point(6, 61);
   this.cbx_livestreamer_retry.Name = "cbx_livestreamer_retry";
   this.cbx_livestreamer_retry.Size = new System.Drawing.Size(60, 17);
   this.cbx_livestreamer_retry.TabIndex = 4;
   this.cbx_livestreamer_retry.Text = "Retry ?";
   this.cbx_livestreamer_retry.UseVisualStyleBackColor = true;
   // 
   // cb_livestreamer_loglevel
   // 
   this.cb_livestreamer_loglevel.FormattingEnabled = true;
   this.cb_livestreamer_loglevel.Items.AddRange(new object[] {
            "none",
            "error",
            "warning",
            "info",
            "debug"});
   this.cb_livestreamer_loglevel.Location = new System.Drawing.Point(81, 33);
   this.cb_livestreamer_loglevel.Name = "cb_livestreamer_loglevel";
   this.cb_livestreamer_loglevel.Size = new System.Drawing.Size(301, 21);
   this.cb_livestreamer_loglevel.TabIndex = 3;
   // 
   // label9
   // 
   this.label9.AutoSize = true;
   this.label9.Location = new System.Drawing.Point(3, 36);
   this.label9.Name = "label9";
   this.label9.Size = new System.Drawing.Size(57, 13);
   this.label9.TabIndex = 2;
   this.label9.Text = "Log Level:";
   // 
   // tb_livestreamer_path
   // 
   this.tb_livestreamer_path.Location = new System.Drawing.Point(81, 7);
   this.tb_livestreamer_path.Name = "tb_livestreamer_path";
   this.tb_livestreamer_path.Size = new System.Drawing.Size(252, 20);
   this.tb_livestreamer_path.TabIndex = 1;
   this.tb_livestreamer_path.Text = "livestreamer";
   // 
   // label8
   // 
   this.label8.AutoSize = true;
   this.label8.Location = new System.Drawing.Point(3, 10);
   this.label8.Name = "label8";
   this.label8.Size = new System.Drawing.Size(32, 13);
   this.label8.TabIndex = 0;
   this.label8.Text = "Path:";
   // 
   // tabs
   // 
   this.tabs.Controls.Add(this.tb_livestreamer);
   this.tabs.Location = new System.Drawing.Point(12, 65);
   this.tabs.Name = "tabs";
   this.tabs.SelectedIndex = 0;
   this.tabs.Size = new System.Drawing.Size(396, 390);
   this.tabs.TabIndex = 3;
   // 
   // btnSearchForLivestreamer
   // 
   this.btnSearchForLivestreamer.Location = new System.Drawing.Point(340, 7);
   this.btnSearchForLivestreamer.Name = "btnSearchForLivestreamer";
   this.btnSearchForLivestreamer.Size = new System.Drawing.Size(42, 20);
   this.btnSearchForLivestreamer.TabIndex = 9;
   this.btnSearchForLivestreamer.Text = "...";
   this.btnSearchForLivestreamer.UseVisualStyleBackColor = true;
   this.btnSearchForLivestreamer.Click += new System.EventHandler(this.btnSearchForLivestreamer_Click);
   // 
   // cbxDontShowConsoleWindow
   // 
   this.cbxDontShowConsoleWindow.AutoSize = true;
   this.cbxDontShowConsoleWindow.Checked = true;
   this.cbxDontShowConsoleWindow.CheckState = System.Windows.Forms.CheckState.Checked;
   this.cbxDontShowConsoleWindow.Location = new System.Drawing.Point(4, 85);
   this.cbxDontShowConsoleWindow.Name = "cbxDontShowConsoleWindow";
   this.cbxDontShowConsoleWindow.Size = new System.Drawing.Size(158, 17);
   this.cbxDontShowConsoleWindow.TabIndex = 10;
   this.cbxDontShowConsoleWindow.Text = "Don\'t show console window";
   this.cbxDontShowConsoleWindow.UseVisualStyleBackColor = true;
   // 
   // Form1
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(420, 660);
   this.Controls.Add(this.tb_log);
   this.Controls.Add(this.cb_quality);
   this.Controls.Add(this.tabs);
   this.Controls.Add(this.button1);
   this.Controls.Add(this.tb_genUrl);
   this.Controls.Add(this.tb_userUrl);
   this.Name = "Form1";
   this.Text = "livestreamer-gui";
   this.tb_livestreamer.ResumeLayout(false);
   this.tb_livestreamer.PerformLayout();
   ((System.ComponentModel.ISupportInitialize)(this.num_livestreamer_attempts)).EndInit();
   ((System.ComponentModel.ISupportInitialize)(this.num_livestreamer_delay)).EndInit();
   this.tabs.ResumeLayout(false);
   this.ResumeLayout(false);
   this.PerformLayout();

  }

  #endregion

  private System.Windows.Forms.TextBox tb_userUrl;
  private System.Windows.Forms.TextBox tb_genUrl;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.ComboBox cb_quality;
  private System.Windows.Forms.TextBox tb_log;
  private System.Windows.Forms.TabPage tb_livestreamer;
  private System.Windows.Forms.NumericUpDown num_livestreamer_attempts;
  private System.Windows.Forms.Label label11;
  private System.Windows.Forms.Label label10;
  private System.Windows.Forms.NumericUpDown num_livestreamer_delay;
  private System.Windows.Forms.CheckBox cbx_livestreamer_retry;
  private System.Windows.Forms.ComboBox cb_livestreamer_loglevel;
  private System.Windows.Forms.Label label9;
  private System.Windows.Forms.TextBox tb_livestreamer_path;
  private System.Windows.Forms.Label label8;
  private System.Windows.Forms.TabControl tabs;
  private System.Windows.Forms.Button btnSearchForLivestreamer;
  private System.Windows.Forms.CheckBox cbxDontShowConsoleWindow;
 }
}

