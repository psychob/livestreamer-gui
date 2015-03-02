namespace livestreamer_gui
{
 partial class AutoComplete
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
   this.lbItems = new System.Windows.Forms.ListBox();
   this.btnRemove = new System.Windows.Forms.Button();
   this.btnClearList = new System.Windows.Forms.Button();
   this.SuspendLayout();
   // 
   // lbItems
   // 
   this.lbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.lbItems.FormattingEnabled = true;
   this.lbItems.Location = new System.Drawing.Point(12, 12);
   this.lbItems.Name = "lbItems";
   this.lbItems.Size = new System.Drawing.Size(290, 277);
   this.lbItems.TabIndex = 0;
   // 
   // btnRemove
   // 
   this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
   this.btnRemove.Location = new System.Drawing.Point(308, 12);
   this.btnRemove.Name = "btnRemove";
   this.btnRemove.Size = new System.Drawing.Size(75, 23);
   this.btnRemove.TabIndex = 1;
   this.btnRemove.Text = "Remove";
   this.btnRemove.UseVisualStyleBackColor = true;
   this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
   // 
   // btnClearList
   // 
   this.btnClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
   this.btnClearList.Location = new System.Drawing.Point(308, 41);
   this.btnClearList.Name = "btnClearList";
   this.btnClearList.Size = new System.Drawing.Size(75, 23);
   this.btnClearList.TabIndex = 2;
   this.btnClearList.Text = "Clear List";
   this.btnClearList.UseVisualStyleBackColor = true;
   this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
   // 
   // AutoComplete
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(395, 300);
   this.Controls.Add(this.btnClearList);
   this.Controls.Add(this.btnRemove);
   this.Controls.Add(this.lbItems);
   this.MaximizeBox = false;
   this.MinimizeBox = false;
   this.Name = "AutoComplete";
   this.Text = "Auto Complete History";
   this.Load += new System.EventHandler(this.AutoComplete_Load);
   this.ResumeLayout(false);

  }

  #endregion

  private System.Windows.Forms.ListBox lbItems;
  private System.Windows.Forms.Button btnRemove;
  private System.Windows.Forms.Button btnClearList;
 }
}