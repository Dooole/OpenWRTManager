using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenWRTManager
{
    class Logger
    {
        private TextBox tbGeneralLog;
        private TextBox tbSerialActivity;

        public Logger(TextBox tbLog, TextBox tbSerial)
        {
            this.tbGeneralLog = tbLog;
            this.tbSerialActivity = tbSerial;
        }

        public void Print(string msg)
        {
            if (msg == null)
                msg = "<NULL STRING>";

            if (msg == "")
                msg = "<EMPTY STRING>";

            this.tbGeneralLog.AppendText("\r\n" + msg);
        }

        public void ActivitySent(string msg)
        {
            if (msg == null)
                msg = "<NULL STRING>";

            if (msg == "")
                msg = "<EMPTY STRING>";

            this.tbSerialActivity.AppendText(String.Format("SENT: {0}\r\n", msg));
        }

        public void ActivityRecv(string msg)
        {
            if (msg == null)
                msg = "<NULL STRING>";

            if (msg == "")
                msg = "<EMPTY STRING>";

            this.tbSerialActivity.AppendText(String.Format("RECEIVED: {0}\r\n", msg));
        }
    }
}
