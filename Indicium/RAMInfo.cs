using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace Indicium
{
    public class RAM
    {
        public string BankLabel { get; set; }
        public ByteSize Capacity { get; set; }
        public string FormFactor { get; set; }
        public string Manufacturer { get; set; }
        public string MemoryType { get; set; }
        public UInt32 Speed { get; set; }
    }

    public class VirtualMemory
    {
        public ByteSize TotalVirtualMemory { get; set; }
        public ByteSize AvailableVirtualMemory { get; set; }
        public ByteSize UsedVirtualMemory { get; set; }
    }

    public class RAMInfo
    {
        public RAMInfo()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
                foreach (ManagementObject mo in searcher.Get())
                {
                    RAM module = new RAM();
                    
                    module.BankLabel = Convert.ToString(mo.Properties["BankLabel"].Value);
                    module.Capacity = ByteSize.FromBytes(Convert.ToDouble(mo.Properties["Capacity"].Value));
                    module.Manufacturer = Convert.ToString(mo.Properties["Manufacturer"].Value);
                    module.Speed = Convert.ToUInt32(mo.Properties["Speed"].Value);
                    UInt16 memorytype = Convert.ToUInt16(mo.Properties["MemoryType"].Value);
                    UInt16 formfactor = Convert.ToUInt16(mo.Properties["FormFactor"].Value);
                    module.MemoryType = SanitizeMemoryType(memorytype);
                    module.FormFactor = SanitizeFormFactor(formfactor);

                    Modules.Add(module);
                }
            }
            catch { }

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject mo in searcher.Get())
                {
                    VirtualMemory.TotalVirtualMemory = ByteSize.FromKiloBytes(Convert.ToUInt64(mo.Properties["TotalVirtualMemorySize"].Value));
                    VirtualMemory.AvailableVirtualMemory = ByteSize.FromKiloBytes(Convert.ToUInt64(mo.Properties["FreeVirtualMemory"].Value));
                    VirtualMemory.UsedVirtualMemory = VirtualMemory.TotalVirtualMemory.Subtract(VirtualMemory.AvailableVirtualMemory);
                }
            }
            catch { }
        }

        public List<RAM> Modules = new List<RAM>();
        public VirtualMemory VirtualMemory = new VirtualMemory();

        private string SanitizeFormFactor(UInt16 i)
        {
            string result = string.Empty;

            switch (i)
            {
                case 0:
                    result = "Unknown";
                    break;
                case 1:
                    result = "Other";
                    break;
                case 2:
                    result = "SIP";
                    break;
                case 3:
                    result = "DIP";
                    break;
                case 4:
                    result = "ZIP";
                    break;
                case 5:
                    result = "SOJ";
                    break;
                case 6:
                    result = "Proprietary";
                    break;
                case 7:
                    result = "SIMM";
                    break;
                case 8:
                    result = "DIMM";
                    break;
                case 9:
                    result = "TSOP";
                    break;
                case 10:
                    result = "PGA";
                    break;
                case 11:
                    result = "RIMM";
                    break;
                case 12:
                    result = "SODIMM";
                    break;
                case 13:
                    result = "SRIMM";
                    break;
                case 14:
                    result = "SMD";
                    break;
                case 15:
                    result = "SSMP";
                    break;
                case 16:
                    result = "QFP";
                    break;
                case 17:
                    result = "TQFP";
                    break;
                case 18:
                    result = "SOIC";
                    break;
                case 19:
                    result = "LCC";
                    break;
                case 20:
                    result = "PLCC";
                    break;
                case 21:
                    result = "BGA";
                    break;
                case 22:
                    result = "FPBGA";
                    break;
                case 23:
                    result = "LGA";
                    break;
            }

            return result;
        }

        private string SanitizeMemoryType(UInt16 i)
        {
            string result = string.Empty;

            switch (i)
            {
                case 0:
                    result = "Unknown";
                    break;
                case 1:
                    result = "Other";
                    break;
                case 2:
                    result = "DRAM";
                    break;
                case 3:
                    result = "Synchonous DRAM";
                    break;
                case 4:
                    result = "Cache DRAM";
                    break;
                case 5:
                    result = "EDO";
                    break;
                case 6:
                    result = "EDRAM";
                    break;
                case 7:
                    result = "VRAM";
                    break;
                case 8:
                    result = "SRAM";
                    break;
                case 9:
                    result = "RAM";
                    break;
                case 10:
                    result = "ROM";
                    break;
                case 11:
                    result = "Flash";
                    break;
                case 12:
                    result = "EEPROM";
                    break;
                case 13:
                    result = "FEPROM";
                    break;
                case 14:
                    result = "EPROM";
                    break;
                case 15:
                    result = "CDRAM";
                    break;
                case 16:
                    result = "3DRAM";
                    break;
                case 17:
                    result = "SDRAM";
                    break;
                case 18:
                    result = "SGRAM";
                    break;
                case 19:
                    result = "RDRAM";
                    break;
                case 20:
                    result = "DDR";
                    break;
                case 21:
                    result = "DDR2";
                    break;
                case 22:
                    result = "DDR2 FB-DIMM";
                    break;
                case 24:
                    result = "DDR3";
                    break;
                case 25:
                    result = "FBD2";
                    break;
            }

            return result;
        }
    }
}
