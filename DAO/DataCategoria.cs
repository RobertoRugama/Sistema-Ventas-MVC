using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataCategoria : Obligatorio<Categoria>
    {
        private ConexionDB objConexionDB;
        private SqlCommand comand;

        public DataCategoria() {
            objConexionDB = ConexionDB.saberEstado();
           
        }


        public void create(Categoria objCategoria)
        {
            string create = "sp_categoria_add "+ "'"+objCategoria.Nombre+"',"+"'"+objCategoria.Descripcion+"'";
            try
            {
                comand = new SqlCommand(create, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally{
                objConexionDB.getCon().Close();
                objConexionDB.CloseDB();
            }

        }

        public void delete(Categoria obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Categoria obj)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> findAll()
        {
            List<Categoria> listar = new List<Categoria>();
            string findAll = "select * from categoria with(nolock) order by 1 desc";
            try
            {
                comand = new SqlCommand(findAll, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Categoria objcategoria = new Categoria();
                    objcategoria.Nombre = reader[1].ToString();
                    objcategoria.Descripcion = reader[2].ToString();
                    listar.Add(objcategoria);
                }
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            finally {
                objConexionDB.getCon().Close();
                objConexionDB.CloseDB();
            }
            return listar;
        }

        public void update(Categoria obj)
        {
            throw new NotImplementedException();
        }

        public bool BuscarCategoriaPorNombre(Categoria objCategoria)
        {
            bool hayregistro;
            string find = "select * from categoria where nombre = '"+ objCategoria.Nombre + "'";
            try
            {
                comand = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                SqlDataReader reader = comand.ExecuteReader();
                hayregistro = reader.Read();
                if (hayregistro)
                {

                    objCategoria.Nombre = reader[1].ToString();
                    objCategoria.Descripcion = reader[2].ToString();
                    objCategoria.Estado = 99;

                }
                else
                {
                    objCategoria.Estado = 1;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.CloseDB();
            }
            return hayregistro;

        }
    }
}
