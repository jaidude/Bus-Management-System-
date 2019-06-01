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
    public partial class Booking : Form
    {
        OracleConnection con1;
        OracleCommand cmd;
        string query;
        int temp, I;
        OracleConnection CON1;
        OracleCommand CMD;
        string QUERY;
        OracleDataReader RDR;
        //OracleDataReader rdr;


        public void NEWRECORD()
        {
            string query2, ID;
            textBox7.Text = "";
            query2 = "Select max(id) from booking";
            con1.Open();
            cmd = new OracleCommand(query2, con1);
            cmd.CommandText = query2;
            ID = Convert.ToString(cmd.ExecuteScalar());
            //  MessageBox.Show(ID);
            if (ID.Equals(""))
                textBox1.Text = Convert.ToString(1);
            else
            {
                int s;
                s = Convert.ToInt16(ID) + 1;
                textBox1.Text = Convert.ToString(s);
            }
            con1.Close();
        }



        public void CLEARFORM()
        {
            textBox2.Text = "";
            //  textBox3.Text = "";
            textBox6.Text = "";
            //  textBox7.Text = "";
            textBox3.Text = Convert.ToString(0);
            textBox7.Text = Convert.ToString(0);

           // comboBox1.SelectedIndex = 0;
           // comboBox2.SelectedIndex = 0;
           // comboBox3.SelectedIndex = 0;
           // comboBox4.SelectedIndex = 0;
            dateTimePicker1.Text = Convert.ToString(System.DateTime.Now);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd-MMM-yyyy  ";
            textBox2.Focus();
        }


        public void BUSNO()
        {          
            // if (comboBox1.SelectedItem.ToString() == "" || comboBox2.SelectedItem.ToString() == "" || comboBox3.SelectedItem.ToString() == "" || comboBox4.SelectedItem.ToString() == "" || comboBox1.SelectedItem.ToString() == "--SELECT--" || comboBox2.SelectedItem.ToString() == "--SELECT--" || comboBox3.SelectedItem.ToString() == "--SELECT--" || comboBox4.SelectedItem.ToString() == "--SELECT--" )
             if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox1.Text == "--SELECT--" || comboBox2.Text == "--SELECT--" || comboBox3.Text == "--SELECT--" || comboBox4.Text == "--SELECT--" )
            {

            
                textBox3.Text = "";
                    MessageBox.Show("A BUS VIA THIS ROUTE DOESN'T EXIST. PLEASE SELECT SOME OTHER DETAILS.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            else
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

        }




        public void DISPLAY_AMOUNT()
        {
            OracleConnection CON1;
            OracleCommand CMD;
            string QUERY;
            OracleDataReader RDR;

            CON1 = new OracleConnection("Data Source=XE;User ID=project;password=project");


            QUERY = "select amount from buses where bus_type ='" + comboBox4.Text + "' and bus_no= '" + textBox6.Text + "' and timing ='" + comboBox3.Text + "' ";
            CMD = new OracleCommand(QUERY, CON1);

            CON1.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {                
                textBox3.Text = Convert.ToString(RDR["AMOUNT"]);          
            }
            RDR.Close();
            CON1.Close();

        }


        public void PNO()
        {
            string query2, ID, c;
            // fetching the value of max no of passenger from a particular bus
            query2 = "Select max(passenger_no) from booking where s_from='" + comboBox1.Text + "' and d_to='" + comboBox2.Text + "' and bus_timing='" + comboBox3.Text + "' and bus_type='" + comboBox4.Text + "'";
            con1.Open();
            cmd = new OracleCommand(query2, con1);
            cmd.CommandText = query2;
            ID = Convert.ToString(cmd.ExecuteScalar());
            if (ID.Equals(""))
                textBox7.Text = Convert.ToString(1);
            else
            {   //checking if all the seats are reserved
                query2 = "Select count(passenger_no) from booking where s_from='" + comboBox1.Text + "' and d_to='" + comboBox2.Text + "' and bus_timing='" + comboBox3.Text + "' and bus_type='" + comboBox4.Text + "'";
                cmd = new OracleCommand(query2, con1);
                cmd.CommandText = query2;
                c = Convert.ToString(cmd.ExecuteScalar());
                //  MessageBox.Show(c);
                if (Convert.ToInt16(c) == 10)
                {

                    MessageBox.Show("All the seats are reserved for this bus. Please try booking some other bus.");
                }
                else
                {
                    //increment passenger by 1
                    int s;
                    s = Convert.ToInt16(ID) + 1;
                    textBox7.Text = Convert.ToString(s);
                }
            }
            con1.Close();
        }

        
        private string mail;
        private string gname;
        static string message;
        //public Booking(string m)
        public Booking()
        {
            InitializeComponent();
            con1 = new OracleConnection("Data Source=XE;User ID=project;password=project ");
            CON1 = new OracleConnection("Data Source=XE;User ID=project;password=project");
            mail = Login.getemail;
            gname = Login.getname;
          // MessageBox.Show(Convert.ToString(mail));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con1 = new OracleConnection("Data Source=XE;User ID=project;password=project");

            //print
            /* using (NorthwindEntities db = new NorthwindEntities())
             {
                 BindingSource.DataSource = db.Product.ToList();
             }*/
           // MessageBox.Show(gname);


            
            textBox3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "--SELECT--";
            comboBox2.Text = "--SELECT--";
            comboBox3.Text = "--SELECT--";
            comboBox4.Text = "--SELECT--";
            

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

            NEWRECORD();
            CLEARFORM();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd-MMM-yyyy  ";
            textBox3.Text = Convert.ToString(0);
            textBox7.Text = "";

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
            {  comboBox2.Items.Add(RDR["d_to"]);
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
            textBox2.Text = gname;
            CON1.Close();
           // BUSNO();
            //PNO();  
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customercontrol op = new customercontrol();
            op.Show();
            Hide();
        }
    


        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.Text == "--SELECT--" || comboBox3.Text == "--SELECT--" || comboBox4.Text == "--SELECT--" || dateTimePicker1.Text == "" || comboBox2.Text == "--SELECT--")
            {
                MessageBox.Show("Enter All the Details", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

            else
            {


                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = " dd-MMM-yyyy  ";

                try
                {

                    con1.Open();
                    query = "Insert into booking values('" + Convert.ToInt16(textBox1.Text) + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox4.Text + "','" + comboBox3.Text + "','" + textBox6.Text + "','" + Convert.ToInt16((textBox7.Text)) + "','" + textBox3.Text + "')";
                    message = "Dear Customer," + Environment.NewLine + Environment.NewLine + "Your ticket was booked successfully." + Environment.NewLine + Environment.NewLine + "ID:"+ textBox1.Text + Environment.NewLine + "Name: " + textBox2.Text + Environment.NewLine + "From: " + comboBox1.Text + Environment.NewLine + "To: " + comboBox2.Text + Environment.NewLine + "Bus Type: " + comboBox4.Text + Environment.NewLine + "Bus Timing:" + comboBox3.Text + Environment.NewLine + "Price:" + textBox3.Text + Environment.NewLine + Environment.NewLine+ "Please not that the money is not refundable" + Environment.NewLine + Environment.NewLine + "Thank you for choosing our service";
                    cmd = new OracleCommand(query, con1);
                    cmd.CommandType = CommandType.Text;
                    temp = cmd.ExecuteNonQuery();
                    if (temp > 0)
                    {
                        // Command line argument must the the SMTP host.
                              SmtpClient client = new SmtpClient();
                              client.Port = 587;
                              client.Host = "smtp.gmail.com";
                              client.EnableSsl = true;
                              client.Timeout = 10000;
                              client.DeliveryMethod = SmtpDeliveryMethod.Network;
                              client.UseDefaultCredentials = false;
                              client.Credentials = new System.Net.NetworkCredential("companyname@gmail.com", "companypassword");
                              MailMessage mm = new MailMessage("companyname@gmail.com", mail, "BUS RESERVATION SERVICE", message);
                              mm.BodyEncoding = UTF8Encoding.UTF8;
                              mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                              client.Send(mm);

                        MessageBox.Show("TICKET BOOKED SUCESSFULLY.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        CLEARFORM();
                    }
                    else
                        MessageBox.Show(" INSERT OPERATION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (Exception ex)
                {
                    //   MessageBox.Show(ex.Message);
                }

                con1.Close();


                //print ticket
                /*   Graphics g = this.CreateGraphics();
                   bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
                   Graphics mg = Graphics.FromImage(bmp);
                   mg.CopyFromScreen(this.Location.X,this.Location.Y, 0, 0,this.Size);
                   printPreviewDialog1.ShowDialog();
                   */
                NEWRECORD();
            }

           
        }





        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox2.Text = gname;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.comboBox1.SelectedItem.ToString() == "--SELECT--" || this.comboBox2.SelectedItem.ToString() == "--SELECT--" || this.comboBox3.SelectedItem.ToString() == "--SELECT--" || this.comboBox4.SelectedItem.ToString() == "--SELECT--")
            //{
            //    MessageBox.Show("PLEASE ENTER ALL THE DETAILS");
            //}
            //else
            //{
                //this work is done in the form load
                BUSNO();
                DISPLAY_AMOUNT();
                PNO();
            //}

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           /*  if (comboBox4.SelectedItem.ToString() == "AC")
              {
                  textBox3.Text = Convert.ToString(40);
              }
              else if (comboBox4.SelectedItem.ToString() == "NON-AC")
              { textBox3.Text = Convert.ToString(30); }
              else
              {
                  textBox3.Text = "";
              }*/

          //  DISPLAY_AMOUNT(); // this fn will run only after the bus number is displayed ie. in the combobox3


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            // e.Graphics.DawImage(bmp,0,0);
           
        }

        Bitmap bmp;

        private void button3_Click(object sender, EventArgs e)
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "--SELECT--";
            comboBox2.Text = "--SELECT--";
            comboBox3.Text = "--SELECT--";
            comboBox4.Text = "--SELECT--";

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == comboBox2.Text)
            {
                textBox6.Text = "";
                MessageBox.Show("please choose a proper route", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
    
}
