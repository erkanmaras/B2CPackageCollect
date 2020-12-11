using System;

namespace B2CPackageCollect 
{
    public class CollectContext
    {
        public CollectContext(string storeCode, DateTime startDate, DateTime endDate, string printerName = "")
        {
            StoreCode = storeCode;
            StartDate = startDate;
            EndDate = endDate;
            PrinterName = printerName;
        }

        public string StoreCode { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string PrinterName { get; }

        private OperationContext _operationContext;
        public OperationContext OperationContext => _operationContext ?? (_operationContext = new OperationContext());
    }

    public class OperationContext
    {
        public void OperationCompleted()
        {
            CollectReportLoaded=false;
            NotCollectReportLoaded=false;
            DashboardLoaded = false;
        }
        public bool CollectReportLoaded;
        public bool NotCollectReportLoaded;
        public bool DashboardLoaded;

    }

}
