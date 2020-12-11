using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using NLog;

namespace B2CPackageCollect
{
    public class AppContext
    {
     

        public static FrmMain MainForm { get; private set; }
        public static User User { get; private set; }
        public static Logger Logger { get; private set; }
        private static CollectContext _collectContext;
        public static CollectContext CollectContext
        {
            get
            {
                if (_collectContext == null)
                {
                    throw new B2CPackageCollectException("CollectContext is null!");
                }
                return _collectContext;
            }
            set => _collectContext = value;
        }

        public static void Run()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");

            Logger = LogManager.GetCurrentClassLogger();
            AppAppearance.SetGlobalAppearanceSettings();
            MainForm = new FrmMain();
            Application.Run(MainForm);
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            HandleGlobalException(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleGlobalException(e.ExceptionObject);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleGlobalException(e.Exception);
        }

        private static void HandleGlobalException(object ex)
        {
            HandleException(ex as Exception);
        }

        public static void Login(string serverName, string databaseName, string userName, string password)
        {
                Db.Login(serverName, databaseName, userName, password);
                User = new User(serverName, databaseName, userName, password);
        }

        public static void HandleException(Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            if (exception is AggregateException aggregateException)
            {
                exception = Utils.UnwrapAggregateException(aggregateException);
            }

            if (exception is B2CPackageCollectException)
            {
                ShowErrorMessage(exception.Message);
            }
            else
            {
                ShowErrorMessage("Beklenmeyen bir hata oluştu!");
            }

            Logger.Error(exception);
        }

        public static DialogResult ShowErrorMessage(string message)
        {
            return ShowFlyoutMessage(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowQuestionMessage(string message, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            return ShowFlyoutMessage(message, "Soru", buttons, MessageBoxIcon.Asterisk, defaultButton);
        }

        public static DialogResult ShowInformationMessage(string message)
        {
            return  ShowFlyoutMessage(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static void Exit()
        {
            Application.Exit();
        }


        public static DialogResult ShowFlyoutMessage(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            WaitFormScope.CloseIfOpened();
            DialogResult dialogResult;
            Image bitmap = null;
            if (icon != MessageBoxIcon.None)
            {
                bitmap = XtraMessageBox.MessageBoxIconToIcon(icon).ToBitmap();
            }
            var flyoutAction = new FlyoutAction(XtraMessageBox.MessageBoxButtonsToDialogResults(buttons), defaultButton)
            {
                Caption = caption,
                Description = text,
                Image = bitmap
            };
            var flyoutAction1 = flyoutAction;
            using (bitmap)
            {
                dialogResult = FlyoutDialog.Show(AppContext.MainForm, flyoutAction1);
            }
            return dialogResult;
        }

    }
}
