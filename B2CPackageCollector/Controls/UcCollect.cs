using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace B2CPackageCollect
{
    public partial class UcCollect : UcBase
    {
        public UcCollect()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            AppearanceControl();
            AddControlEventHandlers();
            base.Initialize();
        }

        private ProductWithInvoice CurrentProductWithInvoice { get; set; }

        private void AddControlEventHandlers()
        {
            btxtBarcode.ButtonClick += (sender, args) => OnBarcodeButtonClick();
            btxtBarcode.KeyDown += (sender, args) => OnBarcodeKeyDown(args);
            btnPrint.Click += (sender, args) => OnPrintButtonClick();
            btnPreview.Click += (sender, args) => OnPreviewButtonClick();
            btxtBarcode.Enter += (sender, args) => OnBarcodeActivated();
            grdViewInvoiceLines.CustomDrawEmptyForeground += OnGridViewDrawEmptyForeground;
            grdViewInvoiceLines.RowCellStyle += (sender, args) => OnGridViewRowCellStyle(args);
        }

        public override void FocusFirstControl()
        {
            SelectBarcodeControl();
        }

        private void OnBarcodeKeyDown(KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Enter)
            {
                OnBarcodeButtonClick();
            }
        }

        private void OnPrintButtonClick()
        {

            if (CurrentProductWithInvoice == null)
            {
                return;
            }

            if (CurrentProductWithInvoice.Printed())
            {
                if (AppContext.ShowQuestionMessage(StringResource.InvoiceAllReadyPrinted, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }
            }

            var collectContext = AppContext.CollectContext;
            using (new WaitFormScope())
            {
                InvoiceForm.PrintSale(CurrentProductWithInvoice.InvoiceHeader.AlisverisID, collectContext.PrinterName);
                using (var db = new Db(true))
                {
                    db.UpdateInvoicePrinted(CurrentProductWithInvoice.InvoiceHeader.AlisverisID);
                    db.Commit();
                }
            }

            CurrentProductWithInvoice.SetPrinted();
            SetInvoiceStateControls(CurrentProductWithInvoice);
            SelectBarcodeControl();
        }

        private void OnPreviewButtonClick()
        {
            if (CurrentProductWithInvoice == null)
            {
                return;
            }

            using (new WaitFormScope())
            {
                if (!InvoiceForm.PreviewSale(CurrentProductWithInvoice.InvoiceHeader.AlisverisID))
                {
                    return;
                }
                using (var db = new Db())
                {
                    db.UpdateInvoicePrinted(CurrentProductWithInvoice.InvoiceHeader.AlisverisID);
                    db.Commit();
                }
            }
            CurrentProductWithInvoice.SetPrinted();
            SetInvoiceStateControls(CurrentProductWithInvoice);
            SelectBarcodeControl();
        }

        private void OnGridViewRowCellStyle(RowCellStyleEventArgs args)
        {
            if (grdViewInvoiceLines.GetRow(args.RowHandle) is InvoiceLine invoiceLine)
            {
                if (invoiceLine.AllCollected())
                {
                    args.Appearance.BackColor = AppAppearance.GridLineGreen;
                    return;
                }

                if (invoiceLine.SemiCollected())
                {
                    args.Appearance.BackColor = AppAppearance.GridLineYellow;
                }
            }
        }

        private void OnBarcodeActivated()
        {
            //SelectBarcodeControl();
        }

        private void SelectBarcodeControl()
        {
            lcMain.FocusHelper.FocusElement(lciBarcode, false);
            btxtBarcode.SelectAll();
        }

        private void OnGridViewDrawEmptyForeground(object sender, CustomDrawEventArgs args)
        {
            Utils.DrawRecordNotFoundToForeground(sender, args);
        }

        private bool ValidateCurrentProductWithInvoice()
        {
            if (CurrentProductWithInvoice == null || CurrentProductWithInvoice.Printed())
            {
                return true;
            }

            var message = CurrentProductWithInvoice.Completed() ? StringResource.InvoiceCompletedButNotPrinted : StringResource.InvoiceNotPrinted;
            return AppContext.ShowQuestionMessage(message, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
        private void OnBarcodeButtonClick()
        {
            if (!ValidateCurrentProductWithInvoice())
            {
                return;
            }

            ResetControls(true);
            LoadInvoice();
            if (CheckHasReturn(CurrentProductWithInvoice))
            {
                ResetControls();
            }
        }

        private void LoadInvoice()
        {
            var collectContext = AppContext.CollectContext;
            if (string.IsNullOrWhiteSpace(btxtBarcode.Text.Trim()))
            {
                return;
            }

            using (new WaitFormScope())
            {
                try
                {
                    ProductWithInvoice result;
                    using (var db = new Db())
                    {
                        result = db.GetProductWithInvoice(btxtBarcode.Text.Trim(), new FilterParameters(collectContext.StoreCode, collectContext.StartDate, collectContext.EndDate));
                    }

                    var collectedLine = result.Collect();
                    SaveCollectResult(collectedLine, result);
                    ReadResult(result);
                    if (result.Valid())
                    {
                        CurrentProductWithInvoice = result;
                        collectContext.OperationContext.OperationCompleted();
                    }

                }
                catch (Exception ex)
                {
                    ResetControls();
                    AppContext.Logger.Error(ex);
                }
                finally
                {
                    SelectBarcodeControl();
                }
            }
        }

        private bool CheckHasReturn(ProductWithInvoice result)
        {
            if (result == null)
            {
                return false;
            }

            bool hasReturn;
            using (var db = new Db(true))
            {
                hasReturn = db.InvoiceHasReturn(result.InvoiceHeader.AlisverisID);
            }
            if (hasReturn)
            {
                using (var frm = new FrmReturnInvoiceOptions())
                {
                    frm.lblMessage.Text = StringResource.ReturnInvoiceConfirm;
                    frm.CreateButton(StringResource.ContinueCollect, () => true);
                    frm.CreateButton(StringResource.MarkComplete, () => OnMarkComplete(result), DialogResult.Cancel);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    return frm.ShowDialog() == DialogResult.Cancel;
                }
            }
            return false;
        }

        private bool OnMarkComplete(ProductWithInvoice result)
        {
            if (AppContext.ShowQuestionMessage(StringResource.CompleteCollectConfirm, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var alisverisId = result.InvoiceHeader.AlisverisID;
                using (var db = new Db())
                {
                    db.UpdateCollectCompletedAndPrinted(alisverisId, CollectCompleteType.Marked);
                    foreach (var line in result.InvoiceLines)
                    {
                        db.SaveCollectDetail(alisverisId, line.IslemID, line.Miktar);
                    }
                    db.Commit();
                }
                return true;
            }
            return false;
        }


        private void SaveCollectResult(InvoiceLine collectedLine, ProductWithInvoice result)
        {
            if (collectedLine == null)
            {
                return;
            }

            using (var db = new Db(true))
            {
                db.SaveCollectHeaderAndDetail(result.InvoiceHeader.AlisverisID, result.Completed(), collectedLine.IslemID, collectedLine.ToplananMiktar);
                db.Commit();
            }
        }

        private void ReadResult(ProductWithInvoice result)
        {
            Check.NotNull(result, nameof(result));
            if (result.Product == null)
            {
                ResetControls();
                AppContext.ShowErrorMessage(StringResource.ProductNotFound);
                return;
            }

            SetProductControls(result.Product);

            if (!result.InvoiceLines.HasItem())
            {
                ResetInvoiceControls();
                return;
            }

            SetInvoiceControls(result);
        }

        private void ResetControls(bool beforeRead = false)
        {
            CurrentProductWithInvoice = null;
            ResetProductControls(beforeRead);
            ResetInvoiceControls(beforeRead);
        }

        private void ResetProductControls(bool beforeRead = false)
        {
            lblProductDescription.Text = @" ";
        }

        private void SetProductControls(Product product)
        {
            lblProductDescription.Text = product.ToString();
        }

        private void ResetInvoiceControls(bool beforeRead = false)
        {
            deInvoiceDate.ResetText();
            txtInvoiceNumber.ResetText();
            txtCustomerName.ResetText();
            txtCustomerCode.ResetText();
            grdControlInvoiceLines.DataSource = beforeRead ? null : Enumerable.Empty<InvoiceLine>();
            lblPrinted.Text = string.Empty;
            lblCompleted.Text = string.Empty;
            lblTotalQty.Text = string.Empty;
        }

        private void SetInvoiceControls(ProductWithInvoice result)
        {
            txtCustomerCode.Text = result.InvoiceHeader.MusteriKodu;
            txtInvoiceNumber.Text = result.InvoiceHeader.FaturaNumarasi;
            txtCustomerName.Text = result.InvoiceHeader.AdiSoyadi;
            deInvoiceDate.DateTime = result.InvoiceHeader.FaturaTarihi;
            SetInvoiceStateControls(result);
        }

        private void SetInvoiceStateControls(ProductWithInvoice result)
        {
            lblPrinted.ForeColor = result.Printed() ? AppAppearance.GreenForeColor : AppAppearance.RedForeColor;
            lblCompleted.ForeColor = result.Completed() ? AppAppearance.GreenForeColor : AppAppearance.RedForeColor;
            lblPrinted.Text = result.Printed() ? StringResource.Yes : StringResource.No;
            lblCompleted.Text = result.Completed() ? StringResource.Yes : StringResource.No;
            lblTotalQty.Text = result.InvoiceLines.Sum(p => p.Miktar).ToString();
            grdControlInvoiceLines.DataSource = result.InvoiceLines;
            grdViewInvoiceLines.BestFitColumns();
        }

        private void AppearanceControl()
        {
            try
            {
                lcMain.BeginUpdate();
                txtCustomerCode.ReadOnly = true;
                txtCustomerCode.TabStop = false;
                txtCustomerName.ReadOnly = true;
                txtCustomerName.TabStop = false;
                txtInvoiceNumber.ReadOnly = true;
                txtInvoiceNumber.TabStop = false;
                deInvoiceDate.ReadOnly = true;
                deInvoiceDate.TabStop = false;

                Utils.SetGlobalAppearance(lcMain);
                lciPrinted.AppearanceItemCaption.Font = AppAppearance.MediumFont;
                lciCompleted.AppearanceItemCaption.Font = AppAppearance.MediumFont;
                lciTotalQty.AppearanceItemCaption.Font = AppAppearance.MediumFont;

                lblPrinted.Font = AppAppearance.MediumFont;
                lblCompleted.Font = AppAppearance.MediumFont;
                lblTotalQty.Font = AppAppearance.MediumFont;
                AppearanceGrid();
            }
            finally
            {
                lcMain.EndUpdate();
            }

        }

        private void AppearanceGrid()
        {
            try
            {
                grdViewInvoiceLines.BeginUpdate();
                grdViewInvoiceLines.Columns.AddVisible("StokKodu", "Stok Kodu");
                grdViewInvoiceLines.Columns.AddVisible("StokAdi", "Stok Sınıfı");
                grdViewInvoiceLines.Columns.AddVisible("RenkKodu", "Renk Kodu");
                grdViewInvoiceLines.Columns.AddVisible("Beden", "Beden");
                grdViewInvoiceLines.Columns.AddVisible("Miktar", "Miktar");
                grdViewInvoiceLines.Columns.AddVisible("ToplananMiktar", "Toplanan Miktar");
            }
            finally
            {
                grdViewInvoiceLines.EndUpdate();
            }

        }
    }


}