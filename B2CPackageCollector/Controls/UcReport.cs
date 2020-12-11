using DevExpress.XtraTab;

namespace B2CPackageCollect
{
    public partial class UcReport : UcBase
    {
        public UcReport()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            AppearanceControl();
            AddControlEventHandlers();
            ucCollectedReport.Initialize();
            ucNotCollectReport.Initialize();
            if (tabControl.SelectedTabPage.Controls[0] is UcBaseReport baseControl && baseControl.ShouldPrepareReport())
            {
                baseControl.PrepareReport();
            }
            base.Initialize();
        }

        private void AppearanceControl()
        {
            Utils.SetGlobalAppearance(this);
        }

        private void AddControlEventHandlers()
        {
            tabControl.SelectedPageChanging += (sender, args) => OnTabSelectedPageChanging(args);
            tabControl.SelectedPageChanged += (sender, args) => OnTabSelectedPageChanged(args);
        }

        private void OnTabSelectedPageChanged(TabPageChangedEventArgs args)
        {
            if (tabControl.SelectedTabPage.Controls[0] is UcBaseReport baseControl)
            {
                baseControl.FocusFirstControl();
            }

        }

        private void OnTabSelectedPageChanging(TabPageChangedEventArgs args)
        {
            if (args.Page.Controls[0] is UcBaseReport baseControl && baseControl.ShouldPrepareReport())
            {
                using (new WaitFormScope())
                {
                    baseControl.PrepareReport();
                }
            }
        }

        public override void Activated()
        {
            if (tabControl.SelectedTabPage.Controls[0] is UcBaseReport baseControl && baseControl.ShouldPrepareReport())
            {
                using (new WaitFormScope())
                {
                    baseControl.PrepareReport();
                }
            }
            base.Activated();
        }

        public override void FocusFirstControl()
        {
            if (tabControl.SelectedTabPage.Controls[0] is UcBaseReport baseControl)
            {
                baseControl.FocusFirstControl();
            }
        }
    }
}
