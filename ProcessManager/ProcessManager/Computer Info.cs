using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessManager
{
    public partial class Coputer_Info : Form
    {
        private delegate void DELAGATE();
        public Coputer_Info()
        {
            InitializeComponent();
        }

        private void Coputer_Info_Load(object sender, EventArgs e)
        {
            label2.Text = Environment.MachineName;
            label4.Text = Environment.OSVersion.ToString();
            label6.Text = Environment.ProcessorCount.ToString();
            label9.Text = Environment.UserDomainName.ToString();
            label12.Text = Environment.UserName.ToString();
            label14.Text = Environment.Version.ToString();
            label15.Text = Environment.SystemDirectory.ToString();
            label17.Text = Environment.TickCount.ToString();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            getCPUInfoAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            label7.Text = cpumodel + "\n" + Environment.ProcessorCount.ToString() + " Core";
        }

        private async Task getCPUInfoAsync()
        {
            await Task.Run(() => getCPUInfo());
        }

    }
}
