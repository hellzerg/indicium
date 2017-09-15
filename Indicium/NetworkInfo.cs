using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace Indicium
{
    public class NetworkAdapter
    {
        public string AdapterType { get; set; }
        public string Manufacturer { get; set; }
        public string ProductName { get; set; }
        public string PhysicalAdapter { get; set; }
        public string MacAddress { get; set; }
        public string ServiceName { get; set; }
    }

    public class NetworkInfo
    {
        public NetworkInfo()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter");
                foreach (ManagementObject mo in searcher.Get())
                {
                    NetworkAdapter adapter = new NetworkAdapter();

                    adapter.AdapterType = Convert.ToString(mo.Properties["AdapterType"].Value);
                    adapter.Manufacturer = Convert.ToString(mo.Properties["Manufacturer"].Value);
                    adapter.ProductName = Convert.ToString(mo.Properties["ProductName"].Value);
                    bool temp = Convert.ToBoolean(mo.Properties["PhysicalAdapter"].Value);
                    adapter.PhysicalAdapter = (temp) ? "Yes" : "No";
                    adapter.MacAddress = Convert.ToString(mo.Properties["MacAddress"].Value);
                    adapter.ServiceName = Convert.ToString(mo.Properties["ServiceName"].Value);

                    if (temp)
                    {
                        PhysicalAdapters.Add(adapter);
                    }
                    else
                    {
                        VirtualAdapters.Add(adapter);
                    }
                }
            }
            catch //(Exception error)
            {
                //MessageBox.Show("NetworkInfo error: " + error.Message);
            }
        }

        public List<NetworkAdapter> PhysicalAdapters = new List<NetworkAdapter>();
        public List<NetworkAdapter> VirtualAdapters = new List<NetworkAdapter>();
    }
}
