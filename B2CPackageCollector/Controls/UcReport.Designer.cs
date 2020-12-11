namespace B2CPackageCollect
{
    partial class UcReport
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
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageCollect = new DevExpress.XtraTab.XtraTabPage();
            this.ucCollectedReport = new B2CPackageCollect.UcCollectedReport();
            this.tabPageNotCollect = new DevExpress.XtraTab.XtraTabPage();
            this.ucNotCollectReport = new B2CPackageCollect.UcNotCollectReport();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageCollect.SuspendLayout();
            this.tabPageNotCollect.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.AppearancePage.Header.Image = global::B2CPackageCollect.Properties.Resources.GroupHeader_32x32;
            this.tabControl.AppearancePage.Header.Options.UseImage = true;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.tabPageCollect;
            this.tabControl.Size = new System.Drawing.Size(584, 388);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageCollect,
            this.tabPageNotCollect});
            // 
            // tabPageCollect
            // 
            this.tabPageCollect.Controls.Add(this.ucCollectedReport);
            this.tabPageCollect.ImageOptions.Image = global::B2CPackageCollect.Properties.Resources.GroupHeader_32x32;
            this.tabPageCollect.ImageOptions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.tabPageCollect.Name = "tabPageCollect";
            this.tabPageCollect.Size = new System.Drawing.Size(582, 344);
            this.tabPageCollect.Text = "Toplanan Ürün Raporu";
            // 
            // ucCollectedReport
            // 
            this.ucCollectedReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCollectedReport.Location = new System.Drawing.Point(0, 0);
            this.ucCollectedReport.Name = "ucCollectedReport";
            this.ucCollectedReport.Size = new System.Drawing.Size(582, 344);
            this.ucCollectedReport.TabIndex = 0;
            // 
            // tabPageNotCollect
            // 
            this.tabPageNotCollect.Controls.Add(this.ucNotCollectReport);
            this.tabPageNotCollect.ImageOptions.Image = global::B2CPackageCollect.Properties.Resources.InsertHeader_32x32;
            this.tabPageNotCollect.ImageOptions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.tabPageNotCollect.Name = "tabPageNotCollect";
            this.tabPageNotCollect.Size = new System.Drawing.Size(582, 344);
            this.tabPageNotCollect.Text = "Toplanmayan Ürün Raporu";
            // 
            // ucNotCollectReport
            // 
            this.ucNotCollectReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucNotCollectReport.Location = new System.Drawing.Point(0, 0);
            this.ucNotCollectReport.Name = "ucNotCollectReport";
            this.ucNotCollectReport.Size = new System.Drawing.Size(582, 344);
            this.ucNotCollectReport.TabIndex = 0;
            // 
            // UcReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "UcReport";
            this.Size = new System.Drawing.Size(584, 388);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageCollect.ResumeLayout(false);
            this.tabPageNotCollect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabPageCollect;
        private UcCollectedReport ucCollectedReport;
        private DevExpress.XtraTab.XtraTabPage tabPageNotCollect;
        private UcNotCollectReport ucNotCollectReport;
    }
}