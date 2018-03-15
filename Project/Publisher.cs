using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Book_Library
{
    public partial class Publisher : Form
    {
        private OleDbConnection mycon;
        public static string edit;
        int sh;

        public Publisher()
        {
            InitializeComponent();
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\CNLR 2015-2016.mdb");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Publisher_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.Edituri' table. You can move, or remove it, as needed.
            this.edituriTableAdapter.Fill(this._CNLR_2015_2016DataSet.Edituri);
            if (FormHome.valform == 1) 
                button1.Enabled = false;
            FormHome.valform = 0;
            sh = 0;
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd1 = new OleDbCommand("SELECT COUNT(*) FROM Edituri WHERE denumire = '" + textBox2.Text + "' ");
            mycon.Open();
            cmd1.Connection = mycon;
            int denumireCount = (int)cmd1.ExecuteScalar();
            if (denumireCount < 1)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO Edituri (denumire, adresa, telefon, email, website) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                cmd.Connection = mycon;
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Editura introdusă există deja!");
            }
            mycon.Close();
            this.edituriTableAdapter.Fill(this._CNLR_2015_2016DataSet.Edituri);
        }

        private void tstxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                sh = 1;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Edituri WHERE (denumire) LIKE ('%" + tstxtSearch.Text + "%')";
                mycon.Open();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                cmd.Connection = mycon;
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.CreateCells(dataGridView1);
                    dgvr.Cells[0].Value = Convert.ToString(rd[1]);
                    dgvr.Cells[1].Value = Convert.ToString(rd[2]);
                    dgvr.Cells[2].Value = Convert.ToString(rd[3]);
                    dgvr.Cells[3].Value = Convert.ToString(rd[4]);
                    dgvr.Cells[4].Value = Convert.ToString(rd[5]);
                    dgvr.Cells[5].Value = Convert.ToString(rd[0]);
                    dataGridView1.Rows.Add(dgvr);
                }
                rd.Close();
                mycon.Close();

            }
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            int count;
            count = dataGridView1.SelectedRows.Count;
            if (count != 0)
            {
                OleDbCommand cmd1 = new OleDbCommand("DELETE FROM Edituri WHERE id = " + dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + "");
                cmd1.Connection = mycon;
                mycon.Open();
                cmd1.ExecuteNonQuery();
                edituriTableAdapter.Update(_CNLR_2015_2016DataSet.Edituri);
                mycon.Close();
                this.edituriTableAdapter.Fill(this._CNLR_2015_2016DataSet.Edituri);
                if (sh == 1)
                    MessageBox.Show("Rândul selectat a fost şters!");
            }
            else
                MessageBox.Show("Nu a fost selectat nici un rând.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedCells[0].ColumnIndex;
            if (count == 0 )
            {
                edit = dataGridView1.SelectedCells[0].Value.ToString();
            }
            else
                MessageBox.Show("Selectează campul cu denumire înainte de a apăsa butonul salvează!");
            if ( count == 0 )
                Close();
        }
    }
}
