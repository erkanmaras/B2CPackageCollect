
using System;
using System.Windows.Forms;
 

namespace B2CPackageCollect
{
    public partial class UcLogin : UcBase
    {
        public UcLogin()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            AppearanceControl();
            CreateValidationHints();
            AddControlEventHandlers();
            ReadSettings();
            base.Initialize();
        }

        private void AppearanceControl()
        {
            Utils.SetGlobalAppearance(lcMain);
            txtServerName.Properties.MaxLength = 50;
            txtDatabaseName.Properties.MaxLength = 50;
            txtUserName.Properties.MaxLength = 50;
            txtPassword.Properties.MaxLength = 50;
            txtPassword.Properties.UseSystemPasswordChar = true;
        }

        private void AddControlEventHandlers()
        {
            btnLogin.Click += (sender, args) => OnLogin();
            btnCancel.Click += (sender, args) => OnCancel();
        }

        private void OnCancel()
        {
            Application.Exit();
        }

        private void OnLogin()
        {
            if (!ValidateInputControls())
            {
                return;
            }

            AppContext.Login(txtServerName.Text.Trim(), txtDatabaseName.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim());
            SaveSettings();
            //
            InvoiceForm.LoadFormsAsync();
            AppContext.MainForm.ActivateTabContainer();

        }

        private void SaveSettings()
        {
            try
            {
                Properties.Settings.Default.ServerName = txtServerName.Text.Trim();
                Properties.Settings.Default.DatabaseName = txtDatabaseName.Text.Trim();
                Properties.Settings.Default.UserName = txtUserName.Text.Trim();
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                AppContext.Logger.Error(ex);
            }
        }

        private void ReadSettings()
        {
            try
            {
                txtServerName.Text = Properties.Settings.Default.ServerName;
                txtUserName.Text = Properties.Settings.Default.UserName;
                txtDatabaseName.Text = Properties.Settings.Default.DatabaseName;
            }
            catch (Exception ex)
            {
                AppContext.Logger.Error(ex);
            }
        }

        private bool ValidateInputControls()
        {
            var valid = true;
            if (string.IsNullOrWhiteSpace(txtServerName.Text.Trim()))
            {
                valid = !adornerUIManager.SetValidationHintToInvalid(txtServerName);
            }
            if (string.IsNullOrWhiteSpace(txtDatabaseName.Text.Trim()))
            {
                valid = !adornerUIManager.SetValidationHintToInvalid(txtDatabaseName);
            }
            if (string.IsNullOrWhiteSpace(txtUserName.Text.Trim()))
            {
                valid = !adornerUIManager.SetValidationHintToInvalid(txtUserName);
            }

            //if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            //{
            //    valid = !adornerUIManager.SetValidationHintToInvalid(txtPassword);
            //}

            return valid;
        }

        private void CreateValidationHints()
        {
            adornerUIManager.CreateValidationHints(StringResource.Required, txtServerName, txtDatabaseName, txtUserName, txtPassword);
        }
 
    }
}
