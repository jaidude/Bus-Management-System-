using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

using Oracle.DataAccess.Client;
using Microsoft.VisualBasic;


namespace BR
{
    public partial class view : Form
    {
        OracleConnection con1;
        OracleCommand cmd;
        string query;
        int temp, I;
        OracleDataAdapter da;
        DataSet d;

        OracleConnection CON1;
        OracleCommand CMD;
        string QUERY;
        OracleDataReader RDR;

        public view()
        {
            InitializeComponent();
            CON1 = new OracleConnection("Data Source=XE;User ID=project;password=project ");
            con1 = new OracleConnection("Data Source=XE;User ID=project;password=project ");
        }

        public void BNO()
        {
            QUERY = "select bus_no from buses where bus_type ='" + comboBox4.Text + "'and s_from ='" + comboBox1.Text + "'and d_to ='" + comboBox2.Text + "' and timing ='" + comboBox3.Text + "' ";
            CMD = new OracleCommand(QUERY, CON1);
            CON1.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {
                textBox6.Text = Convert.ToString(RDR["BUS_NO"]);

            }
            RDR.Close();
            CON1.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            staffcontrol op = new staffcontrol();
            op.Show();
            Hide();
        }

      

        private void view_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.BOOKING' table. You can move, or remove it, as needed.
            this.bOOKINGTableAdapter1.Fill(this.dataSet2.BOOKING);

            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label7.BackColor = System.Drawing.Color.Transparent;

           
            textBox6.Text = "";
            comboBox1.Text = "--SELECT--";
            comboBox2.Text = "--SELECT--";
            comboBox3.Text = "--SELECT--";
            comboBox4.Text = "--SELECT--";

            //from
            QUERY = "select distinct(s_from) from buses";
            CMD = new OracleCommand(QUERY, CON1);

            CON1.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {
                comboBox1.Items.Add(RDR["s_from"]);

            }
            RDR.Close();
            CON1.Close();

            //to
            QUERY = "select distinct(d_to) from buses";
            CMD = new OracleCommand(QUERY, CON1);
            CON1.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {
                comboBox2.Items.Add(RDR["d_to"]);
            }
            RDR.Close();
            CON1.Close();

            //bustype
            QUERY = "select distinct(bus_type) from buses";
            CMD = new OracleCommand(QUERY, CON1);
            CON1.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {
                comboBox4.Items.Add(RDR["bus_type"]);
            }
            RDR.Close();
            CON1.Close();

            //bustiming
            QUERY = "select distinct(timing) from buses";
            CMD = new OracleCommand(QUERY, CON1);
            CON1.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {
                comboBox3.Items.Add(RDR["timing"]);
            }
            RDR.Close();
            CON1.Close();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("please choose a proper route", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            BNO();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // for displaying the sorted output

            query = "select * from booking where bus_type ='" + comboBox4.Text + "'and s_from ='" + comboBox1.Text + "'and d_to ='" + comboBox2.Text + "' and bus_timing ='" + comboBox3.Text + "' ";
            cmd = new OracleCommand(query, con1);

            try
            {
                con1.Open();
                da = new OracleDataAdapter(query, con1);
                d = new DataSet();
                da.Fill(d, "*");
                dataGridView1.DataSource = d.Tables[0];
                con1.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                con1.Close();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            query = "select * from booking where bus_no='" + textBox6.Text + "' and timing='" + comboBox3.Text + "' and bus_type='" + comboBox4.Text + "'";
            cmd = new OracleCommand(query, con1);

            try
            {
                con1.Open();
                da = new OracleDataAdapter(query, con1);
                d = new DataSet();
                da.Fill(d, "test");
                dataGridView1.DataSource = d.Tables[0];
                con1.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                con1.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedItem.ToString() == "MARGAO")
            //{
            //    comboBox2.Text = "PANJIM";
            //}
            //else if (comboBox1.SelectedItem.ToString() == "PANJIM")
            //{ comboBox2.Text = "MARGAO"; }
            //else
            //{
            //    comboBox2.Text = "--SELECT--";
            //}
        }
    }
}
