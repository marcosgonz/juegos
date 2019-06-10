using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Juegos
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agregarNuevoJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrojuego form = new Registrojuego();

            form.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 form = new AboutBox1();

            form.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            cargardatos();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vistajuego form = new Vistajuego();

            form.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    var item = listView1.Items[i];
                    if (item.Text.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        item.BackColor = SystemColors.Highlight;
                        item.ForeColor = SystemColors.HighlightText;
                    }
                    else
                    {
                        listView1.Items.Remove(item);
                    }
                }
                if (listView1.SelectedItems.Count == 1)
                {
                    listView1.Focus();
                }
            }
            else
                cargardatos();
        }

        public void cargardatos()
        {

         
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../Resources/Gestion_videojuegos.accdb");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select nombre,genero from Juegos", con);

            OleDbDataReader lectura = cmd.ExecuteReader();
            while (lectura.Read())
            {
                ListViewItem item = new ListViewItem(lectura[0].ToString());

                item.SubItems.Add(lectura[1].ToString());
                listView1.Items.Add(item);
               
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                listView1.Clear();
                string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
        
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../Resources/Gestion_videojuegos.accdb");
                con.Open();

                OleDbCommand cmd = new OleDbCommand("select nombre,genero from Juegos where genero= '"+selected+"'", con);

                OleDbDataReader lectura = cmd.ExecuteReader();
                while (lectura.Read())
                {
                    ListViewItem item = new ListViewItem(lectura[0].ToString());

                    item.SubItems.Add(lectura[1].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
        }
    }


    }

