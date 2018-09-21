using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Indicium
{
    public static class Utilities
    {
        public static void CopyToClipboard(string text)
        {
            try
            {
                Clipboard.SetText(text);
            }
            catch { }
        }

        public static void GoogleSearch(string term)
        {
            try
            {
                Process.Start("https://google.com/#q=" + term);
            }
            catch { }
        }

        public static string GetOS()
        {
            return (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName", "");
        }

        public static string GetBitness()
        {
            string bitness = "";

            if (Environment.Is64BitOperatingSystem)
            {
                bitness = "You are working with 64-bit architecture";
            }
            else
            {
                bitness = "You are working with 32-bit architecture";
            }

            return bitness;
        }

        private static string DecodeProductKey(byte[] digitalProductId)
        {
            string key = string.Empty;
            const int keyOffset = 52;
            byte isWin8 = (byte)((digitalProductId[66] / 6) & 1);
            digitalProductId[66] = (byte)((digitalProductId[66] & 0xf7) | (isWin8 & 2) * 4);

            // Possible alpha-numeric characters in product key.
            const string digits = "BCDFGHJKMPQRTVWXY2346789";
            int last = 0;
            for (int i = 24; i >= 0; i--)
            {
                int current = 0;
                for (int j = 14; j >= 0; j--)
                {
                    current = current * 256;
                    current = digitalProductId[j + keyOffset] + current;
                    digitalProductId[j + keyOffset] = (byte)(current / 24);
                    current = current % 24;
                    last = current;
                }
                key = digits[current] + key;
            }
            string keypart1 = key.Substring(1, last);
            const string insert = "N";
            key = key.Substring(1).Replace(keypart1, keypart1 + insert);
            if (last == 0)
                key = insert + key;
            for (int i = 5; i < key.Length; i += 6)
            {
                key = key.Insert(i, "-");
            }
            return key;
        }

        public static string GetProductKey()
        {
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                                          RegistryView.Default);
            const string keyPath = @"Software\Microsoft\Windows NT\CurrentVersion";
            byte[] digitalProductId = (byte[])key.OpenSubKey(keyPath, false).GetValue("DigitalProductId");

            try
            {
                string productKey = DecodeProductKey(digitalProductId);

                if (productKey.Count() > 29)
                {
                    productKey = productKey.Substring(0, 29);
                }

                return productKey;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
