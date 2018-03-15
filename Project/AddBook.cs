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
    public partial class AddBook : Form
    {
        private OleDbConnection mycon;

        public AddBook()
        {
            InitializeComponent();
        }
        private Publisher fedit;
        private Domains fdomeni;
        private Collections fcolecti;
        private GroupsBooks fgrbook;
        private Languages flang;

        private void button2_Click(object sender, EventArgs e)
        {
            FormHome.valform = 0;
            fgrbook = new GroupsBooks();
            fgrbook.ShowDialog();
            fgrbook.Refresh();
            comboBox5.Text = GroupsBooks.grbk;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHome.valform = 0;
            fedit = new Publisher();
            fedit.ShowDialog();
            fedit.Refresh();
            comboBox4.Text = Publisher.edit;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormHome.valform = 0;
            fdomeni = new Domains();
            fdomeni.ShowDialog();
            fdomeni.Refresh();
            comboBox7.Text = Domains.dom;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormHome.valform = 0;
            fcolecti = new Collections();
            fcolecti.ShowDialog();
            fcolecti.Refresh();
            comboBox8.Text = Collections.col;
        }

        private void AddBook_Load(object sender, EventArgs e)
        {
            
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\CNLR 2015-2016.mdb");
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.ColectiiCarti' table. You can move, or remove it, as needed.
            this.colectiiCartiTableAdapter.Fill(this._CNLR_2015_2016DataSet.ColectiiCarti);
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.Domenii' table. You can move, or remove it, as needed.
            this.domeniiTableAdapter.Fill(this._CNLR_2015_2016DataSet.Domenii);
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.Carti' table. You can move, or remove it, as needed.
            this.cartiTableAdapter.Fill(this._CNLR_2015_2016DataSet.Carti);
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.Edituri' table. You can move, or remove it, as needed.
            this.edituriTableAdapter.Fill(this._CNLR_2015_2016DataSet.Edituri);
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.Languages' table. You can move, or remove it, as needed.
            this.languagesTableAdapter.Fill(this._CNLR_2015_2016DataSet.Languages);
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.Grupuri' table. You can move, or remove it, as needed.
            this.grupuriTableAdapter.Fill(this._CNLR_2015_2016DataSet.Grupuri);
            if (FormHome.valform == 1)
                button9.Enabled = false;
            else
                button5.Enabled = false;
            FormHome.valform = 0;
            textBox1.Clear();
            textBox7.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox10.Clear();
            textBox8.Clear();
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.SelectionLength = 0;
            comboBox6.SelectionStart = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // butonul adauga
            if( textBox1.Text == "" || textBox7.Text == "" || textBox2.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || comboBox7.Text == "" || comboBox8.Text == "")
            {
                MessageBox.Show("Nu aţi completat câmpurile obligatorii : Cod Carte, Autor, Titlu, Editura, Grupul, Limba, Domeniul şi Colecţia");
            }
            else
            {
                mycon.Open();
                string ed, gr, col, lg, dom;
                //Editura
                OleDbCommand cmded = new OleDbCommand();
                cmded.CommandType = CommandType.Text;
                cmded.CommandText = @"SELECT * FROM Edituri WHERE (denumire = '" + comboBox4.Text + "')";
                cmded.Connection = mycon;
                OleDbDataReader rded = cmded.ExecuteReader();
                rded.Read();
                ed = Convert.ToString(rded[0]);
                //Grupul
                OleDbCommand cmdgr = new OleDbCommand();
                cmdgr.CommandType = CommandType.Text;
                cmdgr.CommandText = @"SELECT * FROM Grupuri WHERE (denumire = '" + comboBox5.Text + "')";
                cmdgr.Connection = mycon;
                OleDbDataReader rdgr = cmdgr.ExecuteReader();
                rdgr.Read();
                gr = Convert.ToString(rdgr[0]);
                rdgr.Close();
                //Colectia
                OleDbCommand cmdcol = new OleDbCommand();
                cmdcol.CommandType = CommandType.Text;
                cmdcol.CommandText = @"SELECT * FROM ColectiiCarti WHERE (denumire = '" + comboBox8.Text + "')";
                cmdcol.Connection = mycon;
                OleDbDataReader rdcol = cmdcol.ExecuteReader();
                rdcol.Read();
                col = Convert.ToString(rdcol[0]);
                //Limba
                OleDbCommand cmdlg = new OleDbCommand();
                cmdlg.CommandType = CommandType.Text;
                cmdlg.CommandText = @"SELECT * FROM Languages WHERE (denumire = '" + comboBox6.Text + "')";
                cmdlg.Connection = mycon;
                OleDbDataReader rdlg = cmdlg.ExecuteReader();
                rdlg.Read();
                lg = Convert.ToString(rdlg[0]);
                //Domeniul
                OleDbCommand cmddom = new OleDbCommand();
                cmddom.CommandType = CommandType.Text;
                cmddom.CommandText = @"SELECT * FROM Domenii WHERE (denumire = '" + comboBox7.Text + "')";
                cmddom.Connection = mycon;
                OleDbDataReader rddom = cmddom.ExecuteReader();
                rddom.Read();
                dom = Convert.ToString(rddom[0]);
                //Adauga in baza de date
                OleDbCommand cmd1 = new OleDbCommand("SELECT COUNT(*) FROM Carti WHERE codCarte = '" + Convert.ToInt32(textBox1.Text) + "' ");
                cmd1.Connection = mycon;
                int count = (int)cmd1.ExecuteScalar();
                if (count < 1)
                {
                    DateTime localDate = DateTime.Now;
                    string aux = localDate.Year.ToString() + '-' + localDate.Month.ToString() + '-' + localDate.Day.ToString();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO Carti (codCarte, isbn, titlu, autor, anAparitie, locAparitie, idEdituri, idGrupuri, idColectiiCarti, idLanguages, idDomenii, mentiuni, pret, dataAd, dataMod) VALUES ('" + textBox1.Text + "','" + textBox6.Text + "','" + textBox2.Text + "','" + textBox7.Text + "','" + textBox3.Text + "','" + textBox8.Text + "'," + Convert.ToInt32(ed) + "," + Convert.ToInt32(gr) + "," + Convert.ToInt32(col) + "," + Convert.ToInt32(lg) + "," + Convert.ToInt32(dom) + ",'" + textBox5.Text + "','" + textBox4.Text + "','" + aux + "','" + aux + "')";
                    cmd.Connection = mycon;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Cartea cu codul introdus există deja!");
                }
                mycon.Close();
            }
            this.cartiTableAdapter.Fill(this._CNLR_2015_2016DataSet.Carti);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Carti WHERE (codCarte) LIKE ('%" + textBox9.Text + "%')";
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
                    dataGridView1.Rows.Add(dgvr);
                }
                rd.Close();
                mycon.Close();
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Carti WHERE (titlu) LIKE ('%" + textBox12.Text + "%')";
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
                    dataGridView1.Rows.Add(dgvr);
                }
                rd.Close();
                mycon.Close();
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Carti WHERE (autor) LIKE ('%" + textBox13.Text + "%')";
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
                    dataGridView1.Rows.Add(dgvr);
                }
                rd.Close();
                mycon.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormHome.valform = 0;
            flang = new Languages();
            flang.ShowDialog();
            flang.Refresh();
            comboBox6.Text = Languages.lang;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string tString = textBox4.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Introduceţi un număr valid");
                    textBox2.Text = "";
                    return;
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string tString = textBox1.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Introduceţi un număr valid");
                    textBox2.Text = "";
                    return;
                }

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string tString = textBox1.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Introduceţi un număr valid");
                    textBox2.Text = "";
                    return;
                }

            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            string tString = textBox1.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Introduceţi un număr valid");
                    textBox2.Text = "";
                    return;
                }

            }
        }
    }
}
