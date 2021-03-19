using System;
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
using Servises.Services;
using Servises.Services.iServices;
using Servises.TempProgramImportApi;

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
            printOutBattery(getBattery());
            PrintOutRam(GetRam());
            printouttemps(GetTemps());
            PrintOutAdmin(getAdminRights());
        }

        private void printouttemps(TempModell SysTemps)
        {
            Cpu_Temp_Lbl_PrintOut.Text = SysTemps.CpuTemp.ToString();
            Gpu_Temp_Lbl_PrintOut.Text = SysTemps.GpuTemp.ToString();
        }

        private TempModell GetTemps()
        {
            try
            {
                return OpenHardWareSystemTemps.GetTemp();
            }
            catch (Exception e)
            {
                Error_MS_LBL2.Text = "Error, Exeption:" + e;
                return new TempModell();
            }
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
                Error_MS_LBL2.Text = "Error, Exeption:" + e;
                return new GpuModell();
            }
        }

        private CpuModell loadCpu()
        {
            try
            {
                CpuModell cpumodel = new CpuModell();

                Task t3 = Task.Run(() => {
                    cpumodel = Get_Cpu.ReturnCpu();
                });

                t3.Wait();

                return cpumodel;
            }
            catch (Exception e)
            {
                Error_MS_LBL2.Text = "Error, Exeption:" + e;
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
            Max_Resolution_Printout_Lbl.Text        = gpuModell.GpuHighestResAmountSupport.ToString();
        }

        private MotherBoardModell GetMotherbordinfo()
        {
            try
            {
                return MotherBoard.GetModerBoardInfo();
            }
            catch(Exception e)
            {
                Error_MS_LBL2.Text = "Error, Exeption:" + e;
                return new MotherBoardModell();
            }
        }

        private void printOutBios(MotherBoardModell motherborad)
        {
            Bios_Lbl_PrintOut.Text = motherborad.motherBoradBios;
            MotherBoard_Lbl_PrintOut.Text = motherborad.motherBoardName;
        }

        private OSInfoModell Getosinfo()
        {
            try
            {
                OSInfoModell ReturnInfo = new OSInfoModell();

                Task t3 = Task.Run(() => {
                    ReturnInfo = GetOsInfo.GetOS();
                });

                t3.Wait();

                return ReturnInfo;
            }
            catch(Exception e)
            {
                Error_MS_LBL2.Text = "Error, Exeption:" + e;
                return new OSInfoModell();
            }
        }

        private void printOutOS(OSInfoModell os)
        {
            Os_Lbl_PrintOut.Text = os.OsName;
            OS_Build_Lbl_PrintOut.Text = os.OsVersion;
        }

        private void printOutBattery(BatteryModell battery)
        {
            if (battery.hasbattery)
                Battery_Lbl_PrintOut.Text = "Battery found";
            else
                Battery_Lbl_PrintOut.Text = "No battery found";
        }

        private BatteryModell getBattery()
        {
            try
            {
                return Get_Battery.Get_Battaryed();
            }
            catch
            {
                BatteryModell emty = new BatteryModell();

                return emty;
            }
        }

        private RamModell GetRam()
        {
            try
            {
                return Ram_Info.GetRam();
            }
            catch (Exception e)
            {
                Error_MS_LBL2.Text = "Error, Exeption:" + e;
                return new RamModell();
            }
        }

        private void PrintOutRam(RamModell ramModell)
        {
            Ram_Lbl_PrintOut.Text = ramModell.RamAmount + "bytes";
        }

        private void PrintOutAdmin(bool admin)
        {
            IsAdmin_Printout_LBL.Text = admin.ToString();
        }

        private bool getAdminRights()
        {
           return IsAdmin.RundAsAdmin();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void FrontEnd_Load(object sender, EventArgs e)
        {

        }
    }
}
