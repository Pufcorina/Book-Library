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
    public partial class AddClient : Form
    {
        private GroupsClients fgrclienti;
        private OleDbConnection mycon;

        public AddClient()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHome.valform = 0;
            fgrclienti = new GroupsClients();
            fgrclienti.ShowDialog();
            fgrclienti.Refresh();
            comboBox3.Text = GroupsClients.grcl;
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\CNLR 2015-2016.mdb");
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.Clienti' table. You can move, or remove it, as needed.
            this.clientiTableAdapter.Fill(this._CNLR_2015_2016DataSet.Clienti);
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.GrupuriClienti' table. You can move, or remove it, as needed.
            this.grupuriClientiTableAdapter.Fill(this._CNLR_2015_2016DataSet.GrupuriClienti);
            if (FormHome.valform == 1)
                button4.Enabled = false;
            else
                button2.Enabled = false;
            FormHome.valform = 0;
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox13.Clear();
            textBox15.Clear();
            textBox12.Clear();
            comboBox3.Text = "";
            checkBox1.Checked = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Clienti WHERE (nume) LIKE ('%" + textBox14.Text + "%')";
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
                    dataGridView1.Rows.Add(dgvr);
                }
                rd.Close();
                mycon.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Clienti WHERE (activ) LIKE ('%" + textBox1.Text + "%')";
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
                    dataGridView1.Rows.Add(dgvr);
                }
                rd.Close();
                mycon.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // butonul adauga
            if (textBox4.Text == "" || textBox5.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("Nu aţi completat câmpurile obligatorii : Nume, Prenume şi Grupul");
            }
            else
            {
                mycon.Open();
                string gr;
                //Grupul
                OleDbCommand cmdgr = new OleDbCommand();
                cmdgr.CommandType = CommandType.Text;
                cmdgr.CommandText = @"SELECT * FROM GrupuriClienti WHERE (denumire = '" + comboBox3.Text + "')";
                cmdgr.Connection = mycon;
                OleDbDataReader rdgr = cmdgr.ExecuteReader();
                rdgr.Read();
                gr = Convert.ToString(rdgr[0]);
                rdgr.Close();
                //Adauga in baza de date
                OleDbCommand cmd1 = new OleDbCommand("SELECT COUNT(*) FROM Clienti WHERE (nume = '" + textBox4.Text + "' AND prenume = '" + textBox5.Text + "' AND id_Grupuri_Clienti = " + Convert.ToInt32(gr) + ")");
                cmd1.Connection = mycon;
                int count1 = (int)cmd1.ExecuteScalar();

                int totcl;
                string totcl2;
                totcl = dataGridView1.Rows.Count;
                totcl -= 1;
                totcl2 = Convert.ToString(dataGridView1.Rows[totcl].Cells[2].Value);

                if (count1 < 1 )
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    int acti = 1;
                    if ( checkBox1.Checked == false )
                    {
                        acti = 0;
                    }
                    DateTime localDate = DateTime.Now;
                    string aux = localDate.Year.ToString() + '-' + localDate.Month.ToString() + '-' + localDate.Day.ToString();
                    cmd.CommandText = @"INSERT INTO Clienti (nume, prenume, id_Grupuri_Clienti, activ, cnp, CI_Serie, ci, adresa, localitate, judet, telefon, email, mentiuni, dataInscrierii, Data_Mod) VALUES ('" + textBox4.Text + "','" + textBox5.Text + "'," + Convert.ToInt32(gr) + "," + acti + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox13.Text + "','" + textBox15.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" +Convert.ToDateTime(dateTimePicker1.Text) + "','" + aux + "')";
                    cmd.Connection = mycon;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Clientul introdus există deja!");
                }
                mycon.Close();
            }
            this.clientiTableAdapter.Fill(this._CNLR_2015_2016DataSet.Clienti);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string tString = textBox6.Text;
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string tString = textBox8.Text;
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
            string tString = textBox10.Text;
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
