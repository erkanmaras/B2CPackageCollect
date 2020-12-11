using System;
using DevExpress.XtraSplashScreen;

namespace B2CPackageCollect
{
    internal class WaitFormScope : IDisposable
    {
        public WaitFormScope(string message=StringResource.Loading,int pendingTime = 0)
        {
            SplashScreenManager.SkinName = Properties.Settings.Default.SkinName;
            SplashScreenManager.ShowDefaultWaitForm(AppContext.MainForm, false, false, false, pendingTime, StringResource.PleaseWait, message);
        }

        public void Dispose()
        {
            CloseIfOpened();
        }

        public static void CloseIfOpened()
        {
            try
            {
                SplashScreenManager.CloseForm(false);
            }
            catch
            {
                // ignored
            }
        }
    }
}
