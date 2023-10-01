using NLog;
using System;
using System.Configuration;
using System.DirectoryServices;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ADSynchronizer
{
    public partial class frmSyncSettings : Form
    {
        private const string MessageCaption = "AD Synchronizer";
        private const string ConfigFileName = "Settings.json";

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private SyncSettings _settings;

        public frmSyncSettings()
        {
            InitializeComponent();

            InitSettings();
            InitForm();
        }

        private void frmSyncSettings_Load(object sender, EventArgs e)
        {
            ReloadForm(_settings);
        }

        private void InitForm()
        {
            gridMap.AutoGenerateColumns = false;
            gridMap.Columns[0].DataPropertyName = "SourceField";
            gridMap.Columns[1].DataPropertyName = "DestinationField";
        }

        private void btnTestADConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
                {
                    MessageBox.Show(ActiveDirectoryUtility.TestConnectionToLdapServer(txtADServer.Text) ? "Working" : "Failed");
                }
                else
                {
                    MessageBox.Show(ActiveDirectoryUtility.TestConnectionToLdapServer(txtADServer.Text, txtUserName.Text, txtPassword.Text) ? "Working" : "Failed");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Exception caught:\n\n" + ex.ToString());
            }
        }

        private void btnADFill_Click(object sender, EventArgs e)
        {
            try
            {
                cmbADProps.Items.AddRange(ActiveDirectoryUtility.SearchAllProp(txtADServer.Text).ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                Logger.Error("Exception caught:\n\n" + ex.ToString());
            }
        }

        private void btnTestDBConnection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDBConnectionString.Text.Trim()))
            {
                ShowErrorMessage("Invalid DB connection details");
            }
            else
            {
                if (DataAccess.TestConnectionToDBServer(txtDBConnectionString.Text))
                {
                    ShowSuccessfulMessage("Successfully connected to database server");
                }
                else
                {
                    ShowErrorMessage("Error connecting to database server");
                }
            }
        }

        private void tcSync_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
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

        private void btnSaveSetup_Click(object sender, EventArgs e)
        {
            _settings.Source = new SourceADDetails
            {
                ConnectionString = txtADServer.Text,
                UserName = txtUserName.Text,
                EncryptedPassword = txtPassword.Text,
            };

            _settings.Destination = new DestinationDBDetails
            {
                ConnectionString = txtADServer.Text,
            };

            SaveSettings(_settings);
            ShowSuccessfulMessage("Successfully saved connection details");
        }

        private void btnSaveMapping_Click(object sender, EventArgs e)
        {
            var sourceField = cmbADProps.Text;
            var destinationField = cmbDBProps.Text;

            if (!(string.IsNullOrEmpty(sourceField) || string.IsNullOrEmpty(destinationField)))
            {
                var existingMap = _settings.Mappings.FirstOrDefault(m => m.SourceField == sourceField);
                if (existingMap == null)
                {
                    _settings.Mappings.Add(new Mapping
                    {
                        SourceField = sourceField,
                        DestinationField = destinationField
                    });
                }
                else
                {
                    existingMap.DestinationField = destinationField;
                }

                SaveSettings(_settings);
                ReloadForm(_settings);
                ShowSuccessfulMessage("Successfully added mapping");
            }
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

        private void ReloadForm(SyncSettings settings)
        {
            txtADServer.Text = settings.Source.ConnectionString;
            txtUserName.Text = settings.Source.UserName;
            txtPassword.Text = settings.Source.EncryptedPassword;

            txtADServer.Text = settings.Destination.ConnectionString;

            cmbDBProps.Items.Clear();
            cmbDBProps.Items.AddRange(typeof(ImportableUser).GetProperties()?.Select(p => p.Name)?.ToArray());

            cmbADProps.Items.Clear();
            cmbADProps.Items.AddRange(settings.ADProperties.ToArray());

            var mapSource = new BindingSource();
            mapSource.DataSource = settings.Mappings;
            gridMap.DataSource = mapSource;
        }

        private void SaveSettings(SyncSettings settings)
        {
            var assemblyPath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            var settingsFilePath = Path.Combine(Path.GetDirectoryName(assemblyPath), ConfigFileName);

            File.WriteAllText(settingsFilePath, settings.Serialize());
        }

        private void btnADFillUser_Click(object sender, EventArgs e)
        {
            try
            {
                var adUserName = string.IsNullOrEmpty(txtUserName.Text.Trim()) ? null : txtUserName.Text;
                var adUserPassword = string.IsNullOrEmpty(txtPassword.Text.Trim()) ? null : txtPassword.Text;
                var testADUser = txtADUser.Text.Trim();

                _settings.ADProperties = ActiveDirectoryUtility.SearchAllPropFromUser(txtADServer.Text, adUserName, adUserPassword, testADUser).ToList();
                SaveSettings(_settings);
                ReloadForm(_settings);

                ShowSuccessfulMessage("Successfully synchronize AD properties");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);

                Logger.Error("Exception caught:\n\n" + ex.ToString());
            }
        }

        private void btnDeleteMapping_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridMap.SelectedRows)
            {
                var deleteMap = _settings.Mappings.FirstOrDefault(x => x.SourceField == row.Cells[0].Value);
                _settings.Mappings.Remove(deleteMap);
            }

            ReloadForm(_settings);
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

        private void btnSyncUser_Click(object sender, EventArgs e)
        {
            var adSyncUser = txtSyncUser.Text.Trim();

            if (_settings.Source?.ConnectionString == null)
            {
                ShowErrorMessage("Verify AD details");
                return;
            }
            
            if (_settings.Destination?.ConnectionString == null)
            {
                ShowErrorMessage("Verify DB details");
                return;
            }

            if (!_settings.Mappings.Any())
            {
                ShowErrorMessage("Verify Mappings");
                return;
            }

            if (string.IsNullOrEmpty(adSyncUser))
            {
                ShowErrorMessage("Specify AD user sam account name");
                return;
            }

            var sourceADProps = _settings.Mappings.Select(m => m.SourceField).ToList();
            Func<SearchResult, ImportableUser> mapADUser = result => {
                return new ImportableUser
                {
                    DistiguishedName = _settings.Mappings.Any(m => m.DestinationField == "DistiguishedName") ?
                    result.Properties[_settings.Mappings.First(m => m.DestinationField == "DistiguishedName").SourceField][0].ToString()
                    : null,
                };
            };

            try
            {
                using var ad = new ActiveDirectoryUtility(_settings.Source.ConnectionString, _settings.Source.UserName, _settings.Source.EncryptedPassword);
                var user = ad.GetUserBySamAccountName(adSyncUser, sourceADProps, mapADUser);

                ShowSuccessfulMessage($"Got {user.DistiguishedName}");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.ToString());    
            }
        }
    }
}