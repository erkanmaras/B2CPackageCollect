namespace B2CPackageCollect
{
    partial class UcSettings
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
            this.components = new System.ComponentModel.Container();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.deEndDate = new DevExpress.XtraEditors.DateEdit();
            this.deStartDate = new DevExpress.XtraEditors.DateEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cboPrinterName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridLookUpWareHouse = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdColValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdColDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciWareHouse = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciStartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrinterName = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.adornerUIManager = new DevExpress.Utils.VisualEffects.AdornerUIManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrinterName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpWareHouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWareHouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrinterName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornerUIManager)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.btnOk);
            this.lcMain.Controls.Add(this.deEndDate);
            this.lcMain.Controls.Add(this.deStartDate);
            this.lcMain.Controls.Add(this.simpleButton1);
            this.lcMain.Controls.Add(this.cboPrinterName);
            this.lcMain.Controls.Add(this.gridLookUpWareHouse);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1015, 80, 650, 400);
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(800, 600);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "lcMain";
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = global::B2CPackageCollect.Properties.Resources.Apply_32x32;
            this.btnOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOk.Location = new System.Drawing.Point(532, 135);
            this.btnOk.MaximumSize = new System.Drawing.Size(80, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(38, 36);
            this.btnOk.StyleController = this.lcMain;
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Tamam";
            // 
            // deEndDate
            // 
            this.deEndDate.EditValue = null;
            this.deEndDate.Location = new System.Drawing.Point(91, 75);
            this.deEndDate.Name = "deEndDate";
            this.deEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.deEndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.deEndDate.Size = new System.Drawing.Size(479, 20);
            this.deEndDate.StyleController = this.lcMain;
            this.deEndDate.TabIndex = 12;
            // 
            // deStartDate
            // 
            this.deStartDate.EditValue = null;
            this.deStartDate.Location = new System.Drawing.Point(91, 45);
            this.deStartDate.Name = "deStartDate";
            this.deStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.deStartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.deStartDate.Size = new System.Drawing.Size(479, 20);
            this.deStartDate.StyleController = this.lcMain;
            this.deStartDate.TabIndex = 11;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(305, 177);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(33, 22);
            this.simpleButton1.StyleController = this.lcMain;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "4";
            // 
            // cboPrinterName
            // 
            this.cboPrinterName.Location = new System.Drawing.Point(91, 105);
            this.cboPrinterName.Name = "cboPrinterName";
            this.cboPrinterName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPrinterName.Size = new System.Drawing.Size(479, 20);
            this.cboPrinterName.StyleController = this.lcMain;
            this.cboPrinterName.TabIndex = 14;
            // 
            // gridLookUpWareHouse
            // 
            this.gridLookUpWareHouse.Location = new System.Drawing.Point(91, 15);
            this.gridLookUpWareHouse.MinimumSize = new System.Drawing.Size(200, 0);
            this.gridLookUpWareHouse.Name = "gridLookUpWareHouse";
            this.gridLookUpWareHouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpWareHouse.Properties.DisplayMember = "sAciklama";
            this.gridLookUpWareHouse.Properties.ImmediatePopup = true;
            this.gridLookUpWareHouse.Properties.NullText = "";
            this.gridLookUpWareHouse.Properties.PopupView = this.gridLookUpEdit1View;
            this.gridLookUpWareHouse.Properties.ShowFooter = false;
            this.gridLookUpWareHouse.Properties.ValueMember = "sDepo";
            this.gridLookUpWareHouse.Size = new System.Drawing.Size(479, 20);
            this.gridLookUpWareHouse.StyleController = this.lcMain;
            this.gridLookUpWareHouse.TabIndex = 10;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdColValue,
            this.grdColDesc});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsBehavior.Editable = false;
            this.gridLookUpEdit1View.OptionsCustomization.AllowFilter = false;
            this.gridLookUpEdit1View.OptionsCustomization.AllowGroup = false;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // grdColValue
            // 
            this.grdColValue.Caption = "Depo Kodu";
            this.grdColValue.FieldName = "sDepo";
            this.grdColValue.Name = "grdColValue";
            this.grdColValue.Visible = true;
            this.grdColValue.VisibleIndex = 0;
            // 
            // grdColDesc
            // 
            this.grdColDesc.Caption = "Depo Adı";
            this.grdColDesc.FieldName = "sAciklama";
            this.grdColDesc.Name = "grdColDesc";
            this.grdColDesc.Visible = true;
            this.grdColDesc.VisibleIndex = 1;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton1;
            this.layoutControlItem3.Location = new System.Drawing.Point(293, 165);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem3.Size = new System.Drawing.Size(37, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciWareHouse,
            this.lciStartDate,
            this.lciEndDate,
            this.emptySpaceItem3,
            this.layoutControlItem1,
            this.lciPrinterName,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 600);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciWareHouse
            // 
            this.lciWareHouse.Control = this.gridLookUpWareHouse;
            this.lciWareHouse.Location = new System.Drawing.Point(0, 0);
            this.lciWareHouse.Name = "lciWareHouse";
            this.lciWareHouse.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lciWareHouse.OptionsTableLayoutItem.ColumnSpan = 4;
            this.lciWareHouse.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciWareHouse.Size = new System.Drawing.Size(565, 30);
            this.lciWareHouse.Text = "Depo Kodu";
            this.lciWareHouse.TextSize = new System.Drawing.Size(73, 13);
            // 
            // lciStartDate
            // 
            this.lciStartDate.Control = this.deStartDate;
            this.lciStartDate.Location = new System.Drawing.Point(0, 30);
            this.lciStartDate.Name = "lciStartDate";
            this.lciStartDate.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lciStartDate.OptionsTableLayoutItem.ColumnSpan = 4;
            this.lciStartDate.OptionsTableLayoutItem.RowIndex = 1;
            this.lciStartDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciStartDate.Size = new System.Drawing.Size(565, 30);
            this.lciStartDate.Text = "Başlangıç Tarihi";
            this.lciStartDate.TextSize = new System.Drawing.Size(73, 13);
            // 
            // lciEndDate
            // 
            this.lciEndDate.Control = this.deEndDate;
            this.lciEndDate.Location = new System.Drawing.Point(0, 60);
            this.lciEndDate.Name = "lciEndDate";
            this.lciEndDate.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lciEndDate.OptionsTableLayoutItem.ColumnSpan = 4;
            this.lciEndDate.OptionsTableLayoutItem.RowIndex = 2;
            this.lciEndDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciEndDate.Size = new System.Drawing.Size(565, 30);
            this.lciEndDate.Text = "Bitiş Tarihi";
            this.lciEndDate.TextSize = new System.Drawing.Size(73, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(517, 46);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnOk;
            this.layoutControlItem1.Location = new System.Drawing.Point(517, 120);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(48, 46);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lciPrinterName
            // 
            this.lciPrinterName.Control = this.cboPrinterName;
            this.lciPrinterName.Location = new System.Drawing.Point(0, 90);
            this.lciPrinterName.Name = "lciPrinterName";
            this.lciPrinterName.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciPrinterName.Size = new System.Drawing.Size(565, 30);
            this.lciPrinterName.Text = "Yazıcı Adı";
            this.lciPrinterName.TextSize = new System.Drawing.Size(73, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 166);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(565, 414);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(565, 0);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(215, 580);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // adornerUIManager
            // 
            this.adornerUIManager.Owner = this;
            // 
            // UcSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcMain);
            this.Name = "UcSettings";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrinterName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpWareHouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWareHouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrinterName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornerUIManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit deEndDate;
        private DevExpress.XtraEditors.DateEdit deStartDate;
        private DevExpress.XtraLayout.LayoutControlItem lciWareHouse;
        private DevExpress.XtraLayout.LayoutControlItem lciStartDate;
        private DevExpress.XtraLayout.LayoutControlItem lciEndDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem lciPrinterName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.Utils.VisualEffects.AdornerUIManager adornerUIManager;
        private DevExpress.XtraEditors.ComboBoxEdit cboPrinterName;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpWareHouse;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn grdColValue;
        private DevExpress.XtraGrid.Columns.GridColumn grdColDesc;
    }
}