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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSyncSettings));
            this.cmbADProps = new System.Windows.Forms.ComboBox();
            this.tcSync = new System.Windows.Forms.TabControl();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.btnSaveSetup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTestDBConnection = new System.Windows.Forms.Button();
            this.txtDBConnectionString = new System.Windows.Forms.TextBox();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtADServer = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnTestADConnection = new System.Windows.Forms.Button();
            this.tabMapping = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSyncUser = new System.Windows.Forms.Button();
            this.txtSyncUser = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDeleteMapping = new System.Windows.Forms.Button();
            this.btnSaveMapping = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDBProps = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.btnADFillUser = new System.Windows.Forms.Button();
            this.txtADUser = new System.Windows.Forms.TextBox();
            this.gridMap = new System.Windows.Forms.DataGridView();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSync = new System.Windows.Forms.TabPage();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.tcSync.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpSource.SuspendLayout();
            this.tabMapping.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMap)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbADProps
            // 
            this.cmbADProps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbADProps.FormattingEnabled = true;
            this.cmbADProps.Items.AddRange(new object[] {
            "UserID",
            "UserName",
            "CardNo"});
            this.cmbADProps.Location = new System.Drawing.Point(40, 65);
            this.cmbADProps.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbADProps.Name = "cmbADProps";
            this.cmbADProps.Size = new System.Drawing.Size(604, 49);
            this.cmbADProps.TabIndex = 1;
            // 
            // tcSync
            // 
            this.tcSync.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcSync.Controls.Add(this.tabSetup);
            this.tcSync.Controls.Add(this.tabMapping);
            this.tcSync.Controls.Add(this.tabSync);
            this.tcSync.Controls.Add(this.tabReport);
            this.tcSync.Location = new System.Drawing.Point(12, 11);
            this.tcSync.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tcSync.Name = "tcSync";
            this.tcSync.SelectedIndex = 0;
            this.tcSync.Size = new System.Drawing.Size(2448, 1047);
            this.tcSync.TabIndex = 3;
            this.tcSync.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcSync_Selecting);
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.btnSaveSetup);
            this.tabSetup.Controls.Add(this.groupBox1);
            this.tabSetup.Controls.Add(this.grpSource);
            this.tabSetup.Location = new System.Drawing.Point(4, 53);
            this.tabSetup.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabSetup.Size = new System.Drawing.Size(2440, 990);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // btnSaveSetup
            // 
            this.btnSaveSetup.Location = new System.Drawing.Point(2076, 853);
            this.btnSaveSetup.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSaveSetup.Name = "btnSaveSetup";
            this.btnSaveSetup.Size = new System.Drawing.Size(257, 96);
            this.btnSaveSetup.TabIndex = 4;
            this.btnSaveSetup.Text = "Save";
            this.btnSaveSetup.UseVisualStyleBackColor = true;
            this.btnSaveSetup.Click += new System.EventHandler(this.btnSaveSetup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnTestDBConnection);
            this.groupBox1.Controls.Add(this.txtDBConnectionString);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(1292, 87);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(1042, 730);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destination";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 41);
            this.label4.TabIndex = 9;
            this.label4.Text = "DB Connection";
            // 
            // btnTestDBConnection
            // 
            this.btnTestDBConnection.Location = new System.Drawing.Point(678, 615);
            this.btnTestDBConnection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTestDBConnection.Name = "btnTestDBConnection";
            this.btnTestDBConnection.Size = new System.Drawing.Size(313, 79);
            this.btnTestDBConnection.TabIndex = 2;
            this.btnTestDBConnection.Text = "Test DB Connection";
            this.btnTestDBConnection.UseVisualStyleBackColor = true;
            this.btnTestDBConnection.Click += new System.EventHandler(this.btnTestDBConnection_Click);
            // 
            // txtDBConnectionString
            // 
            this.txtDBConnectionString.Location = new System.Drawing.Point(32, 123);
            this.txtDBConnectionString.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDBConnectionString.Multiline = true;
            this.txtDBConnectionString.Name = "txtDBConnectionString";
            this.txtDBConnectionString.Size = new System.Drawing.Size(958, 436);
            this.txtDBConnectionString.TabIndex = 8;
            this.txtDBConnectionString.Text = resources.GetString("txtDBConnectionString.Text");
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
            this.grpSource.Location = new System.Drawing.Point(100, 87);
            this.grpSource.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grpSource.Name = "grpSource";
            this.grpSource.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grpSource.Size = new System.Drawing.Size(1042, 730);
            this.grpSource.TabIndex = 2;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 41);
            this.label3.TabIndex = 7;
            this.label3.Text = "Domain Controller Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 306);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 41);
            this.label2.TabIndex = 6;
            this.label2.Text = "User Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 446);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.txtPassword.Text = "password";
            // 
            // txtADServer
            // 
            this.txtADServer.Location = new System.Drawing.Point(32, 123);
            this.txtADServer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtADServer.Multiline = true;
            this.txtADServer.Name = "txtADServer";
            this.txtADServer.Size = new System.Drawing.Size(958, 157);
            this.txtADServer.TabIndex = 1;
            this.txtADServer.Text = "LDAP://ldap.forumsys.com:389/dc=example,dc=com";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(32, 369);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(958, 47);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.Text = "cn=read-only-admin,dc=example,dc=com";
            // 
            // btnTestADConnection
            // 
            this.btnTestADConnection.Location = new System.Drawing.Point(678, 615);
            this.btnTestADConnection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTestADConnection.Name = "btnTestADConnection";
            this.btnTestADConnection.Size = new System.Drawing.Size(313, 79);
            this.btnTestADConnection.TabIndex = 2;
            this.btnTestADConnection.Text = "Test AD Connection";
            this.btnTestADConnection.UseVisualStyleBackColor = true;
            this.btnTestADConnection.Click += new System.EventHandler(this.btnTestADConnection_Click);
            // 
            // tabMapping
            // 
            this.tabMapping.Controls.Add(this.groupBox2);
            this.tabMapping.Controls.Add(this.tabControl1);
            this.tabMapping.Controls.Add(this.gridMap);
            this.tabMapping.Location = new System.Drawing.Point(4, 53);
            this.tabMapping.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabMapping.Name = "tabMapping";
            this.tabMapping.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabMapping.Size = new System.Drawing.Size(2440, 990);
            this.tabMapping.TabIndex = 1;
            this.tabMapping.Text = "Mapping";
            this.tabMapping.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnSyncUser);
            this.groupBox2.Controls.Add(this.txtSyncUser);
            this.groupBox2.Location = new System.Drawing.Point(1454, 490);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(924, 382);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Verify AD Sync";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 41);
            this.label8.TabIndex = 4;
            this.label8.Text = "Sync AD User";
            // 
            // btnSyncUser
            // 
            this.btnSyncUser.Location = new System.Drawing.Point(59, 213);
            this.btnSyncUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSyncUser.Name = "btnSyncUser";
            this.btnSyncUser.Size = new System.Drawing.Size(248, 76);
            this.btnSyncUser.TabIndex = 2;
            this.btnSyncUser.Text = "Sync User";
            this.btnSyncUser.UseVisualStyleBackColor = true;
            this.btnSyncUser.Click += new System.EventHandler(this.btnSyncUser_Click);
            // 
            // txtSyncUser
            // 
            this.txtSyncUser.Location = new System.Drawing.Point(59, 124);
            this.txtSyncUser.Name = "txtSyncUser";
            this.txtSyncUser.Size = new System.Drawing.Size(382, 47);
            this.txtSyncUser.TabIndex = 3;
            this.txtSyncUser.Text = "riemann";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1463, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(925, 406);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDeleteMapping);
            this.tabPage1.Controls.Add(this.btnSaveMapping);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.cmbADProps);
            this.tabPage1.Controls.Add(this.cmbDBProps);
            this.tabPage1.Location = new System.Drawing.Point(10, 58);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(905, 338);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Mapping";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMapping
            // 
            this.btnDeleteMapping.Location = new System.Drawing.Point(402, 237);
            this.btnDeleteMapping.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnDeleteMapping.Name = "btnDeleteMapping";
            this.btnDeleteMapping.Size = new System.Drawing.Size(242, 90);
            this.btnDeleteMapping.TabIndex = 4;
            this.btnDeleteMapping.Text = "Delete Mapping";
            this.btnDeleteMapping.UseVisualStyleBackColor = true;
            this.btnDeleteMapping.Click += new System.EventHandler(this.btnDeleteMapping_Click);
            // 
            // btnSaveMapping
            // 
            this.btnSaveMapping.Location = new System.Drawing.Point(40, 237);
            this.btnSaveMapping.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnSaveMapping.Name = "btnSaveMapping";
            this.btnSaveMapping.Size = new System.Drawing.Size(228, 90);
            this.btnSaveMapping.TabIndex = 4;
            this.btnSaveMapping.Text = "Save Mapping";
            this.btnSaveMapping.UseVisualStyleBackColor = true;
            this.btnSaveMapping.Click += new System.EventHandler(this.btnSaveMapping_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 41);
            this.label5.TabIndex = 3;
            this.label5.Text = "Source Field";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 117);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 41);
            this.label6.TabIndex = 3;
            this.label6.Text = "Destination Field";
            // 
            // cmbDBProps
            // 
            this.cmbDBProps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDBProps.FormattingEnabled = true;
            this.cmbDBProps.Items.AddRange(new object[] {
            "UserID",
            "UserName",
            "CardNo"});
            this.cmbDBProps.Location = new System.Drawing.Point(40, 161);
            this.cmbDBProps.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbDBProps.Name = "cmbDBProps";
            this.cmbDBProps.Size = new System.Drawing.Size(604, 49);
            this.cmbDBProps.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnADFillUser);
            this.tabPage2.Controls.Add(this.txtADUser);
            this.tabPage2.Location = new System.Drawing.Point(10, 58);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(905, 338);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sync AD Properties";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 41);
            this.label7.TabIndex = 4;
            this.label7.Text = "Test AD User";
            // 
            // btnADFillUser
            // 
            this.btnADFillUser.Location = new System.Drawing.Point(63, 190);
            this.btnADFillUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnADFillUser.Name = "btnADFillUser";
            this.btnADFillUser.Size = new System.Drawing.Size(248, 76);
            this.btnADFillUser.TabIndex = 2;
            this.btnADFillUser.Text = "Sync Properties";
            this.btnADFillUser.UseVisualStyleBackColor = true;
            this.btnADFillUser.Click += new System.EventHandler(this.btnADFillUser_Click);
            // 
            // txtADUser
            // 
            this.txtADUser.Location = new System.Drawing.Point(63, 95);
            this.txtADUser.Name = "txtADUser";
            this.txtADUser.Size = new System.Drawing.Size(382, 47);
            this.txtADUser.TabIndex = 3;
            this.txtADUser.Text = "riemann";
            // 
            // gridMap
            // 
            this.gridMap.AllowUserToAddRows = false;
            this.gridMap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Source,
            this.Destination});
            this.gridMap.Location = new System.Drawing.Point(58, 52);
            this.gridMap.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridMap.Name = "gridMap";
            this.gridMap.RowHeadersWidth = 102;
            this.gridMap.RowTemplate.Height = 49;
            this.gridMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMap.Size = new System.Drawing.Size(1365, 820);
            this.gridMap.TabIndex = 0;
            this.gridMap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMap_CellClick);
            // 
            // Source
            // 
            this.Source.HeaderText = "Source Field";
            this.Source.MinimumWidth = 12;
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Destination
            // 
            this.Destination.HeaderText = "Destination Field";
            this.Destination.MinimumWidth = 12;
            this.Destination.Name = "Destination";
            this.Destination.ReadOnly = true;
            this.Destination.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Destination.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabSync
            // 
            this.tabSync.Location = new System.Drawing.Point(4, 53);
            this.tabSync.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabSync.Name = "tabSync";
            this.tabSync.Size = new System.Drawing.Size(2440, 990);
            this.tabSync.TabIndex = 3;
            this.tabSync.Text = "Synchronization";
            this.tabSync.UseVisualStyleBackColor = true;
            // 
            // tabReport
            // 
            this.tabReport.Location = new System.Drawing.Point(4, 53);
            this.tabReport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabReport.Size = new System.Drawing.Size(2440, 990);
            this.tabReport.TabIndex = 2;
            this.tabReport.Text = "Reports";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // frmSyncSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2472, 1085);
            this.Controls.Add(this.tcSync);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmSyncSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AD Synchronizer";
            this.Load += new System.EventHandler(this.frmSyncSettings_Load);
            this.tcSync.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            this.tabMapping.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComboBox cmbADProps;
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
        private DataGridView gridMap;
        private Button btnSaveSetup;
        private TabPage tabSync;
        private Label label4;
        private TextBox txtDBConnectionString;
        private Button btnSaveMapping;
        private Label label6;
        private Label label5;
        private ComboBox cmbDBProps;
        private DataGridViewTextBoxColumn Source;
        private DataGridViewTextBoxColumn Destination;
        private Button btnADFillUser;
        private Label label7;
        private TextBox txtADUser;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnDeleteMapping;
        private GroupBox groupBox2;
        private Label label8;
        private TextBox txtSyncUser;
        private Button btnSyncUser;
    }
}