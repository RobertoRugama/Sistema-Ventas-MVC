using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataCliente: Obligatorio<Cliente>
    {
        private ConexionDB objConexionDB;
        private SqlCommand comando;

        public DataCliente()
        {
            objConexionDB = ConexionDB.saberEstado();
        }

        public void create(Cliente obj)
        {
            string create = "sp_cliente_adc" + obj.Identificacion + "," + obj.P_nombre + "," + obj.S_nombre + "," + obj.P_apellido + "," + obj.S_apellido +
                "," + obj.Direccion + "," + obj.Telefono + "";
            try
            {
                comando = new SqlCommand(create, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objConexionDB.getCon().Close();
                objConexionDB.CloseDB();
            }
        }

        public void Create1(Cliente objCliente)
        {
            string create = "insert clientes values ('"+objCliente.Identificacion+
                "','"+objCliente.P_nombre+"','"+objCliente.S_nombre+"','"+objCliente.P_apellido+"','"+objCliente.S_apellido+
                "','"+objCliente.Direccion+"','"+objCliente.Telefono+"')";
            try
            {
                comando = new SqlCommand(create, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                objCliente.Estado = 1;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.CloseDB();
            }
        }

        public void delete(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Cliente objCliente)
        {
            bool hayRegistros;
            string find = "select * from Clientes where cliente_ID='" + objCliente.ClienteId + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                //bool Hay Registros
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objCliente.Identificacion = reader[1].ToString();
                    objCliente.P_nombre = reader[2].ToString();
                    objCliente.S_nombre = reader[3].ToString();
                    objCliente.P_apellido = reader[4].ToString();
                    objCliente.S_apellido = reader[5].ToString();
                    objCliente.Direccion = reader[6].ToString();
                    objCliente.Telefono = reader[7].ToString();
                    objCliente.Estado = 99;
                }
                else
                {
                    objCliente.Estado = 1;
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
            return hayRegistros;
        }

        public List<Cliente> findAll()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "select * from Clientes order by P_nombre asc";
            try
            {
                comando = new SqlCommand(findAll, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                SqlDataReader reader;
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.Identificacion = reader[1].ToString();
                    objCliente.P_nombre = reader[2].ToString();
                    objCliente.S_nombre = reader[3].ToString();
                    objCliente.P_apellido = reader[4].ToString();
                    objCliente.S_apellido = reader[5].ToString();
                    objCliente.Direccion = reader[6].ToString();
                    objCliente.Telefono = reader[7].ToString();
                    listaClientes.Add(objCliente);
                    
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.CloseDB();
            }
            return listaClientes.ToList();
        }

        public void update(Cliente obj)
        {
            throw new NotImplementedException();
        }



        public bool findClientePorDNI(Cliente objCliente)
        {
            bool hayRegistros;
            string find = "select * from Clientes where idetificacion ='" + objCliente.Identificacion + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                //bool hayregistros;
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objCliente.Identificacion = reader[1].ToString();
                    objCliente.P_nombre = reader[2].ToString();
                    objCliente.S_nombre = reader[3].ToString();
                    objCliente.P_apellido = reader[4].ToString();
                    objCliente.S_apellido = reader[5].ToString();
                    objCliente.Direccion = reader[6].ToString();
                    objCliente.Telefono = reader[7].ToString();
                    objCliente.Estado = 99;
                }
                else
                {
                    objCliente.Estado = 1;
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
            return hayRegistros;
        }
    }
}
