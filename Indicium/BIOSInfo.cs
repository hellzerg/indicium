using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indicium
{
    public class BIOSInfo
    {
        public BIOSInfo()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                foreach (ManagementObject mo in searcher.Get())
                {
                    Name = Convert.ToString(mo.Properties["Name"].Value);
                    Manufacturer = Convert.ToString(mo.Properties["Manufacturer"].Value);
                    Version = Convert.ToString(mo.Properties["Version"].Value);
                    BuildNumber = Convert.ToString(mo.Properties["BuildNumber"].Value);
                    //ReleaseDate = DateTime.Parse(mo.Properties["ReleaseDate"].Value.ToString());
                }
            }
            catch { }
        }

        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Version { get; set; }
        public string BuildNumber { get; set; }
        //public DateTime ReleaseDate { get; set; }
    }
}
