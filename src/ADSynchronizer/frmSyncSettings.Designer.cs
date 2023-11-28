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
            this.tcSync = new System.Windows.Forms.TabControl();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.btnLoadSetup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnVerifyDBConnection = new System.Windows.Forms.Button();
            this.btnTestDBConnection = new System.Windows.Forms.Button();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtADServer = new System.Windows.Forms.TextBox();
            this.txtADFilter = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnVerifyAD = new System.Windows.Forms.Button();
            this.btnTestADWithFill = new System.Windows.Forms.Button();
            this.btnSyncADProp = new System.Windows.Forms.Button();
            this.btnTestADConnection = new System.Windows.Forms.Button();
            this.tabMapping = new System.Windows.Forms.TabPage();
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
            this.tabPreview = new System.Windows.Forms.TabPage();
            this.gridPreview = new System.Windows.Forms.DataGridView();
            this.txtPreviewRows = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPreviewData = new System.Windows.Forms.Button();
            this.tabSync = new System.Windows.Forms.TabPage();
            this.lstSyncResult = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pgBarSync = new System.Windows.Forms.ProgressBar();
            this.btnCancelSync = new System.Windows.Forms.Button();
            this.btnSyncAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSyncUser = new System.Windows.Forms.Button();
            this.txtSyncUser = new System.Windows.Forms.TextBox();
            this.performSync = new System.ComponentModel.BackgroundWorker();
            this.openSettings = new System.Windows.Forms.OpenFileDialog();
            this.tcSync.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpSource.SuspendLayout();
            this.tabMapping.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMap)).BeginInit();
            this.tabPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreviewRows)).BeginInit();
            this.tabSync.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbADProps
            // 
            this.cmbADProps.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbADProps.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbADProps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbADProps.FormattingEnabled = true;
            this.cmbADProps.Items.AddRange(new object[] {
            "UserID",
            "UserName",
            "CardNo"});
            this.cmbADProps.Location = new System.Drawing.Point(16, 54);
            this.cmbADProps.Margin = new System.Windows.Forms.Padding(1);
            this.cmbADProps.Name = "cmbADProps";
            this.cmbADProps.Size = new System.Drawing.Size(269, 23);
            this.cmbADProps.TabIndex = 1;
            // 
            // tcSync
            // 
            this.tcSync.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcSync.Controls.Add(this.tabSetup);
            this.tcSync.Controls.Add(this.tabMapping);
            this.tcSync.Controls.Add(this.tabPreview);
            this.tcSync.Controls.Add(this.tabSync);
            this.tcSync.Location = new System.Drawing.Point(5, 4);
            this.tcSync.Margin = new System.Windows.Forms.Padding(1);
            this.tcSync.Name = "tcSync";
            this.tcSync.SelectedIndex = 0;
            this.tcSync.Size = new System.Drawing.Size(926, 393);
            this.tcSync.TabIndex = 3;
            this.tcSync.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcSync_Selecting);
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.btnLoadSetup);
            this.tabSetup.Controls.Add(this.groupBox1);
            this.tabSetup.Controls.Add(this.grpSource);
            this.tabSetup.Location = new System.Drawing.Point(4, 27);
            this.tabSetup.Margin = new System.Windows.Forms.Padding(1);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(1);
            this.tabSetup.Size = new System.Drawing.Size(918, 362);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // btnLoadSetup
            // 
            this.btnLoadSetup.Location = new System.Drawing.Point(41, 313);
            this.btnLoadSetup.Margin = new System.Windows.Forms.Padding(1);
            this.btnLoadSetup.Name = "btnLoadSetup";
            this.btnLoadSetup.Size = new System.Drawing.Size(106, 35);
            this.btnLoadSetup.TabIndex = 4;
            this.btnLoadSetup.Text = "Load Settings";
            this.btnLoadSetup.UseVisualStyleBackColor = true;
            this.btnLoadSetup.Click += new System.EventHandler(this.btnLoadSetup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnVerifyDBConnection);
            this.groupBox1.Controls.Add(this.btnTestDBConnection);
            this.groupBox1.Controls.Add(this.txtDBPassword);
            this.groupBox1.Controls.Add(this.txtDBName);
            this.groupBox1.Controls.Add(this.txtDBServer);
            this.groupBox1.Controls.Add(this.txtDBUser);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(500, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(405, 267);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destination";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 75);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Database Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 126);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 15);
            this.label12.TabIndex = 6;
            this.label12.Text = "User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Server";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 176);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Password";
            // 
            // btnVerifyDBConnection
            // 
            this.btnVerifyDBConnection.Location = new System.Drawing.Point(13, 225);
            this.btnVerifyDBConnection.Margin = new System.Windows.Forms.Padding(1);
            this.btnVerifyDBConnection.Name = "btnVerifyDBConnection";
            this.btnVerifyDBConnection.Size = new System.Drawing.Size(129, 29);
            this.btnVerifyDBConnection.TabIndex = 2;
            this.btnVerifyDBConnection.Text = "Verify";
            this.btnVerifyDBConnection.UseVisualStyleBackColor = true;
            this.btnVerifyDBConnection.Click += new System.EventHandler(this.btnVerifyDBConnection_Click);
            // 
            // btnTestDBConnection
            // 
            this.btnTestDBConnection.Location = new System.Drawing.Point(252, 225);
            this.btnTestDBConnection.Margin = new System.Windows.Forms.Padding(1);
            this.btnTestDBConnection.Name = "btnTestDBConnection";
            this.btnTestDBConnection.Size = new System.Drawing.Size(129, 29);
            this.btnTestDBConnection.TabIndex = 2;
            this.btnTestDBConnection.Text = "Test && Save";
            this.btnTestDBConnection.UseVisualStyleBackColor = true;
            this.btnTestDBConnection.Click += new System.EventHandler(this.btnTestDBConnection_Click);
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Location = new System.Drawing.Point(13, 192);
            this.txtDBPassword.Margin = new System.Windows.Forms.Padding(1);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.PasswordChar = '*';
            this.txtDBPassword.Size = new System.Drawing.Size(368, 23);
            this.txtDBPassword.TabIndex = 4;
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(13, 91);
            this.txtDBName.Margin = new System.Windows.Forms.Padding(1);
            this.txtDBName.Multiline = true;
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(368, 25);
            this.txtDBName.TabIndex = 8;
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(13, 40);
            this.txtDBServer.Margin = new System.Windows.Forms.Padding(1);
            this.txtDBServer.Multiline = true;
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(368, 25);
            this.txtDBServer.TabIndex = 8;
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(13, 142);
            this.txtDBUser.Margin = new System.Windows.Forms.Padding(1);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(368, 23);
            this.txtDBUser.TabIndex = 3;
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.label3);
            this.grpSource.Controls.Add(this.label13);
            this.grpSource.Controls.Add(this.label2);
            this.grpSource.Controls.Add(this.label1);
            this.grpSource.Controls.Add(this.txtPassword);
            this.grpSource.Controls.Add(this.txtADServer);
            this.grpSource.Controls.Add(this.txtADFilter);
            this.grpSource.Controls.Add(this.txtUserName);
            this.grpSource.Controls.Add(this.btnVerifyAD);
            this.grpSource.Controls.Add(this.btnTestADWithFill);
            this.grpSource.Controls.Add(this.btnSyncADProp);
            this.grpSource.Controls.Add(this.btnTestADConnection);
            this.grpSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpSource.Location = new System.Drawing.Point(41, 32);
            this.grpSource.Margin = new System.Windows.Forms.Padding(1);
            this.grpSource.Name = "grpSource";
            this.grpSource.Padding = new System.Windows.Forms.Padding(1);
            this.grpSource.Size = new System.Drawing.Size(429, 267);
            this.grpSource.TabIndex = 2;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Domain Controller Path";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 75);
            this.label13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "Additional Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "User Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 176);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(13, 192);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(1);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(397, 23);
            this.txtPassword.TabIndex = 4;
            // 
            // txtADServer
            // 
            this.txtADServer.Location = new System.Drawing.Point(13, 40);
            this.txtADServer.Margin = new System.Windows.Forms.Padding(1);
            this.txtADServer.Multiline = true;
            this.txtADServer.Name = "txtADServer";
            this.txtADServer.Size = new System.Drawing.Size(397, 25);
            this.txtADServer.TabIndex = 1;
            // 
            // txtADFilter
            // 
            this.txtADFilter.Location = new System.Drawing.Point(13, 93);
            this.txtADFilter.Margin = new System.Windows.Forms.Padding(1);
            this.txtADFilter.Name = "txtADFilter";
            this.txtADFilter.Size = new System.Drawing.Size(397, 23);
            this.txtADFilter.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(13, 142);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(1);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(397, 23);
            this.txtUserName.TabIndex = 3;
            // 
            // btnVerifyAD
            // 
            this.btnVerifyAD.Location = new System.Drawing.Point(13, 225);
            this.btnVerifyAD.Margin = new System.Windows.Forms.Padding(1);
            this.btnVerifyAD.Name = "btnVerifyAD";
            this.btnVerifyAD.Size = new System.Drawing.Size(129, 29);
            this.btnVerifyAD.TabIndex = 2;
            this.btnVerifyAD.Text = "Verify";
            this.btnVerifyAD.UseVisualStyleBackColor = true;
            this.btnVerifyAD.Click += new System.EventHandler(this.btnVerifyAD_Click);
            // 
            // btnTestADWithFill
            // 
            this.btnTestADWithFill.Location = new System.Drawing.Point(281, 225);
            this.btnTestADWithFill.Margin = new System.Windows.Forms.Padding(1);
            this.btnTestADWithFill.Name = "btnTestADWithFill";
            this.btnTestADWithFill.Size = new System.Drawing.Size(129, 29);
            this.btnTestADWithFill.TabIndex = 2;
            this.btnTestADWithFill.Text = "Test && Save";
            this.btnTestADWithFill.UseVisualStyleBackColor = true;
            this.btnTestADWithFill.Click += new System.EventHandler(this.btnTestADWithFill_Click);
            // 
            // btnSyncADProp
            // 
            this.btnSyncADProp.Location = new System.Drawing.Point(201, 225);
            this.btnSyncADProp.Margin = new System.Windows.Forms.Padding(1);
            this.btnSyncADProp.Name = "btnSyncADProp";
            this.btnSyncADProp.Size = new System.Drawing.Size(59, 29);
            this.btnSyncADProp.TabIndex = 2;
            this.btnSyncADProp.Text = "Sync Current AD";
            this.btnSyncADProp.UseVisualStyleBackColor = true;
            this.btnSyncADProp.Visible = false;
            this.btnSyncADProp.Click += new System.EventHandler(this.btnSyncADProp_Click);
            // 
            // btnTestADConnection
            // 
            this.btnTestADConnection.Location = new System.Drawing.Point(144, 225);
            this.btnTestADConnection.Margin = new System.Windows.Forms.Padding(1);
            this.btnTestADConnection.Name = "btnTestADConnection";
            this.btnTestADConnection.Size = new System.Drawing.Size(55, 29);
            this.btnTestADConnection.TabIndex = 2;
            this.btnTestADConnection.Text = "Sync Prop From User";
            this.btnTestADConnection.UseVisualStyleBackColor = true;
            this.btnTestADConnection.Visible = false;
            this.btnTestADConnection.Click += new System.EventHandler(this.btnTestADConnection_Click);
            // 
            // tabMapping
            // 
            this.tabMapping.Controls.Add(this.tabControl1);
            this.tabMapping.Controls.Add(this.gridMap);
            this.tabMapping.Location = new System.Drawing.Point(4, 27);
            this.tabMapping.Margin = new System.Windows.Forms.Padding(1);
            this.tabMapping.Name = "tabMapping";
            this.tabMapping.Padding = new System.Windows.Forms.Padding(1);
            this.tabMapping.Size = new System.Drawing.Size(918, 362);
            this.tabMapping.TabIndex = 1;
            this.tabMapping.Text = "Mapping";
            this.tabMapping.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(602, 20);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(309, 328);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage1.Size = new System.Drawing.Size(301, 300);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Mapping";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMapping
            // 
            this.btnDeleteMapping.Location = new System.Drawing.Point(185, 220);
            this.btnDeleteMapping.Name = "btnDeleteMapping";
            this.btnDeleteMapping.Size = new System.Drawing.Size(100, 41);
            this.btnDeleteMapping.TabIndex = 4;
            this.btnDeleteMapping.Text = "Delete Mapping";
            this.btnDeleteMapping.UseVisualStyleBackColor = true;
            this.btnDeleteMapping.Click += new System.EventHandler(this.btnDeleteMapping_Click);
            // 
            // btnSaveMapping
            // 
            this.btnSaveMapping.Location = new System.Drawing.Point(16, 220);
            this.btnSaveMapping.Name = "btnSaveMapping";
            this.btnSaveMapping.Size = new System.Drawing.Size(94, 41);
            this.btnSaveMapping.TabIndex = 4;
            this.btnSaveMapping.Text = "Save Mapping";
            this.btnSaveMapping.UseVisualStyleBackColor = true;
            this.btnSaveMapping.Click += new System.EventHandler(this.btnSaveMapping_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Source Field";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Destination Field";
            // 
            // cmbDBProps
            // 
            this.cmbDBProps.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDBProps.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDBProps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDBProps.FormattingEnabled = true;
            this.cmbDBProps.Items.AddRange(new object[] {
            "UserID",
            "UserName",
            "CardNo"});
            this.cmbDBProps.Location = new System.Drawing.Point(16, 126);
            this.cmbDBProps.Margin = new System.Windows.Forms.Padding(1);
            this.cmbDBProps.Name = "cmbDBProps";
            this.cmbDBProps.Size = new System.Drawing.Size(269, 23);
            this.cmbDBProps.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnADFillUser);
            this.tabPage2.Controls.Add(this.txtADUser);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage2.Size = new System.Drawing.Size(301, 300);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sync Source Fields";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Test AD User";
            // 
            // btnADFillUser
            // 
            this.btnADFillUser.Location = new System.Drawing.Point(183, 217);
            this.btnADFillUser.Margin = new System.Windows.Forms.Padding(1);
            this.btnADFillUser.Name = "btnADFillUser";
            this.btnADFillUser.Size = new System.Drawing.Size(100, 41);
            this.btnADFillUser.TabIndex = 2;
            this.btnADFillUser.Text = "Sync Properties";
            this.btnADFillUser.UseVisualStyleBackColor = true;
            this.btnADFillUser.Click += new System.EventHandler(this.btnADFillUser_Click);
            // 
            // txtADUser
            // 
            this.txtADUser.Location = new System.Drawing.Point(17, 108);
            this.txtADUser.Margin = new System.Windows.Forms.Padding(1);
            this.txtADUser.Name = "txtADUser";
            this.txtADUser.Size = new System.Drawing.Size(268, 23);
            this.txtADUser.TabIndex = 3;
            // 
            // gridMap
            // 
            this.gridMap.AllowUserToAddRows = false;
            this.gridMap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Source,
            this.Destination});
            this.gridMap.Location = new System.Drawing.Point(24, 19);
            this.gridMap.Margin = new System.Windows.Forms.Padding(1);
            this.gridMap.Name = "gridMap";
            this.gridMap.RowHeadersWidth = 102;
            this.gridMap.RowTemplate.Height = 49;
            this.gridMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMap.Size = new System.Drawing.Size(562, 329);
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
            // tabPreview
            // 
            this.tabPreview.Controls.Add(this.gridPreview);
            this.tabPreview.Controls.Add(this.txtPreviewRows);
            this.tabPreview.Controls.Add(this.label9);
            this.tabPreview.Controls.Add(this.btnPreviewData);
            this.tabPreview.Location = new System.Drawing.Point(4, 27);
            this.tabPreview.Name = "tabPreview";
            this.tabPreview.Size = new System.Drawing.Size(918, 362);
            this.tabPreview.TabIndex = 4;
            this.tabPreview.Text = "Preview";
            this.tabPreview.UseVisualStyleBackColor = true;
            // 
            // gridPreview
            // 
            this.gridPreview.AllowUserToAddRows = false;
            this.gridPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPreview.Location = new System.Drawing.Point(17, 59);
            this.gridPreview.Margin = new System.Windows.Forms.Padding(1);
            this.gridPreview.Name = "gridPreview";
            this.gridPreview.RowHeadersWidth = 102;
            this.gridPreview.RowTemplate.Height = 49;
            this.gridPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPreview.Size = new System.Drawing.Size(887, 286);
            this.gridPreview.TabIndex = 9;
            // 
            // txtPreviewRows
            // 
            this.txtPreviewRows.Location = new System.Drawing.Point(131, 25);
            this.txtPreviewRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPreviewRows.Name = "txtPreviewRows";
            this.txtPreviewRows.Size = new System.Drawing.Size(69, 23);
            this.txtPreviewRows.TabIndex = 8;
            this.txtPreviewRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Preview Row Count";
            // 
            // btnPreviewData
            // 
            this.btnPreviewData.Location = new System.Drawing.Point(757, 14);
            this.btnPreviewData.Name = "btnPreviewData";
            this.btnPreviewData.Size = new System.Drawing.Size(147, 41);
            this.btnPreviewData.TabIndex = 5;
            this.btnPreviewData.Text = "Preview Data";
            this.btnPreviewData.UseVisualStyleBackColor = true;
            this.btnPreviewData.Click += new System.EventHandler(this.btnPreviewData_Click);
            // 
            // tabSync
            // 
            this.tabSync.Controls.Add(this.lstSyncResult);
            this.tabSync.Controls.Add(this.groupBox3);
            this.tabSync.Controls.Add(this.groupBox2);
            this.tabSync.Location = new System.Drawing.Point(4, 27);
            this.tabSync.Margin = new System.Windows.Forms.Padding(1);
            this.tabSync.Name = "tabSync";
            this.tabSync.Size = new System.Drawing.Size(918, 362);
            this.tabSync.TabIndex = 3;
            this.tabSync.Text = "Synchronization";
            this.tabSync.UseVisualStyleBackColor = true;
            // 
            // lstSyncResult
            // 
            this.lstSyncResult.FormattingEnabled = true;
            this.lstSyncResult.ItemHeight = 15;
            this.lstSyncResult.Location = new System.Drawing.Point(349, 28);
            this.lstSyncResult.Name = "lstSyncResult";
            this.lstSyncResult.Size = new System.Drawing.Size(542, 289);
            this.lstSyncResult.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pgBarSync);
            this.groupBox3.Controls.Add(this.btnCancelSync);
            this.groupBox3.Controls.Add(this.btnSyncAll);
            this.groupBox3.Location = new System.Drawing.Point(24, 184);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox3.Size = new System.Drawing.Size(308, 134);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sync All Users";
            // 
            // pgBarSync
            // 
            this.pgBarSync.Location = new System.Drawing.Point(24, 46);
            this.pgBarSync.Name = "pgBarSync";
            this.pgBarSync.Size = new System.Drawing.Size(259, 16);
            this.pgBarSync.TabIndex = 6;
            // 
            // btnCancelSync
            // 
            this.btnCancelSync.Enabled = false;
            this.btnCancelSync.Location = new System.Drawing.Point(24, 79);
            this.btnCancelSync.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancelSync.Name = "btnCancelSync";
            this.btnCancelSync.Size = new System.Drawing.Size(100, 33);
            this.btnCancelSync.TabIndex = 5;
            this.btnCancelSync.Text = "Cancel Sync";
            this.btnCancelSync.UseVisualStyleBackColor = true;
            this.btnCancelSync.Click += new System.EventHandler(this.btnCancelSync_Click);
            // 
            // btnSyncAll
            // 
            this.btnSyncAll.Location = new System.Drawing.Point(183, 79);
            this.btnSyncAll.Margin = new System.Windows.Forms.Padding(1);
            this.btnSyncAll.Name = "btnSyncAll";
            this.btnSyncAll.Size = new System.Drawing.Size(100, 33);
            this.btnSyncAll.TabIndex = 5;
            this.btnSyncAll.Text = "Sync All";
            this.btnSyncAll.UseVisualStyleBackColor = true;
            this.btnSyncAll.Click += new System.EventHandler(this.btnSyncAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnSyncUser);
            this.groupBox2.Controls.Add(this.txtSyncUser);
            this.groupBox2.Location = new System.Drawing.Point(24, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(308, 134);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sync Single User";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "AD User";
            // 
            // btnSyncUser
            // 
            this.btnSyncUser.Location = new System.Drawing.Point(183, 84);
            this.btnSyncUser.Margin = new System.Windows.Forms.Padding(1);
            this.btnSyncUser.Name = "btnSyncUser";
            this.btnSyncUser.Size = new System.Drawing.Size(100, 33);
            this.btnSyncUser.TabIndex = 2;
            this.btnSyncUser.Text = "Sync User";
            this.btnSyncUser.UseVisualStyleBackColor = true;
            this.btnSyncUser.Click += new System.EventHandler(this.btnSyncUser_Click);
            // 
            // txtSyncUser
            // 
            this.txtSyncUser.Location = new System.Drawing.Point(24, 45);
            this.txtSyncUser.Margin = new System.Windows.Forms.Padding(1);
            this.txtSyncUser.Name = "txtSyncUser";
            this.txtSyncUser.Size = new System.Drawing.Size(261, 23);
            this.txtSyncUser.TabIndex = 3;
            // 
            // performSync
            // 
            this.performSync.WorkerReportsProgress = true;
            this.performSync.WorkerSupportsCancellation = true;
            this.performSync.DoWork += new System.ComponentModel.DoWorkEventHandler(this.performSync_DoWork);
            this.performSync.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.performSync_ProgressChanged);
            this.performSync.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.performSync_RunWorkerCompleted);
            // 
            // openSettings
            // 
            this.openSettings.DefaultExt = "json";
            this.openSettings.Filter = "json files (*.json)|*.json";
            this.openSettings.RestoreDirectory = true;
            // 
            // frmSyncSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 404);
            this.Controls.Add(this.tcSync);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMap)).EndInit();
            this.tabPreview.ResumeLayout(false);
            this.tabPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreviewRows)).EndInit();
            this.tabSync.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private DataGridView gridMap;
        private TabPage tabSync;
        private Label label4;
        private TextBox txtDBServer;
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
        private Button btnTestADWithFill;
        private Button btnSyncAll;
        private TabPage tabPreview;
        private GroupBox groupBox3;
        private Button btnPreviewData;
        private NumericUpDown txtPreviewRows;
        private Label label9;
        private DataGridView gridPreview;
        private System.ComponentModel.BackgroundWorker performSync;
        private ListBox lstSyncResult;
        private Button btnSyncADProp;
        private Button btnLoadSetup;
        private OpenFileDialog openSettings;
        private Button btnCancelSync;
        private ProgressBar pgBarSync;
        private Label label10;
        private Label label12;
        private Label label11;
        private TextBox txtDBPassword;
        private TextBox txtDBName;
        private TextBox txtDBUser;
        private Button btnVerifyDBConnection;
        private Button btnVerifyAD;
        private Label label13;
        private TextBox txtADFilter;
    }
}