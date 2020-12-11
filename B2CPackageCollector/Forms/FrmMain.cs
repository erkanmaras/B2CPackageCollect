using System;
using System.ComponentModel;
using System.Windows.Forms;
using B2CPackageCollect.Controls;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;

namespace B2CPackageCollect
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();
            InitializeControls();
            AppearanceForm();
            AddControlEventHandlers();
        }

        private DocumentManager _documentManager;
        private WindowsUIView _windowsUiView;
        private TabbedGroup _tabbedContainer;
        private Page _pageContainer;
        private Document _documentLogin;
        private Document _documentCollect;
        private Document _documentReport;
        private Document _documentSettings;
        private Document _documentDashboard;
        public DocumentManager Manager
        {
            get => _documentManager;
            set => _documentManager = value;
        }

        public WindowsUIView WindowsUiView
        {
            get => _windowsUiView;
            set => _windowsUiView = value;
        }

        public TabbedGroup TabbedContainer
        {
            get => _tabbedContainer;
            set => _tabbedContainer = value;
        }

        private void InitializeControls()
        {
            var containerMinimize = new WindowsUIButtonImageOptions();
            var containerExit = new WindowsUIButtonImageOptions();
            containerMinimize.Image = Properties.Resources.GrayScale_Minimize_16x16;
            containerExit.Image = Properties.Resources.GrayScale_Cancel_32x32;
            var containerButtons = new DevExpress.XtraEditors.ButtonPanel.IBaseButton[]
            {
                new WindowsUIButton(StringResource.Minimize, false, containerMinimize, ButtonStyle.PushButton, "", -1, true, null, true, false, true, "MinimizeApplication", -1, false),
                new WindowsUIButton(StringResource.Exit, false, containerExit, ButtonStyle.PushButton, "", -1, true, null, true, false, true, "ExitApplication", -1, false)
            };

            _documentManager = new DocumentManager();
            _windowsUiView = new WindowsUIView();
            _pageContainer = new Page();
            _documentLogin = new Document();
            _tabbedContainer = new TabbedGroup();
            _documentSettings = new Document();
            _documentCollect = new Document();
            _documentReport = new Document();
            _documentDashboard = new Document();
            ((ISupportInitialize)_documentManager).BeginInit();
            ((ISupportInitialize)_windowsUiView).BeginInit();
            ((ISupportInitialize)_pageContainer).BeginInit();
            ((ISupportInitialize)_documentLogin).BeginInit();
            ((ISupportInitialize)_tabbedContainer).BeginInit();
            ((ISupportInitialize)_documentSettings).BeginInit();
            ((ISupportInitialize)_documentCollect).BeginInit();
            ((ISupportInitialize)_documentReport).BeginInit();
            ((ISupportInitialize)_documentDashboard).BeginInit();
            SuspendLayout();
            // 
            // documentManager
            // 
            _documentManager.ContainerControl = this;
            _documentManager.View = _windowsUiView;
            _documentManager.ViewCollection.AddRange(new BaseView[] {_windowsUiView});
            // 
            // windowsUIView
            // 
            _windowsUiView.AddTileWhenCreatingDocument = DevExpress.Utils.DefaultBoolean.False;
            _windowsUiView.AllowCaptionDragMove = DevExpress.Utils.DefaultBoolean.True;
            _windowsUiView.ContentContainers.AddRange(new IContentContainer[] { _pageContainer, _tabbedContainer });
            _windowsUiView.Documents.AddRange(new BaseDocument[] { _documentLogin, _documentSettings, _documentCollect, _documentReport , _documentDashboard });
            _windowsUiView.SplashScreenProperties.Caption = StringResource.ApplicationCaption;
            _windowsUiView.SplashScreenProperties.Image = Properties.Resources.Splash;
            _windowsUiView.SplashScreenProperties.LoadingDescription = StringResource.Loading;
            _windowsUiView.TileProperties.BorderVisibility = DevExpress.XtraEditors.TileItemBorderVisibility.Always;
            _windowsUiView.UseLoadingIndicator = DevExpress.Utils.DefaultBoolean.True;
            _windowsUiView.UseSplashScreen = DevExpress.Utils.DefaultBoolean.True;
            _windowsUiView.SearchPanelProperties.Enabled = false;
            _windowsUiView.BackgroundImage= Properties.Resources.TopLogo;
            _windowsUiView.BackgroundImageLayoutMode = ImageLayoutMode.TopLeft;
   
            // 
            // loginContainer
            // 

            _pageContainer.Buttons.AddRange(containerButtons);
            _pageContainer.Caption = StringResource.ApplicationCaption;
            _pageContainer.Document = _documentLogin;
            _pageContainer.Name = "loginContainer";
            _pageContainer.Properties.ShowCaption = DevExpress.Utils.DefaultBoolean.True;
            _pageContainer.Properties.DestroyOnRemovingChildren = DevExpress.Utils.DefaultBoolean.True;
            // 
            // documentLogin
            // 
            _documentLogin.Caption = StringResource.Login;
            _documentLogin.ControlName = ControlNames.Login;
            // 
            // tabbedContainer
            // 
            AppAppearance.SetAppearance(_tabbedContainer.AppearanceHeaderButton.Hovered, AppAppearance.TileBlue, AppAppearance.TileDarkBlue);
            AppAppearance.SetAppearance(_tabbedContainer.AppearanceHeaderButton.Normal, AppAppearance.TileDarkBlue, AppAppearance.TileLightBlue);
            AppAppearance.SetAppearance(_tabbedContainer.AppearanceHeaderButton.Pressed, AppAppearance.TileLightBlue, AppAppearance.TileDarkBlue);

            _tabbedContainer.Buttons.AddRange(containerButtons);
            _tabbedContainer.Caption = StringResource.ApplicationCaption;
            _tabbedContainer.Items.AddRange(new[] { _documentSettings, _documentCollect, _documentReport , _documentDashboard });
            _tabbedContainer.Properties.AllowHtmlDrawHeaders = DevExpress.Utils.DefaultBoolean.True;
            _tabbedContainer.Properties.ButtonInterval = 10;
            _tabbedContainer.Properties.DestroyOnRemovingChildren = DevExpress.Utils.DefaultBoolean.False;
            _tabbedContainer.Properties.HeaderStyle = HeaderStyle.Tile;
            _tabbedContainer.Properties.Margin = new Padding(0);
            _tabbedContainer.Properties.Orientation = Orientation.Vertical;
            _tabbedContainer.Properties.ShowCaption = DevExpress.Utils.DefaultBoolean.True;
            _tabbedContainer.Properties.ShowContextActionBarOnActivating = DevExpress.Utils.DefaultBoolean.False;
            _tabbedContainer.Properties.SwitchDocumentAnimationMode = DevExpress.XtraBars.Docking2010.Customization.TransitionAnimation.FadeIn;
            _tabbedContainer.Properties.TileColumnCount = 1;
            _tabbedContainer.Properties.TileContentMargin = new Padding(3);
            _tabbedContainer.Properties.TileImageAlignment = TileHeaderContentAlignment.TopRight;
            _tabbedContainer.Properties.TileSize = 80;
            _tabbedContainer.Properties.TileTextAlignment = TileHeaderContentAlignment.BottomLeft;
            _tabbedContainer.Subtitle = string.Empty;

            // documentSettings
            // 
            _documentSettings.Caption = StringResource.Settings;
            _documentSettings.ControlName = ControlNames.Settings;
            _documentSettings.ControlTypeName = "";
            _documentSettings.ImageOptions.Image = Properties.Resources.ControlSettings;
            // 
            // documentCollect
            // 
            _documentCollect.Caption = StringResource.Collect;
            _documentCollect.ControlName = ControlNames.Collect;
            _documentCollect.ControlTypeName = "";
            _documentCollect.ImageOptions.Image = Properties.Resources.ControlPackage;
            // 
            // documentReport
            // 
            _documentReport.Caption = StringResource.Report;
            _documentReport.ControlName = ControlNames.Summary;
            _documentReport.ControlTypeName = "";
            _documentReport.ImageOptions.Image = Properties.Resources.ControlReport;

            // 
            // documentDashboard
            // 
            _documentDashboard.Caption = StringResource.Dashboard;
            _documentDashboard.ControlName = ControlNames.Dashboard;
            _documentDashboard.ControlTypeName = "";
            _documentDashboard.ImageOptions.Image = Properties.Resources.ControlDashboard;

            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 584);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmMain";
            WindowState = FormWindowState.Maximized;
            ((ISupportInitialize)_documentManager).EndInit();
            ((ISupportInitialize)_windowsUiView).EndInit();
            ((ISupportInitialize)_pageContainer).EndInit();
            ((ISupportInitialize)_documentLogin).EndInit();
            ((ISupportInitialize)_tabbedContainer).EndInit();
            ((ISupportInitialize)_documentSettings).EndInit();
            ((ISupportInitialize)_documentCollect).EndInit();
            ((ISupportInitialize)_documentReport).EndInit();
            ((ISupportInitialize)_documentDashboard).EndInit();
            ResumeLayout(false);
        }

      
        private void AppearanceForm()
        {
            Icon = Properties.Resources.App;
            //_windowsUiView.Controller.EnableFullScreenMode(true);
        }

        private void AddControlEventHandlers()
        {
            _windowsUiView.QueryControl += (sender, args) => OnQueryControl(args);
            _windowsUiView.DocumentActivated += (sender, args) => OnDocumentActivated(args);
            _tabbedContainer.ButtonClick += (sender, args) => OnContainerButtonClick(args);
            _pageContainer.ButtonClick += (sender, args) => OnContainerButtonClick(args);
            _tabbedContainer.HeaderClick += (sender, args) => OnTabbedContainerHeaderClick(args);
            _windowsUiView.NavigationBarsShowing += (sender, args) => args.Cancel = true;
        }

        private void OnDocumentActivated(DocumentEventArgs args)
        {
            if (args?.Document?.Control is UcBase baseControl)
            {
                baseControl.FocusFirstControl();
                baseControl.Activated();
            }
        }

        private void OnContainerButtonClick(ButtonEventArgs args)
        {
            if (args.Button.Properties.Tag?.ToString() == "ExitApplication")
            {
                if (AppContext.ShowQuestionMessage(StringResource.DoYouWanttoCloseApllication, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    AppContext.Exit();
                }
                return;
            }

            if (args.Button.Properties.Tag?.ToString() == "MinimizeApplication")
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        public void ActivateTabContainer()
        {
            _windowsUiView.Controller.Activate(_tabbedContainer);
        }

        public void ActivateLoginContainer()
        {
            _windowsUiView.Controller.Activate(_pageContainer);
        }

        public void ActivatePackageDocument()
        {
            _windowsUiView.Controller.Activate(_documentCollect);
        }

        private void OnQueryControl(QueryControlEventArgs e)
        {
            try
            {
                UcBase control = null;
                switch (e.Document.ControlName)
                {
                    
                    case ControlNames.Login:
                        control = new UcLogin();
                        break;
                    case ControlNames.Settings:
                        control = new UcSettings();
                        break;
                    case ControlNames.Collect:
                        control = new UcCollect();
                        break;
                    case ControlNames.Summary:
                        control = new   UcReport();
                        break;
                    case ControlNames.Dashboard:
                        control = new UcDashBoard();
                        break;
                }

                try
                {
                    control?.Initialize();
                }
                catch (Exception exception)
                {
                    AppContext.ShowErrorMessage(exception.Message);
                    AppContext.Logger.Error(exception);
                }

                e.Control = control;
            }
            catch (Exception exception)
            {
                e.Control = new UcError();
                AppContext.Logger.Error(exception);
            }
        }

        private void OnTabbedContainerHeaderClick(DocumentHeaderClickEventArgs e)
        {
            if (e.Document?.ControlName == _windowsUiView.ActiveDocument?.ControlName)
            {
                return;
            }
            e.Handled = _windowsUiView.ActiveDocument != null && !((UcBase)_windowsUiView.ActiveDocument.Control).ValidateForNavigation();
        }


    }
}
