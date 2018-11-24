using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace ProcessManager
{
    public partial class Form1 : Form
    {
        int procssid;
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            procss();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void procss()
        {
            int counter = 1;

            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                string prcs = "Process: '" + theprocess.ProcessName + "'    ID: '" + theprocess.Id + "'    Macine Name: '"+Environment.MachineName+"'";
                richTextBox1.AppendText(prcs);
                richTextBox1.AppendText("\n");
                Application.DoEvents(); // This keeps your form responsive by processing events
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(var process in Process.GetProcessesByName(textBox1.Text))
            {
                process.Kill();
            }
            textBox1.Clear();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            procss();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("ProcssMan.exe");
        }

        private void computerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Coputer_Info frm = new Coputer_Info();
            frm.Show();
        }

        private void activeDirectorysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drives frm = new Drives();
            frm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            float fcpu = pcCPU.NextValue();
            float fram = pcRAM.NextValue();
            progressBarCPU.Value = (int)fcpu;
            progressBarRAM.Value = (int)fram;
            lblCPU.Text = string.Format("{0:0.00}%", fcpu);
            lblCPU_Bottom.Text = string.Format("{0:0.00}%", fcpu);
            lblRAM.Text = string.Format("{0:0.00}%", fram);
            lblRAM_Bottom.Text = string.Format("{0:0.00}%", fram);
            chart1.Series["CPU"].Points.AddY(fcpu);
            chart1.Series["RAM"].Points.AddY(fram);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void lblTotalSpace_Click(object sender, EventArgs e)
        {

        }
    }
}
