﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servises;
using Servises.Modells;
using System.Management;

namespace Hardware
{
    public partial class FrontEnd : Form
    {
        public FrontEnd()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             printoutCpu(loadCpu());
             printOutGPU(loadGpu());
             printOutBios(GetMotherbordinfo());
             printOutOS(Getosinfo());
        }

        private GpuModell loadGpu()
        {
            try
            {
                GpuModell gpumodell = new GpuModell();

                Task t3 = Task.Run(() => {
                    gpumodell = Get_gpu.GpuName();
                });

                t3.Wait();

                return gpumodell;
            }
            catch (Exception e)
            {
                Error_MS_LBL.Text = "Error, Exeption:" + e;
                return new GpuModell();
            }
        }

        private CpuModell loadCpu()
        {
            try
            {
                CpuModell cpumodel = new CpuModell();

                Task t3 = Task.Run(() => {
                    cpumodel = Get_Cpu.Return_Cpu_Name();
                });

                t3.Wait();

                return cpumodel;
            }
            catch (Exception e)
            {
                Error_MS_LBL.Text = "Error, Exeption:" + e;
                return new CpuModell();
            }
        }

        private void printoutCpu(CpuModell cpuModell)
        {
            string[] specifiers = { "G", "C", "D3", "E2", "e3", "F",
                              "N", "P", "X", "000000.0", "#.0",
                              "00000000;(0);**Zero**" };

            Cpu_Lbl_PrintOut.Text = cpuModell.Name;
            Cpu_artchitechture_LBL_Printout.Text = cpuModell.Architecture.ToString();
        }

        private void printOutGPU(GpuModell gpuModell)
        {
            string[] specifiers = { "G", "C", "D3", "E2", "e3", "F",
                              "N", "P", "X", "000000.0", "#.0",
                              "00000000;(0);**Zero**" };

            Gpu_Lbl_PrintOut.Text                   = gpuModell.gpuName;
            Gpu_Driver_Lbl_PrintOut.Text            = gpuModell.GpuDriverVersion;
            Gpu_Arthitecture_Lbl_printout.Text      = gpuModell.GpuVideoArchitecture.ToString();
            Vram_Lbl_PrintOut.Text                  = gpuModell.GpuAdapterRAM.ToString() + "b";
        }

        private MotherBoardModell GetMotherbordinfo()
        {
            try
            {
                return MotherBoard.GetModerBoardInfo();
            }
            catch(Exception e)
            {
                Error_MS_LBL.Text = "Error, Exeption:" + e;
                return new MotherBoardModell();
            }
        }

        private void printOutBios(MotherBoardModell motherborad)
        {
            Bios_Lbl_PrintOut.Text = motherborad.motherBoradBios;
        }

        private OSInfoModell Getosinfo()
        {
            try
            {
                return GetOsInfo.GetOS();
            }
            catch(Exception e)
            {
                Error_MS_LBL.Text = "Error, Exeption:" + e;
                return new OSInfoModell();
            }
            
        }

        private void printOutOS(OSInfoModell os)
        {
            Os_Lbl_PrintOut.Text = os.OsName;
            OS_Build_Lbl_PrintOut.Text = os.OsVersion;
        }
    }
}
