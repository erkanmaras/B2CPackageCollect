using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace B2CPackageCollect.Forms
{
    public class FrmTileDialog : XtraForm
    {

        protected TileGroup tileGroup;

        protected TileGroup TileGroup
        {
            get => tileGroup;
            set
            {
                tileGroup = value;
                tileGroup.Control.Properties.LargeItemWidth = 200;
            }
        }

        public void CreateButton(string text, Func<bool> action, DialogResult dlgResult = DialogResult.OK)
        {
            var tileItem = CreateTile(text, action, dlgResult);
            AppAppearance.SetTileAppearance(tileItem);
            tileGroup.Items.Add(tileItem);
        }

        private TileItem CreateTile(string text, Func<bool> action, DialogResult dlgResult = DialogResult.OK)
        {
            var tile = new TileItem
            {
                ItemSize = TileItemSize.Wide,
                TextAlignment = TileItemContentAlignment.MiddleCenter
            };

            tile.AppearanceItem.Normal.Font = AppAppearance.DefaultFont;
            tile.AppearanceItem.Hovered.Font = tile.AppearanceItem.Normal.Font;
            tile.AppearanceItem.Selected.Font = tile.AppearanceItem.Normal.Font;
            tile.Text = text;

            tile.ItemClick += (sender, args) =>
            {
                if (action?.Invoke() ?? false)
                {
                    DialogResult = dlgResult;
                    Close();
                }
            };
            return tile;
        }

        public void CreateExitButton()
        {
            var tileItem = CreateTile(StringResource.Exit, () => true, DialogResult.Abort);
            AppAppearance.SetAppearance(tileItem.Appearance, AppAppearance.TileRed, ControlPaint.LightLight(AppAppearance.TileRed));
            AppAppearance.SetAppearance(tileItem.AppearanceHover, ControlPaint.Light(AppAppearance.TileRed), ControlPaint.LightLight(AppAppearance.TileRed));
            AppAppearance.SetAppearance(tileItem.AppearanceSelected, ControlPaint.Light(AppAppearance.TileRed), ControlPaint.LightLight(AppAppearance.TileRed));
            tileGroup.Items.Add(tileItem);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            WaitFormScope.CloseIfOpened();
        }
    }
}

