using System;
using System.Collections.Generic;
using System.Text;

namespace Servises.Modells
{
    public class TempModell
    {
        public float CpuTemp { get; set; }
        public bool MultiCpu { get; set; }
        public float GpuTemp { get; set; }
        public bool MultiGpu { get; set; }
        public float RamTemp { get; set; }
        public float MotherboardTemp { get; set; }
    }
}
