using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace Indicium
{
    public class Motherboard
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Chipset { get; set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public string Revision { get; set; }
        public string SystemModel { get; set; }
    }

    public class MotherboardInfo
    {
        public MotherboardInfo()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject mo in searcher.Get())
                {
                    Motherboard mobo = new Motherboard();

                    mobo.Model = Convert.ToString(mo.Properties["Model"].Value);
                    mobo.Manufacturer = Convert.ToString(mo.Properties["Manufacturer"].Value);
                    mobo.Product = Convert.ToString(mo.Properties["Product"].Value);
                    mobo.Version = Convert.ToString(mo.Properties["Version"].Value);

                    try
                    {
                        ManagementObjectSearcher searcher2 = new ManagementObjectSearcher("SELECT * FROM Win32_IDEController");
                        foreach (ManagementObject mo2 in searcher2.Get())
                        {
                            mobo.Chipset = Convert.ToString(mo2.Properties["Description"].Value);
                        }
                    }
                    catch //(Exception error)
                    {
                        //MessageBox.Show("MotherboardInfo error: " + error.Message);
                    }

                    try
                    {
                        ManagementObjectSearcher searcher3 = new ManagementObjectSearcher("SELECT * FROM Win32_IDEController");
                        foreach (ManagementObject mo3 in searcher3.Get())
                        {
                            mobo.Revision = Convert.ToString(mo3.Properties["RevisionNumber"].Value);
                        }
                    }
                    catch //(Exception error)
                    {
                        //MessageBox.Show("MotherboardInfo error: " + error.Message);
                    }

                    try
                    {
                        ManagementObjectSearcher searcher4 = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
                        foreach (ManagementObject mo4 in searcher4.Get())
                        {
                            mobo.SystemModel = Convert.ToString(mo4.Properties["Model"].Value);
                        }
                    }
                    catch //(Exception error)
                    {
                        //MessageBox.Show("BIOSInfo error: " + error.Message);
                    }

                    Boards.Add(mobo);
                }
            }
            catch //(Exception error)
            {
                //MessageBox.Show("MotherboardInfo error: " + error.Message);
            }
        }

        public List<Motherboard> Boards = new List<Motherboard>();
    }
}
