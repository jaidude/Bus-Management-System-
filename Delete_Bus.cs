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

namespace BR
{
    public partial class Delete_Bus : Form
    {
        int temp, I;
        OracleConnection CON1;
        OracleCommand CMD;
        string QUERY;
        OracleDataReader RDR;

        public Delete_Bus()
        {
            InitializeComponent();
            CON1 = new OracleConnection("Data Source=XE;User ID=project;password=project");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            staffcontrol op = new staffcontrol();
            op.Show();
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CON1.Open();
            QUERY = "delete from buses where bus_no='" + comboBox1.Text + "'and timing='"+comboBox2.Text+"' ";
            CMD = new OracleCommand(QUERY, CON1);
            int TEMP = CMD.ExecuteNonQuery();
            if (TEMP > 0)

                MessageBox.Show(" BUS deleted SUCESSFULLY");
            else
                MessageBox.Show("delete OPERATION FAILED ");
            CON1.Close();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Bus_Load(object sender, EventArgs e)
        {

            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label7.BackColor = System.Drawing.Color.Transparent;

            comboBox1.Text = "--SELECT--";
            comboBox2.Text = "--SELECT--";
            //bustiming
            QUERY = "select distinct(timing) from buses";
            CMD = new OracleCommand(QUERY, CON1);
            CON1.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {
                comboBox2.Items.Add(RDR["timing"]);
            }
            RDR.Close();
            CON1.Close();

            //busno
            QUERY = "select distinct(bus_no) from buses";
            CMD = new OracleCommand(QUERY, CON1);
            CON1.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {
                comboBox1.Items.Add(RDR["bus_no"]);
            }
            RDR.Close();
            CON1.Close();
        }
    }
}
