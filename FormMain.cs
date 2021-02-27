using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OpenWRTManager
{
    public partial class FormMain : Form
    {
        private Logger logger;
        private Console console;
        private Command command;
        private Scanner scanner;
        private Login login;
        private ConfigData cfgdata;
        private Config config;

        private void ConfigUIClear()
        {
            textBoxHostname.Clear();
            textBoxWanIp.Clear();
            textBoxWanNm.Clear();
        }

        private void ConfigUIReload()
        {
            textBoxHostname.Text = cfgdata.hostname;
            textBoxWanIp.Text = cfgdata.wanIp;
            textBoxWanNm.Text = cfgdata.wanNetmask;
        }

        private void ConfigUIStore()
        {
            cfgdata.hostname = textBoxHostname.Text;
            cfgdata.wanIp = textBoxWanIp.Text;
            cfgdata.wanNetmask = textBoxWanNm.Text;
        }

        private void LoginUIEnabled(bool logout_enabled)
        {
            labelUsername.Enabled = true;
            textBoxUsername.Enabled = true;
            labelPassword.Enabled = true;
            textBoxPassword.Enabled = true;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = logout_enabled;

            ConfigUIClear();
            groupBoxConfig.Enabled = false;
        }

        private void LoginUIDisabled(bool logout_enabled)
        {
            labelUsername.Enabled = false;
            textBoxUsername.Enabled = false;
            labelPassword.Enabled = false;
            textBoxPassword.Enabled = false;
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = logout_enabled;

            if (logout_enabled)
            {
                groupBoxConfig.Enabled = true;
            }
            else
            {
                ConfigUIClear();
                groupBoxConfig.Enabled = false;
            }
        }

        private void StatusNotification(string msg)
        {
            textBoxStatus.Text = msg;
            textBoxStatus.BackColor = Color.Empty;
        }

        private void StatusInfo(string msg)
        {
            textBoxStatus.Text = msg;
            textBoxStatus.BackColor = Color.Green;
        }

        private void StatusWarning(string msg)
        {
            textBoxStatus.Text = msg;
            textBoxStatus.BackColor = Color.Yellow;
        }

        private void StatusError(string msg)
        {
            textBoxStatus.Text = msg;
            textBoxStatus.BackColor = Color.Red;
        }

        public FormMain()
        {
            InitializeComponent();
            
            this.logger = new Logger(this.textBoxLog, this.textBoxConsole);
            this.console = new Console(this.logger);
            this.command = new Command(this.logger, this.console);
            this.scanner = new Scanner(this.logger, this.console);
            this.login = new Login(this.logger, this.console, this.command);
            this.config = new Config(this.logger, this.console, this.command);

            this.cfgdata = new ConfigData();

            LoginUIDisabled(false);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.logger.Print("Form loaded");
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            Scanner.ScanResult status;

            StatusNotification("SCANNING...");
            LoginUIDisabled(false);

            status = this.scanner.Scan();
            switch (status)
            {
                case Scanner.ScanResult.READY:
                    StatusInfo("READY");
                    LoginUIDisabled(true);
                    break;

                case Scanner.ScanResult.AUTHREQ:
                    StatusWarning("AUTHENTICATION REQUIRED");
                    LoginUIEnabled(false);
                    break;

                case Scanner.ScanResult.FAILED:
                    StatusError("SCAN FAILED");
                    break;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            StatusNotification("SIGNING IN...");

            if (login.SignIn(textBoxUsername.Text, textBoxPassword.Text))
            {
                StatusInfo("READY");
                LoginUIDisabled(true);
            } else
            {
                StatusError("LOGIN FAILED");
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            StatusNotification("SIGNING OUT...");

            login.SignOut();
            LoginUIEnabled(false);

            StatusNotification("");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            StatusNotification("LOADING CONFIG...");
            groupBoxConfig.Enabled = false;

            ConfigUIClear();

            if (!config.Load())
            {
                StatusError("LOAD FAILED");
                groupBoxConfig.Enabled = true;
                return;
            }
            config.Dump();

            cfgdata = config.GetData();
            ConfigUIReload();

            StatusInfo("DONE");
            groupBoxConfig.Enabled = true;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            StatusNotification("APPLYING CONFIG...");
            groupBoxConfig.Enabled = false;

            ConfigUIStore();

            config.SetData(cfgdata);
            if (!config.Apply())
            {
                StatusError("APPLY FAILED");
                groupBoxConfig.Enabled = true;
                return;
            }

            StatusInfo("DONE");
            groupBoxConfig.Enabled = true;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            logger.Print("Opening config XML file...");

            var xml = string.Empty;
            var path = string.Empty;

            using (OpenFileDialog openFileDialogConfig = new OpenFileDialog())
            {
                openFileDialogConfig.InitialDirectory = "c:\\";
                openFileDialogConfig.Filter = "XML data|*.xml";
                openFileDialogConfig.FilterIndex = 2;
                openFileDialogConfig.RestoreDirectory = true;

                if (openFileDialogConfig.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialogConfig.FileName;
                    var fileStream = openFileDialogConfig.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        xml = reader.ReadToEnd();
                    }
                }
            }

            if (xml != "")
            {
                config.SetXML(xml);
                // Refresh form
                cfgdata = config.GetData();
                ConfigUIReload();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            logger.Print("Saving config XML file...");

            // Save UI changes if any
            ConfigUIStore();
            config.SetData(cfgdata);

            string xml = config.GetXML();
            if (xml == "")
            {
                logger.Print("No XML!");
                return;
            }

            SaveFileDialog saveFileDialogConfig = new SaveFileDialog();
            saveFileDialogConfig.Filter = "XML data|*.xml";
            saveFileDialogConfig.Title = "Save config XML File";
            saveFileDialogConfig.ShowDialog();

            if (saveFileDialogConfig.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialogConfig.OpenFile();
                byte[] info = new UTF8Encoding(true).GetBytes(xml);

                switch (saveFileDialogConfig.FilterIndex)
                {
                    case 1:
                        fs.Write(info, 0, info.Length);
                        break;
                }

                fs.Close();
            }
        }
    }
}
