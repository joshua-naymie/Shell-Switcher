using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ShellSwitcher
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        private const
        String SHELL = "Shell",
               EXPLORER = "explorer.exe",
               KODI = "Kodi.exe";


        static void Main(string[] args)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
            if (key != null)
            {
                String value = key.GetValue(SHELL).ToString();

                if(value.Equals(EXPLORER))
                {
                    key.SetValue(SHELL, KODI as Object, RegistryValueKind.String);
                }

                else
                {
                    key.SetValue(SHELL, EXPLORER as Object, RegistryValueKind.String);
                }

                Console.WriteLine(key.GetValue(SHELL).ToString());

                key.Close();
            }

            ExitWindowsEx(0, 0);
        }
    }
}
