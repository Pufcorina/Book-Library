using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.OleDb;

namespace Book_Library
{
    public partial class Loan : Form
    {
        private OleDbConnection mycon;
        private ClientsCatalogue fcatclient;
        private BooksCatalogue fcatbook;
        int idca, idcl;

        public Loan()
        {
            InitializeComponent();
        }

        private void Loan_Load(object sender, EventArgs e)
        {
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\CNLR 2015-2016.mdb");
            DateTime data = new DateTime();
            data = dateTimePicker1.Value;
            dateTimePicker1.Value = data.AddDays(14);
            label4.Text = Convert.ToString(dateTimePicker1.Text);
            FormHome.valform = 0;
            textBox2.Visible = false;

            label11.Text = "Client neselectat";
            label12.Text = "Client neselectat";
            label13.Text = "Client neselectat";
            label18.Text = "Carte neselectată";
            label19.Text = "Carte neselectată";
            label20.Text = "Carte neselectată";
            idca = 0;
            idcl = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormHome.valform = 0;
            fcatclient = new ClientsCatalogue();
            fcatclient.ShowDialog();

            idcl = ClientsCatalogue.idclient;
            if ( idcl != 0 )
            {
                mycon.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Clienti WHERE (id = " + idcl + ")";
                cmd.Connection = mycon;
                OleDbDataReader rd = cmd.ExecuteReader();
                rd.Read();
                label11.Text = Convert.ToString(rd[2]);
                label12.Text = Convert.ToString(rd[3]);
                //Grupul
                OleDbCommand cmdgr = new OleDbCommand();
                cmdgr.CommandType = CommandType.Text;
                cmdgr.CommandText = @"SELECT * FROM GrupuriClienti WHERE (id = " + Convert.ToInt32(rd[13]) + ")";
                cmdgr.Connection = mycon;
                OleDbDataReader rdgr = cmdgr.ExecuteReader();
                rdgr.Read();
                string gr = Convert.ToString(rdgr[1]);
                label13.Text = gr;
                rdgr.Close();
                rd.Close();
                mycon.Close();
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox2.Text = "";
                label4.Text = "";
                DateTime localDate = DateTime.Now;
                label4.Text = localDate.ToString("dd/MM/yyyy");
                textBox2.Visible = true;
                dateTimePicker1.Visible = false;
            }
            else
            {
                dateTimePicker1.Visible = true;
                textBox2.Visible = false;
                DateTime data = new DateTime();
                DateTime localDate = DateTime.Now;
                dateTimePicker1.Value = localDate;
                data = dateTimePicker1.Value;
                dateTimePicker1.Value = data.AddDays(14);
                label4.Text = Convert.ToString(dateTimePicker1.Text);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            if (textBox2.Text == "")
                label4.Text = localDate.ToString("dd/MM/yyyy");
            string tString = textBox2.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Introduceţi un număr valid");
                    textBox2.Text = "";
                    return;
                }
                label4.Text = localDate.AddDays(Convert.ToInt32(textBox2.Text)).ToString("dd/MM/yyyy");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idcl == 0)
                MessageBox.Show("Nu aţi selectat clientul!");
            else
            {
                if(idca == 0)
                    MessageBox.Show("Nu aţi selectat cartea!");
                else
                {
                    DateTime localDate = DateTime.Now;
                    string aux = localDate.Year.ToString() + '-' + localDate.Month.ToString() + '-' + localDate.Day.ToString();
                    mycon.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = mycon;
                    cmd.CommandText = @"INSERT INTO Imprumuturi (idCarti, idClienti, dataImprumut, dataRestituire, mentiuni) VALUES (" + idca + "," + idcl + ",'" + aux + "','" + label4.Text + "','" + textBox1.Text + "')";
                    cmd.ExecuteNonQuery();
                    mycon.Close();
                    label11.Text = "Client neselectat";
                    label12.Text = "Client neselectat";
                    label13.Text = "Client neselectat";
                    label18.Text = "Carte neselectată";
                    label19.Text = "Carte neselectată";
                    label20.Text = "Carte neselectată";
                    idcl = 0;
                    idca = 0;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = Convert.ToString(dateTimePicker1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormHome.valform = 0;
            fcatbook = new BooksCatalogue();
            fcatbook.ShowDialog();

            idca = BooksCatalogue.idcarte;
            if(idca != 0)
            {
                mycon.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Carti WHERE (id = " + idca + ")";
                cmd.Connection = mycon;
                OleDbDataReader rd = cmd.ExecuteReader();
                rd.Read();
                label18.Text = Convert.ToString(rd[1]);
                label19.Text = Convert.ToString(rd[3]);
                label20.Text = Convert.ToString(rd[4]);
                rd.Close();
                mycon.Close();
            }
            
        }
    }
}
