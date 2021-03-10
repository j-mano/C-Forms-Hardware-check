using Servises.Modells;
using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace Servises
{
    public class Ram_Speed
    {
        public static RamModell GetRam()
        {
            RamModell ram = new RamModell();

            try
            {
                ManagementObjectSearcher myRamDevice = new ManagementObjectSearcher("select * from Win32_MemoryDevice");
                ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
                ManagementObjectCollection results = searcher.Get();

                foreach (ManagementObject result in results)
                {
                    ram.RamAmount = result["TotalVisibleMemorySize"].ToString();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return ram;
        }

    }
}
