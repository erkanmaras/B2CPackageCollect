namespace B2CPackageCollect
{
    partial class FrmCollectReportOptions
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
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileRoot = new DevExpress.XtraEditors.TileGroup();
            this.SuspendLayout();
            // 
            // tileControl1
            // 
            this.tileControl1.ColumnCount = 1;
            this.tileControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl1.Groups.Add(this.tileRoot);
            this.tileControl1.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tileControl1.IndentBetweenGroups = 8;
            this.tileControl1.ItemSize = 50;
            this.tileControl1.Location = new System.Drawing.Point(0, 0);
            this.tileControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tileControl1.MaxId = 8;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.OptionsAdaptiveLayout.ItemMinSize = new System.Drawing.Size(0, 0);
            this.tileControl1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileControl1.Padding = new System.Windows.Forms.Padding(0);
            this.tileControl1.RowCount = 4;
            this.tileControl1.Size = new System.Drawing.Size(250, 285);
            this.tileControl1.TabIndex = 0;
            this.tileControl1.Text = "tileControl1";
            this.tileControl1.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Center;
            // 
            // tileRoot
            // 
            this.tileRoot.Name = "tileRoot";
            // 
            // FrmCollectReportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 285);
            this.ControlBox = false;
            this.Controls.Add(this.tileControl1);
            this.Name = "FrmCollectReportOptions";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileRoot;
    }
}