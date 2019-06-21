using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.text.regularexpression;

using Oracle.DataAccess.Client;

namespace BR
{
    public partial class createstaff : Form
    {
        OracleConnection CON1;
        OracleCommand CMD;
        string QUERY;
        int TEMP, I;
        OracleDataReader RDR;



        public createstaff()
        {
            InitializeComponent();
            CON1 = new OracleConnection("Data Source=XE;User ID=project;password=project ");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") && (textBox2.Text == "") && (textBox3.Text == "") && (textBox4.Text == "") && (textBox5.Text == ""))
            {
                if ((textBox6.Text == "") || (textBox7.Text == "") || (textBox8.Text == "") || (textBox9.Text == ""))
                {
                    MessageBox.Show("Enter all the details properly ");
                }
                else
                if (textBox7.Text == textBox8.Text)
                {
                    I = 0;

                    QUERY = "select * from C_Create_Account where username='" + textBox6.Text + "' ";
                    CON1.Open();
                    CMD = new OracleCommand(QUERY, CON1);

                    RDR = CMD.ExecuteReader();

                    while (RDR.Read())
                    {
                        if ((string)RDR["username"] == textBox6.Text)
                            I = 1;
                        else
                            I = I;
                    }
                    RDR.Close();
                    CON1.Close();

                    if (I == 1)
                    {
                        MessageBox.Show(" username exists");
                        textBox6.Text = " ";
                        textBox6.Focus();
                    }

                      //check for email validation
                             else if (!this.textBox9.Text.Contains('@') || !this.textBox9.Text.Contains('.')) 
                         { 
                             MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                         }

                          

                    else
                    {

                        CON1.Open();
                        QUERY = "Insert into C_Create_Account values('" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
                        CMD = new OracleCommand(QUERY, CON1);
                        CMD.CommandType = CommandType.Text;
                        TEMP = CMD.ExecuteNonQuery();
                        if (TEMP > 0)
                        {
                            MessageBox.Show(" RECORD ADDED SUCESSFULLY");
                            Login op = new Login();
                            op.Show();
                            Hide();

                        }
                        else
                            MessageBox.Show("INSERT OPERATION FAILED ");

                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";

                    }


                }
                else
                {
                    MessageBox.Show("PASSWORDS DO NOT MATCH");
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox7.Focus();
                }

            }



            //for staff
            else
            {

                if ((textBox1.Text == " ") || (textBox2.Text == "") || (textBox3.Text == " ") || (textBox4.Text == " ") || (textBox5.Text == " "))
                {
                    MessageBox.Show("Enter all the details properly ");
                }
                else
               if (textBox7.Text == textBox8.Text)
                {
                    I = 0;

                    QUERY = "select * from S_Create_Account where username='" + textBox1.Text + "' ";
                    CON1.Open();
                    CMD = new OracleCommand(QUERY, CON1);

                    RDR = CMD.ExecuteReader();

                    while (RDR.Read())
                    {
                        if ((string)RDR["username"] == textBox6.Text)
                            I = 1;
                        else
                            I = I;
                    }
                    RDR.Close();
                    CON1.Close();

                    if (I == 1)
                    {
                        MessageBox.Show(" username exists");
                        textBox6.Text = " ";
                        textBox6.Focus();
                    }

                    //check for email validation
                    else if (!this.textBox4.Text.Contains('@') || !this.textBox4.Text.Contains('.'))
                    {
                        MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //company code varification
                    else if (textBox5.Text != Convert.ToString(12345))
                    {
                        MessageBox.Show("Comapny code doesnt match. please enter the correct company code.");
                    }

                    else if (textBox5.Text == Convert.ToString(12345))
                    {
                        CON1.Open();
                        QUERY = "Insert into S_Create_Account values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                        CMD = new OracleCommand(QUERY, CON1);
                        CMD.CommandType = CommandType.Text;
                        TEMP = CMD.ExecuteNonQuery();
                        if (TEMP > 0)
                        {
                            MessageBox.Show(" RECORD ADDED SUCESSFULLY");
                            Login op = new Login();
                            op.Show();
                            Hide();

                        }
                        else
                            MessageBox.Show("INSERT OPERATION FAILED ");

                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";

                    }


                }
                else
                {
                    MessageBox.Show("PASSWORDS DO NOT MATCH");
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox7.Focus();
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void createstaff_Load(object sender, EventArgs e)
        {
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label11.BackColor = System.Drawing.Color.Transparent;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login op = new Login();
            op.Show();
            Hide();
        }
    }
}
