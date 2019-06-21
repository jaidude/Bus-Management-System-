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
using Microsoft.VisualBasic;

namespace BR
{
    public partial class viewbuses : Form
    {
        OracleConnection con1;
        OracleCommand cmd;
        string query;
        int temp, I;
        OracleDataAdapter da;
        DataSet d;

        public viewbuses()
        {
            InitializeComponent();
        }

        private void viewbuses_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'busdetails.BUSES' table. You can move, or remove it, as needed.
            this.bUSESTableAdapter.Fill(this.busdetails.BUSES);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            staffcontrol op = new staffcontrol();
            op.Show();
            Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            query = "select * from buses where ";
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
    }
}
