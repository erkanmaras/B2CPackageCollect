using System;
using System.Windows.Forms;
using B2CPackageCollect.Forms;
using DevExpress.XtraEditors;

namespace B2CPackageCollect
{
    public partial class FrmCollectReportOptions : FrmTileDialog
    {
        public FrmCollectReportOptions()
        {
            InitializeComponent();
            TileGroup = tileRoot;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CreateExitButton();
        }
    }
}
