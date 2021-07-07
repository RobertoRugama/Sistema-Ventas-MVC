using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ConexionDB
    {
        private static ConexionDB objConexionDB = null;
        private SqlConnection con;

        private ConexionDB()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        }

        public static ConexionDB saberEstado()
        {
            if (objConexionDB == null)
            {
                objConexionDB = new ConexionDB();
            }
            return objConexionDB;
        }
        public SqlConnection getCon()
        {
            return con;
        }
        public void CloseDB()
        {
            objConexionDB = null;
        }
    }
}
