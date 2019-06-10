using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Juegos
{

    /// <summary>
    /// Clase para acceder a todos los métodos y propiedades de la base de datos
    /// </summary>
    class bbdd
    {

        public static string strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../Resources/Gestion_videojuegos.accdb";
        public static OleDbConnection connection = new OleDbConnection();
        public static OleDbDataAdapter adapteruser;
        public static OleDbDataAdapter adapterjuegos;
        public static DataSet datasetDB = new DataSet();
        public static DataView dataviewjuegos;
        public static OleDbCommand comando = new OleDbCommand("", connection);
        public static OleDbDataReader datareader;
        public static BindingSource bindingReservas = new BindingSource();

        public static void cargarDatos()
        {
            conectar();
            adapteruser = new OleDbDataAdapter("SELECT * FROM Usuario", connection);
            adapteruser.Fill(datasetDB, "Usuario");
            adapterjuegos = new OleDbDataAdapter("SELECT * FROM Juegos", connection);
            adapterjuegos.Fill(datasetDB, "Juegos");
            dataviewjuegos = new DataView(datasetDB.Tables["Juegos"]);
            bindingReservas.DataSource = dataviewjuegos;
            desconectar();
        }

        public static void conectar()
        {
            try
            {
                connection.ConnectionString = strConnection;
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void desconectar()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
    

