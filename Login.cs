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
    public partial class Login : Form
    {
       public static string getemail,getname;
         OracleConnection CON1 = new OracleConnection();
         OracleCommand CMD;
       string QUERY;
        //int TEMP;
         OracleDataReader RDR;

        public Login()
        {
            InitializeComponent();
            CON1 = new OracleConnection("Data Source=XE;User ID=project;password=project ");
        }

        private void Login_Load(object sender, EventArgs e)
        {
            CON1 = new OracleConnection("Data Source=XE;User ID=project;password=project ");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;

            comboBox4.Text = "--SELECT--";
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == " ") || (textBox2.Text == "") || (comboBox4.Text == "") || (comboBox4.Text == "--SELECT--"))
            {
                MessageBox.Show("Enter the all the details");
            }
            // for staff 
            else
            {
                
            if (comboBox4.SelectedItem.ToString() == "Staff")
                {
                    int FLAG = 0;
                    string STR = "";

                    QUERY = "select * from S_CREATE_ACCOUNT where username ='" + textBox1.Text + "' ";
                    CMD = new OracleCommand(QUERY, CON1);

                    CON1.Open();
                    RDR = CMD.ExecuteReader();
                    while (RDR.Read())
                    {
                        STR = (string)RDR["password"];
                        FLAG = 1;
                    }
                    RDR.Close();

                    CON1.Close();
                    if (FLAG == 0)
                    {
                        MessageBox.Show(" username doesnt exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clearform();

                    }
                    else if (textBox2.Text == STR)
                    {
                       
                                 staffcontrol op = new staffcontrol();
                                 op.Show();
                                 Hide();
                        

                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username and Password doesnt match.Please enter correct username and Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Text = " ";
                        textBox2.Focus();
                    }
                }


                // for customer
                else
                {
                    int FLAG1 = 0;
                    string STR1 = "";

                    QUERY = "select * from C_CREATE_ACCOUNT where username ='" + textBox1.Text + "' ";
                    CMD = new OracleCommand(QUERY, CON1);

                    CON1.Open();
                    RDR = CMD.ExecuteReader();
                    while (RDR.Read())
                    {
                        STR1 = (string)RDR["password"];
                        FLAG1 = 1;
                    }
                    RDR.Close();

                    CON1.Close();
                    if (FLAG1 == 0)
                    {
                        MessageBox.Show(" username doesnt exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clearform();

                    }
                    else if (textBox2.Text == STR1)
                    {
                                //fatch the email adderss of the user

                     QUERY = "select email from C_CREATE_ACCOUNT where username ='" + textBox1.Text + "' ";
                    CMD = new OracleCommand(QUERY, CON1);
                        getname = textBox1.Text;
                    CON1.Open();
                    RDR = CMD.ExecuteReader();
                    while (RDR.Read())
                    {
                        getemail = (string)RDR["email"];                       
                    }
                    RDR.Close();

                    CON1.Close();
                        //value passed to the constructor of another form
                     //   MessageBox.Show(getemail);
                      //  Booking m = new Booking(getemail);
                                 customercontrol op = new customercontrol();
                                 op.Show();
                                 Hide();
                           

                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username and Password doesnt match.Please enter correct username and Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Text = " ";
                        textBox2.Focus();
                    }

                }
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgot_password op = new Forgot_password();
            op.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void clearform()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            createstaff op = new createstaff();
            op.Show();
            Hide();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
