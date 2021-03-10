using Servises.Modells;
using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace Servises.Services
{
    public class Get_Battery
    {
        /// <summary>
        /// This returning an model of an simple battery and returning it.
        /// </summary>
        /// <returns></returns>
        public static BatteryModell Get_Battaryed()
        {
            BatteryModell battery = new BatteryModell();

            try
            {
                ManagementObjectSearcher myBatteryObject = new ManagementObjectSearcher("select * from Win32_Battery");

                foreach (ManagementObject obj in myBatteryObject.Get())
                {
                    foreach (PropertyData property in obj.Properties)
                    {
                        battery.name = property.Name;
                        battery.batteryCapacaty = property.Value.ToString();
                    }
                }
            }
            catch
            {
                battery.hasbattery = false;
                throw;
            }

            return battery;
        }
    }
}
