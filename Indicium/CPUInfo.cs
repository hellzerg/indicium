using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Indicium
{
    public class CPU
    {
        public string Name { get; set; }
        public ByteSize L2CacheSize { get; set; }
        public ByteSize L3CacheSize { get; set; }
        public UInt32 Cores { get; set; }
        public UInt32 Threads { get; set; }
        public UInt32 LogicalCpus { get; set; }
        public string Virtualization { get; set; }
        public string DataExecutionPrevention { get; set; }
        public string Stepping { get; set; }
        public string Revision { get; set; }
    }

    public class CPUInfo
    {
        public CPUInfo()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach (ManagementObject mo in searcher.Get())
                {
                    CPU cpu = new CPU();

                    cpu.Name = Convert.ToString(mo.Properties["Name"].Value);
                    cpu.L2CacheSize = ByteSize.FromKiloBytes(Convert.ToDouble(mo.Properties["L2CacheSize"].Value));
                    cpu.L3CacheSize = ByteSize.FromKiloBytes(Convert.ToDouble(mo.Properties["L3CacheSize"].Value));
                    cpu.Cores = Convert.ToUInt32(mo.Properties["NumberOfCores"].Value);
                    cpu.Threads = Convert.ToUInt32(mo.Properties["ThreadCount"].Value);
                    cpu.LogicalCpus = Convert.ToUInt32(mo.Properties["NumberOfLogicalProcessors"].Value);
                    bool temp = Convert.ToBoolean(mo.Properties["VirtualizationFirmwareEnabled"].Value);
                    cpu.Virtualization = (temp) ? "Yes" : "No";
                    cpu.Stepping = Convert.ToString(mo.Properties["Description"].Value);
                    cpu.Revision = Convert.ToString(mo.Properties["Revision"].Value);

                    try
                    {
                        ManagementObjectSearcher searcher2 = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                        foreach (ManagementObject mo2 in searcher2.Get())
                        {
                            bool temp2 = Convert.ToBoolean(mo2.Properties["DataExecutionPrevention_Available"].Value);
                            cpu.DataExecutionPrevention = (temp2) ? "Yes" : "No";
                        }
                    }
                    catch { }

                    if (string.IsNullOrEmpty(cpu.Name)) cpu.Name = GetCPUNameAlternative();

                    CPUs.Add(cpu);
                }
            }
            catch { }
        }

        public List<CPU> CPUs = new List<CPU>();

        private string GetCPUNameAlternative()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0", false))
            {
                return key.GetValue("ProcessorNameString").ToString();
            }
        }
    }
}
