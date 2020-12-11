namespace B2CPackageCollect
{
    partial class UcLogin
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcLogin));
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.txtDatabaseName = new DevExpress.XtraEditors.TextEdit();
            this.txtServerName = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciServerName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDatabaseName = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.adornerUIManager = new DevExpress.Utils.VisualEffects.AdornerUIManager(this.components);
            this.ServerNameHint = new DevExpress.Utils.VisualEffects.ValidationHint();
            this.validationHint2 = new DevExpress.Utils.VisualEffects.ValidationHint();
            this.validationHint3 = new DevExpress.Utils.VisualEffects.ValidationHint();
            this.validationHint4 = new DevExpress.Utils.VisualEffects.ValidationHint();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciControlRoot = new DevExpress.XtraLayout.LayoutControlItem();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciServerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDatabaseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornerUIManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciControlRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(74, 95);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(231, 20);
            this.txtPassword.StyleController = this.lcMain;
            this.txtPassword.TabIndex = 4;
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.txtDatabaseName);
            this.lcMain.Controls.Add(this.txtServerName);
            this.lcMain.Controls.Add(this.btnCancel);
            this.lcMain.Controls.Add(this.btnLogin);
            this.lcMain.Controls.Add(this.txtUserName);
            this.lcMain.Controls.Add(this.txtPassword);
            this.lcMain.Location = new System.Drawing.Point(240, 215);
            this.lcMain.MinimumSize = new System.Drawing.Size(300, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1015, 80, 650, 400);
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(320, 170);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "lcMain";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(74, 35);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(231, 20);
            this.txtDatabaseName.StyleController = this.lcMain;
            this.txtDatabaseName.TabIndex = 10;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(74, 5);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(231, 20);
            this.txtServerName.StyleController = this.lcMain;
            this.txtServerName.TabIndex = 9;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(74, 65);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(231, 20);
            this.txtUserName.StyleController = this.lcMain;
            this.txtUserName.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciUserName,
            this.lciPassword,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.lciServerName,
            this.lciDatabaseName,
            this.emptySpaceItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(320, 170);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciUserName
            // 
            this.lciUserName.Control = this.txtUserName;
            this.lciUserName.Location = new System.Drawing.Point(0, 60);
            this.lciUserName.Name = "lciUserName";
            this.lciUserName.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lciUserName.OptionsTableLayoutItem.ColumnSpan = 4;
            this.lciUserName.OptionsTableLayoutItem.RowIndex = 3;
            this.lciUserName.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciUserName.Size = new System.Drawing.Size(310, 30);
            this.lciUserName.Text = "Kullanıcı Adı";
            this.lciUserName.TextSize = new System.Drawing.Size(66, 13);
            // 
            // lciPassword
            // 
            this.lciPassword.Control = this.txtPassword;
            this.lciPassword.Location = new System.Drawing.Point(0, 90);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lciPassword.OptionsTableLayoutItem.ColumnSpan = 4;
            this.lciPassword.OptionsTableLayoutItem.RowIndex = 4;
            this.lciPassword.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciPassword.Size = new System.Drawing.Size(310, 30);
            this.lciPassword.Text = "Şifre";
            this.lciPassword.TextSize = new System.Drawing.Size(66, 13);
            // 
            // lciServerName
            // 
            this.lciServerName.Control = this.txtServerName;
            this.lciServerName.Location = new System.Drawing.Point(0, 0);
            this.lciServerName.Name = "lciServerName";
            this.lciServerName.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lciServerName.OptionsTableLayoutItem.ColumnSpan = 4;
            this.lciServerName.OptionsTableLayoutItem.RowIndex = 1;
            this.lciServerName.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciServerName.Size = new System.Drawing.Size(310, 30);
            this.lciServerName.Text = "Sunucu Adı";
            this.lciServerName.TextSize = new System.Drawing.Size(66, 13);
            // 
            // lciDatabaseName
            // 
            this.lciDatabaseName.Control = this.txtDatabaseName;
            this.lciDatabaseName.Location = new System.Drawing.Point(0, 30);
            this.lciDatabaseName.Name = "lciDatabaseName";
            this.lciDatabaseName.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lciDatabaseName.OptionsTableLayoutItem.ColumnSpan = 4;
            this.lciDatabaseName.OptionsTableLayoutItem.RowIndex = 2;
            this.lciDatabaseName.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciDatabaseName.Size = new System.Drawing.Size(310, 30);
            this.lciDatabaseName.Text = "Veritabanı Adı";
            this.lciDatabaseName.TextSize = new System.Drawing.Size(66, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(206, 50);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(310, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(10, 170);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // adornerUIManager
            // 
            this.adornerUIManager.Elements.Add(this.ServerNameHint);
            this.adornerUIManager.Elements.Add(this.validationHint2);
            this.adornerUIManager.Elements.Add(this.validationHint3);
            this.adornerUIManager.Elements.Add(this.validationHint4);
            this.adornerUIManager.Owner = this;
            // 
            // ServerNameHint
            // 
            this.ServerNameHint.Properties.IndeterminateState.ShowBorder = DevExpress.Utils.DefaultBoolean.False;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pictureEdit1);
            this.layoutControl1.Controls.Add(this.lcMain);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(47, 121, 650, 400);
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup2;
            this.layoutControl1.Size = new System.Drawing.Size(800, 600);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "\"";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciControlRoot,
            this.layoutControlItem1});
            this.layoutControlGroup2.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.layoutControlGroup2.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 50D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.AutoSize;
            columnDefinition2.Width = 320D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition3.Width = 50D;
            this.layoutControlGroup2.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2,
            columnDefinition3});
            rowDefinition1.Height = 50D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition2.Height = 170D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.AutoSize;
            rowDefinition3.Height = 50D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutControlGroup2.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3});
            this.layoutControlGroup2.Size = new System.Drawing.Size(800, 600);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // lciControlRoot
            // 
            this.lciControlRoot.Control = this.lcMain;
            this.lciControlRoot.Location = new System.Drawing.Point(230, 205);
            this.lciControlRoot.Name = "lciControlRoot";
            this.lciControlRoot.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lciControlRoot.OptionsTableLayoutItem.RowIndex = 1;
            this.lciControlRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciControlRoot.Size = new System.Drawing.Size(320, 170);
            this.lciControlRoot.TextSize = new System.Drawing.Size(0, 0);
            this.lciControlRoot.TextVisible = false;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::B2CPackageCollect.Properties.Resources.logo;
            this.pictureEdit1.Location = new System.Drawing.Point(12, 387);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit1.Size = new System.Drawing.Size(226, 201);
            this.pictureEdit1.StyleController = this.layoutControl1;
            this.pictureEdit1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = global::B2CPackageCollect.Properties.Resources.Cancel_32x32;
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCancel.Location = new System.Drawing.Point(265, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(38, 36);
            this.btnCancel.StyleController = this.lcMain;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "İptal";
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Appearance.Image")));
            this.btnLogin.Appearance.Options.UseImage = true;
            this.btnLogin.ImageOptions.Image = global::B2CPackageCollect.Properties.Resources.Apply_32x32;
            this.btnLogin.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLogin.Location = new System.Drawing.Point(213, 127);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(38, 36);
            this.btnLogin.StyleController = this.lcMain;
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Giriş";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCancel;
            this.layoutControlItem5.Location = new System.Drawing.Point(258, 120);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 4;
            this.layoutControlItem5.OptionsTableLayoutItem.RowIndex = 5;
            this.layoutControlItem5.Size = new System.Drawing.Size(52, 50);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnLogin;
            this.layoutControlItem4.Location = new System.Drawing.Point(206, 120);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 3;
            this.layoutControlItem4.OptionsTableLayoutItem.RowIndex = 5;
            this.layoutControlItem4.Size = new System.Drawing.Size(52, 50);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pictureEdit1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 375);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem1.Size = new System.Drawing.Size(230, 205);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ucLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "UcLogin";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciServerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDatabaseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornerUIManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciControlRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lciUserName;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtServerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit txtDatabaseName;
        private DevExpress.XtraLayout.LayoutControlItem lciServerName;
        private DevExpress.XtraLayout.LayoutControlItem lciDatabaseName;
        private DevExpress.Utils.VisualEffects.AdornerUIManager adornerUIManager;
        private DevExpress.Utils.VisualEffects.ValidationHint ServerNameHint;
        private DevExpress.Utils.VisualEffects.ValidationHint validationHint2;
        private DevExpress.Utils.VisualEffects.ValidationHint validationHint3;
        private DevExpress.Utils.VisualEffects.ValidationHint validationHint4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem lciControlRoot;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}