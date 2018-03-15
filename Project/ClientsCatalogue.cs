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

namespace Book_Library
{
    public partial class ClientsCatalogue : Form
    {
        private OleDbConnection mycon;
        public static int idclient;
        int sh, imprumut;

        public ClientsCatalogue()
        {
            InitializeComponent();
        }

        private AddClient fclient;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormHome.valform = 1;
            fclient = new AddClient();
            fclient.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormHome.valform = 0;
            fclient = new AddClient();
            fclient.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            idclient = 0;
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int count;
            count = dataGridView1.SelectedRows.Count;
            if (count != 0)
            {
                OleDbCommand cmd1 = new OleDbCommand("DELETE FROM Clienti WHERE  id = " + dataGridView1.SelectedRows[0].Cells[16].Value.ToString() + "");
                cmd1.Connection = mycon;
                mycon.Open();
                cmd1.ExecuteNonQuery();
                clientiTableAdapter.Update(_CNLR_2015_2016DataSet.Clienti);
                mycon.Close();
                if (sh == 1)
                    MessageBox.Show("Rândul selectat a fost şters!");
            }
            else
                MessageBox.Show("Nu a fost selectat nici un rând.");
            this.clientiTableAdapter.Fill(this._CNLR_2015_2016DataSet.Clienti);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int rowindex = dataGridView1.SelectedCells[0].RowIndex;
            idclient = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[16].Value);
            Close();
        }

        private void ClientsCatalogue_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.GrupuriClienti' table. You can move, or remove it, as needed.
            this.grupuriClientiTableAdapter.Fill(this._CNLR_2015_2016DataSet.GrupuriClienti);
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\CNLR 2015-2016.mdb");
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.Clienti' table. You can move, or remove it, as needed.
            this.clientiTableAdapter.Fill(this._CNLR_2015_2016DataSet.Clienti);
            if (FormHome.valform == 1)
                button1.Enabled = false;
            FormHome.valform = 0;
            sh = 0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                sh = 1;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Clienti WHERE (nume) LIKE ('%" + textBox1.Text + "%')";
                mycon.Open();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                cmd.Connection = mycon;
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.CreateCells(dataGridView1);
                    dgvr.Cells[0].Value = Convert.ToString(rd[2]);
                    dgvr.Cells[1].Value = Convert.ToString(rd[3]);
                    dgvr.Cells[2].Value = Convert.ToString(rd[1]);
                    dgvr.Cells[3].Value = Convert.ToString(rd[13]);
                    dgvr.Cells[4].Value = Convert.ToBoolean(rd[14]);
                    dgvr.Cells[5].Value = Convert.ToString(rd[4]);
                    dgvr.Cells[6].Value = Convert.ToString(rd[5]);
                    dgvr.Cells[7].Value = Convert.ToString(rd[6]);
                    dgvr.Cells[8].Value = Convert.ToString(rd[7]);
                    dgvr.Cells[9].Value = Convert.ToString(rd[8]);
                    dgvr.Cells[10].Value = Convert.ToString(rd[9]);
                    dgvr.Cells[11].Value = Convert.ToString(rd[10]);
                    dgvr.Cells[12].Value = Convert.ToString(rd[11]);
                    dgvr.Cells[13].Value = Convert.ToString(rd[12]);
                    dgvr.Cells[14].Value = Convert.ToString(rd[17]);
                    dgvr.Cells[15].Value = Convert.ToString(rd[15]);
                    dgvr.Cells[16].Value = Convert.ToString(rd[0]);
                    dataGridView1.Rows.Add(dgvr);
                }
                rd.Close();
                mycon.Close();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                sh = 1;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Clienti WHERE (prenume) LIKE ('%" + textBox2.Text + "%')";
                mycon.Open();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                cmd.Connection = mycon;
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.CreateCells(dataGridView1);
                    dgvr.Cells[0].Value = Convert.ToString(rd[2]);
                    dgvr.Cells[1].Value = Convert.ToString(rd[3]);
                    dgvr.Cells[2].Value = Convert.ToString(rd[1]);
                    dgvr.Cells[3].Value = Convert.ToString(rd[13]);
                    dgvr.Cells[4].Value = Convert.ToBoolean(rd[14]);
                    dgvr.Cells[5].Value = Convert.ToString(rd[4]);
                    dgvr.Cells[6].Value = Convert.ToString(rd[5]);
                    dgvr.Cells[7].Value = Convert.ToString(rd[6]);
                    dgvr.Cells[8].Value = Convert.ToString(rd[7]);
                    dgvr.Cells[9].Value = Convert.ToString(rd[8]);
                    dgvr.Cells[10].Value = Convert.ToString(rd[9]);
                    dgvr.Cells[11].Value = Convert.ToString(rd[10]);
                    dgvr.Cells[12].Value = Convert.ToString(rd[11]);
                    dgvr.Cells[13].Value = Convert.ToString(rd[12]);
                    dgvr.Cells[14].Value = Convert.ToString(rd[17]);
                    dgvr.Cells[15].Value = Convert.ToString(rd[15]);
                    dgvr.Cells[16].Value = Convert.ToString(rd[0]);
                    dataGridView1.Rows.Add(dgvr);
                }
                rd.Close();
                mycon.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mycon.Open();
            int rowindex = dataGridView1.SelectedCells[0].RowIndex;
            int idcl = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[16].Value);
            imprumut = 0;
            dataGridView2.Rows.Clear();
            OleDbCommand cmdidcl = new OleDbCommand();
            OleDbCommand cmdidcarte = new OleDbCommand();
            cmdidcl.CommandType = CommandType.Text;
            cmdidcarte.CommandType = CommandType.Text;
            cmdidcl.CommandText = @"SELECT COUNT(*) FROM Imprumuturi WHERE (idClienti = " + idcl + ")";
            cmdidcl.Connection = mycon;
            cmdidcarte.Connection = mycon;
            imprumut = Convert.ToInt32(cmdidcl.ExecuteScalar());
            if (imprumut != 0)
            {
                dataGridView2.Rows.Clear();
                int idcarte;
                cmdidcl.CommandText = @"SELECT * FROM Imprumuturi WHERE (idClienti = " + idcl + ")";
                OleDbDataReader rdcl = cmdidcl.ExecuteReader();
                while (rdcl.Read())
                {
                    idcarte = Convert.ToInt32(Convert.ToString(rdcl[1]));
                    cmdidcarte.CommandText = @"SELECT * FROM Carti WHERE (id = " + idcarte + ")";
                    OleDbDataReader rdcarte = cmdidcarte.ExecuteReader();
                    rdcarte.Read();
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.CreateCells(dataGridView2);
                    dgvr.Cells[0].Value = Convert.ToString(rdcarte[1]);
                    dgvr.Cells[1].Value = Convert.ToString(rdcarte[3]);
                    dgvr.Cells[2].Value = Convert.ToString(rdcarte[4]);
                    rdcarte.Close();
                    dataGridView2.Rows.Add(dgvr);
                }
                
                rdcl.Close();
            }
            

            mycon.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = label4.Text = "";
            mycon.Open();
            int rowindex = dataGridView2.SelectedCells[0].RowIndex;
            string codcarte = dataGridView2.Rows[rowindex].Cells[0].Value.ToString();

            OleDbCommand cmdcodcarte = new OleDbCommand();
            cmdcodcarte.CommandType = CommandType.Text;
            cmdcodcarte.CommandText = @"SELECT * FROM Carti WHERE (codCarte = '" + codcarte + "')";
            cmdcodcarte.Connection = mycon;
            OleDbDataReader rdcarte = cmdcodcarte.ExecuteReader();
            rdcarte.Read();
            int idcarte = Convert.ToInt32(rdcarte[0]);
            OleDbCommand cmdcart = new OleDbCommand();
            cmdcart.CommandType = CommandType.Text;
            cmdcart.Connection = mycon;
            cmdcart.CommandText = @"SELECT * FROM Imprumuturi WHERE (idCarti = " + idcarte + ")";
            OleDbDataReader rdc = cmdcart.ExecuteReader();
            rdc.Read();
            label2.Text = Convert.ToString(rdc[3]);
            label4.Text = Convert.ToString(rdc[4]);
            rdc.Close();
            rdcarte.Close();

            mycon.Close();
        }
    }
}
