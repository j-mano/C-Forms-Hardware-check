using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor;
using System.Threading;
using Servises.Modells;
using System.Linq;

namespace Servises.TempProgramImportApi
{

    public class OpenHardWareSystemTemps
    {
        /// <summary>
        /// This class is building on openHardware monitor. https://openhardwaremonitor.org/documentation/
        /// Experimental and just newly realesed cpus and gpus might causes some problem
        /// Cpus from intel core 2 and amd equvelent, onward are supported.
        /// .net 4.5+ or .net core is requierd
        /// This function returning pacage temps of each device. Motherboard returning vrm temps.
        /// </summary>
        public static TempModell GetTemp()
        {
            TempModell returnTemps = new TempModell();

            try
            {
                TempSensor sensors = Servises.TempProgramImportApi.GetSensors.GetTempSensor();

                List<float> cpuListtemps = new List<float>();
                List<float> gpuListtemps = new List<float>();

                // validation of multigpu/sli/crossfire
                if (sensors.Gpusensors.Count > 1)
                    returnTemps.MultiGpu = true;
                else
                    returnTemps.MultiGpu = false;

                // validating if system is multicpu/server hardware. Some cpus has die and surface sensors wich is shown as 2 sensor. example amd ryzen. Hence count > 2.
                if (sensors.Cpusensors.Count > 2)
                    returnTemps.MultiCpu = true;
                else
                    returnTemps.MultiCpu = false;

                // Returning the single value of the cpu temp if only 1 is found. Otherwise is giving the avarage of all cpu´s in the system.
                foreach (ISensor CpuSensors in sensors.Cpusensors)
                {
                    if(returnTemps.MultiCpu == false)
                        returnTemps.CpuTemp = CpuSensors.Value.GetValueOrDefault();
                    else
                        cpuListtemps.Add(CpuSensors.Value.GetValueOrDefault());
                }
                if(returnTemps.MultiCpu == true)
                    returnTemps.CpuTemp = (float)Queryable.Average((IQueryable<decimal>)cpuListtemps);

                // Returning the single value of the gpu temp if only 1 is found. Otherwise is giving the avarage of all gpu´s in the system.
                foreach (ISensor GpusenSensors in sensors.Gpusensors)
                {
                    if(returnTemps.MultiGpu == false)
                        returnTemps.GpuTemp = GpusenSensors.Value.GetValueOrDefault();
                    else
                        gpuListtemps.Add(GpusenSensors.Value.GetValueOrDefault());
                }
                if (returnTemps.MultiGpu == true)
                    returnTemps.GpuTemp = (float)Queryable.Average((IQueryable<decimal>)gpuListtemps);

                // Not validated to work. Priveous developers didn't have access to propper hardware
                foreach (ISensor RamSensors in sensors.RamSensors)
                {
                    returnTemps.RamTemp = RamSensors.Value.GetValueOrDefault();
                }

                // Not validated to work. Priveous developers didn't have access to propper hardware
                foreach (ISensor Motherboarssensors in sensors.Motherboarssensors)
                {
                    returnTemps.MotherboardTemp = Motherboarssensors.Value.GetValueOrDefault();
                }

                return returnTemps;
            }
            catch
            {
                throw;
            }
        }
    }
}
