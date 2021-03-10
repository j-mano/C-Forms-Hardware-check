using System;
using System.Collections.Generic;
using System.Text;

namespace Servises.Modells
{
    public class CpuModell
    {
        public string Name { get; set; }
        public string DeviceID { get; set; }
        public string Manufacturer { get; set; }
        public string Caption { get; set; }
        public uint NumberOfCores { get; set; }
        public UInt32 NumberOfEnabledCore { get; set; }
        public UInt32 NumberOfLogicalProcessors { get; set; }
        public UInt16 Architecture { get; set; }
        public string Family { get; set; }
        public string ProcessorType { get; set; }
        public string Characteristics { get; set; }
        public string AddressWidth { get; set; }
    }
}
