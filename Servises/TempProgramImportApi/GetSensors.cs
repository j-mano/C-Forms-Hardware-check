using System;
using System.Collections.Generic;
using System.Text;
using OpenHardwareMonitor.Hardware;
using Servises.Modells;

namespace Servises.TempProgramImportApi
{
    class GetSensors
    {
        // Licensing can be found here: https://openhardwaremonitor.org/license/

        /// <summary>
        /// This class is building on openHardware monitor. https://openhardwaremonitor.org/documentation/
        /// Experimental and just newly realesed cpus and gpus might causes some problem
        /// Cpus from intel core 2 and onward are supported.
        /// .net 4.5+ or .net core is requierd
        /// This returning an tempsensormodell on cpu, gpu, motherbord and ram.
        /// </summary>
        public static TempSensor GetTempSensor()
        {
            // Returning an list of sensors belonging to each hardwaretype.
            TempSensor ReturnSensors = new TempSensor();
            ReturnSensors.Cpusensors = new List<ISensor>();
            ReturnSensors.Gpusensors = new List<ISensor>();
            ReturnSensors.RamSensors = new List<ISensor>();
            ReturnSensors.Motherboarssensors = new List<ISensor>();

            // Opening the hardware to be read.
            Computer ComputerSensors = new Computer()
            {
                GPUEnabled           = true,
                CPUEnabled           = true,
                MainboardEnabled     = true,
                RAMEnabled           = true,
                // hdd and fan not used for now. And MAY be used in the futere. Remove if you feel it in the way.
                HDDEnabled           = true,
                FanControllerEnabled = true
            };

            ComputerSensors.Open();

            foreach (var hardware in ComputerSensors.Hardware)
            {
                // Nvidia gpu temp reader. Do not find amd / ati gpus. Will give sensor of all nvidia gpus of the system. nv-link / sli system return sensors of sevral gpus.
                if (hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                ReturnSensors.Gpusensors.Add(sensor);
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }

                // AMD / ATI temp gpu reader. Do not find Nvidia gpus. Will give sensor of all amd/ati gpus of the system. Crossfire system return sensors of sevral gpus.
                if (hardware.HardwareType == HardwareType.GpuAti)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                ReturnSensors.Gpusensors.Add(sensor);
                            }
                        }
                        catch
                        {
                            throw;
                        }
                        
                    }
                }

                // Motherboard temp reader. Not validated to work
                if (hardware.HardwareType == HardwareType.Mainboard)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                ReturnSensors.Motherboarssensors.Add(sensor);
                            }    
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }

                // Ram temp reader. Not validated to work
                if (hardware.HardwareType == HardwareType.RAM)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            try
                            {
                                ReturnSensors.RamSensors.Add(sensor);
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }
                }

                
                // Cpu temp reader. Will give sensor of all cpus in the system. servers vill give sensors of sevral cpus.
                if (hardware.HardwareType == HardwareType.CPU)
                {
                    hardware.Update();
                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        try
                        {
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                ReturnSensors.Cpusensors.Add(sensor);
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }

            ComputerSensors.Close();

            return ReturnSensors;
        }
    }
}
