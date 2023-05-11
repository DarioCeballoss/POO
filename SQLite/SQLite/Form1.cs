using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SQLite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Establecer el puntero a da DB
            SQLiteConnection cadenaConexion = new SQLiteConnection("Data Source = C:\\POO\\SQLite\\DB_Demo.db");
            // Abrir la DB
            cadenaConexion.Open();
            //Armar la consulta a realizar sobre la DB
            string consulta = "select * from personas";
            //Crear el comando
            SQLiteCommand comando = new SQLiteCommand(consulta, cadenaConexion);
            //Crear el objeto lector de datos que va a recivir el resultado
            SQLiteDataReader datos = comando.ExecuteReader();
            //Los datos deben ser guardados en el objeto de tipo tabla que pueda heredar la estructura del resultado
            DataTable tableresult = new DataTable();
            tableresult.Load(datos);
            // Agrego a la grilla el proveedor de los datos u origen de los mismos que en este caso sera el objeto DataTable
            dtg_tablaresultado.DataSource = tableresult;
            //Cierro la DB
            cadenaConexion.Close();
        }
    }
}
