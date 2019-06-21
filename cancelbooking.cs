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

using System.Net.Mail;
using System.Text;

namespace BR
{
    public partial class cancelbooking : Form
    {
        OracleConnection con1;
        OracleCommand cmd;
        string query;
        OracleDataReader RDR;


        private string gname,mail;

        public cancelbooking()
        {
            InitializeComponent();
            con1 = new OracleConnection("Data Source=XE;User ID=project;password=project ");
            gname = Login.getname;
            mail = Login.getemail;
        }

        private void cancelbooking_Load(object sender, EventArgs e)
        {
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
           // textBox2.Text = gname;
            
            query = "Select id from booking where name='"+ textBox2.Text+"'";
            con1.Open();
            cmd = new OracleCommand(query, con1);
            RDR = cmd.ExecuteReader();
            while (RDR.Read())
            {
                s = (string)(RDR["id"]);              
            }

            con1.Close();
            textBox1.Text = s;
           // MessageBox.Show(textBox1.Text);
            //MessageBox.Show(textBox2.Text);
        }
        string s;
        private void button1_Click(object sender, EventArgs e)
        {
            customercontrol op = new customercontrol();
            op.Show();
            Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           // textBox2.Text = gname;  //for hardcoding uncomment textbox in load in needed
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || (textBox1.Text == "" && textBox2.Text == ""))
            {
                MessageBox.Show("Enter All the Details", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int FLAG = 0;
                string STR = "";

                query = "select * from booking where id ='" + textBox1.Text + "' ";
               cmd = new OracleCommand(query, con1);

                con1.Open();
                RDR = cmd.ExecuteReader();
                while (RDR.Read())
                {
                    STR = (string)RDR["name"];
                    FLAG = 1;
                }
                RDR.Close();

                con1.Close();
                if (FLAG == 0)
                {
                    MessageBox.Show(" DATA DIDN'T MATCH. PLEASE ENTER THE DATA CORRECTLY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    

                }

               
                else
                {
                    string message = "Dear Customer," + Environment.NewLine + Environment.NewLine + "Your ticket was canceled successfully." + Environment.NewLine + Environment.NewLine + "ID:" + textBox1.Text + Environment.NewLine + "Name: " + textBox2.Text + Environment.NewLine + "";
                    con1.Open();
                    query = "delete from booking where ID='" + textBox1.Text + "' and name='" + textBox2.Text + "'";
                    cmd = new OracleCommand(query, con1);
                    int TEMP = cmd.ExecuteNonQuery();
                    if (TEMP > 0)
                    {
                        // Command line argument must the the SMTP host.
                         SmtpClient client = new SmtpClient();
                         client.Port = 587;
                         client.Host = "smtp.gmail.com";
                         client.EnableSsl = true;
                         client.Timeout = 10000;
                         client.DeliveryMethod = SmtpDeliveryMethod.Network;
                         client.UseDefaultCredentials = false;
                         client.Credentials = new System.Net.NetworkCredential("addjoybarreto26@gmail.com", "ajBarreto26");
                         MailMessage mm = new MailMessage("addjoybarreto26@gmail.com", mail, "BUS RESERVATION SERVICE", message);
                         mm.BodyEncoding = UTF8Encoding.UTF8;
                         mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                         client.Send(mm);
                        MessageBox.Show(" RECORD DELETED SUCESSFULLY");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    else
                        MessageBox.Show("DATA DIDN'T MATCH. DELETE OPERATION FAILED ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con1.Close();
                }
            }
        }
    }
}
