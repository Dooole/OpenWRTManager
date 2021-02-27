namespace OpenWRTManager
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.labelConsole = new System.Windows.Forms.Label();
            this.buttonScan = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.groupBoxConfig = new System.Windows.Forms.GroupBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.groupBoxSystem = new System.Windows.Forms.GroupBox();
            this.groupBoxNetwork = new System.Windows.Forms.GroupBox();
            this.labelHostname = new System.Windows.Forms.Label();
            this.labelWanIp = new System.Windows.Forms.Label();
            this.textBoxHostname = new System.Windows.Forms.TextBox();
            this.textBoxWanIp = new System.Windows.Forms.TextBox();
            this.labelWanNm = new System.Windows.Forms.Label();
            this.textBoxWanNm = new System.Windows.Forms.TextBox();
            this.groupBoxConfig.SuspendLayout();
            this.groupBoxSystem.SuspendLayout();
            this.groupBoxNetwork.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.Location = new System.Drawing.Point(15, 410);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ReadOnly = true;
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxConsole.Size = new System.Drawing.Size(458, 240);
            this.textBoxConsole.TabIndex = 0;
            // 
            // labelConsole
            // 
            this.labelConsole.AutoSize = true;
            this.labelConsole.Location = new System.Drawing.Point(12, 394);
            this.labelConsole.Name = "labelConsole";
            this.labelConsole.Size = new System.Drawing.Size(84, 13);
            this.labelConsole.TabIndex = 1;
            this.labelConsole.Text = "Console activity:";
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(15, 12);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 23);
            this.buttonScan.TabIndex = 2;
            this.buttonScan.Text = "Scan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(479, 410);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(459, 240);
            this.textBoxLog.TabIndex = 3;
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(476, 394);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(28, 13);
            this.labelLog.TabIndex = 4;
            this.labelLog.Text = "Log:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStatus.Location = new System.Drawing.Point(96, 15);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(842, 20);
            this.textBoxStatus.TabIndex = 5;
            this.textBoxStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(175, 149);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(133, 20);
            this.textBoxUsername.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(175, 175);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(133, 20);
            this.textBoxPassword.TabIndex = 7;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(111, 152);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 8;
            this.labelUsername.Text = "Username:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(113, 178);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Password:";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(152, 210);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 10;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(233, 210);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonLogout.TabIndex = 11;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // groupBoxConfig
            // 
            this.groupBoxConfig.Controls.Add(this.groupBoxNetwork);
            this.groupBoxConfig.Controls.Add(this.groupBoxSystem);
            this.groupBoxConfig.Controls.Add(this.buttonOpen);
            this.groupBoxConfig.Controls.Add(this.buttonSave);
            this.groupBoxConfig.Controls.Add(this.buttonApply);
            this.groupBoxConfig.Controls.Add(this.buttonLoad);
            this.groupBoxConfig.Location = new System.Drawing.Point(479, 41);
            this.groupBoxConfig.Name = "groupBoxConfig";
            this.groupBoxConfig.Size = new System.Drawing.Size(459, 343);
            this.groupBoxConfig.TabIndex = 12;
            this.groupBoxConfig.TabStop = false;
            this.groupBoxConfig.Text = "Configuration";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(378, 19);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(378, 48);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(378, 314);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(378, 285);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // groupBoxSystem
            // 
            this.groupBoxSystem.Controls.Add(this.textBoxHostname);
            this.groupBoxSystem.Controls.Add(this.labelHostname);
            this.groupBoxSystem.Location = new System.Drawing.Point(6, 28);
            this.groupBoxSystem.Name = "groupBoxSystem";
            this.groupBoxSystem.Size = new System.Drawing.Size(345, 103);
            this.groupBoxSystem.TabIndex = 4;
            this.groupBoxSystem.TabStop = false;
            this.groupBoxSystem.Text = "System";
            // 
            // groupBoxNetwork
            // 
            this.groupBoxNetwork.Controls.Add(this.textBoxWanNm);
            this.groupBoxNetwork.Controls.Add(this.labelWanNm);
            this.groupBoxNetwork.Controls.Add(this.textBoxWanIp);
            this.groupBoxNetwork.Controls.Add(this.labelWanIp);
            this.groupBoxNetwork.Location = new System.Drawing.Point(6, 137);
            this.groupBoxNetwork.Name = "groupBoxNetwork";
            this.groupBoxNetwork.Size = new System.Drawing.Size(345, 200);
            this.groupBoxNetwork.TabIndex = 5;
            this.groupBoxNetwork.TabStop = false;
            this.groupBoxNetwork.Text = "Network";
            // 
            // labelHostname
            // 
            this.labelHostname.AutoSize = true;
            this.labelHostname.Location = new System.Drawing.Point(6, 30);
            this.labelHostname.Name = "labelHostname";
            this.labelHostname.Size = new System.Drawing.Size(58, 13);
            this.labelHostname.TabIndex = 0;
            this.labelHostname.Text = "Hostname:";
            // 
            // labelWanIp
            // 
            this.labelWanIp.AutoSize = true;
            this.labelWanIp.Location = new System.Drawing.Point(6, 32);
            this.labelWanIp.Name = "labelWanIp";
            this.labelWanIp.Size = new System.Drawing.Size(60, 13);
            this.labelWanIp.TabIndex = 0;
            this.labelWanIp.Text = "IP address:";
            // 
            // textBoxHostname
            // 
            this.textBoxHostname.Location = new System.Drawing.Point(92, 27);
            this.textBoxHostname.Name = "textBoxHostname";
            this.textBoxHostname.Size = new System.Drawing.Size(100, 20);
            this.textBoxHostname.TabIndex = 1;
            // 
            // textBoxWanIp
            // 
            this.textBoxWanIp.Location = new System.Drawing.Point(92, 29);
            this.textBoxWanIp.Name = "textBoxWanIp";
            this.textBoxWanIp.Size = new System.Drawing.Size(100, 20);
            this.textBoxWanIp.TabIndex = 1;
            // 
            // labelWanNm
            // 
            this.labelWanNm.AutoSize = true;
            this.labelWanNm.Location = new System.Drawing.Point(6, 65);
            this.labelWanNm.Name = "labelWanNm";
            this.labelWanNm.Size = new System.Drawing.Size(72, 13);
            this.labelWanNm.TabIndex = 2;
            this.labelWanNm.Text = "Subnet mask:";
            // 
            // textBoxWanNm
            // 
            this.textBoxWanNm.Location = new System.Drawing.Point(92, 62);
            this.textBoxWanNm.Name = "textBoxWanNm";
            this.textBoxWanNm.Size = new System.Drawing.Size(100, 20);
            this.textBoxWanNm.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 662);
            this.Controls.Add(this.groupBoxConfig);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.labelConsole);
            this.Controls.Add(this.textBoxConsole);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "OpenWRT Manager";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBoxConfig.ResumeLayout(false);
            this.groupBoxSystem.ResumeLayout(false);
            this.groupBoxSystem.PerformLayout();
            this.groupBoxNetwork.ResumeLayout(false);
            this.groupBoxNetwork.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxConsole;
        private System.Windows.Forms.Label labelConsole;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.GroupBox groupBoxConfig;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.GroupBox groupBoxNetwork;
        private System.Windows.Forms.Label labelWanIp;
        private System.Windows.Forms.GroupBox groupBoxSystem;
        private System.Windows.Forms.TextBox textBoxHostname;
        private System.Windows.Forms.Label labelHostname;
        private System.Windows.Forms.TextBox textBoxWanNm;
        private System.Windows.Forms.Label labelWanNm;
        private System.Windows.Forms.TextBox textBoxWanIp;
    }
}

