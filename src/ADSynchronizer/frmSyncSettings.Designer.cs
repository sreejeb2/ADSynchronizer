namespace ADSynchronizer
{
    partial class frmSyncSettings
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbADProps = new System.Windows.Forms.ComboBox();
            this.btnADFill = new System.Windows.Forms.Button();
            this.tcSync = new System.Windows.Forms.TabControl();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTestDBConnection = new System.Windows.Forms.Button();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtADServer = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnTestADConnection = new System.Windows.Forms.Button();
            this.tabMapping = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.tcSync.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpSource.SuspendLayout();
            this.tabMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbADProps
            // 
            this.cmbADProps.FormattingEnabled = true;
            this.cmbADProps.Location = new System.Drawing.Point(439, 1261);
            this.cmbADProps.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbADProps.Name = "cmbADProps";
            this.cmbADProps.Size = new System.Drawing.Size(497, 49);
            this.cmbADProps.TabIndex = 1;
            // 
            // btnADFill
            // 
            this.btnADFill.Location = new System.Drawing.Point(1578, 1270);
            this.btnADFill.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnADFill.Name = "btnADFill";
            this.btnADFill.Size = new System.Drawing.Size(357, 74);
            this.btnADFill.TabIndex = 2;
            this.btnADFill.Text = "Fill";
            this.btnADFill.UseVisualStyleBackColor = true;
            this.btnADFill.Click += new System.EventHandler(this.btnADFill_Click);
            // 
            // tcSync
            // 
            this.tcSync.Controls.Add(this.tabSetup);
            this.tcSync.Controls.Add(this.tabMapping);
            this.tcSync.Controls.Add(this.tabReport);
            this.tcSync.Location = new System.Drawing.Point(12, 12);
            this.tcSync.Name = "tcSync";
            this.tcSync.SelectedIndex = 0;
            this.tcSync.Size = new System.Drawing.Size(2448, 990);
            this.tcSync.TabIndex = 3;
            this.tcSync.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcSync_Selecting);
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.groupBox1);
            this.tabSetup.Controls.Add(this.grpSource);
            this.tabSetup.Location = new System.Drawing.Point(10, 58);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(2428, 922);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTestDBConnection);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(1292, 88);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(1042, 731);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destination";
            // 
            // btnTestDBConnection
            // 
            this.btnTestDBConnection.Location = new System.Drawing.Point(677, 614);
            this.btnTestDBConnection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTestDBConnection.Name = "btnTestDBConnection";
            this.btnTestDBConnection.Size = new System.Drawing.Size(313, 80);
            this.btnTestDBConnection.TabIndex = 2;
            this.btnTestDBConnection.Text = "Test DB Connection";
            this.btnTestDBConnection.UseVisualStyleBackColor = true;
            this.btnTestDBConnection.Click += new System.EventHandler(this.btnTestDBConnection_Click);
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.label3);
            this.grpSource.Controls.Add(this.label2);
            this.grpSource.Controls.Add(this.label1);
            this.grpSource.Controls.Add(this.txtPassword);
            this.grpSource.Controls.Add(this.txtADServer);
            this.grpSource.Controls.Add(this.txtUserName);
            this.grpSource.Controls.Add(this.btnTestADConnection);
            this.grpSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpSource.Location = new System.Drawing.Point(100, 88);
            this.grpSource.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grpSource.Name = "grpSource";
            this.grpSource.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grpSource.Size = new System.Drawing.Size(1042, 731);
            this.grpSource.TabIndex = 2;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 41);
            this.label3.TabIndex = 7;
            this.label3.Text = "Domain Controller Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 41);
            this.label2.TabIndex = 6;
            this.label2.Text = "User Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 41);
            this.label1.TabIndex = 5;
            this.label1.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(32, 514);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(958, 47);
            this.txtPassword.TabIndex = 4;
            // 
            // txtADServer
            // 
            this.txtADServer.Location = new System.Drawing.Point(32, 124);
            this.txtADServer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtADServer.Multiline = true;
            this.txtADServer.Name = "txtADServer";
            this.txtADServer.Size = new System.Drawing.Size(958, 156);
            this.txtADServer.TabIndex = 1;
            this.txtADServer.Text = "LDAP://flipgroup.com.au,OU=Users,OU=Melbourne,OU=Victoria,DC=flipgroup,DC=com,DC=" +
    "au";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(32, 370);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(958, 47);
            this.txtUserName.TabIndex = 3;
            // 
            // btnTestADConnection
            // 
            this.btnTestADConnection.Location = new System.Drawing.Point(677, 614);
            this.btnTestADConnection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTestADConnection.Name = "btnTestADConnection";
            this.btnTestADConnection.Size = new System.Drawing.Size(313, 80);
            this.btnTestADConnection.TabIndex = 2;
            this.btnTestADConnection.Text = "Test AD Connection";
            this.btnTestADConnection.UseVisualStyleBackColor = true;
            this.btnTestADConnection.Click += new System.EventHandler(this.btnTestADConnection_Click);
            // 
            // tabMapping
            // 
            this.tabMapping.Controls.Add(this.dataGridView1);
            this.tabMapping.Location = new System.Drawing.Point(10, 58);
            this.tabMapping.Name = "tabMapping";
            this.tabMapping.Padding = new System.Windows.Forms.Padding(3);
            this.tabMapping.Size = new System.Drawing.Size(2428, 922);
            this.tabMapping.TabIndex = 1;
            this.tabMapping.Text = "Mapping";
            this.tabMapping.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(58, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 102;
            this.dataGridView1.RowTemplate.Height = 49;
            this.dataGridView1.Size = new System.Drawing.Size(1417, 821);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabReport
            // 
            this.tabReport.Location = new System.Drawing.Point(10, 58);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(2428, 922);
            this.tabReport.TabIndex = 2;
            this.tabReport.Text = "Reports";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // frmSyncSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2472, 1418);
            this.Controls.Add(this.tcSync);
            this.Controls.Add(this.btnADFill);
            this.Controls.Add(this.cmbADProps);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmSyncSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AD Synchronizer";
            this.tcSync.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            this.tabMapping.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComboBox cmbADProps;
        private Button btnADFill;
        private TabControl tcSync;
        private TabPage tabSetup;
        private GroupBox groupBox1;
        private Button btnTestDBConnection;
        private GroupBox grpSource;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtADServer;
        private TextBox txtUserName;
        private Button btnTestADConnection;
        private TabPage tabMapping;
        private TabPage tabReport;
        private DataGridView dataGridView1;
    }
}