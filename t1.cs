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

using System.Net.Mail;
using System.Text;


namespace BR
{
    public partial class t1 : Form
    {
        OracleConnection CON1;
        OracleCommand CMD;
        string QUERY;
        OracleDataReader RDR;

        //Login lg = new Login();
        

        public t1()
        {
            InitializeComponent();
            CON1 = new OracleConnection("Data Source=XE;User ID=project;password=project");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           

            // CMD = new OracleCommand(QUERY, CON1);
            //CMD.CommandText = QUERY;
            //comboBox1.Text = Convert.ToString(CMD.ExecuteScalar());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*// Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("addjoybarreto26@gmail.com", "ajBarreto26");

            MailMessage mm = new MailMessage("addjoybarreto26@gmail.com", mail, "booking", "this is working...");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);*/
        }

        private string mail= "addjoybarreto26@gmail.com";
        string message = "";
        public t1(string m)
        {
            mail = m;
        }

        private void t1_Load(object sender, EventArgs e)
        {

          //  MessageBox.Show(mail);
        }

       
    }
}
