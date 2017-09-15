using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicium
{
    public class OSInfo
    {
        public string OperatingSystem { get; set; }
        public string SystemType { get; set; }
        public string ProductKey { get; set; }
        public string ComputerName { get; set; }

        public OSInfo()
        {
            OperatingSystem = Utilities.GetOS();
            if (Environment.Is64BitOperatingSystem)
            {
                SystemType = "64-bit";
            }
            else
            {
                SystemType = "32-bit";
            }
            ProductKey = Utilities.GetProductKey();
            ComputerName = Environment.MachineName;
        }
    }
}
