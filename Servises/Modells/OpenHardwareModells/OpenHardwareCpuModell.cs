using System;
using System.Collections.Generic;
using System.Text;

namespace Servises.Modells.OpenHardwareModells
{
    class OpenHardwareCpuModell
    {
        // This is for multicpu support
        List<OpenHardwareCpuModell> Cpus {get; set;}

        String Name { get; set; }

        float ClockSpeed { get; set; }
        float voltage { get; set; }
        float highestPowerConsumtion { get; set; }
        float currentPowerConsumtion { get; set; }
    }
}
