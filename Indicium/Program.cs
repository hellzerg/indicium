using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indicium
{
    static class Program
    {
        /* VERSION PROPERTIES */
        /* DO NOT LEAVE THEM EMPTY */

        // Enter current version here
        internal readonly static float Major = 1;
        internal readonly static float Minor = 8;

        /* END OF VERSION PROPERTIES */

        private readonly static string noadminmsg = "Indicium needs to be run as administrator!\nApp will now close...";
        private readonly static string unsupportedmsg = "Indicium works in Windows 7 or higher!\nApp will now close...";

        internal static string GetCurrentVersionToString()
        {
            return Major.ToString() + "." + Minor.ToString();
        }

        internal static float GetCurrentVersion()
        {
            return float.Parse(GetCurrentVersionToString());
        }
        
        private static bool IsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private static bool IsSevenOrHigher()
        {
            string os = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName", "");
            bool legit;

            if ((os.Contains("XP")) || (os.Contains("Vista")) || os.Contains("Server 2003"))
            {
                legit = false;
            }
            else
            {
                legit = true;
            }
            return legit;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (IsAdmin() == false)
            {
                Messager f = new Messager(noadminmsg);
                f.ShowDialog();

                Application.Exit();
            }
            else
            {
                if (IsSevenOrHigher() == true)
                {
                    string resource = "Indicium.Newtonsoft.Json.dll";
                    EmbeddedAssembly.Load(resource, "Newtonsoft.Json.dll");
                    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

                    // load settings, if there is no settings, load defaults
                    Options.LoadSettings();

                    Application.Run(new Main());
                }
                else
                {
                    Messager f = new Messager(unsupportedmsg);
                    f.ShowDialog();

                    Application.Exit();
                }
            }
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }
    }
}
