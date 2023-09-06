using System.Configuration;
using System.Data.OleDb;

namespace Datos.Conexiones
{
    public class Conexion
    {
        public string ConnectionString => ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

        private static OleDbConnection ConexionConBD;
        private static OleDbCommand Orden;
        private static OleDbDataReader Lector;

        //PROPIEDAD---------------------------------------------------------------------
        public OleDbDataReader Leer
        {
            get
            {
                return Lector;
            }
        }

        //METODOS-----------------------------------------------------------------------
        public bool IniciarLector(string Consulta)
        {
            if (ConexionEstado() == true)
            {
                try
                {
                    Orden = new OleDbCommand(Consulta, ConexionConBD);
                    Lector = Orden.ExecuteReader();
                    return true;
                }
                catch
                {
                    CerrarConexion();
                }
            }
            return false;
        }
        public bool Guardar(string Consulta)
        {
            if (ConexionEstado() == true)
            {
                try
                {
                    Orden = new OleDbCommand(Consulta, ConexionConBD);
                    Orden.ExecuteNonQuery();
                    CerrarConexion();
                    return true;
                }
                catch
                {
                    CerrarConexion();
                }
            }
            return false;
        }
        public void CerrarConexion()
        {
            if (Lector != null) Lector.Close();
            if (ConexionConBD != null) ConexionConBD.Close();
        }

        //FUNCIONES---------------------------------------------------------------------
        private bool ConexionEstado()
        {
            try
            {
                ConexionConBD = new OleDbConnection(ConnectionString);
                ConexionConBD.Open();
                return true;
            }
            catch
            {
                CerrarConexion();
                return false;
            }
        }
    }
}
