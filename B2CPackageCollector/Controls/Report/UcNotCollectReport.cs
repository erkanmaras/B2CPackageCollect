using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;

namespace B2CPackageCollect
{
    public partial class UcNotCollectReport : UcBaseGridReport
    {
        public UcNotCollectReport()
        {
            InitializeComponent();
            GrdViewReport = grdView;
        }

        public override void Initialize()
        {
            AppearanceControl();
            AppearanceGrid();
            AddControlEventHandlers();
            base.Initialize();
        }

        public override bool ShouldPrepareReport()
        {
            return !AppContext.CollectContext.OperationContext.NotCollectReportLoaded;
        }

        public override void PrepareReport()
        {
            LoadDatasource();
        }

        private void AppearanceControl()
        {
            Utils.SetGlobalAppearance(lcMain);
        }

        private void AddControlEventHandlers()
        {
            btnMenu.Click += (sender, args) => OnMenuClick();
            btnRefresh.Click += (sender, args) => OnRefreshClick();
            grdView.CustomDrawGroupRow += (sender, args) => OnCustomDrawGroupRow(args);
        }

        private void OnRefreshClick()
        {
            using (new WaitFormScope())
            {
                LoadDatasource(true);
            }
        }

        private void AppearanceGrid()
        {
            try
            {
                grdView.BeginUpdate();
                grdView.BestFitMaxRowCount = 10;
                grdView.OptionsBehavior.AutoExpandAllGroups = true;
                var colNumber = grdView.Columns.AddVisible("FaturaNumarasi", "Fatura Numarası");
                var colDate = grdView.Columns.AddVisible("FaturaTarihi", "Fatura Tarihi");
                var colCustomer = grdView.Columns.AddVisible("MusteriKodu", "Muşteri Kodu");

                grdView.Columns.AddVisible("StokKodu", "Stok Kodu");
                grdView.Columns.AddVisible("Barkod", "Barkod");
                grdView.Columns.AddVisible("StokSinifi", "Stok Sınıfı");
                grdView.Columns.AddVisible("RenkKodu", "Renk Kodu");
                grdView.Columns.AddVisible("Beden", "Beden");
                grdView.Columns.AddVisible("Gun", "Verim(Süre)");

                var colQty = grdView.Columns.AddVisible("Miktar", "Miktar");
                colQty.SummaryItem.SummaryType = SummaryItemType.Sum;
                colQty.SummaryItem.DisplayFormat = @"Miktar:{0}";

                grdView.SortInfo.ClearAndAddRange(
                    new GridColumnSortInfo[] {
                                  new GridMergedColumnSortInfo(
                                      new[] { colNumber, colDate,colCustomer},
                                      new[] { ColumnSortOrder.Ascending, ColumnSortOrder.Ascending, ColumnSortOrder.Ascending }
                                      )}
                    , 2);
            }
            finally
            {
                grdView.EndUpdate();
            }
        }

        private void OnMenuClick()
        {
            var currentLine = GetCurrentLine();
            if (currentLine == null)
            {
                AppContext.ShowInformationMessage(StringResource.SelectInvoiceBeforeAction);
                return;
            }

            currentLine = (CollectReportLine)grdView.GetFocusedRow();
            var allLines = Datasource.Where(p => p.AlisverisID == currentLine.AlisverisID).AsList();

            using (var frm = new FrmCollectReportOptions())
            {
                frm.CreateButton(StringResource.ReturnAll, () => OnReturnAll(allLines));
                frm.CreateButton(StringResource.MarkComplete, () => OnComplete(allLines));
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private bool OnComplete(List<CollectReportLine> allLines)
        {
            if (AppContext.ShowQuestionMessage(StringResource.CompleteCollectConfirm, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var alisverisId = allLines.First().AlisverisID;
                using (var db = new Db())
                {
                    db.SaveCollectHeader(alisverisId,true);
                    db.UpdateCollectCompletedAndPrinted(alisverisId,CollectCompleteType.Marked);
                    allLines.ForEach((p) => db.SaveCollectDetail(alisverisId, p.IslemID, p.Miktar));
                    db.Commit();
                }
                RemoveFromDatasource(alisverisId);
                return true;
            }
            return false;
        }

        private void LoadDatasource(bool force = false)
        {
            var collectContext = AppContext.CollectContext;
            if (!force && collectContext.OperationContext.NotCollectReportLoaded)
            {
                return;
            }

            try
            {
                grdControl.BeginUpdate();
                grdControl.DataSource = null;
                using (var db = new Db())
                {
                    SetDatasource(db.GetNotCollectReport(new FilterParameters(collectContext.StoreCode, collectContext.StartDate, collectContext.EndDate)));
                }
                collectContext.OperationContext.NotCollectReportLoaded = true;
            }
            finally
            {
                grdControl.EndUpdate();
            }
        }

        public override void Activated()
        {
            base.Activated();
            LoadDatasource();
        }

        public override void FocusFirstControl()
        {
            lcMain.FocusHelper.FocusElement(lciGrid, false);
            grdView.ShowFindPanel();
        }

    }
}
