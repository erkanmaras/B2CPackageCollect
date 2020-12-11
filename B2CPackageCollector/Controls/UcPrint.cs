using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace B2CPackageCollect.Controls
{
    public partial class UcPrint : UcBase
    {

        public UcPrint()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            AddControlEventHandlers();
            AppearanceControl();
            base.Initialize();
        }

        private void AppearanceControl()
        {
            Utils.SetGlobalAppearance(lcMain);
        }

        private void AddControlEventHandlers()
        {
            btnPrint.Click += (sender, args) => OnPrintClick();
            btnCancel.Click += (sender, args) => OnCancelClick();
        }

        public XtraReport Document { get; set; }
        public string PrinterName { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GeneratePreview();
        }

        public void GeneratePreview()
        {
            if (documentViewer.PrintingSystem != null)
            {
                documentViewer.PrintingSystem.ClearContent();
                documentViewer.PrintingSystem = null;
            }

            documentViewer.PrintingSystem = Document.PrintingSystem;
            Document.CreateDocument(true);
        }

        private void OnPrintClick()
        {
            Document.PrintingSystem.ShowPrintStatusDialog = false;
            Document.PrintingSystem.ShowMarginsWarning = false;
            Document.Print(PrinterName);
            if (ParentForm != null)
            {
                ParentForm.DialogResult = DialogResult.OK;
            }
        }

        private void OnCancelClick()
        {
            if (ParentForm != null)
            {
                ParentForm.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
