using System.Drawing;
using DevExpress.Skins;
using System.Windows.Forms;
using B2CPackageCollect.Properties;
using DevExpress.XtraEditors;

namespace B2CPackageCollect
{
    internal class AppAppearance
    {
        public static void SetGlobalAppearanceSettings()
        {
            
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Settings.Default.SkinName;
            WindowsFormsSettings.DefaultFont = new Font(WindowsFormsSettings.DefaultFont.FontFamily.Name, Settings.Default.FontSize);
            WindowsFormsSettings.TouchScaleFactor = Settings.Default.TouchUIScaleFactor;
            WindowsFormsSettings.TouchUIMode = Settings.Default.TouchUI ? DevExpress.LookAndFeel.TouchUIMode.True : DevExpress.LookAndFeel.TouchUIMode.False;
            WindowsFormsSettings.ScrollUIMode = Settings.Default.TouchUI ? ScrollUIMode.Touch : ScrollUIMode.Default;
            WindowsFormsSettings.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.False;
       
            ScrollBarBase.UIMode = ScrollUIMode.Touch;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SkinManager.EnableFormSkins();
            WindowsFormsSettings.AllowHoverAnimation = DevExpress.Utils.DefaultBoolean.False;
            DevExpress.XtraBars.Controls.Animator.AllowFadeAnimation = false;
            DevExpress.XtraBars.BarAndDockingController.Default.PropertiesBar.MenuAnimationType = DevExpress.XtraBars.AnimationType.None;
            DevExpress.XtraBars.BarAndDockingController.Default.PropertiesBar.SubmenuHasShadow = false;
            DevExpress.XtraBars.BarAndDockingController.Default.PropertiesBar.AllowLinkLighting = false;

            DefaultFont = WindowsFormsSettings.DefaultFont;
            MediumFont = new Font(WindowsFormsSettings.DefaultFont.FontFamily.Name, Settings.Default.FontSize + 3);
            LargeFont = new Font(WindowsFormsSettings.DefaultFont.FontFamily.Name, Settings.Default.FontSize + 3);

            var metroUiSkin = MetroUISkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
            var metroUiElement = metroUiSkin[MetroUISkins.SkinHeader];
            metroUiElement.ContentMargins.Top = 5;
            metroUiElement.ContentMargins.Bottom = 5;

            metroUiElement = metroUiSkin[MetroUISkins.SkinActionsBar];
            metroUiElement.ContentMargins.Top = 0;
            metroUiElement.ContentMargins.Bottom = 0;

            metroUiElement = metroUiSkin[MetroUISkins.SkinPageGroupItemHeader];
            metroUiElement.ContentMargins.Top = 0;
            metroUiElement.ContentMargins.Bottom = 0;

            metroUiElement = metroUiSkin[MetroUISkins.SkinPageGroupItemHeaderButton];
            metroUiElement.ContentMargins.Top = 3;
            metroUiElement.ContentMargins.Bottom = 3;
        }

        public static Color GetSkinForeColor(string skinName)
        {
            var skin = GridSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default);
            var skinElement = skin[skinName];
            return skinElement.Color.ForeColor;
        }

        public static Color GetSkinBackColor(string skinName)
        {
            var skin = GridSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default);
            var skinElement = skin[skinName];
            return skinElement.Color.BackColor;
        }

        private static Color _skinControlColor = Color.Empty;
        public static Color GetSkinControlColor()
        {
            if (_skinControlColor == Color.Empty)
            {
                var skin = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                _skinControlColor = skin.Colors[CommonColors.Control];
            }

            return _skinControlColor;
        }

        private static Color _skinControlTextColor = Color.Empty;
        public static Color GetSkinControlTextColor()
        {
            if (_skinControlTextColor == Color.Empty)
            {
                var skin = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                _skinControlTextColor = skin.Colors[CommonColors.ControlText];
            }

            return _skinControlTextColor;
        }


        public static Color GridLineReadOnlyGray = Color.FromArgb(242, 242, 242);
        public static Color GridLineGreen = Color.FromArgb(202, 239, 201);
        public static Color GridLightLineGreen = Color.FromArgb(240, 255, 240);
        public static Color GridLineRed = Color.FromArgb(255, 180, 180);
        public static Color GridLineYellow = Color.FromArgb(240, 228, 180);
        public static Color GridLineOrange = Color.FromArgb(255, 188, 51);
        public static Color GreenForeColor = Color.FromArgb(71, 166, 27);
        public static Color LightGreenForeColor = Color.FromArgb(82, 191, 31);
        public static Color BlueForeColor = Color.FromArgb(25, 71, 138);
        public static Color GrayForeColor = Color.FromArgb(140, 140, 140);
        public static Color DarkGrayForeColor = Color.FromArgb(115, 115, 115);
        public static Color RedForeColor = Color.FromArgb(215, 39, 41);
        public static Color OrangeForeColor = Color.FromArgb(255, 137, 0);
        public static Color RequiredEditorRed = Color.FromArgb(255, 180, 180);

        public static Color TileBlue = Color.FromArgb(0, 125, 209);
        public static Color TileLightBlue = Color.FromArgb(25, 163, 255);
        public static Color TileDarkBlue = Color.FromArgb(25, 71, 138);
        public static Color TileRed = Color.FromArgb(197, 34, 65);
        public static Color TileBorderRed = Color.FromArgb(160, 0, 0);

        public static Font DefaultFont { get; private set; }
        public static Font MediumFont { get; private set; }
        public static Font LargeFont { get; private set; }

        public static void SetTileAppearance(TileItem tile)
        {
            SetAppearance(tile.AppearanceHover, TileBlue, TileDarkBlue);
            SetAppearance(tile.Appearance, TileDarkBlue, TileLightBlue);
            SetAppearance(tile.AppearanceSelected, TileLightBlue, TileDarkBlue);

        }
        public static void SetAppearance(DevExpress.Utils.AppearanceObject appearance, Color backColor, Color borderColor)
        {
            appearance.BackColor = backColor;
            appearance.BorderColor = borderColor;
            appearance.FontSizeDelta = -2;
            appearance.ForeColor = Color.White;
            appearance.Options.UseBackColor = true;
            appearance.Options.UseBorderColor = true;
            appearance.Options.UseFont = true;
            appearance.Options.UseForeColor = true;
        }

    }
}
