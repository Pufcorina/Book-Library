using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_Library
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }
        private BooksCatalogue fcatbook;
        private ClientsCatalogue fcatclient;
        private void button4_Click(object sender, EventArgs e)
        {
            fcatbook = new BooksCatalogue();
            fcatbook.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fcatclient = new ClientsCatalogue();
            fcatclient.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            FormHome.valform = 0;
        }
    }
}
