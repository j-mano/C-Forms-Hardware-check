using System;
using System.Collections.Generic;
using System.Text;

namespace Servises.Modells
{
    public class GpuModell
    {
        public string gpuName { get; set; }
        public string GpuStatus { get; set; }
        public string GpuDeviceID { get; set; }
        public UInt32 GpuAdapterRAM { get; set; }
        public string GpuInstalledDisplayDrivers { get; set; }
        public string GpuDriverVersion { get; set; }
        public string GpuVideoProcessor { get; set; }
        public UInt16 GpuVideoArchitecture { get; set; }
        public UInt16 GpuVideoMemoryType { get; set; }
        public string GpuHighestResAmountSupport { get; set; }
    }
}
