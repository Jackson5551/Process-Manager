using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProcessManager
{
    public partial class Drives : Form
    {
        public Drives()
        {
            InitializeComponent();
            richTextBox2.Clear();
            DiskandDriveInfo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    richTextBox2.AppendText("\nVolume Label: " + d.VolumeLabel );
                    richTextBox2.AppendText("\nFile System:  " + d.DriveFormat);
                    richTextBox2.AppendText("\nAvalable Space to current User: " + d.AvailableFreeSpace / 1024 / 1024 / 1024 + "GB");
                    richTextBox2.AppendText("\nTotal Avalable Space: " + d.TotalFreeSpace / 1024 / 1024 / 1024 + "GB");
                    richTextBox2.AppendText("\nTotal Size:  " + d.TotalSize / 1024 / 1024 / 1024 + "GB");
                }
                richTextBox2.AppendText("\n---------------------------------------------------------------------");
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DiskandDriveInfo();
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Drives_Load(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DiskandDriveInfo();
        }
    }
}
