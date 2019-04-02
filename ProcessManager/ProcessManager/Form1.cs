﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Management;

namespace ProcessManager
{
    public partial class Form1 : Form
    {
        private delegate void DELAGATE();
        public Form1()
        {
            InitializeComponent();

            procss();

            DiskandDriveInfo();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void procss()
        {
            
            Process[] processlist = Process.GetProcesses();

            dataGridView1.Rows.Clear();

            foreach (Process theprocess in processlist)
            {
                //Fill the DataGrid with info
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = theprocess.ProcessName;
                dataGridView1.Rows[n].Cells[1].Value = theprocess.Id;
                dataGridView1.Rows[n].Cells[2].Value = Environment.MachineName;
                dataGridView1.Rows[n].Cells[3].Value = theprocess.PagedMemorySize64 / 1024 / 1024 + " MB";
                Application.DoEvents(); // This keeps your form responsive by processing events
            }
        }


        private async Task getCPUInfoAsync()
        {
            await Task.Run(() => getCPUInfo());
        }

        public void getCPUInfo()
        {
            Delegate del = new DELAGATE(gci_content);
            this.Invoke(del);
        }

        private void gci_content()
        {
            string speed = "";
            string cpumodel = "";
            var searcher = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor");
            foreach (var item in searcher.Get())
            {
                var clockSpeed = 0.001f * (uint)item["MaxClockSpeed"];
                speed = clockSpeed.ToString();
            }
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject mo in mos.Get())
            {
                var model = mo["Name"];
                cpumodel = model.ToString();
            }
            label6.Text = cpumodel + "\n" + Environment.ProcessorCount.ToString() + " Core";
        }

        public void OldProcessList()
        {

            Process []
            processlist = Process.GetProcesses();

            richTextBox1.Clear();

            foreach (Process theprocess in processlist)
            {
                string prcs = "Process: '" + theprocess.ProcessName + "'  ||  ID: '" + theprocess.Id + "'  ||  Macine Name: '"+Environment.MachineName+"'";
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
            procss();
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
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

        int counter = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            Process[] processlist = Process.GetProcesses();

            float fcpu = pcCPU.NextValue();
            float fram = pcRAM.NextValue();
            float runprocs = processlist.GetLength(0);
            progressBarCPU.Value = (int)fcpu;
            progressBarRAM.Value = (int)fram;
            lblCPU.Text = string.Format("{0:0.00}%", fcpu);
            lblCPU_Bottom.Text = string.Format("{0:0.00}%", fcpu);
            lblRAM.Text = string.Format("{0:0.00}%", fram);
            lblRAM_Bottom.Text = string.Format("{0:0.00}%", fram);
            chart1.Series["CPU"].Points.AddY(fcpu);
            chart2.Series["CPU"].Points.AddY(fcpu);
            chart1.Series["RAM"].Points.AddY(fram);
            chart3.Series["RAM"].Points.AddY(fram);
            lblNUMPROCS.Text = string.Format("{0:0}", runprocs);
            counter = counter + 1;
            if (counter == 60)
            {
                chart1.Series["CPU"].Points.Clear();
                chart2.Series["CPU"].Points.Clear();
                chart1.Series["RAM"].Points.Clear();
                chart3.Series["RAM"].Points.Clear();
                procss();
                OldProcessList();
                counter = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            getCPUInfoAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private void lblTotalSpace_Click(object sender, EventArgs e)
        {

        }

        private void computerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Coputer_Info frm = new Coputer_Info();
            frm.Show();
        }

        private void disksAndDrivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drives frm = new Drives();
            frm.Show();
        }

        private void cLIBETAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("ProcssMan.exe");
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            procss();
        }

        private void cLIBETAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("ProcssMan.exe");
        }

        public void DiskandDriveInfo()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                richTextBox2.AppendText("\nDrive " + d.Name);
                richTextBox2.AppendText("\nDrive Type: " + d.DriveType);
                if (d.IsReady == true)
                {
                    richTextBox2.AppendText("\nVolume Label: " + d.VolumeLabel);
                    richTextBox2.AppendText("\nFile System:  " + d.DriveFormat);
                    richTextBox2.AppendText("\nAvalable Space to current User: " + d.AvailableFreeSpace / 1024 / 1024 / 1024 + "GB");
                    richTextBox2.AppendText("\nTotal Avalable Space: " + d.TotalFreeSpace / 1024 / 1024 / 1024 + "GB");
                    richTextBox2.AppendText("\nTotal Size:  " + d.TotalSize / 1024 / 1024 / 1024 + "GB");

                }
                richTextBox2.AppendText("\n---------------------------------------------------------------------");
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OldProcessList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://jackson5551.github.io/ProcessManagerNet/");
        }

        private void projectPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Jackson5551/Process-Manager");
        }

        private void jackson5551sWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://jackson5551.github.io/");
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OldProcessList();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "R")
            {
                procss();
            }
            else if (e.Control && e.KeyCode.ToString() == "T")
            {
                Process.Start("ProcssMan.exe");
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "R")
            {
                OldProcessList();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "T")
            {
                Process.Start("ProcssMan.exe");
            }
        }

        private void refreshToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DiskandDriveInfo();
        }

        private void LicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Licensefrm frm = new Licensefrm();
            frm.Show();
        }
    }
}
