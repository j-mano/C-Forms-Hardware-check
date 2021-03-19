using Servises.Modells;
using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace Servises
{
    public class Ram_Info
    {
        /// <summary>
        /// Get information about the systemram.
        /// </summary>
        /// <returns></returns>
        public static RamModell GetRam()
        {
            RamModell ram = new RamModell();

            try
            {
                // Ram information
                ObjectQuery RamDevice                   = new ObjectQuery("SELECT * FROM Win32_MemoryDevice");
                ManagementObjectSearcher searcherRam    = new ManagementObjectSearcher(RamDevice);
                ManagementObjectCollection RamInfo      = searcherRam.Get();
                // os specifik things
                ObjectQuery OsWin32                     = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcherOS     = new ManagementObjectSearcher(OsWin32);
                ManagementObjectCollection OsInfo       = searcherOS.Get();

                
                foreach (ManagementObject result in OsInfo)
                {
                    ram.RamAmount = result["TotalVisibleMemorySize"].ToString();
                }


                foreach (ManagementObject RamStick in RamInfo)
                {
                    ram.RamName         = RamStick["Name"].ToString();
                }

                return ram;
            }
            catch
            {
                throw;
            }
        }
    }
}
