using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWRTManager
{
    public class ConfigData
    {
        public string hostname { get; set; }
        public string shadowLine { get; set; }
        public string wanIp { get; set; }
        public string wanNetmask { get; set; }
    }
}
