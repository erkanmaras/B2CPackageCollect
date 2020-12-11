using System;
using System.Data.SqlClient;

namespace B2CPackageCollect
{
    public partial class UcSettings : UcBase
    {
        public UcSettings()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            AppearanceControl();
            AddControlEventHandlers();
            CreateValidationHints();
            LoadWarehouse();
            ReadSettings();
            base.Initialize();
        }

        private void AddControlEventHandlers()
        {
            btnOk.Click += (sender, args) => OnOk();
            deStartDate.EditValueChanged += (sender, args) => deEndDate.Properties.MinValue = deStartDate.DateTime;
            gridLookUpWareHouse.QueryPopUp += (sender, args) => OnWareHouseQueryPopUp();
            cboPrinterName.Properties.QueryPopUp += (sender, args) => OnPrinterNameQueryPopUp();
        }

        private void OnOk()
        {
            if (!ValidateInputControls())
            {
                return;
            }
            AppContext.MainForm.ActivatePackageDocument();
        }

        private void OnWareHouseQueryPopUp()
        {
            LoadWarehouse();
        }

        private void LoadWarehouse()
        {
            if (gridLookUpWareHouse.Properties.DataSource == null)
            {
                try
                {
                    using (var db = new Db())
                    {
                        gridLookUpWareHouse.Properties.DataSource = db.GetWarehouses();
                    }
                }
                catch (SqlException ex)
                {
                    AppContext.Logger.Error(ex);
                    AppContext.ShowErrorMessage(StringResource.WarehouseCannotLoad);
                }
            }
        }

        private void AppearanceControl()
        {
            try
            {
                lcMain.BeginUpdate();
                Utils.SetGlobalAppearance(lcMain);
            }
            finally
            {
                lcMain.EndUpdate();
            }
        }

        public override bool ValidateForNavigation()
        {
            return ValidateInputControls();
        }

        private bool ValidateInputControls()
        {
            var valid = true;
            if (string.IsNullOrWhiteSpace(gridLookUpWareHouse.StringEditValue()))
            {
                valid = !adornerUIManager.SetValidationHintToInvalid(gridLookUpWareHouse);
            }
            if (string.IsNullOrWhiteSpace(deStartDate.Text.Trim()))
            {
                valid = !adornerUIManager.SetValidationHintToInvalid(deStartDate);
            }
            if (string.IsNullOrWhiteSpace(deEndDate.Text.Trim()))
            {
                valid = !adornerUIManager.SetValidationHintToInvalid(deEndDate);
            }
            if (deEndDate.DateTime < deStartDate.DateTime)
            {
                valid = !adornerUIManager.SetValidationHintToInvalid(deEndDate, StringResource.InvalidValue);
            }

            if (valid)
            {
                AppContext.CollectContext = new CollectContext(gridLookUpWareHouse.StringEditValue(), deStartDate.DateTime, deEndDate.DateTime, cboPrinterName.Text);
                adornerUIManager.SetValidationHintsToValid();
                SaveSettings();
            }
            return valid;
        }

        private void SaveSettings()
        {
            try
            {
                Properties.Settings.Default.WarehouseCode = gridLookUpWareHouse.StringEditValue();
                Properties.Settings.Default.PrinterName = cboPrinterName.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                AppContext.Logger.Error(ex);
            }
        }

        private void CreateValidationHints()
        {
            adornerUIManager.CreateValidationHints(StringResource.Required, gridLookUpWareHouse, deStartDate, deEndDate);
        }

        private void OnPrinterNameQueryPopUp()
        {
            if (cboPrinterName.Properties.Items.HasItem())
            {
                return;
            }

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cboPrinterName.Properties.Items.Add(printer);
            }
        }

        private void ReadSettings()
        {
            try
            {
                gridLookUpWareHouse.EditValue = Properties.Settings.Default.WarehouseCode;
                cboPrinterName.Text = Properties.Settings.Default.PrinterName;
                deStartDate.DateTime = DateTime.Now.AddDays(-1);
                deEndDate.DateTime = DateTime.Now;
            }
            catch (Exception ex)
            {
               AppContext.Logger.Error(ex);
            }
           
        }
    }
}
