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
    public partial class BooksCatalogue : Form
    {
        private AddBook fbook;
        private OleDbConnection mycon;
        int totcl = 0;
        int idcdc, idcl;
        string grcarte, edcarte, colcarte, lbcarte, domcarte;
        int idgrc, ided, idcol, idlb, iddom;
        string codcarte;
        int imprumut;
        int sh;
        public static int idcarte;

        public BooksCatalogue()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mycon.Open();
            int rowindex = dataGridView1.SelectedCells[0].RowIndex;
            int idcl = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[16].Value);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            mycon.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (imprumut != 0)
                MessageBox.Show("Cartea este împrumutată!");
            else
            {
                int rowindex = dataGridView1.SelectedCells[0].RowIndex;
                idcarte = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[15].Value);
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BooksCatalogue_Load(object sender, EventArgs e)
        {
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\CNLR 2015-2016.mdb");
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.Carti' table. You can move, or remove it, as needed.
            this.cartiTableAdapter.Fill(this._CNLR_2015_2016DataSet.Carti);
            FormHome.valform = 0;
            totcl = dataGridView1.Rows.Count;
            label1.Text = Convert.ToString(totcl);
            sh = 0;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormHome.valform = 0;
            fbook = new AddBook();
            fbook.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormHome.valform = 1;
            fbook = new AddBook();
            fbook.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                sh = 1;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Carti WHERE (titlu) LIKE ('%" + textBox1.Text + "%')";
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
                    dgvr.Cells[1].Value = Convert.ToString(rd[3]);
                    dgvr.Cells[2].Value = Convert.ToString(rd[4]);
                    dgvr.Cells[3].Value = Convert.ToString(rd[2]);
                    dgvr.Cells[4].Value = Convert.ToString(rd[6]);
                    dgvr.Cells[5].Value = Convert.ToString(rd[7]);
                    dgvr.Cells[6].Value = Convert.ToString(rd[15]);
                    dgvr.Cells[7].Value = Convert.ToString(rd[16]);
                    dgvr.Cells[8].Value = Convert.ToString(rd[17]);
                    dgvr.Cells[9].Value = Convert.ToString(rd[18]);
                    dgvr.Cells[10].Value = Convert.ToString(rd[19]);
                    dgvr.Cells[11].Value = Convert.ToString(rd[12]);
                    dgvr.Cells[12].Value = Convert.ToString(rd[14]);
                    dgvr.Cells[13].Value = Convert.ToString(rd[21]);
                    dgvr.Cells[14].Value = Convert.ToString(rd[13]);
                    dgvr.Cells[15].Value = Convert.ToString(rd[0]);
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
                cmd.CommandText = @"SELECT * FROM Carti WHERE (autor) LIKE ('%" + textBox2.Text + "%')";
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
                    dgvr.Cells[1].Value = Convert.ToString(rd[3]);
                    dgvr.Cells[2].Value = Convert.ToString(rd[4]);
                    dgvr.Cells[3].Value = Convert.ToString(rd[2]);
                    dgvr.Cells[4].Value = Convert.ToString(rd[6]);
                    dgvr.Cells[5].Value = Convert.ToString(rd[7]);
                    dgvr.Cells[6].Value = Convert.ToString(rd[15]);
                    dgvr.Cells[7].Value = Convert.ToString(rd[16]);
                    dgvr.Cells[8].Value = Convert.ToString(rd[17]);
                    dgvr.Cells[9].Value = Convert.ToString(rd[18]);
                    dgvr.Cells[10].Value = Convert.ToString(rd[19]);
                    dgvr.Cells[11].Value = Convert.ToString(rd[12]);
                    dgvr.Cells[12].Value = Convert.ToString(rd[14]);
                    dgvr.Cells[13].Value = Convert.ToString(rd[21]);
                    dgvr.Cells[14].Value = Convert.ToString(rd[13]);
                    dgvr.Cells[15].Value = Convert.ToString(rd[0]);
                    dataGridView1.Rows.Add(dgvr);
                }
                rd.Close();
                mycon.Close();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                sh = 1;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Carti WHERE (codCarte) LIKE ('%" + textBox3.Text + "%')";
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
                    dgvr.Cells[1].Value = Convert.ToString(rd[3]);
                    dgvr.Cells[2].Value = Convert.ToString(rd[4]);
                    dgvr.Cells[3].Value = Convert.ToString(rd[2]);
                    dgvr.Cells[4].Value = Convert.ToString(rd[6]);
                    dgvr.Cells[5].Value = Convert.ToString(rd[7]);
                    dgvr.Cells[6].Value = Convert.ToString(rd[15]);
                    dgvr.Cells[7].Value = Convert.ToString(rd[16]);
                    dgvr.Cells[8].Value = Convert.ToString(rd[17]);
                    dgvr.Cells[9].Value = Convert.ToString(rd[18]);
                    dgvr.Cells[10].Value = Convert.ToString(rd[19]);
                    dgvr.Cells[11].Value = Convert.ToString(rd[12]);
                    dgvr.Cells[12].Value = Convert.ToString(rd[14]);
                    dgvr.Cells[13].Value = Convert.ToString(rd[21]);
                    dgvr.Cells[14].Value = Convert.ToString(rd[13]);
                    dgvr.Cells[15].Value = Convert.ToString(rd[0]);
                    dataGridView1.Rows.Add(dgvr);
                }
                rd.Close();
                mycon.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mycon.Open();
            label22.Text = label23.Text = label24.Text = label25.Text = label26.Text = label27.Text = label28.Text = label29.Text = label30.Text = label31.Text = label32.Text = label33.Text = "";
                
            int count = dataGridView1.SelectedCells.Count;
            int rowindex;
            string ed, gr, col, lg, dom;
            rowindex = dataGridView1.SelectedCells[0].RowIndex;
            grcarte = dataGridView1.Rows[rowindex].Cells[7].Value.ToString();
            edcarte = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
            colcarte = dataGridView1.Rows[rowindex].Cells[8].Value.ToString();
            lbcarte = dataGridView1.Rows[rowindex].Cells[9].Value.ToString();
            domcarte = dataGridView1.Rows[rowindex].Cells[10].Value.ToString();
            codcarte = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            if ( grcarte == "" )
                idgrc = 0;
            else
                idgrc = Convert.ToInt32(grcarte);
            if ( edcarte == "" )
                ided = 0;
            else
                ided = Convert.ToInt32(edcarte);
            if ( colcarte == "")
                idcol = 0;
            else
                idcol = Convert.ToInt32(colcarte);
            if (lbcarte == "")
                idlb = 0;
            else
                idlb = Convert.ToInt32(lbcarte);
            if (domcarte == "")
                iddom = 0;
            else
                iddom = Convert.ToInt32(domcarte);
            if (codcarte == "")
                MessageBox.Show("Cartea introdusă nu are cod, nu figurează în baza împrumuturilor.");
            else
            {
                OleDbCommand cmdcodcarte = new OleDbCommand();
                cmdcodcarte.CommandType = CommandType.Text;
                cmdcodcarte.CommandText = @"SELECT * FROM Carti WHERE (codCarte = '" + codcarte + "')";
                cmdcodcarte.Connection = mycon;
                OleDbDataReader rdcdc = cmdcodcarte.ExecuteReader();
                rdcdc.Read();
                idcdc = Convert.ToInt32(Convert.ToString(rdcdc[0]));
                rdcdc.Close();

                OleDbCommand cmdidcarte = new OleDbCommand();
                cmdidcarte.CommandType = CommandType.Text;
                cmdidcarte.CommandText = @"SELECT COUNT(*) FROM Imprumuturi WHERE (idCarti = " + idcdc + ")";
                cmdidcarte.Connection = mycon;
                imprumut = Convert.ToInt32(cmdidcarte.ExecuteScalar());
                if( imprumut != 0 )
                {
                    cmdidcarte.CommandText = @"SELECT * FROM Imprumuturi WHERE (idCarti = " + idcdc + ")";
                    OleDbDataReader rdidc = cmdidcarte.ExecuteReader();
                    rdidc.Read();
                    idcl = Convert.ToInt32(Convert.ToString(rdidc[2]));
                    label26.Text = Convert.ToString(rdidc[3]);
                    label27.Text = Convert.ToString(rdidc[4]);
                    rdidc.Close();
                    cmdidcarte.CommandText = @"SELECT * FROM Clienti WHERE (id = " + idcl + ")";
                    OleDbDataReader rdcl = cmdidcarte.ExecuteReader();
                    rdcl.Read();
                    label23.Text = Convert.ToString(rdcl[2]);
                    label24.Text = Convert.ToString(rdcl[3]);
                    //Grupul
                    OleDbCommand cmdgr = new OleDbCommand();
                    cmdgr.CommandType = CommandType.Text;
                    cmdgr.CommandText = @"SELECT * FROM GrupuriClienti WHERE (id = " + Convert.ToInt32(rdcl[13]) + ")";
                    cmdgr.Connection = mycon;
                    OleDbDataReader rdgrcl = cmdgr.ExecuteReader();
                    rdgrcl.Read();
                    string grcl = Convert.ToString(rdgrcl[1]);
                    label25.Text = grcl;
                    rdgrcl.Close();

                    rdcl.Close();
                }
                

            }
            

            //Grupul carte
            if( idgrc != 0 )
            {
                OleDbCommand cmdgr = new OleDbCommand();
                cmdgr.CommandType = CommandType.Text;
                cmdgr.CommandText = @"SELECT * FROM Grupuri WHERE (id = " + idgrc + ")";
                cmdgr.Connection = mycon;
                OleDbDataReader rdgr = cmdgr.ExecuteReader();
                rdgr.Read();
                gr = Convert.ToString(rdgr[1]);
                rdgr.Close();
                label30.Text = gr;
            }


            //Editura
            if (ided != 0)
            {
                OleDbCommand cmded = new OleDbCommand();
                cmded.CommandType = CommandType.Text;
                cmded.CommandText = @"SELECT * FROM Edituri WHERE (id = " + ided + ")";
                cmded.Connection = mycon;
                OleDbDataReader rded = cmded.ExecuteReader();
                rded.Read();
                ed = Convert.ToString(rded[1]);
                label29.Text = ed;
            }

            //Colectia
            if( idcol != 0 )
            {
                OleDbCommand cmdcol = new OleDbCommand();
                cmdcol.CommandType = CommandType.Text;
                cmdcol.CommandText = @"SELECT * FROM ColectiiCarti WHERE (id = " + idcol + ")";
                cmdcol.Connection = mycon;
                OleDbDataReader rdcol = cmdcol.ExecuteReader();
                rdcol.Read();
                col = Convert.ToString(rdcol[1]);
                label31.Text = col;
            }

            //Limba
            if (idlb != 0)
            {
                OleDbCommand cmdlg = new OleDbCommand();
                cmdlg.CommandType = CommandType.Text;
                cmdlg.CommandText = @"SELECT * FROM Languages WHERE (id = " + idlb + ")";
                cmdlg.Connection = mycon;
                OleDbDataReader rdlg = cmdlg.ExecuteReader();
                rdlg.Read();
                lg = Convert.ToString(rdlg[1]);
                label32.Text = lg;
            }

            //Domenii
            if( iddom != 0 )
            {
                OleDbCommand cmddom = new OleDbCommand();
                cmddom.CommandType = CommandType.Text;
                cmddom.CommandText = @"SELECT * FROM Domenii WHERE (id = " + iddom + ")";
                cmddom.Connection = mycon;
                OleDbDataReader rddom = cmddom.ExecuteReader();
                rddom.Read();
                dom = Convert.ToString(rddom[1]);
                label33.Text = dom;
            }
            mycon.Close();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int count;
            count = dataGridView1.SelectedRows.Count;
            if (count != 0)
            {
                OleDbCommand cmd1 = new OleDbCommand("DELETE FROM Carti WHERE  id = " + dataGridView1.SelectedRows[0].Cells[15].Value.ToString() + "");
                cmd1.Connection = mycon;
                //MessageBox.Show(cmd1.CommandText);
                mycon.Open();
                cmd1.ExecuteNonQuery();
                cartiTableAdapter.Update(_CNLR_2015_2016DataSet.Carti);
                mycon.Close();
                if (sh == 1)
                    MessageBox.Show("Rândul selectat a fost şters!");
            }
            else
                MessageBox.Show("Nu a fost selectat nici un rând.");
            this.cartiTableAdapter.Fill(this._CNLR_2015_2016DataSet.Carti);
        }
    }
}
