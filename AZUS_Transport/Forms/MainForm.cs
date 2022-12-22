using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZUS_Transport.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

         
        }

        private void niTaskbar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;

        }
    }
  
}
