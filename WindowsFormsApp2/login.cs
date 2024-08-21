using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.Globalization;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;

namespace WindowsFormsApp2
{
    public partial class login : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string machine = "";
        public static string machine_name = "";
        public static string aplikator = "";        
        public static string level = "";
        public static string format_pic = "";
        public static string user_name = "";
        public static string NoReg = "";
        public static string shift;
        public static string spv;
        public static bool stats_rph = false;
        public String hasil = "0";
        bool sf_assy=false;
        public static string line_assy, assy_laoding;
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        SqlConnection cnn;

        public login()
        {
            InitializeComponent();
            label3.Visible = false;
            Panel1 panel = new Panel1();

            // if (string.IsNullOrEmpty(rjTextBox1.Text))
            //{
              //  checkBox1.Enabled = false;
                //checkBox3.Enabled = false;
                //checkBox4.Enabled = false;
                //Console.WriteLine("Checkboxes disabled");
            //}
            //else
            //{
              //  checkBox1.Enabled = true;
                //checkBox3.Enabled = true;
                //checkBox4.Enabled = true;
                //Console.WriteLine("Checkboxes enabled");
            //}

            // Set to no text.
            //  rjTextBox2.Text = "";
            // The password character is an asterisk.
            //  rjTextBox2.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            // rjTextBox2.MaxLength = 14;
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread( );
            this.Close();
        }


        

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

            
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            //  Disabled Checkbox Before Form Inputed
            // if (string.IsNullOrEmpty(rjTextBox1.Text))


            //  SetValueForText2 = textBox2.Text;
            /*
            cnn = new SqlConnection(connetionString);
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            */

            //  Console.WriteLine(rjTextBox1.Texts);

            if (stats_rph == true)
            {

                this.Hide();

                var form1 = new Form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            else if (sf_assy == true && assy_laoding!=null && line_assy !=null)
            {
                this.Hide();

                var form1 = new Form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();

            }


            else if (Convert.ToInt16(hasil) > 0)
            {
                SetValueForText1 = NoReg;

                // aplikator = rjTextBox2.Texts;
                if (shift == "1" || shift == "3" || shift == "2")
                {
                    this.Hide();

                    var form1 = new Form1();
                    form1.Closed += (s, args) => this.Close();
                    form1.Show();
                }
                else
                    MessageBox.Show("Pilih Shift");

            }
            else
            {
                label3.Visible = true;
                label3.Text = "wrong NIK, please enter valid NIK";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // string phrase = comboBox1.Text;
            // string[] words = phrase.Split('-');
            // Console.WriteLine(words[1]);
            // machine = words[1];
            // machine_name = phrase;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sf_assy = false;
            tableLayoutPanel3.Hide();
            Panel1 pnl1  = new Panel1();
            addusercontrol(pnl1);
            // TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            // tableLayoutPanel1.Controls.Add(panel1);
            // tableLayoutPanel1.Show();
            
            /*
            main_pnl.Controls.Add(new Panel1());
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            */
        }

        private void addusercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            main_pnl.Controls.Clear();
            main_pnl.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            sf_assy = false;
            tableLayoutPanel3.Hide();
            Panel2 pnl2 = new Panel2(this);
            addusercontrol(pnl2);
            //foreach (Control ctrl in panel1.Controls)
            //{
            //    ctrl.Dispose();
            //}
            //panel1.Controls.Add(new Panel2());
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            sf_assy = true;
            
            
            
            //foreach (Control ctrl in panel1.Controls)
            //{
            //    ctrl.Dispose();
            //}
            //panel1.Controls.Add(new Panel3());
        }

        private void main_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cnn = new SqlConnection(connetionString);
                SqlDataReader dataReader, dataReader2;
                SqlDataAdapter adapter = new SqlDataAdapter();
                try
                {
                    cnn.Open();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }

                

                if (sf_assy == false)
                {
                    Console.WriteLine(rjTextBox1.Texts);
                    int lenght = rjTextBox1.Texts.Length;
                    string noreg = rjTextBox1.Texts.Remove(7);
                    Console.WriteLine(noreg);
                    string pass = rjTextBox1.Texts.Remove(0, 7);
                    Console.WriteLine(pass);
                    NoReg = noreg;
                    global.sNoreg = noreg;

                    SqlCommand cmd = new SqlCommand("SELECT count(*) as jumlah from [MSQCOK] where Noreg=@noreg and Password = @pass", cnn);
                    cmd.Parameters.AddWithValue("@noreg", noreg);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        // Console.WriteLine(dataReader.GetString(0));

                        hasil = String.Format("{0}", dataReader["jumlah"]);



                        Console.WriteLine(hasil);
                        // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                        //data2txt.Text = dataReader.GetString("jumlah");
                    }
                }
                else
                {
                    tableLayoutPanel3.Hide();
                    Panel3 pnl3 = new Panel3(this);
                    addusercontrol(pnl3);
                    global.sNoreg = rjTextBox1.Texts;


                    
                    


                    SqlCommand cmd = new SqlCommand("select distinct KOMESIN from TRRPHTARGETASSYpart where KOMESIN NOT LIKE '%xx%'", cnn);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        // Console.WriteLine(dataReader.GetString(0));

                        hasil = String.Format("{0}", dataReader["KOMESIN"]);
                        pnl3.comboBox3.Items.Add(hasil);



                        Console.WriteLine(hasil);
                        // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                        //data2txt.Text = dataReader.GetString("jumlah");
                    }

                    cnn.Close();
                  
                }

                cnn.Close();

                try
                {
                    cnn.Open();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                SqlCommand cmd2 = new SqlCommand("select count(*) as jumlah, nama, level, ext from db_pegawai where noreg = @zip and(tgl_resign is null or tgl_resign >= getdate()) group by nama, level, ext", cnn);
                cmd2.Parameters.AddWithValue("@zip", NoReg);
                dataReader2 = cmd2.ExecuteReader();
                while (dataReader2.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    //hasil = String.Format("{0}", dataReader["jumlah"]);


                    user_name = String.Format("{0}", dataReader2["nama"]);
                    level = String.Format("{0}", dataReader2["level"]);
                    format_pic = String.Format("{0}", dataReader2["ext"]);
                    Console.WriteLine(user_name);
                    Console.WriteLine(level);
                    Console.WriteLine(format_pic);
                    label2.Text = user_name;
                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                }

            }
        }

        private void rjTextBox1__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel3.Hide();
            login_rph login_Rph = new login_rph();
            addusercontrol(login_Rph);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stats_rph = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

