using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using DevExpress.Data;
using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace B2CPackageCollect
{
    public partial class UcCollectedReport : UcBaseGridReport
    {
        public UcCollectedReport()
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
            return !AppContext.CollectContext.OperationContext.CollectReportLoaded;
        }

        public override void PrepareReport()
        {
            LoadDatasource();
        }
        private void AppearanceControl()
        {
            try
            {
                lcMain.BeginUpdate();
                Utils.SetGlobalAppearance(lcMain);
            }
            finally
            {
                lcMain.EndUpdate();
            }
        }

        private void AddControlEventHandlers()
        {
            btnMenu.Click += (sender, args) => OnMenuClick();
            btnRefresh.Click += (sender, args) => OnRefreshClick();
            grdView.RowCellStyle += (sender, args) => OnGridViewRowCellStyle(args);
            grdView.CustomDrawGroupRow += (sender, args) => OnCustomDrawGroupRow(args);
        }

        private void OnRefreshClick()
        {
            using (new WaitFormScope())
            {
                LoadDatasource(true);
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
                if (!currentLine.Printed())
                {
                    frm.CreateButton(StringResource.Print, () => OnPrint(allLines));
                    frm.CreateButton(StringResource.PrintPreview, () => OnPreview(allLines));
                    frm.CreateButton(StringResource.MarkComplete, () => OnComplete(allLines));
                }
                else if (!currentLine.Completed())
                {
                    frm.CreateButton(StringResource.ReturnAll, () => OnReturnAll(allLines));
                    frm.CreateButton(StringResource.ReturnNotCollecteds, () => OnReturnPartial(allLines));
                    frm.CreateButton(StringResource.MarkComplete, () => OnComplete(allLines));
                }
                else
                {
                    frm.CreateButton(StringResource.Print, () => OnRePrint(allLines));
                    frm.CreateButton(StringResource.PrintPreview, () => OnRePreview(allLines));
                }

                frm.CreateButton(StringResource.CancelCollect, () => OnCancelCollect(allLines));

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
                    db.UpdateCollectCompletedAndPrinted(alisverisId, CollectCompleteType.Marked);
                    allLines.ForEach((p) => db.SaveCollectDetail(alisverisId, p.IslemID, p.Miktar));
                    db.Commit();
                }

                allLines.ForEach((p) => p.MarkCollected());
                grdView.RefreshData();
                return true;
            }
            return false;
        }

        private bool OnCancelCollect(IList<CollectReportLine> lines)
        {
            if (AppContext.ShowQuestionMessage(StringResource.CancelCollectConfirm, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var alisverisId = lines.First().AlisverisID;
                using (var db = new Db())
                {
                    db.CancelCollect(alisverisId);
                    db.Commit();
                }
                RemoveFromDatasource(alisverisId);
                return true;
            }
            return false;
        }

        private bool OnReturnPartial(IList<CollectReportLine> lines)
        {
            if (AppContext.ShowQuestionMessage(StringResource.ReturnNotCollectedConfirm, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return false;
            }

            try
            {
                var alisverisId = lines.First().AlisverisID;
                using (new WaitFormScope())
                {
                    InvoiceDetailsForReturn invoiceDetails;
                    using (var db = new Db())
                    {
                        invoiceDetails = db.GetInvoiceDetailsForReturn(alisverisId, AppContext.User.UserName);
                    }
                    if (!invoiceDetails.Lines.HasItem())
                    {
                        throw new B2CPackageCollectException(StringResource.InvoiceNotFound);
                    }

                    var notCollectedLines = lines.Where(p => p.ToplananMiktar < p.Miktar).ToList();
                    var paymentTotal = GetPartialPaymentAmount(notCollectedLines, invoiceDetails);
                    var payments = new Dictionary<string, object>() { { Properties.Settings.Default.ReturnPaymentTypeCode, paymentTotal } };
                    ReturnLines(notCollectedLines, invoiceDetails, new List<IDictionary<string, object>>() { payments });
                }
            }
            catch (Exception e)
            {
                AppContext.Logger.Error(e);
                throw new B2CPackageCollectException(StringResource.OperationFailedRetry);
            }
            return true;
        }

        private decimal GetPartialPaymentAmount(IEnumerable<CollectReportLine> lines, InvoiceDetailsForReturn detailsForReturn)
        {
            var selectedLines = detailsForReturn.Lines.Where(p => lines.Any(r => r.IslemID == Utils.ToDecimal(p["IslemID"])));
            decimal payment = 0;
            foreach (var line in selectedLines)
            {
                payment += (Utils.ToDecimal(line["ItemPrice"]) * Utils.ToDecimal(line["ItemAmount"])) - Utils.ToDecimal(line["DigerIndirim"]);
            }
            return payment;
        }

        private bool OnPreview(IList<CollectReportLine> lines)
        {
            var firstLine = lines.First();
            using (new WaitFormScope())
            {
                InvoiceForm.PreviewSale(firstLine.AlisverisID);
                using (var db = new Db(true))
                {
                    db.UpdateInvoicePrinted(firstLine.AlisverisID);
                    db.Commit();
                }
                lines.ForEach(p => p.Yazdirildi = true);
            }

            if (firstLine.Completed())
            {
                RemoveFromDatasource(firstLine.AlisverisID);
            }
            else
            {
                grdView.RefreshData();
            }
            return true;
        }

        private bool OnPrint(IList<CollectReportLine> lines)
        {
            var firstLine = lines.First();
            using (new WaitFormScope())
            {
                var collectContext = AppContext.CollectContext;
                InvoiceForm.PrintSale(firstLine.AlisverisID, collectContext.PrinterName);
                using (var db = new Db(true))
                {
                    db.UpdateInvoicePrinted(firstLine.AlisverisID);
                    db.Commit();
                }
                lines.ForEach(p => p.Yazdirildi = true);
            }

            if (firstLine.Completed())
            {
                RemoveFromDatasource(firstLine.AlisverisID);
            }
            else
            {
                grdView.RefreshData();
            }
            return true;
        }


        private bool OnRePrint(IList<CollectReportLine> lines)
        {
            var firstLine = lines.First();
            var collectContext = AppContext.CollectContext;
            InvoiceForm.PrintSale(firstLine.AlisverisID, collectContext.PrinterName);
            return true;
        }

        private bool OnRePreview(IList<CollectReportLine> lines)
        {
            var firstLine = lines.First();
            InvoiceForm.PreviewSale(firstLine.AlisverisID);
            return true;
        }

        private void AppearanceGrid()
        {
            try
            {
                grdView.BeginUpdate();
                grdView.BestFitMaxRowCount = 10;
                grdView.OptionsBehavior.AutoExpandAllGroups = true;

                var chkYesNo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                {
                    DisplayValueChecked = StringResource.Yes,
                    DisplayValueUnchecked = StringResource.No
                };

                var colNumber = grdView.Columns.AddVisible("FaturaNumarasi", "Fat.No");
                var colCustomerName = grdView.Columns.AddVisible("AdiSoyadi", "Adı");
                var colDate = grdView.Columns.AddVisible("FaturaTarihi", "Fat.Tar");
                var colCustomerCode = grdView.Columns.AddVisible("MusteriKodu", "Müş.Kod");

                var colComplete = grdView.Columns.AddVisible("Tamamlandi", "T");
                colComplete.ColumnEdit = chkYesNo;

                var colPrint = grdView.Columns.AddVisible("Yazdirildi", "Y");
                colPrint.ColumnEdit = chkYesNo;

                grdView.Columns.AddVisible("StokKodu", "Stok Kodu");
                grdView.Columns.AddVisible("Barkod", "Barkod");
                grdView.Columns.AddVisible("StokSinifi", "Stok Sınıfı");
                //grdView.Columns.AddVisible("RenkKodu", "Renk Kodu");
                //grdView.Columns.AddVisible("Beden", "Beden");
                var colCollectedDate = grdView.Columns.AddVisible("ToplananGun", "Toplanma Tarihi");
                colCollectedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                colCollectedDate.DisplayFormat.FormatString = "g";//"dd/MM/yyyy hh:mm";

                grdView.Columns.AddVisible("Gun", "Verim(Süre)");
                var colQty = grdView.Columns.AddVisible("Miktar", "Miktar");
                colQty.SummaryItem.SummaryType = SummaryItemType.Sum;
                colQty.SummaryItem.DisplayFormat = @"Miktar:{0}";

                var colCollectedQty = grdView.Columns.AddVisible("ToplananMiktar", "Toplanan");
                colCollectedQty.SummaryItem.SummaryType = SummaryItemType.Sum;
                colCollectedQty.SummaryItem.DisplayFormat = @"Toplanan:{0}";

                var colCollectedRemeaningQty = grdView.Columns.AddVisible("KalanMiktar", "Kalan");
                colCollectedRemeaningQty.SummaryItem.SummaryType = SummaryItemType.Sum;
                colCollectedRemeaningQty.SummaryItem.DisplayFormat = @"Kalan:{0}";

                grdView.SortInfo.ClearAndAddRange(
                    new GridColumnSortInfo[] {
                                  new GridMergedColumnSortInfo(
                                      new[] { colNumber, colCustomerName,colDate, colCustomerCode, colComplete, colPrint},
                                      new[] { ColumnSortOrder.Ascending, ColumnSortOrder.Ascending,ColumnSortOrder.Ascending, ColumnSortOrder.Ascending, ColumnSortOrder.Ascending }
                                      )}
                    , 6);
            }
            finally
            {
                grdView.EndUpdate();
            }
        }

        private void LoadDatasource(bool force = false)
        {
            var collectContext = AppContext.CollectContext;
            if (!force && collectContext.OperationContext.CollectReportLoaded)
            {
                return;
            }

            try
            {
                grdView.BeginUpdate();
                grdControl.DataSource = null;
                using (var db = new Db())
                {
                    SetDatasource(db.GetCollectReport(new FilterParameters(collectContext.StoreCode, collectContext.StartDate, collectContext.EndDate)));
                }
                collectContext.OperationContext.CollectReportLoaded = true;
            }
            finally
            {
                grdView.EndUpdate();

            }
        }

        private void OnGridViewRowCellStyle(RowCellStyleEventArgs args)
        {
            if (grdView.GetRow(args.RowHandle) is CollectReportLine line)
            {
                if (!line.Collected())
                {
                    args.Appearance.BackColor = AppAppearance.GridLineRed;
                    return;
                }

                //if (!line.Printed())
                //{
                //    args.Appearance.BackColor = AppAppearance.GridLineYellow;
                //    return;
                //}

                args.Appearance.BackColor = AppAppearance.GridLineGreen;
            }
        }

        public override void FocusFirstControl()
        {
            lcMain.FocusHelper.FocusElement(lciGrid, false);
            grdView.ShowFindPanel();
        }
    }
}
