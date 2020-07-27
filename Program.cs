using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Diagnostics;
using System.Threading;
using System.Management.Automation.Runspaces;

namespace TestPowerShell
{
    class Program
    {
        static void Main(string[] args)
        {
            string script = "..\\..\\script-ps.ps1";


            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript(script);
                //  ps.AddParameter("Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy Unrestricted");
                var result = ps.Invoke();
                // var result = ps.Invoke("Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy Unrestricted");
                //  var result = ps.Invoke("Set-ExecutionPolicy UnRestricted");
                if (ps.HadErrors)
                {
                    Console.WriteLine($"Found {ps.Streams.Error.Count} errors!");
                    foreach (var error in ps.Streams.Error)
                    {
                        Console.WriteLine($"{error.Exception.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Finished!");
                }
            }

            //var process = new ProcessStartInfo()
            //{
            //    FileName = "powershell.exe",
            //    Arguments = $"-NoProfile -ExecutionPolicy unrestricted -file {script}",
            //    UseShellExecute = false
            //};

            //Process.Start(process);
            Console.ReadKey();
        }
    }
}
