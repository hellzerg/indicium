using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indicium
{
    public class AudioDevice
    {
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public string Status { get; set; }
    }

    public class AudioInfo
    {
        public AudioInfo()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
                foreach (ManagementObject mo in searcher.Get())
                {
                    AudioDevice device = new AudioDevice();

                    device.ProductName = Convert.ToString(mo.Properties["ProductName"].Value);
                    device.Manufacturer = Convert.ToString(mo.Properties["Manufacturer"].Value);
                    device.Status = Convert.ToString(mo.Properties["Status"].Value);

                    AudioDevices.Add(device);
                }
            }
            catch { }
        }

        public List<AudioDevice> AudioDevices = new List<AudioDevice>();
    }
}
