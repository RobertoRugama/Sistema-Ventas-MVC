using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProducto:Obligatorio<Producto>
    {
        private ConexionDB objConexionDB;
        SqlCommand comando;

        public DataProducto(){
            objConexionDB =  ConexionDB.saberEstado();
        }

        public void create(Producto obj)
        {
            string query = "sp_producto_add " + "'" + obj.CategoriaId + "','" + obj.Nombre + "','" + obj.PrecioUnitario + "'";
            try
            {
                comando = new SqlCommand(query, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.CloseDB();
            }
        }

        public void delete(Producto obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Producto obj)
        {
            throw new NotImplementedException();
        }

        public List<Producto> findAll()
        {
            List<Producto> ListaProducto = new List<Producto>();
            string query = "select top 10 * from productos with(nolock) order by 1 desc";
            try
            {
                comando = new SqlCommand(query, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Producto prod = new Producto();
                    prod.CategoriaId = Convert.ToInt32(reader[1].ToString());
                    prod.Nombre = reader[2].ToString();
                    prod.PrecioUnitario = Convert.ToInt32(reader[3].ToString());
                    ListaProducto.Add(prod);

                }
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.CloseDB();
            }
            return ListaProducto;
        }

        public void update(Producto obj)
        {
            throw new NotImplementedException();
        }

        public bool FindProductNombre(Producto obj)
        {
            bool HayRegistros;
            string query = "select top 10 * from Productos where nombre = '" + obj.Nombre + "'";
            try
            {
                comando = new SqlCommand(query, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                // bool hayRegistro.
                SqlDataReader reader = comando.ExecuteReader();
                HayRegistros = reader.Read();
                if (HayRegistros)
                {
                    obj.CategoriaId = Convert.ToInt32(reader[1].ToString());
                    obj.Nombre = reader[2].ToString();
                    obj.PrecioUnitario = Convert.ToInt32(reader[3].ToString());
                    obj.Estado = 99;
                }
                else
                {
                    obj.Estado = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.CloseDB();
            }
            return HayRegistros;
        }
    }
}
