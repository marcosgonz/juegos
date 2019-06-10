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
    public partial class Registrouser : Form
    {
        public Registrouser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            bbdd.conectar();
            bbdd.comando.CommandText = "INSERT INTO Usuario([nombre], [apellido], [fecha_nacimiento], [nombre_usuario], [contraseña]) VALUES (@nombre, @apellido, @fecha_nacimiento, @nombre_usuario, " +
                "@contraseña)";
            string fecha = dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year;
            int r = 0;
            bbdd.comando.Parameters.AddRange(new OleDbParameter[]
            {
                    new OleDbParameter("@nombre", textBox1.Text),
                    new OleDbParameter("@apellido", textBox2.Text),
                    new OleDbParameter("@fecha_nacimiento", fecha),
                    new OleDbParameter("@nombre_usuario", textBox3.Text),
                    new OleDbParameter("@contraseña", textBox4.Text)
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

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_alta_Click_1(object sender, EventArgs e)
        {

        }
    }
    }

