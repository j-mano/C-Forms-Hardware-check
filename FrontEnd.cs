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

namespace Hardware
{
    public partial class FrontEnd : Form
    {
        public FrontEnd()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             printoutCpu(loadCpu());
        }

        private CpuModell loadCpu()
        {
            CpuModell cpumodel = new CpuModell();

            Task t3 = Task.Run(() => {
                cpumodel = Get_Cpu.Return_Cpu_Name();
            });

            t3.Wait();

            return cpumodel;
        }

        private void printoutCpu(CpuModell cpuModell)
        {
            string[] specifiers = { "G", "C", "D3", "E2", "e3", "F",
                              "N", "P", "X", "000000.0", "#.0",
                              "00000000;(0);**Zero**" };

            Cpu_Lbl_PrintOut.Text = cpuModell.Name;
            Cpu_artchitechture_LBL_Printout.Text = cpuModell.Architecture.ToString();
        }
    }
}
