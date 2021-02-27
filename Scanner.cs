using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWRTManager
{
    class Scanner
    {
        private Logger scannerLogger;
        private Console scannerConsole;

        public enum ScanResult
        {
            READY,
            AUTHREQ,
            FAILED
        }

        public Scanner(Logger logger, Console console)
        {
            this.scannerLogger = logger;
            this.scannerConsole = console;
        }

        public ScanResult Scan()
        {
            ScanResult result = ScanResult.FAILED;
            string output = "";
            int tries = 5;

            this.scannerLogger.Print("Start scan...");

            try
            {
                while (tries > 0)
                {
                    this.scannerConsole.Send("");

                    output = this.scannerConsole.Receive();
                    if (output.Length > 0)
                    {
                        this.scannerLogger.Print("Console is alive!");
                        if (Command.IsAuthOutput(output))
                        {
                            this.scannerLogger.Print("Authentication required!");
                            result = ScanResult.AUTHREQ;
                            break;
                        }
                        else if (Command.IsReadyOutput(output))
                        {
                            this.scannerLogger.Print("Console is ready!");
                            result = ScanResult.READY;
                            break;
                        }
                    }

                    Thread.Sleep(500); // 0.5 sec
                    tries -= 1;
                }
            }
            catch
            {
                this.scannerLogger.Print("Failed to scan!");
                return result;
            }

            return result;
        }
    }
}
