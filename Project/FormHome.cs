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
    public partial class FormHome : Form
    {

        private AddClient fclient;
        private AddBook fbook;
        private Publisher fedit;
        private GroupsBooks fgroupbook;
        private GroupsClients fgroupclient;
        private Loan floan;
        private Domains fdomanis;
        private ReturnBook freturn;
        private BooksCatalogue fcacatalog;
        private Booking fbooking;
        private ClientsCatalogue fclcatalog;
        private Collections fcolectii;
        private Languages flanguage;
        public static int valform;
        public FormHome()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            valform = 1;
            fclient = new AddClient();
            fclient.Show();
        }

        private void adăugareCliențiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valform = 1;
            fclient = new AddClient();
            fclient.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            valform = 1;
            fbook = new AddBook();
            fbook.FormBorderStyle = FormBorderStyle.FixedDialog;
            fbook.MaximizeBox = false;
            fbook.MinimizeBox = false;
            fbook.StartPosition = FormStartPosition.CenterScreen;
            fbook.Show();
        }

        private void adăugareCărțiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valform = 1;
            fbook = new AddBook();
            fbook.Show();
        }

        private void catalogEdituriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valform = 1;
            fedit = new Publisher();
            fedit.Show();
        }

        private void catalogGrupuriCărțiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valform = 1;
            fgroupbook = new GroupsBooks();
            fgroupbook.Show();
        }

        private void împrumutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            floan = new Loan();
            floan.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            floan = new Loan();
            floan.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            freturn = new ReturnBook();
            freturn.Show();
        }

        private void catalogDomeniiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valform = 1;
            fdomanis = new Domains();
            fdomanis.Show();
        }

        private void ieșireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            valform = 1;
            fclcatalog = new ClientsCatalogue();
            fclcatalog.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            valform = 1;
            fcacatalog = new BooksCatalogue();
            fcacatalog.Show();
        }

        private void restituireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            freturn = new ReturnBook();
            freturn.Show();
        }

        private void rezervareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fbooking = new Booking();
            fbooking.Show();
        }

        private void catalogCliențiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valform = 1;
            fclcatalog = new ClientsCatalogue();
            fclcatalog.Show();
        }

        private void catalogGrupuriDeCliențiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valform = 1;
            fgroupclient = new GroupsClients();
            fgroupclient.Show();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void catalogCărțiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valform = 1;
            fcacatalog = new BooksCatalogue();
            fcacatalog.Show();
        }

        private void catalogGrupuriCărțiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            valform = 1;
            fcolectii = new Collections();
            fcolectii.Show();
        }

        private void catalogLimbiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valform = 1;
            flanguage = new Languages();
            flanguage.Show();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            valform = 0;
        }
    }
}
