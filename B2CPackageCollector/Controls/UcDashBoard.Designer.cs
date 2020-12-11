using DevExpress.XtraLayout.Utils;

namespace B2CPackageCollect.Controls
{
    partial class UcDashBoard
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
            this.chartLines = new DevExpress.XtraCharts.ChartControl();
            this.chartOrders = new DevExpress.XtraCharts.ChartControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciOrder = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciLines = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.btnRefresh);
            this.lcMain.Controls.Add(this.chartLines);
            this.lcMain.Controls.Add(this.chartOrders);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(636, 241, 650, 400);
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(702, 520);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // chartLines
            // 
            this.chartLines.Legend.Name = "Default Legend";
            this.chartLines.Location = new System.Drawing.Point(20, 257);
            this.chartLines.Name = "chartLines";
            this.chartLines.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartLines.Size = new System.Drawing.Size(662, 203);
            this.chartLines.TabIndex = 5;
            // 
            // chartOrders
            // 
            this.chartOrders.Legend.Name = "Default Legend";
            this.chartOrders.Location = new System.Drawing.Point(20, 10);
            this.chartOrders.Name = "chartOrders";
            this.chartOrders.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartOrders.Size = new System.Drawing.Size(662, 227);
            this.chartOrders.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciOrder,
            this.lciLines,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(702, 520);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciOrder
            // 
            this.lciOrder.Control = this.chartOrders;
            this.lciOrder.Location = new System.Drawing.Point(0, 0);
            this.lciOrder.Name = "lciOrder";
            this.lciOrder.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 0, 10);
            this.lciOrder.Size = new System.Drawing.Size(682, 237);
            this.lciOrder.TextSize = new System.Drawing.Size(0, 0);
            this.lciOrder.TextVisible = false;
            // 
            // lciLines
            // 
            this.lciLines.Control = this.chartLines;
            this.lciLines.Location = new System.Drawing.Point(0, 237);
            this.lciLines.Name = "lciLines";
            this.lciLines.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.lciLines.Size = new System.Drawing.Size(682, 223);
            this.lciLines.TextSize = new System.Drawing.Size(0, 0);
            this.lciLines.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 460);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(632, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = global::B2CPackageCollect.Properties.Resources.Refresh_32x32;
            this.btnRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRefresh.Location = new System.Drawing.Point(644, 472);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(46, 36);
            this.btnRefresh.StyleController = this.lcMain;
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "simpleButton1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnRefresh;
            this.layoutControlItem1.Location = new System.Drawing.Point(632, 460);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(50, 40);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // UcDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcMain);
            this.Name = "UcDashBoard";
            this.Size = new System.Drawing.Size(702, 520);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraCharts.ChartControl chartOrders;
        private DevExpress.XtraLayout.LayoutControlItem lciOrder;
        private DevExpress.XtraCharts.ChartControl chartLines;
        private DevExpress.XtraLayout.LayoutControlItem lciLines;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
