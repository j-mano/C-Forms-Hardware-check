using System;
using System.Collections.Generic;
using System.Text;
using OpenHardwareMonitor.Hardware;
using Servises.Modells;

namespace Servises.TempProgramImportApi
{
    public class OpenHardwareGpu
    {
        Computer ComputerGpu = new Computer()
        {
            GPUEnabled = true
        };

        /* 
         * Multi gpus has been accounted for but its expected to have the same kind of gpu inside.
         * Sli, Crossfire or multiDie gpu solution was in mind when this wass developt. load is expected to load evenly. 
         * Temps and fanspeed is expected to be in the same area.
         * Specifikations are expected to be identical.
        */

        /// <summary>
        /// Returning an list of gpu or gpus if crossfire/nvlink/sli is used.
        /// </summary>
        /// <returns></returns>
        public List<string> returnGpuName()
        {
           List<string> returnString = new List<string>();

            try
            {
                ComputerGpu.Open();
                TempSensor sensors = Servises.TempProgramImportApi.GetSensors.GetTempSensor();

                foreach (var hardware in ComputerGpu.Hardware) {
                    // Nvidia gpu temp reader. Do not find amd / ati gpus
                    if (hardware.HardwareType == HardwareType.GpuNvidia)
                    {
                        returnString.Add(hardware.Name);
                    }

                    // AMD / ATI temp gpu reader. Do not find Nvidia gpus
                    if (hardware.HardwareType == HardwareType.GpuAti)
                    {
                        returnString.Add(hardware.Name);
                    }
                }

                ComputerGpu.Close();
            }
            catch
            {
                throw;
            }

            return returnString;
        }

        /// <summary>
        /// Return the amount of gpuCores on the gpu. Quite many for modern Gpus.
        /// </summary>
        /// <returns></returns>
        public string returnGpuCores()
        {
            string returnString = "";

            foreach (var hardware in ComputerGpu.Hardware)
            {
                // Nvidia gpu temp reader. Do not find amd / ati gpus
                if (hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Clock)
                            {
                                returnString = sensor.Values.ToString();
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }

                // AMD / ATI temp gpu reader. Do not find Nvidia gpus
                if (hardware.HardwareType == HardwareType.GpuAti)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Clock)
                            {
                                returnString = sensor.Values.ToString();
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }

            return returnString;
        }

        /// <summary>
        /// Returning the fanSpeed of on the gpus
        /// </summary>
        /// <returns></returns>
        public string returnFanSpeed()
        {
            string returnString = 0;

            foreach (var hardware in ComputerGpu.Hardware)
            {
                // Nvidia gpu temp reader. Do not find amd / ati gpus
                if (hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Fan)
                            {
                                returnString = sensor.Values.ToString();
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }

                // AMD / ATI temp gpu reader. Do not find Nvidia gpus
                if (hardware.HardwareType == HardwareType.GpuAti)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Fan)
                            {
                                returnString = sensor.Values.ToString();
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }

            return returnString;
        }

        public List<string> returnPowerConsumtion()
        {
            List<string> returnString = new List<string>();

            foreach (var hardware in ComputerGpu.Hardware)
            {
                // Nvidia gpu temp reader. Do not find amd / ati gpus
                if (hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Power)
                            {
                                returnString.Add(sensor.Values.ToString());
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }

                // AMD / ATI temp gpu reader. Do not find Nvidia gpus
                if (hardware.HardwareType == HardwareType.GpuAti)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Power)
                            {
                                returnString.Add(sensor.Values.ToString());
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }

            return returnString;
        }

        public string returnTemp()
        {
            string returnString = "";

            foreach (var hardware in ComputerGpu.Hardware)
            {
                // Nvidia gpu temp reader. Do not find amd / ati gpus
                if (hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                returnString = sensor.SensorType.ToString();
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }

                // AMD / ATI temp gpu reader. Do not find Nvidia gpus
                if (hardware.HardwareType == HardwareType.GpuAti)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                returnString = sensor.SensorType.ToString();
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }

            return returnString;
        }
    }
}
