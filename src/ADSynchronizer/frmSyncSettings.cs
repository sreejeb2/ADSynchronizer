using NLog;
using System.ComponentModel;
using System.DirectoryServices;
using System.Reflection;

namespace ADSynchronizer
{
    public partial class frmSyncSettings : Form
    {
        private const string MessageCaption = "AD Synchronizer";
        private const string ConfigFileName = "Settings.json";

        private static readonly Logger Logger = LogManager.GetLogger("ErrorLog");
        private static readonly Logger AuditLogger = LogManager.GetLogger("AuditLog");
        private readonly IEncryptionService _encryptionService;
        
        private SyncSettings _settings;

        public frmSyncSettings(IEncryptionService encryptionService)
        {
            try
            {
                _encryptionService = encryptionService;

                InitializeComponent();
                tcSync.SizeMode = TabSizeMode.Fixed;
                tcSync.ItemSize = new Size((tcSync.Width / tcSync.TabPages.Count) - 10, 40);

                InitSettings();
                InitForm();
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex, "Cannot open the application");
            }
        }

        private void frmSyncSettings_Load(object sender, EventArgs e)
        {
            ReloadForm();
        }

        private void InitForm()
        {
            gridMap.AutoGenerateColumns = false;
            gridMap.Columns[0].DataPropertyName = "SourceField";
            gridMap.Columns[1].DataPropertyName = "DestinationField";
        }

        private void btnLoadSetup_Click(object sender, EventArgs e)
        {
            try
            {
                openSettings.FileName = ConfigFileName;

                if (openSettings.ShowDialog() == DialogResult.OK)
                {
                    var settingsFilePath = openSettings.FileName;
                    _settings = SyncSettings.Deserialize(File.ReadAllText(settingsFilePath));

                    ReloadForm();
                    SaveSettings(_settings);

                    ShowSuccessfulMessage("Successfully loaded settings");
                    AuditLogger.Info("Successfully loaded settings file from {settingsFilePath}", settingsFilePath);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error loading settings file");

                Logger.Error(ex, "Exception loading settings file");
            }
        }

        private void btnVerifyAD_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveDirectoryUtility.SearchAllProp(txtADServer.Text.Trim(), txtUserName.Text.Trim(), 
                    txtPassword.Text.Trim(), txtADFilter.Text.Trim()).ToList();

                AuditLogger.Trace($"Verified AD connection: {txtADServer.Text},{txtADFilter.Text} using {txtUserName.Text}:{txtPassword.Text}");
                ShowSuccessfulMessage("Successfully connected to AD");
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error connecting to AD");

                Logger.Error(ex, "Exception getting AD properties");
            }
        }

        private void btnTestADWithFill_Click(object sender, EventArgs e)
        {
            try
            {
                _settings.ADProperties = ActiveDirectoryUtility.SearchAllProp(txtADServer.Text.Trim(), txtUserName.Text.Trim(), 
                    txtPassword.Text.Trim(), txtADFilter.Text.Trim()).ToList();
                _settings.Source = new SourceADDetails
                {
                    ConnectionString = txtADServer.Text.Trim(),
                    Filter = txtADFilter.Text.Trim(),
                    UserName = txtUserName.Text.Trim(),
                    EncryptedPassword = _encryptionService.Encrypt(txtPassword.Text.Trim()),
                };

                SaveSettings(_settings);
                AuditLogger.Info("Saved AD details and reloaded source properties");
                ReloadForm();

                ShowSuccessfulMessage("Successfully connected and synchronized source properties");
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error connecting to AD");

                Logger.Error(ex, "Exception getting AD properties");
            }
        }

        private void btnTestADConnection_Click(object sender, EventArgs e)
        {
            try
            {
                _settings.ADProperties = ActiveDirectoryUtility.SearchAllProp(txtADServer.Text.Trim(), txtUserName.Text.Trim()).ToList();
                _settings.Source = new SourceADDetails
                {
                    ConnectionString = txtADServer.Text.Trim(),
                    UserName = txtUserName.Text.Trim(),
                    EncryptedPassword = _encryptionService.Encrypt(txtPassword.Text.Trim()),
                };
                SaveSettings(_settings);
                ReloadForm();

                ShowSuccessfulMessage("Successfully connected and synchronized AD properties");
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error connecting to AD");

                Logger.Error(ex, "Exception getting AD properties");
            }
        }

        private void btnSyncADProp_Click(object sender, EventArgs e)
        {
            try
            {
                _settings.ADProperties = ActiveDirectoryUtility.SearchAllProp(txtUserName.Text.Trim()).ToList();
                _settings.Source = new SourceADDetails
                {
                    ConnectionString = txtADServer.Text.Trim(),
                    UserName = txtUserName.Text.Trim(),
                    EncryptedPassword = _encryptionService.Encrypt(txtPassword.Text.Trim()),
                };
                SaveSettings(_settings);
                ReloadForm();

                ShowSuccessfulMessage("Successfully connected and synchronized AD properties");
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error connecting to AD");

                Logger.Error(ex, "Exception getting AD properties");
            }
        }

        private void btnVerifyDBConnection_Click(object sender, EventArgs e)
        {
            var dbConnectionString = string.Format(DataAccess.DBConnectionStringFormat,
                                    txtDBServer.Text.Trim(),
                                    txtDBName.Text.Trim(),
                                    txtDBUser.Text.Trim(),
                                    txtDBPassword.Text.Trim());

            if (string.IsNullOrEmpty(dbConnectionString))
            {
                ShowErrorMessage("Invalid database details");
            }
            else
            {
                AuditLogger.Trace($"Verified DB connection: {txtDBServer.Text},{txtDBName.Text} using {txtDBUser.Text}:{txtDBPassword.Text}");

                if (DataAccess.TestConnectionToDBServer(_settings.Destination.DBType, dbConnectionString))
                {
                    ShowSuccessfulMessage("Successfully connected to database server");
                }
                else
                {
                    ShowErrorMessage("Error connecting to database server");
                }
            }
        }

        private void btnTestDBConnection_Click(object sender, EventArgs e)
        {
            var dbConnectionString = string.Format(DataAccess.DBConnectionStringFormat,
                                    txtDBServer.Text.Trim(),
                                    txtDBName.Text.Trim(),
                                    txtDBUser.Text.Trim(),
                                    txtDBPassword.Text.Trim());

            if (string.IsNullOrEmpty(dbConnectionString))
            {
                ShowErrorMessage("Invalid database details");
            }
            else
            {
                if (DataAccess.TestConnectionToDBServer(_settings.Destination.DBType, dbConnectionString))
                {
                    _settings.Destination = new DestinationDBDetails
                    {
                        Server = txtDBServer.Text.Trim(),
                        DBName = txtDBName.Text.Trim(),
                        UserName = txtDBUser.Text.Trim(),
                        EncryptedPassword = _encryptionService.Encrypt(txtDBPassword.Text.Trim()),
                    };

                    SaveSettings(_settings);
                    AuditLogger.Info("Saved DB connection details");
                    ShowSuccessfulMessage("Successfully connected and saved the database details");
                }
                else
                {
                    ShowErrorMessage("Error connecting to database server");
                }
            }
        }

        private void tcSync_Selecting(object sender, TabControlCancelEventArgs e)
        {
            var result = string.Empty;

            if (e.TabPageIndex > 0)
            {
                result = SyncUtil.ValidateSetup(_settings);
            }

            if (string.IsNullOrWhiteSpace(result) && e.TabPageIndex > 1)
            {
                result = SyncUtil.ValidateMappings(_settings);
            }

            if (!string.IsNullOrWhiteSpace(result))
            {
                e.Cancel = true;
                ShowErrorMessage(result);
            }
        }

        private void ShowSuccessfulMessage(string message)
        {
            MessageBox.Show(message, MessageCaption);
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSaveMapping_Click(object sender, EventArgs e)
        {
            var sourceField = cmbADProps.Text;
            var destinationField = cmbDBProps.Text;

            if (!(string.IsNullOrEmpty(sourceField) || string.IsNullOrEmpty(destinationField)))
            {
                var existingMap = _settings.Mappings.FirstOrDefault(m => m.DestinationField == destinationField);
                if (existingMap == null)
                {
                    _settings.Mappings.Add(new Mapping
                    {
                        SourceField = sourceField,
                        DestinationField = destinationField
                    });

                    AuditLogger.Info($"Added mapping for {destinationField} from {sourceField}");
                }
                else
                {
                    AuditLogger.Info($"Updating mapping of {destinationField} from {existingMap.SourceField} to {sourceField}");

                    existingMap.SourceField = sourceField;
                }

                SaveSettings(_settings);
                ReloadForm();
            }
        }

        //private void btnADFillUser_Click(object sender, EventArgs e)
        //{
        //    var adUserName = string.IsNullOrEmpty(_settings.Source.UserName) ? null : _settings.Source.UserName;
        //    var adUserPassword = string.IsNullOrEmpty(_settings.Source.EncryptedPassword) ? null : _encryptionService.Decrypt(_settings.Source.EncryptedPassword);
        //    var testADUser = txtADUser.Text.Trim();

        //    try
        //    {
        //        _settings.ADProperties = ActiveDirectoryUtility.SearchAllPropFromUser(_settings.Source.ConnectionString, adUserName, adUserPassword, testADUser).ToList();
        //        SaveSettings(_settings);
        //        ReloadForm();

        //        ShowSuccessfulMessage("Successfully synchronized AD properties");
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowErrorMessage(ex.Message);

        //        Logger.Error(ex, $"Exception getting AD properties for user: {testADUser}");
        //    }
        //}

        private void btnDeleteMapping_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridMap.SelectedRows)
            {
                var deleteMap = _settings.Mappings.FirstOrDefault(x => x.SourceField == row.Cells[0].Value);
                _settings.Mappings.Remove(deleteMap);
                AuditLogger.Info($"Deleted mapping for {deleteMap.DestinationField} from {deleteMap.SourceField}");
            }

            ReloadForm();
        }

        private void gridMap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = e.RowIndex;

            if (selectedRow >= 0)
            {
                cmbADProps.SelectedItem = _settings.Mappings[selectedRow].SourceField;
                cmbDBProps.SelectedItem = _settings.Mappings[selectedRow].DestinationField;
            }
        }

        private void btnPreviewData_Click(object sender, EventArgs e)
        {
            var errorMessage = SyncUtil.ValidateSettings(_settings);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                ShowErrorMessage(errorMessage);
                return;
            }

            try
            {
                var adUserName = string.IsNullOrEmpty(_settings.Source.UserName) ? null : _settings.Source.UserName;
                var adUserPassword = string.IsNullOrEmpty(_settings.Source.EncryptedPassword) ? null : _encryptionService.Decrypt(_settings.Source.EncryptedPassword);

                using var ad = new ActiveDirectoryUtility(_settings.Source.ConnectionString, adUserName, adUserPassword);

                var (data, totalRecords) = ad.PreviewUsers(_settings.Mappings, (int)txtPreviewRows.Value, _settings.Source.Filter);
                
                gridPreview.DataSource = data;
                
                AuditLogger.Trace($"Previewed {data.Rows.Count} of {totalRecords} users");
                ShowSuccessfulMessage($"Successfully read {data.Rows.Count} of {totalRecords} users");
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error previewing AD data");
                Logger.Error(ex, "Exception previewing AD data");
            }

        }

        private void btnSyncUser_Click(object sender, EventArgs e)
        {
            var adSyncUser = txtSyncUser.Text.Trim();

            if (string.IsNullOrEmpty(adSyncUser))
            {
                ShowErrorMessage("Specify AD user sAMAccount name");
                return;
            }

            var errorMessage = SyncUtil.ValidateSettings(_settings);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                ShowErrorMessage(errorMessage);
                return;
            }

            try
            {
                var adUserName = string.IsNullOrEmpty(_settings.Source.UserName) ? null : _settings.Source.UserName;
                var adUserPassword = string.IsNullOrEmpty(_settings.Source.EncryptedPassword) ? null : _encryptionService.Decrypt(_settings.Source.EncryptedPassword);
                using var ad = new ActiveDirectoryUtility(_settings.Source.ConnectionString, adUserName, adUserPassword);

                UpdateProgress($"Started reading AD data for user:{adSyncUser}");
                var result = ad.GetUser(adSyncUser, _settings.Mappings, _settings.Source.Filter);
                UpdateProgress($"Completed reading AD data for user:{adSyncUser}, found {result?.Count ?? 0} matches");

                if (result?.Count() == 1)
                {
                    var studentADData = result.First();

                    SyncUtil.SyncDB(SyncUtil.DBConnectionString(_settings, _encryptionService), _settings.Destination.DBType, studentADData, UpdateProgress);

                    UpdateProgress($"Sucessfully synchronized {adSyncUser}, with {studentADData.Value.Values?.Count ?? 0} properties");
                }
                else
                {
                    UpdateProgress($"Invalid result, found {result?.Count ?? 0} matches in AD for {adSyncUser}");
                }
            }
            catch (Exception ex)
            {
                UpdateProgress($"Exception sync AD user: {adSyncUser}");
                Logger.Error(ex, $"Exception sync AD user: {adSyncUser}");
            }
        }

        private void UpdateProgress(string message)
        {
            AuditLogger.Info(message);
            lstSyncResult.Items.Add(message);
        }

        private void btnSyncAll_Click(object sender, EventArgs e)
        {
            if(performSync.IsBusy) return;

            var errorMessage = SyncUtil.ValidateSettings(_settings);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                ShowErrorMessage(errorMessage);
                return;
            }

            btnSyncAll.Enabled = false;
            btnCancelSync.Enabled = true;

            performSync.RunWorkerAsync();
        }

        private void InitSettings()
        {
            var assemblyPath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            var settingsFilePath = Path.Combine(Path.GetDirectoryName(assemblyPath), ConfigFileName);

            if (File.Exists(settingsFilePath))
            {
                _settings = SyncSettings.Deserialize(File.ReadAllText(settingsFilePath));
            }
            else
            {
                _settings = new SyncSettings();
                var settings = _settings.Serialize();

                File.WriteAllText(settingsFilePath, settings);
            }
        }

        private void ReloadForm()
        {
            txtADServer.Text = _settings.Source.ConnectionString;
            txtADFilter.Text = _settings.Source.Filter;
            txtUserName.Text = _settings.Source.UserName;
            txtPassword.Text = _encryptionService.Decrypt(_settings.Source.EncryptedPassword);

            txtDBServer.Text = _settings.Destination.Server;
            txtDBName.Text = _settings.Destination.DBName;
            txtDBUser.Text = _settings.Destination.UserName;
            txtDBPassword.Text = _encryptionService.Decrypt(_settings.Destination.EncryptedPassword);

            cmbDBProps.Items.Clear();
            cmbDBProps.Items.AddRange(typeof(ImportableStudent).GetProperties()?.Select(p => p.Name)?.OrderBy(p => p)?.ToArray());

            cmbADProps.Items.Clear();
            cmbADProps.Items.AddRange(_settings.ADProperties.OrderBy(d => d).ToArray());

            var mapSource = new BindingSource();
            mapSource.DataSource = _settings.Mappings;
            gridMap.DataSource = mapSource;
        }

        private static void SaveSettings(SyncSettings settings)
        {
            var assemblyPath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            var settingsFilePath = Path.Combine(Path.GetDirectoryName(assemblyPath), ConfigFileName);

            File.WriteAllText(settingsFilePath, settings.Serialize());
        }

        private void performSync_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var adUserName = string.IsNullOrEmpty(_settings.Source.UserName) ? null : _settings.Source.UserName;
                var adUserPassword = string.IsNullOrEmpty(_settings.Source.EncryptedPassword) ? null : _encryptionService.Decrypt(_settings.Source.EncryptedPassword);
                using var ad = new ActiveDirectoryUtility(_settings.Source.ConnectionString, adUserName, adUserPassword);

                PercentProgress = 0;
                ReportProgress("Started reading AD data");
                var result = ad.GetAllUsers(_settings.Mappings, _settings.Source.Filter);
                ReportProgress($"Completed reading AD data, got {result?.Values.Count ?? 0} users");

                if (result?.Count() > 0)
                {
                    PercentProgress = 50;
                    ReportProgress($"Started sync to DB");
                    var dbConnectionString = SyncUtil.DBConnectionString(_settings, _encryptionService);

                    foreach (var studentADData in result.Select((user, i) => new { i, user }))
                    {
                        if (performSync.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        PercentProgress += studentADData.i / result.Values.Count * 40;
                        SyncUtil.SyncDB(dbConnectionString, _settings.Destination.DBType, studentADData.user, (m) => ReportProgress(m, 0));
                    }
                    
                    ReportProgress($"Completed sync to DB");

                    ReportProgress($"Started deactivating users");
                    var dataAccess = new DataAccess(_settings.Destination.DBType, dbConnectionString);
                    dataAccess.DeactivateUsers(result.Keys.ToList());
                    PercentProgress = 100;
                    ReportProgress($"Completed deactivating users");
                }
                else
                {
                    PercentProgress = 100;
                    ReportProgress($"No users found to sync to DB");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception sync AD");
                throw;
            }
        }

        private void performSync_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lstSyncResult.Items.Add(e.UserState as string);
            pgBarSync.Value = e.ProgressPercentage;
        }

        private void performSync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message;
            
            if (e.Error != null)
            {
                message = $"Sync completed with error, {e.Error.Message}";
            }
            else if (e.Cancelled)
            {
                message = "Sync cancelled";
            }
            else 
            {
                message = "Sync sucessfully completed";
            }

            AuditLogger.Info(message);
            lstSyncResult.Items.Add(message);

            pgBarSync.Value = 100;
            btnSyncAll.Enabled = true;
            btnCancelSync.Enabled = false;
        }

        private int PercentProgress { get; set; }

        private void ReportProgress(string message, int percentProgress = 0)
        {
            AuditLogger.Info(message);

            if(percentProgress > 0)
            {
                PercentProgress += percentProgress;
            }

            performSync.ReportProgress(PercentProgress, message);
        }

        private void btnCancelSync_Click(object sender, EventArgs e)
        {
            performSync.CancelAsync();
            btnCancelSync.Enabled = false;
        }
    }
}