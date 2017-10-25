using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Indicium
{
    public class Keyboard
    {
        public string Name { get; set; }
        public string Layout { get; set; }
        public string Status { get; set; }
        public UInt16 FunctionKeys { get; set; }
        public string Locked { get; set; }
    }

    public class PointingDevice
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Status { get; set; }
        public UInt16 Buttons { get; set; }
        public string Locked { get; set; }
        public string HardwareType { get; set; }
        public string PointingType { get; set; }
        public string DeviceInterface { get; set; }
    }

    //public class Printer
    //{

    //}

    public class PeripheralsInfo
    {
        public PeripheralsInfo()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Keyboard");
                foreach (ManagementObject mo in searcher.Get())
                {
                    Keyboard keyboard = new Keyboard();

                    keyboard.Name = Convert.ToString(mo.Properties["Description"].Value);
                    keyboard.Layout = Convert.ToString(mo.Properties["Layout"].Value);
                    keyboard.Status = Convert.ToString(mo.Properties["Status"].Value);
                    keyboard.FunctionKeys = Convert.ToUInt16(mo.Properties["NumberOfFunctionKeys"].Value);
                    bool temp = Convert.ToBoolean(mo.Properties["IsLocked"].Value);
                    keyboard.Locked = (temp) ? "Yes" : "No";

                    Keyboards.Add(keyboard);
                }
            }
            catch { }

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PointingDevice");
                foreach (ManagementObject mo in searcher.Get())
                {
                    PointingDevice pointingDevice = new PointingDevice();

                    pointingDevice.Name = Convert.ToString(mo.Properties["Description"].Value);
                    pointingDevice.Manufacturer = Convert.ToString(mo.Properties["Manufacturer"].Value);
                    pointingDevice.Status = Convert.ToString(mo.Properties["Status"].Value);
                    pointingDevice.Buttons = Convert.ToUInt16(mo.Properties["NumberOfButtons"].Value);
                    bool temp = Convert.ToBoolean(mo.Properties["IsLocked"].Value);
                    pointingDevice.Locked = (temp) ? "Yes" : "No";
                    pointingDevice.HardwareType = Convert.ToString(mo.Properties["HardwareType"].Value);
                    UInt16 i = Convert.ToUInt16(mo.Properties["PointingType"].Value);
                    pointingDevice.PointingType = SanitizePointingType(i);
                    UInt16 i2 = Convert.ToUInt16(mo.Properties["DeviceInterface"].Value);
                    pointingDevice.DeviceInterface = SanitizeDeviceInterface(i2);

                    PointingDevices.Add(pointingDevice);
                }
            }
            catch { }
        }

        public List<Keyboard> Keyboards = new List<Keyboard>();
        public List<PointingDevice> PointingDevices = new List<PointingDevice>();
        //public List<Printer> Printers = new List<Printer>();

        private string SanitizeDeviceInterface(UInt16 i)
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
                    result = "Serial";
                    break;
                case 4:
                    result = "PS/2";
                    break;
                case 5:
                    result = "Infrared";
                    break;
                case 6:
                    result = "HP-HIL";
                    break;
                case 7:
                    result = "Bus mouse";
                    break;
                case 8:
                    result = "ADB (Apple Desktop Bus)";
                    break;
                case 160:
                    result = "Bus mouse DB-9";
                    break;
                case 161:
                    result = "Bus mouse micro-DIN";
                    break;
                case 162:
                    result = "USB";
                    break;
            }

            return result;
        }

        private string SanitizePointingType(UInt16 i)
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
                    result = "Mouse";
                    break;
                case 4:
                    result = "Track Ball";
                    break;
                case 5:
                    result = "Track Point";
                    break;
                case 6:
                    result = "Glide Point";
                    break;
                case 7:
                    result = "Touch Pad";
                    break;
                case 8:
                    result = "Touch Screen";
                    break;
                case 9:
                    result = "Mouse - Optical Sensor";
                    break;
            }

            return result;
        }
    }
}
