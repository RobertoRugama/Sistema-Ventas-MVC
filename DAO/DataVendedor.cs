using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DataVendedor : Obligatorio<Vendedor>
    {
        private ConexionDB objConexionBD;
        private SqlCommand comando;

        public DataVendedor()
        {
            objConexionBD = ConexionDB.saberEstado();
        }
        public void create(Vendedor objVendedor)
        {
            string create = "sp_vendedor_add " + objVendedor.Identificacion+ "," + objVendedor.P_nombre + "," + objVendedor.S_nombre + "," + objVendedor.P_apellido + "," +
                objVendedor.S_apellido + "," + objVendedor.Telefono +" ";
            try
            {
                comando = new SqlCommand(create, objConexionBD.getCon());
                objConexionBD.getCon().Open();
                comando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                if (ex.Message.Length>1)
                {
                    MessageBox.Show(ex.Message);
                    objVendedor.Estado = 1;
                }
                else
                {
                    MessageBox.Show("El Registro " + objVendedor.Identificacion + "Fue Guardado con Exito", "Informacion", MessageBoxButtons.OK);

                }
            }
            finally
            {
                objConexionBD.getCon().Close();
                objConexionBD.CloseDB();
            }
            
        }

        public void delete(Vendedor obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Vendedor objvendedor)
        {
            bool hayregistros;
            string find = "select * from vendedor where vendedor_id='" + objvendedor.VendedorID + "'";
            try
            {
                comando = new SqlCommand(find, objConexionBD.getCon());
                objConexionBD.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayregistros = reader.Read();
                if (hayregistros)
                {
                    objvendedor.Identificacion = reader[1].ToString();
                    objvendedor.P_nombre = reader[2].ToString();
                    objvendedor.S_nombre = reader[3].ToString();
                    objvendedor.P_apellido = reader[4].ToString();
                    objvendedor.S_apellido = reader[5].ToString();
                    objvendedor.Telefono = reader[6].ToString();
                    objvendedor.Estado = 99;

                }
                else
                {
                    objvendedor.Estado = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexionBD.getCon().Close();
                objConexionBD.CloseDB();
            }
            return hayregistros;
        }
        public bool findVendedorPorDNI(Vendedor objVendedor)
        {
            bool hayregistros;
            string find = "select * from vendedor where identificacion='"+objVendedor.Identificacion+"'";
            try
            {
                comando = new SqlCommand(find, objConexionBD.getCon());
                objConexionBD.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayregistros = reader.Read();
                if (hayregistros)
                {
                    objVendedor.Identificacion = reader[1].ToString();
                    objVendedor.P_nombre = reader[2].ToString();
                    objVendedor.S_nombre = reader[3].ToString();
                    objVendedor.P_apellido = reader[4].ToString();
                    objVendedor.S_apellido = reader[5].ToString();
                    objVendedor.Telefono = reader[6].ToString();
                    objVendedor.Estado = 99;
                }
                else
                {
                    objVendedor.Estado = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexionBD.getCon().Close();
                objConexionBD.CloseDB();
            }
            return hayregistros;
            
        }

        public List<Vendedor> findAll()
        {
            List<Vendedor> listarVendedores = new List<Vendedor>();
            string findAll = "Select * from Vendedor order by p_nombre asc";
            try
            {
                comando = new SqlCommand(findAll, objConexionBD.getCon());
                objConexionBD.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Vendedor objVendedor = new Vendedor();
                    objVendedor.Identificacion = reader[1].ToString();
                    objVendedor.P_nombre = reader[2].ToString();
                    objVendedor.S_nombre = reader[3].ToString();
                    objVendedor.P_apellido = reader[4].ToString();
                    objVendedor.S_apellido = reader[5].ToString();
                    objVendedor.Telefono = reader[6].ToString();
                    listarVendedores.Add(objVendedor);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objConexionBD.getCon().Close();
                objConexionBD.CloseDB();
            }
            return listarVendedores;
        }

        public void update(Vendedor obj)
        {
            throw new NotImplementedException();
        }
    }
}
