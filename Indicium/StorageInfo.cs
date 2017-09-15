using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace Indicium
{
    public class Disk
    {
        public UInt32 BytesPerSector { get; set; }
        public string FirmwareRevision { get; set; }
        public string MediaType { get; set; }
        public string Model { get; set; }
        public ByteSize Capacity { get; set; }
    }

    public class Volume
    {
        public UInt64 BlockSize { get; set; }
        public ByteSize Capacity { get; set; }
        public string Compressed { get; set; }
        public string DriveLetter { get; set; }
        public string DriveType { get; set; }
        public string FileSystem { get; set; }
        public ByteSize FreeSpace { get; set; }
        public ByteSize UsedSpace { get; set; }
        public string Indexing { get; set; }
        public string Label { get; set; }
    }

    public class StorageInfo
    {
        public StorageInfo()
        {
            try
            {
                ManagementObjectSearcher searcher2 = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject mo2 in searcher2.Get())
                {
                    Disk disk = new Disk();

                    disk.Model = Convert.ToString(mo2.Properties["Model"].Value);
                    disk.BytesPerSector = Convert.ToUInt32(mo2.Properties["BytesPerSector"].Value);
                    disk.FirmwareRevision = Convert.ToString(mo2.Properties["FirmwareRevision"].Value);
                    disk.MediaType = Convert.ToString(mo2.Properties["MediaType"].Value);
                    disk.Capacity = ByteSize.FromBytes(Convert.ToDouble(mo2.Properties["Size"].Value));

                    Disks.Add(disk);
                }
            }
            catch //(Exception error)
            {
                //MessageBox.Show("DiskInfo error: " + error.Message);
            }

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Volume");
                foreach (ManagementObject mo in searcher.Get())
                {
                    Volume volume = new Volume();

                    volume.BlockSize = Convert.ToUInt64(mo.Properties["BlockSize"].Value);
                    volume.Capacity = ByteSize.FromBytes(Convert.ToDouble(mo.Properties["Capacity"].Value));
                    bool temp = Convert.ToBoolean(mo.Properties["Compressed"].Value);
                    volume.Compressed = (temp) ? "Yes" : "No";
                    volume.DriveLetter = Convert.ToString(mo.Properties["DriveLetter"].Value);
                    UInt32 i = Convert.ToUInt32(mo.Properties["DriveType"].Value);
                    volume.DriveType = SanitizeDriveType(i);
                    volume.FileSystem = Convert.ToString(mo.Properties["FileSystem"].Value);
                    volume.FreeSpace = ByteSize.FromBytes(Convert.ToDouble(mo.Properties["FreeSpace"].Value));
                    volume.UsedSpace = volume.Capacity.Subtract(volume.FreeSpace);
                    bool temp2 = Convert.ToBoolean(mo.Properties["IndexingEnabled"].Value);
                    volume.Indexing = (temp2) ? "Yes" : "No";
                    volume.Label = Convert.ToString(mo.Properties["Label"].Value);

                    if (i == 2)
                    {
                        Removables.Add(volume);
                    }
                    else if (i == 5)
                    {
                        Opticals.Add(volume);
                    }
                    else
                    {
                        Volumes.Add(volume);
                    }
                    
                }
            }
            catch //(Exception error)
            {
                //MessageBox.Show("VolumeInfo error: " + error.Message);
            }
        }

        public List<Disk> Disks = new List<Disk>();
        public List<Volume> Volumes = new List<Volume>();
        public List<Volume> Removables = new List<Volume>();
        public List<Volume> Opticals = new List<Volume>();
        
        private string SanitizeDriveType(UInt32 i)
        {
            string result = string.Empty;

            switch (i)
            {
                case 0:
                    result = "Unknown";
                    break;
                case 1:
                    result = "No Root Directory";
                    break;
                case 2:
                    result = "Removable Disk";
                    break;
                case 3:
                    result = "Local Disk";
                    break;
                case 4:
                    result = "Network Drive";
                    break;
                case 5:
                    result = "Compact Disk";
                    break;
                case 6:
                    result = "RAM Disk";
                    break;
            }

            return result;
        }
    }
}
