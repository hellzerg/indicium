using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace Indicium
{
    public partial class MainForm : Form
    {
        readonly string _latestVersionLink = "https://raw.githubusercontent.com/hellzerg/indicium/master/version.txt";
        readonly string _releasesLink = "https://github.com/hellzerg/indicium/releases";

        readonly string _noNewVersionMessage = "You already have the latest version!";
        readonly string _betaVersionMessage = "You are using an experimental version!";

        private string NewVersionMessage(string latest)
        {
            return string.Format("There is a new version available!\n\nLatest version: {0}\nCurrent version: {1}\n\nDo you want to download it now?", latest, Program.GetCurrentVersionToString());
        }

        private void CheckForUpdate()
        {
            WebClient client = new WebClient
            {
                Encoding = Encoding.UTF8
            };

            string latestVersion = string.Empty;
            try
            {
                latestVersion = client.DownloadString(_latestVersionLink);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (!string.IsNullOrEmpty(latestVersion))
            {
                if (float.Parse(latestVersion) > Program.GetCurrentVersion())
                {
                    if (MessageBox.Show(NewVersionMessage(latestVersion), "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Process.Start(_releasesLink);
                        }
                        catch { }
                    }
                }
                else if (float.Parse(latestVersion) == Program.GetCurrentVersion())
                {
                    MessageBox.Show(_noNewVersionMessage, "No update available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(_betaVersionMessage, "No update available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        readonly string _ByteSizeNull = " b";

        OSInfo osInfo = new OSInfo();
        CPUInfo cpuInfo = new CPUInfo();
        RAMInfo ramInfo = new RAMInfo();
        MotherboardInfo motherboardInfo = new MotherboardInfo();
        GPUInfo gpuInfo = new GPUInfo();
        StorageInfo storageInfo = new StorageInfo();
        NetworkInfo networkInfo = new NetworkInfo();
        AudioInfo audioInfo = new AudioInfo();
        BIOSInfo biosInfo = new BIOSInfo();
        PeripheralsInfo peripheralsInfo = new PeripheralsInfo();

        Color disabled = Color.DodgerBlue;
        Color enabled = Color.White;
        LinkBehavior link = LinkBehavior.AlwaysUnderline;
        LinkBehavior nolink = LinkBehavior.NeverUnderline;

        ViewType SelectedView = ViewType.Summary;
        protected internal List<TreeView> views = new List<TreeView>();

        ByteSize temp;
        string memoryType = string.Empty;
        uint memorySpeed;

        private void ViewSelector(ViewType i)
        {
            FixColor();
            SelectedView = i;

            switch (i)
            {
                case ViewType.Summary:
                    LinkSummary.LinkColor = enabled;
                    LinkSummary.LinkBehavior = link;
                    LinkCPU.LinkColor = LinkRAM.LinkColor = LinkMotherboard.LinkColor = LinkGPU.LinkColor = LinkStorage.LinkColor = LinkNetwork.LinkColor = LinkAudio.LinkColor = LinkBIOS.LinkColor = LinkPeripherals.LinkColor = disabled;
                    LinkCPU.LinkBehavior = LinkRAM.LinkBehavior = LinkMotherboard.LinkBehavior = LinkGPU.LinkBehavior = LinkStorage.LinkBehavior = LinkNetwork.LinkBehavior = LinkAudio.LinkBehavior = LinkBIOS.LinkBehavior = LinkPeripherals.LinkBehavior = nolink;
                    CPUView.Visible = RAMView.Visible = MotherboardView.Visible = GraphicsView.Visible = StorageView.Visible = NetworkView.Visible = AudioView.Visible = BIOSView.Visible = PeripheralsView.Visible = false;
                    SummaryView.Visible = true;
                    break;
                case ViewType.CPU:
                    LinkCPU.LinkColor = enabled;
                    LinkCPU.LinkBehavior = link;
                    LinkSummary.LinkColor = LinkRAM.LinkColor = LinkMotherboard.LinkColor = LinkGPU.LinkColor = LinkStorage.LinkColor = LinkNetwork.LinkColor = LinkAudio.LinkColor = LinkBIOS.LinkColor = LinkPeripherals.LinkColor = disabled;
                    LinkSummary.LinkBehavior = LinkRAM.LinkBehavior = LinkMotherboard.LinkBehavior = LinkGPU.LinkBehavior = LinkStorage.LinkBehavior = LinkNetwork.LinkBehavior = LinkAudio.LinkBehavior = LinkPeripherals.LinkBehavior = LinkBIOS.LinkBehavior = nolink;
                    SummaryView.Visible = RAMView.Visible = MotherboardView.Visible = GraphicsView.Visible = StorageView.Visible = NetworkView.Visible = AudioView.Visible = BIOSView.Visible = PeripheralsView.Visible = false;
                    CPUView.Visible = true;
                    break;
                case ViewType.RAM:
                    LinkRAM.LinkColor = enabled;
                    LinkRAM.LinkBehavior = link;
                    LinkSummary.LinkColor = LinkCPU.LinkColor = LinkMotherboard.LinkColor = LinkGPU.LinkColor = LinkStorage.LinkColor = LinkNetwork.LinkColor = LinkAudio.LinkColor = LinkBIOS.LinkColor = LinkPeripherals.LinkColor = disabled;
                    LinkSummary.LinkBehavior = LinkCPU.LinkBehavior = LinkMotherboard.LinkBehavior = LinkGPU.LinkBehavior = LinkStorage.LinkBehavior = LinkNetwork.LinkBehavior = LinkAudio.LinkBehavior = LinkPeripherals.LinkBehavior = LinkBIOS.LinkBehavior = nolink;
                    SummaryView.Visible = CPUView.Visible = MotherboardView.Visible = GraphicsView.Visible = StorageView.Visible = NetworkView.Visible = AudioView.Visible = BIOSView.Visible = PeripheralsView.Visible = false;
                    RAMView.Visible = true;
                    break;
                case ViewType.Motherboard:
                    LinkMotherboard.LinkColor = enabled;
                    LinkMotherboard.LinkBehavior = link;
                    LinkSummary.LinkColor = LinkCPU.LinkColor = LinkRAM.LinkColor = LinkGPU.LinkColor = LinkStorage.LinkColor = LinkNetwork.LinkColor = LinkAudio.LinkColor = LinkBIOS.LinkColor = LinkPeripherals.LinkColor = disabled;
                    LinkSummary.LinkBehavior = LinkCPU.LinkBehavior = LinkRAM.LinkBehavior = LinkGPU.LinkBehavior = LinkStorage.LinkBehavior = LinkNetwork.LinkBehavior = LinkAudio.LinkBehavior = LinkPeripherals.LinkBehavior = LinkBIOS.LinkBehavior = nolink;
                    SummaryView.Visible = CPUView.Visible = RAMView.Visible = GraphicsView.Visible = StorageView.Visible = NetworkView.Visible = AudioView.Visible = BIOSView.Visible = PeripheralsView.Visible = false;
                    MotherboardView.Visible = true;
                    break;
                case ViewType.Graphics:
                    LinkGPU.LinkColor = enabled;
                    LinkGPU.LinkBehavior = link;
                    LinkSummary.LinkColor = LinkCPU.LinkColor = LinkRAM.LinkColor = LinkMotherboard.LinkColor = LinkStorage.LinkColor = LinkNetwork.LinkColor = LinkAudio.LinkColor = LinkPeripherals.LinkColor = LinkBIOS.LinkColor = disabled;
                    LinkSummary.LinkBehavior = LinkCPU.LinkBehavior = LinkRAM.LinkBehavior = LinkMotherboard.LinkBehavior = LinkStorage.LinkBehavior = LinkNetwork.LinkBehavior = LinkAudio.LinkBehavior = LinkPeripherals.LinkBehavior = LinkBIOS.LinkBehavior = nolink;
                    SummaryView.Visible = CPUView.Visible = RAMView.Visible = MotherboardView.Visible = StorageView.Visible = NetworkView.Visible = AudioView.Visible = BIOSView.Visible = PeripheralsView.Visible = false;
                    GraphicsView.Visible = true;
                    break;
                case ViewType.Storage:
                    LinkStorage.LinkColor = enabled;
                    LinkStorage.LinkBehavior = link;
                    LinkSummary.LinkColor = LinkCPU.LinkColor = LinkRAM.LinkColor = LinkMotherboard.LinkColor = LinkGPU.LinkColor = LinkNetwork.LinkColor = LinkAudio.LinkColor = LinkBIOS.LinkColor = LinkPeripherals.LinkColor = disabled;
                    LinkSummary.LinkBehavior = LinkCPU.LinkBehavior = LinkRAM.LinkBehavior = LinkMotherboard.LinkBehavior = LinkGPU.LinkBehavior = LinkNetwork.LinkBehavior = LinkAudio.LinkBehavior = LinkPeripherals.LinkBehavior = LinkBIOS.LinkBehavior = nolink;
                    SummaryView.Visible = CPUView.Visible = RAMView.Visible = MotherboardView.Visible = GraphicsView.Visible = NetworkView.Visible = AudioView.Visible = BIOSView.Visible = PeripheralsView.Visible = false;
                    StorageView.Visible = true;
                    break;
                case ViewType.Network:
                    LinkNetwork.LinkColor = enabled;
                    LinkNetwork.LinkBehavior = link;
                    LinkSummary.LinkColor = LinkCPU.LinkColor = LinkRAM.LinkColor = LinkMotherboard.LinkColor = LinkGPU.LinkColor = LinkStorage.LinkColor = LinkAudio.LinkColor = LinkBIOS.LinkColor = LinkPeripherals.LinkColor = disabled;
                    LinkSummary.LinkBehavior = LinkCPU.LinkBehavior = LinkRAM.LinkBehavior = LinkMotherboard.LinkBehavior = LinkGPU.LinkBehavior = LinkStorage.LinkBehavior = LinkAudio.LinkBehavior = LinkPeripherals.LinkBehavior = LinkBIOS.LinkBehavior = nolink;
                    SummaryView.Visible = CPUView.Visible = RAMView.Visible = MotherboardView.Visible = GraphicsView.Visible = StorageView.Visible = AudioView.Visible = BIOSView.Visible = PeripheralsView.Visible = false;
                    NetworkView.Visible = true;
                    break;
                case ViewType.Audio:
                    LinkAudio.LinkColor = enabled;
                    LinkAudio.LinkBehavior = link;
                    LinkSummary.LinkColor = LinkCPU.LinkColor = LinkRAM.LinkColor = LinkMotherboard.LinkColor = LinkGPU.LinkColor = LinkStorage.LinkColor = LinkNetwork.LinkColor = LinkBIOS.LinkColor = LinkPeripherals.LinkColor = disabled;
                    LinkSummary.LinkBehavior = LinkCPU.LinkBehavior = LinkRAM.LinkBehavior = LinkMotherboard.LinkBehavior = LinkGPU.LinkBehavior = LinkStorage.LinkBehavior = LinkNetwork.LinkBehavior = LinkPeripherals.LinkBehavior = LinkBIOS.LinkBehavior = nolink;
                    SummaryView.Visible = CPUView.Visible = RAMView.Visible = MotherboardView.Visible = GraphicsView.Visible = StorageView.Visible = NetworkView.Visible = BIOSView.Visible = PeripheralsView.Visible = false;
                    AudioView.Visible = true;
                    break;
                case ViewType.Peripherals:
                    LinkPeripherals.LinkColor = enabled;
                    LinkPeripherals.LinkBehavior = link;
                    LinkSummary.LinkColor = LinkCPU.LinkColor = LinkRAM.LinkColor = LinkMotherboard.LinkColor = LinkGPU.LinkColor = LinkStorage.LinkColor = LinkNetwork.LinkColor = LinkAudio.LinkColor = LinkBIOS.LinkColor = disabled;
                    LinkSummary.LinkBehavior = LinkCPU.LinkBehavior = LinkRAM.LinkBehavior = LinkMotherboard.LinkBehavior = LinkGPU.LinkBehavior = LinkStorage.LinkBehavior = LinkNetwork.LinkBehavior = LinkAudio.LinkBehavior = LinkBIOS.LinkBehavior = nolink;
                    SummaryView.Visible = CPUView.Visible = RAMView.Visible = MotherboardView.Visible = GraphicsView.Visible = StorageView.Visible = NetworkView.Visible = AudioView.Visible = BIOSView.Visible = false;
                    PeripheralsView.Visible = true;
                    break;
                case ViewType.BIOS:
                    LinkBIOS.LinkColor = enabled;
                    LinkBIOS.LinkBehavior = link;
                    LinkSummary.LinkColor = LinkCPU.LinkColor = LinkRAM.LinkColor = LinkMotherboard.LinkColor = LinkGPU.LinkColor = LinkStorage.LinkColor = LinkNetwork.LinkColor = LinkPeripherals.LinkColor = LinkAudio.LinkColor = disabled;
                    LinkSummary.LinkBehavior = LinkCPU.LinkBehavior = LinkRAM.LinkBehavior = LinkMotherboard.LinkBehavior = LinkGPU.LinkBehavior = LinkStorage.LinkBehavior = LinkPeripherals.LinkBehavior = LinkNetwork.LinkBehavior = LinkAudio.LinkBehavior = nolink;
                    SummaryView.Visible = CPUView.Visible = RAMView.Visible = MotherboardView.Visible = GraphicsView.Visible = StorageView.Visible = NetworkView.Visible = AudioView.Visible = PeripheralsView.Visible = false;
                    BIOSView.Visible = true;
                    break;
            }

            FixColor();
        }

        private void SaveView()
        {
            Form f = ActiveForm;
            Bitmap bmp = new Bitmap(f.Width, f.Height);
            f.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Title = "Choose where to save the image...";
            dialog.Filter = "PNG Images|*.png";

            switch (SelectedView)
            {
                case ViewType.Peripherals:
                    dialog.FileName = "Peripherals";
                    break;
                case ViewType.Audio:
                    dialog.FileName = "Audio";
                    break;
                case ViewType.BIOS:
                    dialog.FileName = "BIOS";
                    break;
                case ViewType.CPU:
                    dialog.FileName = "CPU";
                    break;
                case ViewType.Graphics:
                    dialog.FileName = "Graphics";
                    break;
                case ViewType.Motherboard:
                    dialog.FileName = "Motherboard";
                    break;
                case ViewType.Network:
                    dialog.FileName = "Network";
                    break;
                case ViewType.RAM:
                    dialog.FileName = "RAM";
                    break;
                case ViewType.Storage:
                    dialog.FileName = "Storage";
                    break;
                case ViewType.Summary:
                    dialog.FileName = "Summary";
                    break;
            }

            DialogResult result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                bmp.Save(dialog.FileName);
            }
        }

        private void SaveAllViews()
        {
            string folder = Application.StartupPath + "\\" + Environment.MachineName + "\\";

            string os = JsonConvert.SerializeObject(osInfo, Formatting.Indented);
            string cpu = JsonConvert.SerializeObject(cpuInfo, Formatting.Indented);
            string ram = JsonConvert.SerializeObject(ramInfo, Formatting.Indented);
            string mobo = JsonConvert.SerializeObject(motherboardInfo, Formatting.Indented);
            string gpu = JsonConvert.SerializeObject(gpuInfo, Formatting.Indented);
            string storage = JsonConvert.SerializeObject(storageInfo, Formatting.Indented);
            string network = JsonConvert.SerializeObject(networkInfo, Formatting.Indented);
            string audio = JsonConvert.SerializeObject(audioInfo, Formatting.Indented);
            string peripherals = JsonConvert.SerializeObject(peripheralsInfo, Formatting.Indented);
            string bios = JsonConvert.SerializeObject(biosInfo, Formatting.Indented);

            Directory.CreateDirectory(folder);

            File.WriteAllText(folder + "OS.json", os);
            File.WriteAllText(folder + "CPUs.json", cpu);
            File.WriteAllText(folder + "RAM.json", ram);
            File.WriteAllText(folder + "Motherboards.json", mobo);
            File.WriteAllText(folder + "Graphics.json", gpu);
            File.WriteAllText(folder + "Storage.json", storage);
            File.WriteAllText(folder + "Network.json", network);
            File.WriteAllText(folder + "Audio.json", audio);
            File.WriteAllText(folder + "BIOS.json", bios);
            File.WriteAllText(folder + "Peripherals.json", peripherals);

            Process.Start(folder);
        }

        private void LoadSummaryView()
        {
            SummaryView.Nodes["rootOS"].Nodes.Add("OS: " + osInfo.OperatingSystem);
            SummaryView.Nodes["rootOS"].Nodes.Add("System type: " + osInfo.SystemType);
            SummaryView.Nodes["rootOS"].Nodes.Add("Product key: " + osInfo.ProductKey);
            SummaryView.Nodes["rootOS"].Nodes.Add("Computer name: " + osInfo.ComputerName);

            if (cpuInfo.CPUs.Count > 0)
            {
                foreach (CPU cpu in cpuInfo.CPUs)
                {
                    SummaryView.Nodes["rootCPU"].Nodes.Add(string.Format("{0} ({1} Cores, {2} Threads)", cpu.Name, cpu.Cores.ToString(), cpu.LogicalCpus.ToString()));
                }
            }
            else
            {
                SummaryView.Nodes["rootCPU"].Nodes.Add("No CPUs detected");
            }

            if (ramInfo.Modules.Count > 0)
            {
                //temp = new ByteSize();
                foreach (RAM ram in ramInfo.Modules)
                {
                    temp += ram.Capacity;
                    memoryType = ram.MemoryType;
                    memorySpeed = ram.Speed;
                }
                SummaryView.Nodes["rootRAM"].Nodes.Add(string.Format("{0} {1} @ {2} MHz", temp, memoryType, memorySpeed));
            }
            else
            {
                SummaryView.Nodes["rootRAM"].Nodes.Add("No RAM modules detected");
            }

            if (motherboardInfo.Boards.Count > 0)
            {
                foreach (Motherboard mobo in motherboardInfo.Boards)
                {
                    SummaryView.Nodes["rootMotherboard"].Nodes.Add(string.Format("{0}", mobo.Manufacturer));
                }
            }
            else
            {
                SummaryView.Nodes["rootMotherboard"].Nodes.Add("No motherboards detected");
            }
            
            if (gpuInfo.GPUs.Count > 0)
            {
                foreach (GPU gpu in gpuInfo.GPUs)
                {
                    SummaryView.Nodes["rootGPU"].Nodes.Add(string.Format("{0} ({1})", gpu.Name, gpu.Memory));
                }
            }
            else
            {
                SummaryView.Nodes["rootGPU"].Nodes.Add("No GPUs detected");
            }

            if (storageInfo.Disks.Count > 0)
            {
                foreach (Disk disk in storageInfo.Disks)
                {
                    if (disk.Capacity.ToString() != _ByteSizeNull)
                    {
                        SummaryView.Nodes["rootStorage"].Nodes.Add(string.Format("{0} ({1})", disk.Model, disk.Capacity));
                    }
                    else
                    {
                        SummaryView.Nodes["rootStorage"].Nodes.Add(string.Format("{0}", disk.Model));
                    }
                }
            }
            else
            {
                SummaryView.Nodes["rootStorage"].Nodes.Add("No disks detected");
            }

            if (networkInfo.PhysicalAdapters.Count > 0)
            {
                foreach (NetworkAdapter adapter in networkInfo.PhysicalAdapters)
                {
                    SummaryView.Nodes["rootNetwork"].Nodes.Add(string.Format("{0}", adapter.ProductName));
                }
            }
            else
            {
                SummaryView.Nodes["rootNetwork"].Nodes.Add("No network adapters detected");
            }
           
            if (audioInfo.AudioDevices.Count > 0)
            {
                foreach (AudioDevice device in audioInfo.AudioDevices)
                {
                    SummaryView.Nodes["rootAudio"].Nodes.Add(string.Format("{0}", device.ProductName));
                }
            }
            else
            {
                SummaryView.Nodes["rootAudio"].Nodes.Add("No audio devices detected");
            }

            if (peripheralsInfo.Keyboards.Count > 0)
            {
                foreach (Keyboard keyboard in peripheralsInfo.Keyboards)
                {
                    SummaryView.Nodes["rootPeripheral"].Nodes.Add(string.Format("{0}", keyboard.Name));
                }
            }
            else
            {
                SummaryView.Nodes["rootPeripheral"].Nodes.Add("No keyboards detected");
            }

            if (peripheralsInfo.PointingDevices.Count > 0)
            {
                foreach (PointingDevice pointingDevice in peripheralsInfo.PointingDevices)
                {
                    SummaryView.Nodes["rootPeripheral"].Nodes.Add(string.Format("{0}", pointingDevice.Name));
                }
            }
            else
            {
                SummaryView.Nodes["rootPeripheral"].Nodes.Add("No pointing devices detected");
            }

            if (biosInfo != null)
            {
                SummaryView.Nodes["rootBIOS"].Nodes.Add(string.Format("{0} {1}", biosInfo.Manufacturer, biosInfo.Name));
            }
            else
            {
                SummaryView.Nodes["rootBIOS"].Nodes.Add("Unable to detect BIOS");
            }

            SummaryView.ExpandAll();
        }

        private void LoadCPUView()
        {
            if (cpuInfo.CPUs.Count > 0)
            {
                foreach (CPU cpu in cpuInfo.CPUs)
                {
                    TreeNode node = new TreeNode(cpu.Name);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("Cores: " + cpu.Cores);
                    node.Nodes.Add("Threads: " + cpu.LogicalCpus);
                    //node.Nodes.Add("Logical CPUs: " + cpu.LogicalCpus);
                    node.Nodes.Add("Virtualization: " + cpu.Virtualization);
                    node.Nodes.Add("Data Execution Prevention: " + cpu.DataExecutionPrevention);
                    node.Nodes.Add("L2 Cache: " + cpu.L2CacheSize);
                    node.Nodes.Add("L3 Cache: " + cpu.L3CacheSize);
                    node.Nodes.Add("Stepping: " + cpu.Stepping);
                    node.Nodes.Add("Revision: " + cpu.Revision);
                    CPUView.Nodes.Add(node);
                }
            }
            else
            {
                CPUView.Nodes.Add("No CPUs detected");
            }

            CPUView.ExpandAll();
        }

        private void LoadRAMView()
        {
            if (ramInfo.Modules.Count > 0)
            {
                foreach (RAM ram in ramInfo.Modules)
                {
                    TreeNode node = new TreeNode(ram.BankLabel.Replace("Bank", "Module"));
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("Manufacturer: " + ram.Manufacturer);
                    node.Nodes.Add("Size: " + ram.Capacity);
                    node.Nodes.Add("Memory Type: " + ram.MemoryType);
                    node.Nodes.Add("Speed: " + ram.Speed + " MHz");
                    node.Nodes.Add("Form Factor: " + ram.FormFactor);
                    RAMView.Nodes.Add(node);
                }
            }
            else
            {
                RAMView.Nodes.Add("No RAM modules detected");
            }
            
            if (ramInfo.VirtualMemory != null)
            {
                TreeNode node = new TreeNode("Virtual Memory");
                node.ForeColor = disabled;
                node.Tag = Options.ThemeTag;
                node.Nodes.Add("Total: " + ramInfo.VirtualMemory.TotalVirtualMemory);
                node.Nodes.Add("Available : " +ramInfo.VirtualMemory.AvailableVirtualMemory);
                node.Nodes.Add("Used: " + ramInfo.VirtualMemory.UsedVirtualMemory);
                RAMView.Nodes.Add(node);
            }

            RAMView.ExpandAll();
        }

        private void LoadMotherboardView()
        {
            if (motherboardInfo.Boards.Count > 0)
            {
                foreach (Motherboard mobo in motherboardInfo.Boards)
                {
                    TreeNode node = new TreeNode(mobo.Manufacturer);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("System: " + mobo.SystemModel);
                    node.Nodes.Add("Chipset: " + mobo.Chipset);
                    node.Nodes.Add("Product: " + mobo.Product);
                    node.Nodes.Add("Model: " + mobo.Model);
                    node.Nodes.Add("Version: " + mobo.Version);
                    node.Nodes.Add("Revision: " + mobo.Revision);
                    MotherboardView.Nodes.Add(node);
                }
            }
            else
            {
                MotherboardView.Nodes.Add("No motherboards detected");
            }

            MotherboardView.ExpandAll();
        }

        private void LoadGraphicsView()
        {
            if (gpuInfo.GPUs.Count > 0)
            {
                foreach (GPU gpu in gpuInfo.GPUs)
                {
                    TreeNode node = new TreeNode(gpu.Name);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("Video Memory: " + gpu.Memory);
                    node.Nodes.Add("Video Memory Type: " + gpu.VideoMemoryType);
                    node.Nodes.Add("DAC Type: " + gpu.DACType);
                    node.Nodes.Add("Current Resolution: " + gpu.ResolutionX + " x " + gpu.ResolutionY);
                    node.Nodes.Add("Current Refresh Rate: " + gpu.RefreshRate + " Hz");
                    GraphicsView.Nodes.Add(node);
                }
            }
            else
            {
                GraphicsView.Nodes.Add("No GPUs detected");
            }

            GraphicsView.ExpandAll();
        }

        private void LoadStorageView()
        {
            if (storageInfo.Disks.Count > 0)
            {
                foreach (Disk disk in storageInfo.Disks)
                {
                    TreeNode node = new TreeNode(disk.Model);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    if (disk.Capacity.ToString() != _ByteSizeNull)
                    {
                        node.Nodes.Add("Size: " + disk.Capacity);
                    }
                    else
                    {
                        node.Nodes.Add("Size: -");
                    }
                    node.Nodes.Add("Firmware Revision: " + disk.FirmwareRevision);
                    node.Nodes.Add("Media Type: " + disk.MediaType);
                    node.Nodes.Add("Bytes/Sector: " + disk.BytesPerSector);
                    StorageView.Nodes["rootDisk"].Nodes.Add(node);
                }
            }
            else
            {
                StorageView.Nodes["rootDisk"].Nodes.Add("No disks detected");
            }

            if (storageInfo.Volumes.Count > 0)
            {
                foreach (Volume volume in storageInfo.Volumes)
                {
                    string tmp = string.Empty;
                    if (!string.IsNullOrEmpty(volume.DriveLetter))
                    {
                        tmp = " (" + volume.DriveLetter + ")";
                    }
                    else
                    {
                        tmp = string.Empty;
                    }

                    TreeNode node = new TreeNode(volume.Label + tmp);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("File System: " + volume.FileSystem);
                    if (volume.Capacity.ToString() != _ByteSizeNull)
                    {
                        node.Nodes.Add("Size: " + volume.Capacity);
                    }
                    else
                    {
                        node.Nodes.Add("Size: -");
                    }
                    if (volume.UsedSpace.ToString() != _ByteSizeNull)
                    {
                        node.Nodes.Add("Used Space: " + volume.UsedSpace);
                    }
                    else
                    {
                        node.Nodes.Add("Used Space: -");
                    }
                    if (volume.FreeSpace.ToString() != _ByteSizeNull)
                    {
                        node.Nodes.Add("Free Space: " + volume.FreeSpace);
                    }
                    else
                    {
                        node.Nodes.Add("Free Space: -");
                    }
                    node.Nodes.Add("Indexing: " + volume.Indexing);
                    node.Nodes.Add("Compressed: " + volume.Compressed);
                    node.Nodes.Add("Drive Type: " + volume.DriveType);
                    node.Nodes.Add("Block Size: " + volume.BlockSize);
                    StorageView.Nodes["rootVolume"].Nodes.Add(node);
                }
            }
            else
            {
                StorageView.Nodes["rootVolume"].Nodes.Add("No volumes detected");
            }

            if (storageInfo.Opticals.Count > 0)
            {
                foreach (Volume optical in storageInfo.Opticals)
                {
                    string tmp = string.Empty;
                    if (!string.IsNullOrEmpty(optical.DriveLetter))
                    {
                        tmp = " (" + optical.DriveLetter + ")";
                    }
                    else
                    {
                        tmp = string.Empty;
                    }

                    TreeNode node = new TreeNode(optical.Label + tmp);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("File System: " + optical.FileSystem);
                    if (optical.Capacity.ToString() != _ByteSizeNull)
                    {
                        node.Nodes.Add("Size: " + optical.Capacity);
                    }
                    else
                    {
                        node.Nodes.Add("Size: -");
                    }
                    if (optical.UsedSpace.ToString() != _ByteSizeNull)
                    {
                        node.Nodes.Add("Used Space: " + optical.UsedSpace);
                    }
                    else
                    {
                        node.Nodes.Add("Used Space: -");
                    }
                    if (optical.FreeSpace.ToString() != _ByteSizeNull)
                    {
                        node.Nodes.Add("Free Space: " + optical.FreeSpace);
                    }
                    else
                    {
                        node.Nodes.Add("Free Space: -");
                    }
                    node.Nodes.Add("Indexing: " + optical.Indexing);
                    node.Nodes.Add("Compressed: " + optical.Compressed);
                    node.Nodes.Add("Drive Type: " + optical.DriveType);
                    node.Nodes.Add("Block Size: " + optical.BlockSize);
                    StorageView.Nodes["rootOptical"].Nodes.Add(node);
                }
            }
            else
            {
                StorageView.Nodes["rootOptical"].Nodes.Add("No opticals detected");
            }

            if (storageInfo.Removables.Count > 0)
            {
                foreach (Volume removable in storageInfo.Removables)
                {
                    string tmp = string.Empty;
                    if (!string.IsNullOrEmpty(removable.DriveLetter))
                    {
                        tmp = " (" + removable.DriveLetter + ")";
                    }
                    else
                    {
                        tmp = string.Empty;
                    }

                    TreeNode node = new TreeNode(removable.Label + tmp);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("File System: " + removable.FileSystem);
                    if (removable.Capacity.ToString() != _ByteSizeNull)
                    {
                        node.Nodes.Add("Size: " + removable.Capacity);
                    }
                    else
                    {
                        node.Nodes.Add("Size: -");
                    }
                    if (removable.UsedSpace.ToString() != _ByteSizeNull)
                    {
                        node.Nodes.Add("Used Space: " + removable.UsedSpace);
                    }
                    else
                    {
                        node.Nodes.Add("Used Space: -");
                    }
                    if (removable.FreeSpace.ToString() != _ByteSizeNull)
                    {
                        node.Nodes.Add("Free Space: " + removable.FreeSpace);
                    }
                    else
                    {
                        node.Nodes.Add("Free Space: -");
                    }
                    node.Nodes.Add("Indexing: " + removable.Indexing);
                    node.Nodes.Add("Compressed: " + removable.Compressed);
                    node.Nodes.Add("Drive Type: " + removable.DriveType);
                    node.Nodes.Add("Block Size: " + removable.BlockSize);
                    StorageView.Nodes["rootRemovable"].Nodes.Add(node);
                }
            }
            else
            {
                StorageView.Nodes["rootRemovable"].Nodes.Add("No removables detected");
            }

            StorageView.ExpandAll();
        }

        private void LoadNetworkView()
        {
            if (networkInfo.PhysicalAdapters.Count > 0)
            {
                foreach (NetworkAdapter adapter in networkInfo.PhysicalAdapters)
                {
                    TreeNode node = new TreeNode(adapter.ProductName);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("Manufacturer: " + adapter.Manufacturer);
                    node.Nodes.Add("Adapter Type: " + adapter.AdapterType);
                    node.Nodes.Add("MAC Address: " + adapter.MacAddress);
                    node.Nodes.Add("Physical Adapter: " + adapter.PhysicalAdapter);
                    node.Nodes.Add("Service Name: " + adapter.ServiceName);
                    NetworkView.Nodes["rootPhysical"].Nodes.Add(node);
                }
            }
            else
            {
                NetworkView.Nodes["rootPhysical"].Nodes.Add("No physical adapters detected");
            }

            if (networkInfo.VirtualAdapters.Count > 0)
            {
                foreach (NetworkAdapter adapter in networkInfo.VirtualAdapters)
                {
                    TreeNode node = new TreeNode(adapter.ProductName);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("Manufacturer: " + adapter.Manufacturer);
                    node.Nodes.Add("Adapter Type: " + adapter.AdapterType);
                    node.Nodes.Add("MAC Address: " + adapter.MacAddress);
                    node.Nodes.Add("Physical Adapter: " + adapter.PhysicalAdapter);
                    node.Nodes.Add("Service Name: " + adapter.ServiceName);
                    NetworkView.Nodes["rootVirtual"].Nodes.Add(node);
                }
            }
            else
            {
                NetworkView.Nodes["rootVirtual"].Nodes.Add("No virtual adapters detected");
            }

            NetworkView.ExpandAll();
        }

        private void LoadAudioView()
        {
            if (audioInfo.AudioDevices.Count > 0)
            {
                foreach (AudioDevice device in audioInfo.AudioDevices)
                {
                    TreeNode node = new TreeNode(device.ProductName);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("Manufacturer: " + device.Manufacturer);
                    node.Nodes.Add("Status: " + device.Status);
                    AudioView.Nodes.Add(node);
                }
            }
            else
            {
                AudioView.Nodes.Add("No audio devices detected");
            }

            AudioView.ExpandAll();
        }

        private void LoadPeripheralsView()
        {
            if (peripheralsInfo.Keyboards.Count > 0)
            {
                foreach (Keyboard keyboard in peripheralsInfo.Keyboards)
                {
                    TreeNode node = new TreeNode(keyboard.Name);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("Layout: " + keyboard.Layout);
                    node.Nodes.Add("Function Keys: " + keyboard.FunctionKeys);
                    node.Nodes.Add("Status: " + keyboard.Status);
                    node.Nodes.Add("Locked: " + keyboard.Locked);
                    PeripheralsView.Nodes["rootKeyboard"].Nodes.Add(node);
                }
            }
            else
            {
                PeripheralsView.Nodes["rootKeyboard"].Nodes.Add("No keyboards detected");
            }

            if (peripheralsInfo.PointingDevices.Count > 0)
            {
                foreach (PointingDevice pointingDevice in peripheralsInfo.PointingDevices)
                {
                    TreeNode node = new TreeNode(pointingDevice.Name);
                    node.ForeColor = disabled;
                    node.Tag = Options.ThemeTag;
                    node.Nodes.Add("Manufacturer: " + pointingDevice.Manufacturer);
                    node.Nodes.Add("Buttons: " + pointingDevice.Buttons);
                    node.Nodes.Add("Pointing Type: " + pointingDevice.PointingType);
                    node.Nodes.Add("Device Interface: " + pointingDevice.DeviceInterface);
                    node.Nodes.Add("Hardware Type: " + pointingDevice.HardwareType);
                    node.Nodes.Add("Status: " + pointingDevice.Status);
                    node.Nodes.Add("Locked: " + pointingDevice.Locked);
                    PeripheralsView.Nodes["rootPointing"].Nodes.Add(node);
                }
            }
            else
            {
                PeripheralsView.Nodes["rootPointing"].Nodes.Add("No pointing devices detected");
            }

            PeripheralsView.ExpandAll();
        }

        private void LoadBIOSView()
        {
            if (biosInfo != null)
            {
                TreeNode node = new TreeNode(biosInfo.Name);
                node.ForeColor = disabled;
                node.Tag = Options.ThemeTag;
                node.Nodes.Add("Manufacturer: " + biosInfo.Manufacturer);
                node.Nodes.Add("Version: " + biosInfo.Version);
                node.Nodes.Add("Build Number: " + biosInfo.BuildNumber);
                //node.Nodes.Add("Date: " + biosInfo.ReleaseDate.ToLongDateString());
                BIOSView.Nodes.Add(node);
            }
            else
            {
                BIOSView.Nodes.Add("Unable to detect BIOS");
            }

            BIOSView.ExpandAll();
        }

        private void InitializeViews()
        {
            views.Add(SummaryView);
            views.Add(CPUView);
            views.Add(RAMView);
            views.Add(MotherboardView);
            views.Add(GraphicsView);
            views.Add(StorageView);
            views.Add(NetworkView);
            views.Add(AudioView);
            views.Add(BIOSView);
            views.Add(PeripheralsView);
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeViews();
            Options.ApplyTheme(this, views);
            helperMenu.Renderer = new ToolStripRendererMaterial();
        }

        private void FixColor()
        {
            switch (Options.CurrentOptions.Color)
            {
                case Theme.Caramel:
                    disabled = Color.DarkOrange;
                    break;
                case Theme.Lime:
                    disabled = Color.LimeGreen;
                    break;
                case Theme.Magma:
                    disabled = Color.Tomato;
                    break;
                case Theme.Minimal:
                    disabled = Color.Gray;
                    break;
                case Theme.Ocean:
                    disabled = Color.DodgerBlue;
                    break;
                case Theme.Zerg:
                    disabled = Color.MediumOrchid;
                    break;
            }

            if (LinkSummary.LinkBehavior == link)
            {
                LinkSummary.LinkColor = enabled;
            }
            if (LinkCPU.LinkBehavior == link)
            {
                LinkCPU.LinkColor = enabled;
            }
            if (LinkRAM.LinkBehavior == link)
            {
                LinkRAM.LinkColor = enabled;
            }
            if (LinkMotherboard.LinkBehavior == link)
            {
                LinkMotherboard.LinkColor = enabled;
            }
            if (LinkGPU.LinkBehavior == link)
            {
                LinkGPU.LinkColor = enabled;
            }
            if (LinkStorage.LinkBehavior == link)
            {
                LinkStorage.LinkColor = enabled;
            }
            if (LinkNetwork.LinkBehavior == link)
            {
                LinkNetwork.LinkColor = enabled;
            }
            if (LinkAudio.LinkBehavior == link)
            {
                LinkAudio.LinkColor = enabled;
            }
            if (LinkPeripherals.LinkBehavior == link)
            {
                LinkPeripherals.LinkColor = enabled;
            }
            if (LinkBIOS.LinkBehavior == link)
            {
                LinkBIOS.LinkColor = enabled;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            FixColor();

            lblversion.Text = "Version: " + Program.GetCurrentVersionToString();
            lblos.Text = "Microsoft " + Utilities.GetOS();
            lblbitness.Text = Utilities.GetBitness();

            LoadSummaryView();
            LoadCPUView();
            LoadRAMView();
            LoadMotherboardView();
            LoadGraphicsView();
            LoadStorageView();
            LoadNetworkView();
            LoadAudioView();
            LoadPeripheralsView();
            LoadBIOSView();
            
            ViewSelector(ViewType.Summary);
            SummaryView.Nodes[0].EnsureVisible();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog(this);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSelector(ViewType.Summary);
        }

        private void LinkCPU_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSelector(ViewType.CPU);
        }

        private void LinkRAM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSelector(ViewType.RAM);
        }

        private void LinkMotherboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSelector(ViewType.Motherboard);
        }

        private void LinkGPU_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSelector(ViewType.Graphics);
        }

        private void LinkStorage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSelector(ViewType.Storage);
        }

        private void LinkNetwork_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSelector(ViewType.Network);
        }

        private void LinkAudio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSelector(ViewType.Audio);
        }

        private void LinkBIOS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSelector(ViewType.BIOS);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options.SaveSettings();
        }

        private void LinkPeripherals_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSelector(ViewType.Peripherals);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveAllViews();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OptionsDialog f = new OptionsDialog(this);
            f.ShowDialog(this);
            FixColor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveView();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (SelectedView)
            {
                case ViewType.Audio:
                    Utilities.CopyToClipboard(AudioView.SelectedNode.Text);
                    break;
                case ViewType.BIOS:
                    Utilities.CopyToClipboard(BIOSView.SelectedNode.Text);
                    break;
                case ViewType.CPU:
                    Utilities.CopyToClipboard(CPUView.SelectedNode.Text);
                    break;
                case ViewType.Graphics:
                    Utilities.CopyToClipboard(GraphicsView.SelectedNode.Text);
                    break;
                case ViewType.Motherboard:
                    Utilities.CopyToClipboard(MotherboardView.SelectedNode.Text);
                    break;
                case ViewType.Network:
                    Utilities.CopyToClipboard(NetworkView.SelectedNode.Text);
                    break;
                case ViewType.Peripherals:
                    Utilities.CopyToClipboard(PeripheralsView.SelectedNode.Text);
                    break;
                case ViewType.RAM:
                    Utilities.CopyToClipboard(RAMView.SelectedNode.Text);
                    break;
                case ViewType.Storage:
                    Utilities.CopyToClipboard(StorageView.SelectedNode.Text);
                    break;
                case ViewType.Summary:
                    Utilities.CopyToClipboard(SummaryView.SelectedNode.Text);
                    break;
            }
        }

        private void googleSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (SelectedView)
            {
                case ViewType.Audio:
                    Utilities.GoogleSearch(AudioView.SelectedNode.Text);
                    break;
                case ViewType.BIOS:
                    Utilities.GoogleSearch(BIOSView.SelectedNode.Text);
                    break;
                case ViewType.CPU:
                    Utilities.GoogleSearch(CPUView.SelectedNode.Text);
                    break;
                case ViewType.Graphics:
                    Utilities.GoogleSearch(GraphicsView.SelectedNode.Text);
                    break;
                case ViewType.Motherboard:
                    Utilities.GoogleSearch(MotherboardView.SelectedNode.Text);
                    break;
                case ViewType.Network:
                    Utilities.GoogleSearch(NetworkView.SelectedNode.Text);
                    break;
                case ViewType.Peripherals:
                    Utilities.GoogleSearch(PeripheralsView.SelectedNode.Text);
                    break;
                case ViewType.RAM:
                    Utilities.GoogleSearch(RAMView.SelectedNode.Text);
                    break;
                case ViewType.Storage:
                    Utilities.GoogleSearch(StorageView.SelectedNode.Text);
                    break;
                case ViewType.Summary:
                    Utilities.GoogleSearch(SummaryView.SelectedNode.Text);
                    break;
            }
        }

        private void AudioView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                AudioView.SelectedNode = e.Node;
            }
        }

        private void BIOSView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                BIOSView.SelectedNode = e.Node;
            }
        }

        private void CPUView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                CPUView.SelectedNode = e.Node;
            }
        }

        private void GraphicsView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                GraphicsView.SelectedNode = e.Node;
            }
        }

        private void MotherboardView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                MotherboardView.SelectedNode = e.Node;
            }
        }

        private void NetworkView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                NetworkView.SelectedNode = e.Node;
            }
        }

        private void PeripheralsView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                PeripheralsView.SelectedNode = e.Node;
            }
        }

        private void RAMView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                RAMView.SelectedNode = e.Node;
            }
        }

        private void StorageView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                StorageView.SelectedNode = e.Node;
            }
        }

        private void SummaryView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                SummaryView.SelectedNode = e.Node;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckForUpdate();
        }
    }
}
