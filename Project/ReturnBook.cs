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
    public partial class ReturnBook : Form
    {
        private OleDbConnection mycon;

        public ReturnBook()
        {
            InitializeComponent();
        }
        private ClientsCatalogue fcatclient;

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormHome.valform = 0;
            fcatclient = new ClientsCatalogue();
            fcatclient.ShowDialog();
            if (ClientsCatalogue.idclient != 0)
            {
                mycon.Open();
                dataGridView1.Rows.Clear();
                OleDbCommand cmdidcl = new OleDbCommand();
                OleDbCommand cmdidcarte = new OleDbCommand();
                cmdidcl.CommandType = CommandType.Text;
                cmdidcarte.CommandType = CommandType.Text;
                cmdidcl.CommandText = @"SELECT COUNT(*) FROM Imprumuturi WHERE (idClienti = " + ClientsCatalogue.idclient + ")";
                cmdidcl.Connection = mycon;
                cmdidcarte.Connection = mycon;
                int imprumut = Convert.ToInt32(cmdidcl.ExecuteScalar());
                if (imprumut != 0)
                {
                    dataGridView1.Rows.Clear();
                    int idcarte;
                    cmdidcl.CommandText = @"SELECT * FROM Imprumuturi WHERE (idClienti = " + ClientsCatalogue.idclient + ")";
                    OleDbDataReader rdcl = cmdidcl.ExecuteReader();
                    while (rdcl.Read())
                    {
                        idcarte = Convert.ToInt32(Convert.ToString(rdcl[1]));
                        cmdidcarte.CommandText = @"SELECT * FROM Carti WHERE (id = " + idcarte + ")";
                        OleDbDataReader rdcarte = cmdidcarte.ExecuteReader();
                        rdcarte.Read();
                        DataGridViewRow dgvr = new DataGridViewRow();
                        dgvr.CreateCells(dataGridView1);
                        dgvr.Cells[0].Value = Convert.ToString(rdcarte[1]);
                        dgvr.Cells[1].Value = Convert.ToString(rdcarte[3]);
                        dgvr.Cells[2].Value = Convert.ToString(rdcarte[4]);
                        rdcarte.Close();
                        dataGridView1.Rows.Add(dgvr);
                    }

                    rdcl.Close();
                }
                cmdidcl.CommandText = @"SELECT * FROM Clienti WHERE (id = " + ClientsCatalogue.idclient + ")";
                OleDbDataReader rdidcl = cmdidcl.ExecuteReader();
                rdidcl.Read();
                label5.Text = Convert.ToString(rdidcl[2]);
                label6.Text = Convert.ToString(rdidcl[3]);
                rdidcl.Close();
                mycon.Close();
            }
            else
            {
                label5.Text = "";
                label6.Text = "";
            }
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\CNLR 2015-2016.mdb");
            FormHome.valform = 0;
            label5.Text = "";
            label6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mycon.Open();
            int count;
            count = dataGridView1.SelectedRows.Count;
            if (count != 0)
            {
                int rowindex = dataGridView1.SelectedCells[0].RowIndex;
                string codcarte = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

                OleDbCommand cmdcodcarte = new OleDbCommand();
                cmdcodcarte.CommandType = CommandType.Text;
                cmdcodcarte.CommandText = @"SELECT * FROM Carti WHERE (codCarte = '" + codcarte + "')";
                cmdcodcarte.Connection = mycon;
                OleDbDataReader rdcarte = cmdcodcarte.ExecuteReader();
                rdcarte.Read();
                int idcarte = Convert.ToInt32(rdcarte[0]);
                MessageBox.Show(Convert.ToString(idcarte));
                rdcarte.Close();
                OleDbCommand cmd1 = new OleDbCommand("DELETE FROM Imprumuturi WHERE  idCarti = " + idcarte + "");
                cmd1.Connection = mycon;
                cmd1.ExecuteNonQuery();
                Close();
            }
            else
                MessageBox.Show("Nu a fost selectat nici un rând.");
            mycon.Close();
        }
    }
}
