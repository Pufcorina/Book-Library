﻿using System;
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
using System.Data.Sql;

namespace Book_Library
{
    public partial class Languages : Form
    {
        private OleDbConnection mycon;
        int sh;
        public static string lang;

        public Languages()
        {
            InitializeComponent();
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\CNLR 2015-2016.mdb");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd1 = new OleDbCommand("SELECT COUNT(*) FROM Languages WHERE denumire = '" + textBox2.Text + "' ");
            mycon.Open();
            cmd1.Connection = mycon;                    
            int denumireCount = (int)cmd1.ExecuteScalar();
            if( denumireCount < 1 )
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO Languages (denumire) VALUES ('" + textBox2.Text + "')";
                cmd.Connection = mycon;
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Limba introdusă există deja!");
            }
            mycon.Close();
            this.languagesTableAdapter.Fill(this._CNLR_2015_2016DataSet.Languages);
        }

        private void Languages_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_CNLR_2015_2016DataSet.Languages' table. You can move, or remove it, as needed.
            this.languagesTableAdapter.Fill(this._CNLR_2015_2016DataSet.Languages);
            if (FormHome.valform == 1)
                button4.Enabled = false;
            FormHome.valform = 0;
            sh = 0;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int count;
            count = dataGridView1.SelectedRows.Count;
            if (count != 0)
            {
                OleDbCommand cmd1 = new OleDbCommand("DELETE FROM Languages WHERE id = " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "");
                cmd1.Connection = mycon;
                mycon.Open();
                cmd1.ExecuteNonQuery();
                languagesTableAdapter.Update(_CNLR_2015_2016DataSet.Languages);
                mycon.Close();
                this.languagesTableAdapter.Fill(this._CNLR_2015_2016DataSet.Languages);
                if (sh == 1)
                    MessageBox.Show("Rândul selectat a fost şters!");
            }
            else
                MessageBox.Show("Nu a fost selectat nici un rând.");
        }
            

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                OleDbCommand cmd1 = new OleDbCommand("SELECT COUNT(*) FROM Languages WHERE denumire = '" + textBox2.Text + "' ");
                mycon.Open();
                cmd1.Connection = mycon;
                int denumireCount = (int)cmd1.ExecuteScalar();
                if (denumireCount < 1)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO Languages (denumire) VALUES ('" + textBox2.Text + "')";
                    cmd.Connection = mycon;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Limba introdusa există deja!");
                }
                mycon.Close();
                this.languagesTableAdapter.Fill(this._CNLR_2015_2016DataSet.Languages);
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                sh = 1;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Languages WHERE (denumire) LIKE ('%" + toolStripTextBox1.Text + "%')";
                mycon.Open();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                cmd.Connection = mycon;
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.CreateCells(dataGridView1);
                    dgvr.Cells[0].Value = rd[1];
                    dgvr.Cells[1].Value = Convert.ToString(rd[0]);
                    dataGridView1.Rows.Add(dgvr);
                }
                rd.Close();
                mycon.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedCells[0].ColumnIndex;
            if (count == 0)
            {
                lang = dataGridView1.SelectedCells[0].Value.ToString();
            }
            else
                MessageBox.Show("Selectează campul cu denumire înainte de a apăsa butonul salvează!");
            if (count == 0)
                Close();
        }
    }
}
