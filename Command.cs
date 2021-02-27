using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWRTManager
{
    class Command
    {
        private Console commandConsole;
        private Logger commandLogger;

        public Command(Logger logger, Console console)
        {
            this.commandLogger = logger;
            this.commandConsole = console;
        }
        public static bool IsAuthOutput(string output)
        {
            if (output.IndexOf("login:") != -1 ||
                    output.IndexOf("Login:") != -1 ||
                    output.IndexOf("Password:") != -1 ||
                    output.IndexOf("password:") != -1 ||
                    output.IndexOf("incorrect") != -1)
            {
                return true;
            }
            return false;
        }

        public static bool IsLoginOutput(string output)
        {
            if (output.IndexOf("login:") != -1 ||
                    output.IndexOf("Login:") != -1)
            {
                return true;
            }
            return false;
        }

        public static bool IsPasswordOutput(string output)
        {
            if (output.IndexOf("Password:") != -1 ||
                    output.IndexOf("password:") != -1)
            {
                return true;
            }
            return false;
        }

        public static bool IsIncorrectdOutput(string output)
        {
            if (output.IndexOf("incorrect") != -1 ||
                    output.IndexOf("Incorrect") != -1)
            {
                return true;
            }
            return false;
        }

        public static bool IsReadyOutput(string output)
        {
            if (output.IndexOf("@") != -1 ||
                    output.IndexOf("#") != -1)
            {
                return true;
            }
            return false;
        }

        public string Send(string cmd)
        {
            const int LINES_MAX = 8;
            string[] output = new string[LINES_MAX];

            string cmdRaw = String.Format("{0} 2>/dev/null; echo \"=/$?/\"", cmd);
            this.commandConsole.Send(cmdRaw);

            bool marker_ok = false;
            int lines = 0;
            while (lines < LINES_MAX)
            {
                string line = this.commandConsole.ReceiveLine();
                if (line == "")
                {
                    break;
                }

                output[lines] = line;
                lines++;

                if (line.IndexOf("=/0/") != -1)
                {
                    this.commandLogger.Print("Found success end marker, stop reading!");
                    marker_ok = true;
                    break;
                }

                if (line.IndexOf("=/1/") != -1)
                {
                    this.commandLogger.Print("Found failed end marker, stop reading!");
                    break;
                }
            }

            if (lines < 3 || !marker_ok)
            {
                this.commandLogger.Print("Bad command output");
                return "";
            }

            this.commandLogger.Print(String.Format("Output[{0}]={1}", cmd, output[lines - 2]));
            return output[lines - 2];
        }

        public string SendSafe(string cmd)
        {
            int retries = 32;

            // Wait for ready input
            while (retries > 0)
            {
                retries--;

                string cmdline = this.commandConsole.ReceiveLine();
                if (IsReadyOutput(cmdline))
                {
                    break;
                }

                this.commandConsole.Send("");
                Thread.Sleep(300); // 0.3 sec
            }

            return this.Send(cmd);
        }
    }
}
