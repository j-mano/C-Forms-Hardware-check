using System;
using System.Collections.Generic;
using System.Text;

namespace Servises.Modells.OpenHardwareModells
{
    class OpenHardwareGpuModell
    {
        // This is for multigpu support
        List<OpenHardwareGpuModell> gpus { get; set; }

        string name { get; set; }
        string gpuFanSpeed { get; set; }
        float MaxPoweConsumtion { get; set; }
        float CurrentConsumtion { get; set; }
    }
}
