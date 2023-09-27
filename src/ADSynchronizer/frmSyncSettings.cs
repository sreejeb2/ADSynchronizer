using NLog;
using System.Configuration;
using System.DirectoryServices;
using System.Runtime.CompilerServices;

namespace ADSynchronizer
{
    public partial class frmSyncSettings : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public frmSyncSettings()
        {
            InitializeComponent();
        }

        private void btnTestADConnection_Click(object sender, EventArgs e)
        {
            try
            {
                //var syncSettings = SyncSettings.FromConfiguration(Configuration);
                //ldapConnection.Path = "LDAP://OU=staffusers,DC=leeds-art,DC=ac,DC=uk";

                if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
                {
                    MessageBox.Show(ActiveDirectoryUtility.TestConnectionToLdapServer(txtADServer.Text) ? "Working" : "Failed");
                }
                else
                {
                    MessageBox.Show(ActiveDirectoryUtility.TestConnectionToLdapServer(txtADServer.Text, txtUserName.Text, txtPassword.Text) ? "Working" : "Failed");
                }

                //using (var ad = new ActiveDirectoryUtility(txtADServer.Text))
                //{
                //    foreach (var user in ad.FindUsers("sree"))
                //    {
                //        Console.WriteLine(string.Format("{0,-20} : {1}", user.DisplayName, user.Email));
                //    } 
                //}
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

        }

        private void tcSync_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
            }
        }
    }
}