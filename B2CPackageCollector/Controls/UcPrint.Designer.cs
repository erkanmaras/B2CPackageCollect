namespace B2CPackageCollect.Controls
{
    partial class UcPrint
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.documentViewer = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciPreview = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrint = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciCancel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.btnCancel);
            this.lcMain.Controls.Add(this.btnPrint);
            this.lcMain.Controls.Add(this.documentViewer);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsView.UseDefaultDragAndDropRendering = false;
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(482, 434);
            this.lcMain.TabIndex = 1;
            this.lcMain.Text = "lcMain";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = global::B2CPackageCollect.Properties.Resources.Cancel_32x32;
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCancel.Location = new System.Drawing.Point(429, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(38, 36);
            this.btnCancel.StyleController = this.lcMain;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "simpleButton2";
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.Image = global::B2CPackageCollect.Properties.Resources.Print_32x321;
            this.btnPrint.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPrint.Location = new System.Drawing.Point(381, 383);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(38, 36);
            this.btnPrint.StyleController = this.lcMain;
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "simpleButton1";
            // 
            // documentViewer
            // 
            this.documentViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.documentViewer.IsMetric = false;
            this.documentViewer.Location = new System.Drawing.Point(15, 15);
            this.documentViewer.Name = "documentViewer";
            this.documentViewer.Size = new System.Drawing.Size(452, 358);
            this.documentViewer.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciPreview,
            this.lciPrint,
            this.emptySpaceItem1,
            this.lciCancel});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(482, 434);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciPreview
            // 
            this.lciPreview.Control = this.documentViewer;
            this.lciPreview.Location = new System.Drawing.Point(0, 0);
            this.lciPreview.Name = "lciPreview";
            this.lciPreview.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciPreview.Size = new System.Drawing.Size(462, 368);
            this.lciPreview.TextSize = new System.Drawing.Size(0, 0);
            this.lciPreview.TextVisible = false;
            // 
            // lciPrint
            // 
            this.lciPrint.Control = this.btnPrint;
            this.lciPrint.Location = new System.Drawing.Point(366, 368);
            this.lciPrint.Name = "lciPrint";
            this.lciPrint.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciPrint.Size = new System.Drawing.Size(48, 46);
            this.lciPrint.TextSize = new System.Drawing.Size(0, 0);
            this.lciPrint.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 368);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(366, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciCancel
            // 
            this.lciCancel.Control = this.btnCancel;
            this.lciCancel.Location = new System.Drawing.Point(414, 368);
            this.lciCancel.Name = "lciCancel";
            this.lciCancel.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciCancel.Size = new System.Drawing.Size(48, 46);
            this.lciCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancel.TextVisible = false;
            // 
            // ucPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcMain);
            this.Name = "UcPrint";
            this.Size = new System.Drawing.Size(482, 434);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer;
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lciPreview;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem lciPrint;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem lciCancel;
    }
}
