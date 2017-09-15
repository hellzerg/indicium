using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace Indicium
{
    public class GPU
    {
        public string Name { get; set; }
        public ByteSize Memory { get; set; }
        public UInt32 ResolutionX { get; set; }
        public UInt32 ResolutionY { get; set; }
        public UInt32 RefreshRate { get; set; }
        public string DACType { get; set; }
        public string VideoMemoryType { get; set; }
    }

    public class GPUInfo
    {
        public GPUInfo()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                foreach (ManagementObject mo in searcher.Get())
                {
                    GPU gpu = new GPU();

                    gpu.Name = Convert.ToString(mo.Properties["Name"].Value);
                    gpu.Memory = ByteSize.FromBytes(Convert.ToDouble(mo.Properties["AdapterRAM"].Value));
                    gpu.ResolutionX = Convert.ToUInt32(mo.Properties["CurrentHorizontalResolution"].Value);
                    gpu.ResolutionY = Convert.ToUInt32(mo.Properties["CurrentVerticalResolution"].Value);
                    gpu.RefreshRate = Convert.ToUInt32(mo.Properties["CurrentRefreshRate"].Value);
                    gpu.DACType = Convert.ToString(mo.Properties["AdapterDACType"].Value);
                    UInt16 vtype = Convert.ToUInt16(mo.Properties["VideoMemoryType"].Value);
                    gpu.VideoMemoryType = SanitizeMemoryType(vtype);

                    GPUs.Add(gpu);
                }
            }
            catch //(Exception error)
            {
                //MessageBox.Show("GPUInfo error: " + error.Message);
            }
        }

        public List<GPU> GPUs = new List<GPU>();

        private string SanitizeMemoryType(UInt16 i)
        {
            string result = string.Empty;

            switch (i)
            {
                case 1:
                    result = "Other";
                    break;
                case 2:
                    result = "Unknown";
                    break;
                case 3:
                    result = "VRAM";
                    break;
                case 4:
                    result = "DRAM";
                    break;
                case 5:
                    result = "SRAM";
                    break;
                case 6:
                    result = "WRAM";
                    break;
                case 7:
                    result = "EDO RAM";
                    break;
                case 8:
                    result = "Burst Synchronous DRAM";
                    break;
                case 9:
                    result = "Pipelined Burst SRAM";
                    break;
                case 10:
                    result = "CDRAM";
                    break;
                case 11:
                    result = "3DRAM";
                    break;
                case 12:
                    result = "SDRAM";
                    break;
                case 13:
                    result = "SGRAM";
                    break;
            }

            return result;
        }
    }
}
