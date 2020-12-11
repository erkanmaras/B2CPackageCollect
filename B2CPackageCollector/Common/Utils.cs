using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace B2CPackageCollect
{
    internal static class Utils
    {
        public static Exception UnwrapAggregateException(AggregateException ex)
        {
            if (ex.InnerExceptions?.Count > 0)
            {
                var innerEx = ex.InnerExceptions[0];
                if (innerEx is AggregateException exception)
                {
                    return UnwrapAggregateException(exception);
                }
                return innerEx;
            }
            return ex;
        }


        public static void SetGlobalAppearance(ContainerControl containerControl)
        {
            foreach (var control in containerControl.Controls)
            {
                if (control is ContainerControl container)
                {
                    SetGlobalAppearance(container);

                }
                else if (control is BaseEdit baseEdit)
                {
                    if (baseEdit.MaximumSize.IsEmpty)
                    {
                        baseEdit.MaximumSize = new Size(500, 0);
                    }
                    if (baseEdit.MinimumSize.IsEmpty)
                    {
                        baseEdit.MinimumSize = new Size(100, 0);
                    }
                }
                else if (control is BaseButton basebutton)
                {
                    if (basebutton.MinimumSize.IsEmpty)
                    {
                        basebutton.MinimumSize = new Size(70, 40);
                        basebutton.MaximumSize = new Size(70, 40);
                    }
                }
            }
        }

        public static DynamicParameters ToDynamicParameters(IDictionary<string, object> parameters)
        {
            if (parameters is null || !parameters.Any())
            {
                return null;
            }

            var dynamicParameters = new DynamicParameters();

            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }
            return dynamicParameters;
        }

        public static void DrawRecordNotFoundToForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e )
        {
            if (((GridView)sender).GridControl.DataSource is DataTable table)
            {
                if (table.Rows.Count == 0)
                {
                    DrawRecordNotFoundToForeground(e);
                }
            }

            if (((GridView)sender).GridControl.DataSource is IList list)
            {
                if (list.Count == 0)
                {
                    DrawRecordNotFoundToForeground(e);
                }
            }
        }

        public static void DrawRecordNotFoundToForeground( DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            DrawTextCenter(e.Graphics, "Sipariş Bulunamadı!", e.Bounds, true);
        }

        public static void DrawTextCenter(Graphics graphics, string text, Rectangle bounds,  bool transparent = true)
        {
            DrawTextCenter(graphics, text, bounds,AppAppearance. GetSkinBackColor(DevExpress.Skins.GridSkins.SkinGridRow), Color.FromArgb(50, AppAppearance.GetSkinForeColor(DevExpress.Skins.GridSkins.SkinGridRow)), transparent);
        }

        public static decimal ToDecimal(object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            return decimal.TryParse(obj.ToString(), out var output) ? output : 0;
        }

        public static void DrawTextCenter(Graphics graphics, string text, Rectangle bounds, Color backColor, Color foreColor, bool transparent = true)
        {
            var fontName = DevExpress.Utils.AppearanceObject.DefaultFont.FontFamily.Name;
            var fontSize = (DevExpress.Utils.AppearanceObject.DefaultFont.Size * 3) + 5;
            var minFontSize = 5;
            var maxFontSize = 50;
            var font = new Font(fontName, fontSize);
            var size = graphics.MeasureString(text, font);
            if (size.Width > bounds.Size.Width)
            {
                var hRatio = bounds.Size.Height / size.Height;
                var wRatio = bounds.Size.Width / size.Width;
                var minRatio = Math.Min(hRatio, wRatio);
                var newSize = font.Size * minRatio;
                newSize = Math.Min(Math.Max(newSize, minFontSize), maxFontSize);
                font = new Font(font.FontFamily, newSize, font.Style);
            }


            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            if (!transparent)
            {
                graphics.Clear(backColor);
            }

            using (var brush = new SolidBrush(foreColor))
            {
                graphics.DrawString(text, font, brush, bounds, format);
            }

        }

     
    }
}
