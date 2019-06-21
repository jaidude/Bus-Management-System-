using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BR
{
    public partial class staffcontrol : Form
    {
        public staffcontrol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Booking op = new Booking();
            op.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login op = new Login();
            op.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            view op = new view();
            op.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            update op = new update();
            op.Show();
            Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            viewbuses op = new viewbuses();
            op.Show();
            Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Add_Bus op = new Add_Bus();
            op.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Delete_Bus op = new Delete_Bus();
            op.Show();
            Hide();
        }
    }
}
