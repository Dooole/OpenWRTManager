using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenWRTManager
{
    class Config
    {
        private ConfigData config;
        private Logger configLogger;
        private Console configConsole;
        private Command configCommand;

        public Config(Logger logger, Console console, Command command)
        {
            this.config = new ConfigData();
            this.configLogger = logger;
            this.configConsole = console;
            this.configCommand = command;
        }

        public ConfigData GetData()
        {
            return this.config;
        }

        public void SetData(ConfigData cfg)
        {
            this.config = cfg;
        }

        public string GetXML()
        {
            string xml = "";
            try
            {
                using (var stringwriter = new System.IO.StringWriter())
                {
                    ConfigData cfg = this.GetData();

                    var serializer = new XmlSerializer(cfg.GetType());
                    serializer.Serialize(stringwriter, cfg);
                    xml = stringwriter.ToString();
                }
            }
            catch
            {
                this.configLogger.Print("Failed serialize to XML...");
            }

            return xml;
        }

        public void SetXML(string xml)
        {
            try
            {
                using (var stringReader = new System.IO.StringReader(xml))
                {
                    var serializer = new XmlSerializer(typeof(ConfigData));
                    ConfigData cfg = serializer.Deserialize(stringReader) as ConfigData;
                    this.config = cfg;
   
                }
            }
            catch
            {
                this.configLogger.Print("Failed deserialize from XML...");
            }
        }

        public void Dump()
        {
            this.configLogger.Print("---CONFIG:---");
            this.configLogger.Print(String.Format("system.@system[0].hostname={0}", this.config.hostname));
            this.configLogger.Print(String.Format("network.wan.ipaddr", this.config.wanIp));
            this.configLogger.Print(String.Format("network.wan.netmask", this.config.wanNetmask));
            this.configLogger.Print("-------------");
        }

        public bool Load()
        {
            string key, val;

            key = "system.@system[0].hostname";
            val = this.configCommand.Send("uci get " + key);
            if (val == "")
            {
                this.configLogger.Print("Failed to load: " + key);
                return false;
            }
            this.config.hostname = val;
            Thread.Sleep(300);

            val = this.configCommand.Send("grep root /etc/shadow");
            if (val == "")
            {
                this.configLogger.Print("Failed to load: " + "grep root /etc/shadow");
                return false;
            }
            this.config.shadowLine = val;
            Thread.Sleep(300);

            key = "network.wan.ipaddr";
            val = this.configCommand.Send("uci get " + key);
            if (val == "")
            {
                this.configLogger.Print("Failed to load: " + key);
                return false;
            }
            this.config.wanIp = val;
            Thread.Sleep(300);

            key = "network.wan.netmask";
            val = this.configCommand.Send("uci get " + key);
            if (val == "")
            {
                this.configLogger.Print("Failed to load: " + key);
                return false;
            }
            this.config.wanNetmask = val;
            Thread.Sleep(300);

            return true;
        }

        public bool Apply()
        {
            string key, val, ret;

            key = "system.@system[0].hostname";
            val = this.config.hostname;
            if (val != "")
            {
                ret = this.configCommand.Send(String.Format("uci set {0}={1}", key, val));
                if (ret == "")
                {
                    this.configLogger.Print("Failed to set: " + key);
                    return false;
                }
                Thread.Sleep(300);
            }

            val = this.config.shadowLine;
            if (val != "")
            {
                this.configCommand.Send("sed -i '/root/d' /etc/shadow");
                Thread.Sleep(300);
                this.configCommand.Send(String.Format("echo '{0}' >> /etc/shadow", val));
                Thread.Sleep(300);
            }

            key = "network.wan.ipaddr";
            val = this.config.wanIp;
            if (val != "")
            {
                ret = this.configCommand.Send(String.Format("uci set {0}={1}", key, val));
                if (ret == "")
                {
                    this.configLogger.Print("Failed to set: " + key);
                    return false;
                }
                Thread.Sleep(300);
            }

            key = "network.wan.netmask";
            val = this.config.wanNetmask;
            if (val != "")
            {
                ret = this.configCommand.Send(String.Format("uci set {0}={1}", key, val));
                if (ret == "")
                {
                    this.configLogger.Print("Failed to set: " + key);
                    return false;
                }
                Thread.Sleep(300);
            }

            this.configCommand.SendSafe("uci commit system");
            this.configCommand.SendSafe("uci commit network");

            this.configCommand.SendSafe("/etc/init.d/system restart");
            this.configCommand.SendSafe("/etc/init.d/network restart");

            this.configConsole.WaitSilence();

            return true;
        }
    }
}
