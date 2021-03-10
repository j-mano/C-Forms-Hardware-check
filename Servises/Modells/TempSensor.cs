using System;
using System.Collections.Generic;
using System.Text;
using OpenHardwareMonitor.Hardware;

namespace Servises.Modells
{
    public class TempSensor
    {
        public List<ISensor> Cpusensors { get; set; }
        public List<ISensor> Gpusensors { get; set; }
        public List<ISensor> Motherboarssensors { get; set; }
        public List<ISensor> RamSensors { get; set; }
    }
}
