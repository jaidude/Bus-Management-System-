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
    public partial class Add_Bus : Form
    {
        OracleConnection CON1;
        OracleCommand CMD;
        string QUERY;
        OracleDataReader RDR;
        int TEMP;
        public Add_Bus()
        {
            InitializeComponent();
            CON1 = new OracleConnection("Data Source=XE;User ID=project;password=project ");
        }

        private void Add_Bus_Load(object sender, EventArgs e)
        {
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label6.BackColor = System.Drawing.Color.Transparent;

            comboBox1.Text = "--SELECT--";

            //bustype
            QUERY = "select distinct(bus_type) from buses";
            CMD = new OracleCommand(QUERY, CON1);
            CON1.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {
                comboBox1.Items.Add(RDR["bus_type"]);
            }
            RDR.Close();
            CON1.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                MessageBox.Show("please choose a proper root", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            staffcontrol op = new staffcontrol();
            op.Show();
            Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == " ") || (textBox2.Text == "") || (textBox3.Text == " ") || (textBox4.Text == " ") || (textBox5.Text == " ") || (comboBox1.Text == " "))
            {
                MessageBox.Show("Enter all the details properly ");
            }
            else
            { 
                    CON1.Open();
                    QUERY = "Insert into buses values('" + textBox1.Text.ToUpper() + "','" + comboBox1.Text + "','" + textBox2.Text.ToUpper() + "','" + textBox3.Text.ToUpper() + "','" + textBox5.Text.ToUpper() + "','" + textBox4.Text.ToUpper() + "')";
                    CMD = new OracleCommand(QUERY, CON1);
                    CMD.CommandType = CommandType.Text;
                    TEMP = CMD.ExecuteNonQuery();
                    if (TEMP > 0)
                    {
                        MessageBox.Show(" RECORD ADDED SUCESSFULLY");                       

                    }
                    else
                        MessageBox.Show("INSERT OPERATION FAILED ");


            }
            

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
