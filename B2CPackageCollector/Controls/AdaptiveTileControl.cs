using System;
using DevExpress.XtraEditors;

namespace B2CPackageCollect.Controls
{
   public class AdaptiveTileControl:TileControl
    {
        public int CaclBestLargeItemWidth()
        {
            if (ColumnCount == 0)
            {
                return -1;
            }

            return (Size.Width- (Padding.Left + Padding.Right+ IndentBetweenItems * Math.Max((ColumnCount - 1), 0))) / ColumnCount;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (Orientation == System.Windows.Forms.Orientation.Vertical)
            {
                BeginUpdate();
                ((ITileControl)this).Properties.LargeItemWidth = CaclBestLargeItemWidth() * ColumnCount == 1 ? 1 : 2;
                EndUpdate();
            }
            
        }
    }
}
