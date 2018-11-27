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
            DiskandDriveInfo();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void procss()
        {
            int counter = 1;

            Process[] processlist = Process.GetProcesses();

            dataGridView1.Rows.Clear();

            foreach (Process theprocess in processlist)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = theprocess.ProcessName;
                dataGridView1.Rows[n].Cells[1].Value = theprocess.Id;
                dataGridView1.Rows[n].Cells[2].Value = Environment.MachineName;
                Application.DoEvents(); // This keeps your form responsive by processing events
            }
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
            chart1.Series["RAM"].Points.AddY(fram);
            lblNUMPROCS.Text = string.Format("{0:0}", runprocs);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
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
                    richTextBox2.AppendText("\nAvalable Space to current User: " + d.AvailableFreeSpace);
                    richTextBox2.AppendText("\nTotal Avalable Space: " + d.TotalFreeSpace);
                    richTextBox2.AppendText("\nTotal Size:  " + d.TotalSize);
                    
                }
                richTextBox2.AppendText("\n---------------------------------------------------------------------");
            }
        }
       
    }
}
