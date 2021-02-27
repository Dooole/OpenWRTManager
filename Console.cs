using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWRTManager
{
    class Console
    {
        private SerialPort serialPort;
        private Logger serialLogger;

        public Console(Logger logger)
        {
            this.serialLogger = logger;

            string portName = "";
            foreach (string s in SerialPort.GetPortNames())
            {
                this.serialLogger.Print("Found port: " + s);
                portName = s;
                break;
            }

            this.serialLogger.Print("Using port: " + portName);

            this.serialPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
            this.serialPort.Handshake = Handshake.None;
            this.serialPort.ReadTimeout = 3000; // 3 seconds
            this.serialPort.WriteTimeout = 3000;

            try
            {
                this.serialPort.Open();
            }
            catch (UnauthorizedAccessException ex)
            {
                this.serialLogger.Print("Failed to open, already running?: " + ex);
            }
            catch (System.IO.IOException ex)
            {
                this.serialLogger.Print("Failed to open: " + ex);
            }
        }

        public string ReceiveLine()
        {
            string line = "";

            try
            {
                line = this.serialPort.ReadLine();
                this.serialLogger.ActivityRecv(line);
            }
            catch
            {
                this.serialLogger.Print("Timeout/No output - done reading line");
                return line;
            }

            return line;
        }

        public string Receive()
        {
            string total = "";

            try
            {
                while (true)
                {
                    string line = serialPort.ReadLine();
                    this.serialLogger.ActivityRecv(line);
                    total += line;
                }
            }
            catch
            {
                this.serialLogger.Print("Timeout/No output - done reading");
                return total;
            }
        }

        public void WaitSilence()
        {
            try
            {
                while (true)
                {
                    string line = this.serialPort.ReadLine();
                    this.serialLogger.ActivityRecv(line);
                    Thread.Sleep(500);
                }
            }
            catch
            {
                this.serialLogger.Print("Timeout/No output - done waiting");
                return;
            }
        }

        public void Send(string line)
        {
            try
            {
                this.serialPort.WriteLine(line);
                this.serialLogger.ActivitySent(line);
            }
            catch (TimeoutException ex)
            {
                this.serialLogger.Print("Failed to write: " + ex);
                return;
            }
        }
    }
}
