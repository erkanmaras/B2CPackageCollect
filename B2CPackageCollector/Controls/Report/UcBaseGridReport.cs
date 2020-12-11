using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraGrid.Views.Grid;

namespace B2CPackageCollect
{
    public class UcBaseGridReport : UcBaseReport
    {
        protected GridView GrdViewReport;
        protected IEnumerable<CollectReportLine> Datasource;

        protected CollectReportLine GetCurrentLine()
        {
            CollectReportLine currentLine = null;
            if (GrdViewReport.IsDataRow(GrdViewReport.FocusedRowHandle))
            {
                currentLine = (CollectReportLine)GrdViewReport.GetFocusedRow();
            }
            else if (GrdViewReport.IsGroupRow(GrdViewReport.FocusedRowHandle))
            {
                currentLine = (CollectReportLine)GrdViewReport.GetRow(GrdViewReport.GetChildRowHandle(GrdViewReport.FocusedRowHandle, 0));
            }
            return currentLine;
        }
        
        protected bool OnReturnAll(IList<CollectReportLine> lines)
        {
            Check.NotNull(lines, nameof(lines));
            if (AppContext.ShowQuestionMessage(StringResource.ReturnAllConfirm, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
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

                    ReturnLines(lines, invoiceDetails, invoiceDetails.Payments.AsList());

                }
            }
            catch (Exception e)
            {
                AppContext.Logger.Error(e);
                throw new B2CPackageCollectException(StringResource.OperationFailedRetry);
            }

            return true;
        }

        protected void ReturnLines(IList<CollectReportLine> lines, InvoiceDetailsForReturn detailsForReturn, List<IDictionary<string, object>> payments)
        {
            var insertTable = new List<IDictionary<string, object>>();

            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                var detailLine = detailsForReturn.Lines.FirstOrDefault(p => Utils.ToDecimal(p["IslemID"]) == line.IslemID);
                if (detailLine == null)
                {
                    throw new B2CPackageCollectException(StringResource.InvoiceReturnDetailNotFound);
                }

                var insertRow = detailLine;

                for (var j = 0; j < 5; j++)
                {
                    object type = string.Empty;
                    object amount = 0;
                    if (detailsForReturn.Lines.Count - 1 == i && j < payments.Count)
                    {
                        var paymentLine = payments[j];
                        type = paymentLine["PaymentType"];
                        amount = paymentLine["PaymentAmount"];
                    }
                    insertRow.Add("PaymentType" + (j + 1), type);
                    insertRow.Add("PaymentAmount" + (j + 1), amount);
                }

                insertRow.Remove("IslemID");
                insertTable.Add(insertRow);
            }

            using (var db = new Db(true))
            {
                db.SaveReturnInvoice(insertTable);
                db.UpdateCollectCompleted(lines.First().AlisverisID);
                db.Commit();
            }
            RemoveFromDatasource(lines.First().AlisverisID);
        }


        protected void SetDatasource(IEnumerable<CollectReportLine> data)
        {
            Datasource = data;
            GrdViewReport.GridControl.DataSource = data;
            GrdViewReport.BestFitColumns();
        }

        protected void RemoveFromDatasource(string alisveriId)
        {
            try
            {

                GrdViewReport.BeginDataUpdate();
                SetDatasource(Datasource.Where(p => p.AlisverisID != alisveriId).ToList());
            }
            finally
            {
                GrdViewReport.EndDataUpdate();
            }
        }

        protected void OnCustomDrawGroupRow(DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            if (e.RowHandle == GrdViewReport.FocusedRowHandle)
            {
                e.Appearance.ForeColor = AppAppearance.BlueForeColor;
            }

        }

    

    }
}
