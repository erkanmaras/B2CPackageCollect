using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using B2CPackageCollect.Controls;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraReports.UI;

namespace B2CPackageCollect
{
    public class InvoiceForm
    {
        private static XtraReport _saleForm;

        private static XtraReport LoadForm()
        {
            var form = new XtraReport();
            form.LoadLayout(System.IO.Path.Combine(Application.StartupPath, @"InvoiceForms\PesinFatura.repx"));
            return form;
        }

        public static void PrintSale(string alisveriId, string printerName = "")
        {
            try
            {
                EnsureFormLoaded();

                using (var db = new Db())
                {
                    _saleForm.DataSource = db.GetSaleInvoiceFormDatasource(alisveriId);
                    _saleForm.CreateDocument();
                }
                _saleForm.PrinterName = printerName;
                _saleForm.Print(printerName);
            }
            catch (Exception ex)
            {
                AppContext.Logger.Error(ex);
                throw new B2CPackageCollectException(StringResource.OperationFailedRetry);
            }
          
        }

        private static void EnsureFormLoaded()
        {
            if (_saleForm == null)
            {
                try
                {
                    _saleForm = LoadForm();
                }
                catch (Exception e)
                {
                    AppContext.Logger.Error(e);
                    throw new B2CPackageCollectException(StringResource.InvoiceFormCannotLoad);
                }
            }
            _saleForm.DataSource = null;
           
        }

        public static bool PreviewSale(string alisveriId)
        {
            try
            {
                EnsureFormLoaded();

                using (var db = new Db())
                {
                    _saleForm.DataSource = db.GetSaleInvoiceFormDatasource(alisveriId);
                    _saleForm.CreateDocument();
                }

                var control = new UcPrint
                {
                    Document = _saleForm
                };
                control.Initialize();

                WaitFormScope.CloseIfOpened();
                return FlyoutDialog.Show(AppContext.MainForm, control) == DialogResult.OK;
            }
            catch (Exception ex)
            {
               AppContext.Logger.Error(ex);
                throw new B2CPackageCollectException(StringResource.OperationFailedRetry);
            }
          
        }

        public static void LoadFormsAsync()
        {

            Task.Factory.StartNew(LoadForm)
                          .ContinueWith(
                              p =>
                              {
                                  if (_saleForm == null)
                                  {
                                      _saleForm = p.Result;
                                  }
                              },
                              TaskContinuationOptions.OnlyOnRanToCompletion);

        }
    }
}

