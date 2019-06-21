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
    public partial class customercontrol : Form
    {
        public customercontrol()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login op = new Login();
            op.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Booking op = new Booking();
            op.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancelbooking op = new cancelbooking();
            op.Show();
            Hide();
        }

        //   private void button5_Click(object sender, EventArgs e)
        //    {
        //  view op = new view();
        //   op.Show();
        //   Hide();
        //   }
    }
}
