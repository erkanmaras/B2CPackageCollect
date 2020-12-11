using System;
using System.Windows.Forms;
using B2CPackageCollect.Forms;
using DevExpress.XtraEditors;

namespace B2CPackageCollect
{
    public partial class FrmReturnInvoiceOptions : FrmTileDialog
    {
        public FrmReturnInvoiceOptions()
        {
            InitializeComponent();
            TileGroup = tileRoot;
            lblMessage.Font = AppAppearance.MediumFont;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CreateExitButton();
        }
    }
}
