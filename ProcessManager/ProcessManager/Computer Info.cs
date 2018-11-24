using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessManager
{
    public partial class Coputer_Info : Form
    {
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
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
