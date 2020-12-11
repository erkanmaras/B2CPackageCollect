namespace B2CPackageCollect
{
    partial class UcNotCollectReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcNotCollectReport));
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnMenu = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.grdControl = new DevExpress.XtraGrid.GridControl();
            this.grdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcgRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciRefresh = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMenu = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.btnMenu);
            this.lcMain.Controls.Add(this.btnRefresh);
            this.lcMain.Controls.Add(this.grdControl);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsFocus.AllowFocusGroups = false;
            this.lcMain.OptionsFocus.AllowFocusTabbedGroups = false;
            this.lcMain.OptionsView.UseDefaultDragAndDropRendering = false;
            this.lcMain.Root = this.lcgRoot;
            this.lcMain.Size = new System.Drawing.Size(523, 340);
            this.lcMain.TabIndex = 7;
            this.lcMain.Text = "lcMain";
            // 
            // btnMenu
            // 
            this.btnMenu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.ImageOptions.Image")));
            this.btnMenu.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMenu.Location = new System.Drawing.Point(480, 299);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(38, 36);
            this.btnMenu.StyleController = this.lcMain;
            this.btnMenu.TabIndex = 9;
            this.btnMenu.Text = "btnMenu";
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = global::B2CPackageCollect.Properties.Resources.Refresh_32x32;
            this.btnRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRefresh.Location = new System.Drawing.Point(432, 299);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(38, 36);
            this.btnRefresh.StyleController = this.lcMain;
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "simpleButton1";
            // 
            // grdControl
            // 
            this.grdControl.Location = new System.Drawing.Point(0, 0);
            this.grdControl.MainView = this.grdView;
            this.grdControl.Name = "grdControl";
            this.grdControl.Size = new System.Drawing.Size(523, 289);
            this.grdControl.TabIndex = 4;
            this.grdControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView});
            // 
            // grdView
            // 
            this.grdView.GridControl = this.grdControl;
            this.grdView.Name = "grdView";
            this.grdView.OptionsBehavior.Editable = false;
            this.grdView.OptionsFind.AlwaysVisible = true;
            this.grdView.OptionsFind.FindNullPrompt = "Ara ...";
            this.grdView.OptionsFind.ShowClearButton = false;
            this.grdView.OptionsFind.ShowCloseButton = false;
            this.grdView.OptionsSelection.MultiSelect = true;
            this.grdView.OptionsView.ShowFooter = true;
            this.grdView.OptionsView.ShowGroupPanel = false;
            // 
            // lcgRoot
            // 
            this.lcgRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgRoot.GroupBordersVisible = false;
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciGrid,
            this.emptySpaceItem1,
            this.lciRefresh,
            this.lciMenu});
            this.lcgRoot.Name = "lcgRoot";
            this.lcgRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgRoot.Size = new System.Drawing.Size(523, 340);
            this.lcgRoot.TextVisible = false;
            // 
            // lciGrid
            // 
            this.lciGrid.Control = this.grdControl;
            this.lciGrid.Location = new System.Drawing.Point(0, 0);
            this.lciGrid.Name = "lciGrid";
            this.lciGrid.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 5);
            this.lciGrid.Size = new System.Drawing.Size(523, 294);
            this.lciGrid.TextSize = new System.Drawing.Size(0, 0);
            this.lciGrid.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 294);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(427, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciRefresh
            // 
            this.lciRefresh.Control = this.btnRefresh;
            this.lciRefresh.Location = new System.Drawing.Point(427, 294);
            this.lciRefresh.Name = "lciRefresh";
            this.lciRefresh.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciRefresh.Size = new System.Drawing.Size(48, 46);
            this.lciRefresh.TextSize = new System.Drawing.Size(0, 0);
            this.lciRefresh.TextVisible = false;
            // 
            // lciMenu
            // 
            this.lciMenu.Control = this.btnMenu;
            this.lciMenu.Location = new System.Drawing.Point(475, 294);
            this.lciMenu.Name = "lciMenu";
            this.lciMenu.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciMenu.Size = new System.Drawing.Size(48, 46);
            this.lciMenu.TextSize = new System.Drawing.Size(0, 0);
            this.lciMenu.TextVisible = false;
            // 
            // UcNotCollectReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcMain);
            this.Name = "UcNotCollectReport";
            this.Size = new System.Drawing.Size(523, 340);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grdControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView;
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgRoot;
        private DevExpress.XtraLayout.LayoutControlItem lciGrid;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem lciRefresh;
        private DevExpress.XtraEditors.SimpleButton btnMenu;
        private DevExpress.XtraLayout.LayoutControlItem lciMenu;
    }
}