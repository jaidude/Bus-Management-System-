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
    public partial class Forgot_password : Form
    {

        OracleConnection CON1;
        OracleCommand CMD;
        string QUERY;
        int TEMP, I;
        OracleDataReader RDR;

        public Forgot_password()
        {
            InitializeComponent();
            CON1 = new OracleConnection("Data Source=XE;User ID=project;password=project ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login op = new Login();
            op.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
            { 
            if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Enter All the Details ");
            }


            else
                if (textBox6.Text == textBox7.Text)
            {
                I = 0;

                QUERY = "select * from C_Create_Account where username='" + textBox5.Text + "' ";
                CON1.Open();
                CMD = new OracleCommand(QUERY, CON1);

                RDR = CMD.ExecuteReader();

                while (RDR.Read())
                {
                    if ((string)RDR["username"] == textBox5.Text)
                        I = 1;
                    else
                        I = I;
                }
                RDR.Close();
                CON1.Close();

                if (I == 1)
                {
                    MessageBox.Show(" username exists");
                    textBox5.Text = "";
                    textBox5.Focus();
                }
                else
                {
                    CON1.Open();
                    QUERY = "Update C_Create_Account set password='" + textBox6.Text + "', confirm_password='" + textBox7.Text + "' where username='" + textBox5.Text + "'";
                    // QUERY = "Update LAB Set PARTICULAR='" + TextBox2.Text + "',NAME_OF_SUP='" + TextBox3.Text.ToUpper() + "',ADDRESS='" + TextBox4.Text + "' Where ID='" + TextBox1.Text + "'";
                    CMD = new OracleCommand(QUERY, CON1);
                    CMD.CommandType = CommandType.Text;
                    TEMP = CMD.ExecuteNonQuery();
                    if (TEMP > 0)
                    {
                        MessageBox.Show(" PASSWORD CHANGED SUCESSFULLY");
                        Login op = new Login();
                        op.Show();
                        Hide();
                    }
                    else
                        MessageBox.Show("COULDEN'T CHANGE THE PASSWORD");

                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }

            }
            else
            {
                MessageBox.Show("PASSWORDS DO NOT MATCH");
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Focus();
            }
        }
            //for staff
            else{
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Enter All the Details ");
                }


                else
                if (textBox2.Text == textBox3.Text)
                {
                    I = 0;

                    QUERY = "select * from C_Create_Account where username='" + textBox5.Text + "' ";
                    CON1.Open();
                    CMD = new OracleCommand(QUERY, CON1);

                    RDR = CMD.ExecuteReader();

                    while (RDR.Read())
                    {
                        if ((string)RDR["username"] == textBox5.Text)
                            I = 1;
                        else
                            I = I;
                    }
                    RDR.Close();
                    CON1.Close();

                    if (I == 1)
                    {
                        MessageBox.Show(" username exists");
                        textBox5.Text = "";
                        textBox5.Focus();
                    }
                    else
                    {
                       if (textBox4.Text != Convert.ToString(12345))
                        {
                            MessageBox.Show("Comapny code doesnt match. please enter the correct company code.");
                        }

                         if (textBox4.Text == Convert.ToString(12345))
                        {
                            CON1.Open();
                            QUERY = "Update S_Create_Account set password='" + textBox2.Text + "', confirm_password='" + textBox3.Text + "' where username='" + textBox1.Text + "'";
                            // QUERY = "Update LAB Set PARTICULAR='" + TextBox2.Text + "',NAME_OF_SUP='" + TextBox3.Text.ToUpper() + "',ADDRESS='" + TextBox4.Text + "' Where ID='" + TextBox1.Text + "'";
                            CMD = new OracleCommand(QUERY, CON1);
                            CMD.CommandType = CommandType.Text;
                            TEMP = CMD.ExecuteNonQuery();
                            if (TEMP > 0)
                            {
                                MessageBox.Show(" PASSWORD CHANGED SUCESSFULLY");
                                Login op = new Login();
                                op.Show();
                                Hide();
                            }
                            else
                                MessageBox.Show("COULDEN'T CHANGE THE PASSWORD");

                            textBox5.Text = "";
                            textBox6.Text = "";
                            textBox7.Text = "";
                        }
                    }
                    


                }
                else
                {
                    MessageBox.Show("PASSWORDS DO NOT MATCH");
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Focus();
                }
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

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

        private void Forgot_password_Load(object sender, EventArgs e)
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
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
