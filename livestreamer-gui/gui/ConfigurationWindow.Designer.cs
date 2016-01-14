namespace livestreamer_gui.gui
{
    partial class ConfigurationWindow
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
            this.lvConfigurationData = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbValues = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lvConfigurationData
            // 
            this.lvConfigurationData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvConfigurationData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chType,
            this.chValue});
            this.lvConfigurationData.Location = new System.Drawing.Point(12, 12);
            this.lvConfigurationData.Name = "lvConfigurationData";
            this.lvConfigurationData.Size = new System.Drawing.Size(250, 366);
            this.lvConfigurationData.TabIndex = 0;
            this.lvConfigurationData.UseCompatibleStateImageBehavior = false;
            this.lvConfigurationData.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 117;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.Width = 52;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 69;
            // 
            // lbValues
            // 
            this.lbValues.FormattingEnabled = true;
            this.lbValues.Location = new System.Drawing.Point(268, 12);
            this.lbValues.Name = "lbValues";
            this.lbValues.Size = new System.Drawing.Size(253, 368);
            this.lbValues.TabIndex = 1;
            // 
            // ConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 390);
            this.Controls.Add(this.lbValues);
            this.Controls.Add(this.lvConfigurationData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationWindow";
            this.Text = "Configuration Data";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvConfigurationData;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.ListBox lbValues;
    }
}