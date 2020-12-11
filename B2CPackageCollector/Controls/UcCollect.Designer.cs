namespace B2CPackageCollect
{
    partial class UcCollect
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
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.lblCompleted = new DevExpress.XtraEditors.LabelControl();
            this.lblPrinted = new DevExpress.XtraEditors.LabelControl();
            this.lblProductDescription = new DevExpress.XtraEditors.LabelControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.deInvoiceDate = new DevExpress.XtraEditors.DateEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerCode = new DevExpress.XtraEditors.TextEdit();
            this.grdControlInvoiceLines = new DevExpress.XtraGrid.GridControl();
            this.grdViewInvoiceLines = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btxtBarcode = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciPrint = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciBarcode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCustomerCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCustomerName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciInvoiceDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciInvoiceNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCompleted = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrinted = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPreview = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTotalQty = new DevExpress.XtraEditors.LabelControl();
            this.lciTotalQty = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deInvoiceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInvoiceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControlInvoiceLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewInvoiceLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btxtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciInvoiceDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciInvoiceNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCompleted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrinted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTotalQty)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.lblTotalQty);
            this.lcMain.Controls.Add(this.btnPreview);
            this.lcMain.Controls.Add(this.lblCompleted);
            this.lcMain.Controls.Add(this.lblPrinted);
            this.lcMain.Controls.Add(this.lblProductDescription);
            this.lcMain.Controls.Add(this.btnPrint);
            this.lcMain.Controls.Add(this.deInvoiceDate);
            this.lcMain.Controls.Add(this.txtCustomerName);
            this.lcMain.Controls.Add(this.txtInvoiceNumber);
            this.lcMain.Controls.Add(this.txtCustomerCode);
            this.lcMain.Controls.Add(this.grdControlInvoiceLines);
            this.lcMain.Controls.Add(this.btxtBarcode);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(480, 80, 650, 400);
            this.lcMain.OptionsFocus.AllowFocusGroups = false;
            this.lcMain.OptionsFocus.AllowFocusReadonlyEditors = false;
            this.lcMain.OptionsFocus.AllowFocusTabbedGroups = false;
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(687, 432);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "lcMain";
            // 
            // btnPreview
            // 
            this.btnPreview.ImageOptions.Image = global::B2CPackageCollect.Properties.Resources.PrintPreview_32x32;
            this.btnPreview.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPreview.Location = new System.Drawing.Point(558, 381);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(52, 36);
            this.btnPreview.StyleController = this.lcMain;
            this.btnPreview.TabIndex = 19;
            this.btnPreview.Text = "simpleButton1";
            // 
            // lblCompleted
            // 
            this.lblCompleted.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCompleted.Location = new System.Drawing.Point(77, 392);
            this.lblCompleted.MinimumSize = new System.Drawing.Size(80, 0);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(80, 13);
            this.lblCompleted.StyleController = this.lcMain;
            this.lblCompleted.TabIndex = 18;
            // 
            // lblPrinted
            // 
            this.lblPrinted.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPrinted.Location = new System.Drawing.Point(214, 392);
            this.lblPrinted.MinimumSize = new System.Drawing.Size(80, 0);
            this.lblPrinted.Name = "lblPrinted";
            this.lblPrinted.Size = new System.Drawing.Size(80, 13);
            this.lblPrinted.StyleController = this.lcMain;
            this.lblPrinted.TabIndex = 17;
            this.lblPrinted.Text = " ";
            // 
            // lblProductDescription
            // 
            this.lblProductDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblProductDescription.Location = new System.Drawing.Point(325, 18);
            this.lblProductDescription.Name = "lblProductDescription";
            this.lblProductDescription.Size = new System.Drawing.Size(347, 13);
            this.lblProductDescription.StyleController = this.lcMain;
            this.lblProductDescription.TabIndex = 16;
            this.lblProductDescription.Text = " ";
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.Image = global::B2CPackageCollect.Properties.Resources.Print_32x321;
            this.btnPrint.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPrint.Location = new System.Drawing.Point(620, 381);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(52, 36);
            this.btnPrint.StyleController = this.lcMain;
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "Yazdır";
            // 
            // deInvoiceDate
            // 
            this.deInvoiceDate.EditValue = null;
            this.deInvoiceDate.Location = new System.Drawing.Point(419, 75);
            this.deInvoiceDate.Name = "deInvoiceDate";
            this.deInvoiceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deInvoiceDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deInvoiceDate.Size = new System.Drawing.Size(250, 20);
            this.deInvoiceDate.StyleController = this.lcMain;
            this.deInvoiceDate.TabIndex = 14;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(106, 75);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(212, 20);
            this.txtCustomerName.StyleController = this.lcMain;
            this.txtCustomerName.TabIndex = 13;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(419, 45);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(250, 20);
            this.txtInvoiceNumber.StyleController = this.lcMain;
            this.txtInvoiceNumber.TabIndex = 12;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(106, 45);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(212, 20);
            this.txtCustomerCode.StyleController = this.lcMain;
            this.txtCustomerCode.TabIndex = 11;
            // 
            // grdControlInvoiceLines
            // 
            this.grdControlInvoiceLines.Location = new System.Drawing.Point(15, 105);
            this.grdControlInvoiceLines.MainView = this.grdViewInvoiceLines;
            this.grdControlInvoiceLines.Name = "grdControlInvoiceLines";
            this.grdControlInvoiceLines.Size = new System.Drawing.Size(657, 266);
            this.grdControlInvoiceLines.TabIndex = 10;
            this.grdControlInvoiceLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewInvoiceLines});
            // 
            // grdViewInvoiceLines
            // 
            this.grdViewInvoiceLines.GridControl = this.grdControlInvoiceLines;
            this.grdViewInvoiceLines.Name = "grdViewInvoiceLines";
            this.grdViewInvoiceLines.OptionsBehavior.Editable = false;
            this.grdViewInvoiceLines.OptionsFilter.AllowFilterEditor = false;
            this.grdViewInvoiceLines.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.grdViewInvoiceLines.OptionsView.ShowGroupPanel = false;
            // 
            // btxtBarcode
            // 
            this.btxtBarcode.Location = new System.Drawing.Point(106, 15);
            this.btxtBarcode.Name = "btxtBarcode";
            this.btxtBarcode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)});
            this.btxtBarcode.Size = new System.Drawing.Size(212, 20);
            this.btxtBarcode.StyleController = this.lcMain;
            this.btxtBarcode.TabIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciPrint,
            this.emptySpaceItem2,
            this.lciBarcode,
            this.lciCustomerCode,
            this.lciCustomerName,
            this.lciInvoiceDate,
            this.lciInvoiceNumber,
            this.layoutControlItem1,
            this.emptySpaceItem3,
            this.layoutControlItem3,
            this.lciCompleted,
            this.lciPrinted,
            this.lciPreview,
            this.lciTotalQty});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(687, 432);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciPrint
            // 
            this.lciPrint.Control = this.btnPrint;
            this.lciPrint.Location = new System.Drawing.Point(605, 366);
            this.lciPrint.Name = "lciPrint";
            this.lciPrint.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciPrint.Size = new System.Drawing.Size(62, 46);
            this.lciPrint.TextSize = new System.Drawing.Size(0, 0);
            this.lciPrint.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(411, 366);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(132, 46);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciBarcode
            // 
            this.lciBarcode.Control = this.btxtBarcode;
            this.lciBarcode.Location = new System.Drawing.Point(0, 0);
            this.lciBarcode.Name = "lciBarcode";
            this.lciBarcode.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lciBarcode.OptionsTableLayoutItem.ColumnSpan = 4;
            this.lciBarcode.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciBarcode.Size = new System.Drawing.Size(313, 30);
            this.lciBarcode.Text = "Barkod";
            this.lciBarcode.TextSize = new System.Drawing.Size(88, 13);
            // 
            // lciCustomerCode
            // 
            this.lciCustomerCode.Control = this.txtCustomerCode;
            this.lciCustomerCode.Location = new System.Drawing.Point(0, 30);
            this.lciCustomerCode.Name = "lciCustomerCode";
            this.lciCustomerCode.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciCustomerCode.Size = new System.Drawing.Size(313, 30);
            this.lciCustomerCode.Text = "Müşteri Kodu";
            this.lciCustomerCode.TextSize = new System.Drawing.Size(88, 13);
            // 
            // lciCustomerName
            // 
            this.lciCustomerName.Control = this.txtCustomerName;
            this.lciCustomerName.Location = new System.Drawing.Point(0, 60);
            this.lciCustomerName.Name = "lciCustomerName";
            this.lciCustomerName.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciCustomerName.Size = new System.Drawing.Size(313, 30);
            this.lciCustomerName.Text = "Müşteri Adı Soyadı";
            this.lciCustomerName.TextSize = new System.Drawing.Size(88, 13);
            // 
            // lciInvoiceDate
            // 
            this.lciInvoiceDate.Control = this.deInvoiceDate;
            this.lciInvoiceDate.Location = new System.Drawing.Point(313, 60);
            this.lciInvoiceDate.Name = "lciInvoiceDate";
            this.lciInvoiceDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciInvoiceDate.Size = new System.Drawing.Size(351, 30);
            this.lciInvoiceDate.Text = "Fatura Tarihi";
            this.lciInvoiceDate.TextSize = new System.Drawing.Size(88, 13);
            // 
            // lciInvoiceNumber
            // 
            this.lciInvoiceNumber.Control = this.txtInvoiceNumber;
            this.lciInvoiceNumber.Location = new System.Drawing.Point(313, 30);
            this.lciInvoiceNumber.Name = "lciInvoiceNumber";
            this.lciInvoiceNumber.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciInvoiceNumber.Size = new System.Drawing.Size(351, 30);
            this.lciInvoiceNumber.Text = "Fatura Numarası";
            this.lciInvoiceNumber.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdControlInvoiceLines;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(110, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(667, 276);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(664, 0);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(1, 1);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(3, 90);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lblProductDescription;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem3.Location = new System.Drawing.Point(313, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(351, 30);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            this.layoutControlItem3.TrimClientAreaToControl = false;
            // 
            // lciCompleted
            // 
            this.lciCompleted.Control = this.lblCompleted;
            this.lciCompleted.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lciCompleted.Location = new System.Drawing.Point(0, 366);
            this.lciCompleted.Name = "lciCompleted";
            this.lciCompleted.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 2, 2, 2);
            this.lciCompleted.Size = new System.Drawing.Size(149, 46);
            this.lciCompleted.Text = "Tamamladı:";
            this.lciCompleted.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciCompleted.TextSize = new System.Drawing.Size(54, 13);
            this.lciCompleted.TextToControlDistance = 5;
            this.lciCompleted.TrimClientAreaToControl = false;
            // 
            // lciPrinted
            // 
            this.lciPrinted.Control = this.lblPrinted;
            this.lciPrinted.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lciPrinted.Location = new System.Drawing.Point(149, 366);
            this.lciPrinted.Name = "lciPrinted";
            this.lciPrinted.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciPrinted.Size = new System.Drawing.Size(140, 46);
            this.lciPrinted.Text = "Yazdırıldı:";
            this.lciPrinted.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciPrinted.TextSize = new System.Drawing.Size(45, 13);
            this.lciPrinted.TextToControlDistance = 5;
            this.lciPrinted.TrimClientAreaToControl = false;
            // 
            // lciPreview
            // 
            this.lciPreview.Control = this.btnPreview;
            this.lciPreview.Location = new System.Drawing.Point(543, 366);
            this.lciPreview.Name = "lciPreview";
            this.lciPreview.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciPreview.Size = new System.Drawing.Size(62, 46);
            this.lciPreview.TextSize = new System.Drawing.Size(0, 0);
            this.lciPreview.TextVisible = false;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotalQty.Location = new System.Drawing.Point(336, 392);
            this.lblTotalQty.MinimumSize = new System.Drawing.Size(80, 0);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(80, 13);
            this.lblTotalQty.StyleController = this.lcMain;
            this.lblTotalQty.TabIndex = 20;
            this.lblTotalQty.Text = " ";
            // 
            // lciTotalQty
            // 
            this.lciTotalQty.Control = this.lblTotalQty;
            this.lciTotalQty.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lciTotalQty.Location = new System.Drawing.Point(289, 366);
            this.lciTotalQty.Name = "lciTotalQty";
            this.lciTotalQty.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciTotalQty.Size = new System.Drawing.Size(122, 46);
            this.lciTotalQty.Text = "Adet:";
            this.lciTotalQty.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciTotalQty.TextSize = new System.Drawing.Size(27, 13);
            this.lciTotalQty.TextToControlDistance = 5;
            this.lciTotalQty.TrimClientAreaToControl = false;
            // 
            // UcCollect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcMain);
            this.Name = "UcCollect";
            this.Size = new System.Drawing.Size(687, 432);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deInvoiceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInvoiceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControlInvoiceLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewInvoiceLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btxtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciInvoiceDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciInvoiceNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCompleted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrinted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTotalQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit deInvoiceDate;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.TextEdit txtInvoiceNumber;
        private DevExpress.XtraEditors.TextEdit txtCustomerCode;
        private DevExpress.XtraGrid.GridControl grdControlInvoiceLines;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewInvoiceLines;
        private DevExpress.XtraEditors.ButtonEdit btxtBarcode;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem lciPrint;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem lciBarcode;
        private DevExpress.XtraLayout.LayoutControlItem lciCustomerCode;
        private DevExpress.XtraLayout.LayoutControlItem lciCustomerName;
        private DevExpress.XtraLayout.LayoutControlItem lciInvoiceDate;
        private DevExpress.XtraLayout.LayoutControlItem lciInvoiceNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.LabelControl lblProductDescription;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl lblCompleted;
        private DevExpress.XtraEditors.LabelControl lblPrinted;
        private DevExpress.XtraLayout.LayoutControlItem lciCompleted;
        private DevExpress.XtraLayout.LayoutControlItem lciPrinted;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraLayout.LayoutControlItem lciPreview;
        private DevExpress.XtraEditors.LabelControl lblTotalQty;
        private DevExpress.XtraLayout.LayoutControlItem lciTotalQty;
    }
}