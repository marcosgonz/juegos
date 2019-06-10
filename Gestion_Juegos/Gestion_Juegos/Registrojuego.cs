using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Juegos
{
    public partial class Registrojuego : Form
    {
        public Registrojuego()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bbdd.conectar();
            bbdd.comando.CommandText = "INSERT INTO Juegos([nombre], [genero], [ruta_imagen]) VALUES (@nombre, @genero, @ruta_imagen)";
            string ruta = pictureBox1.ImageLocation;
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            int r = 0;
            bbdd.comando.Parameters.AddRange(new OleDbParameter[]
            {
                    new OleDbParameter("@nombre", textBox1.Text),
                    new OleDbParameter("@genero", selected),
                    new OleDbParameter("@ruta_imagen", ruta)
            });

            r = bbdd.comando.ExecuteNonQuery();

            if (r > 0)
            {
                MessageBox.Show("Insertado correctamente");
            }
            else
            {
                MessageBox.Show("Error al insertar");
            }
            bbdd.desconectar();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files(*.jpg;*.png;)|*.jpg;*.png;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(@"../../Resources/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
