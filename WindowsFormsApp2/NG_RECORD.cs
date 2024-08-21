using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class NG_RECORD : Form
    {
        SF_CNC sf_cnc;
        public NG_RECORD(SF_CNC sf_cnc)
        {
            InitializeComponent();
            this.sf_cnc = sf_cnc;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            sf_cnc.save_data_NG(guna2TextBox1.Text,guna2TextBox2.Text,comboBox1.Text);
        }
    }
}
