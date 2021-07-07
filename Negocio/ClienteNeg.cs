using DAO;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Negocio
{
    public class ClienteNeg
    {
        private DataCliente objDataCliente;

        public ClienteNeg()
        {
            objDataCliente = new DataCliente();
        }
        public List<Cliente> FindALL()
        {
            return objDataCliente.findAll();
        }
        public void create(Cliente objCliente)
        {
            bool verificacion = true;

            //Begin Valida Identificacion Retorna Estado =1
            string identificacion = objCliente.Identificacion;
            if (identificacion==null)
            {
                objCliente.Estado = 10;
                return;
            }
            else
            {
                identificacion = objCliente.Identificacion.Trim();
                verificacion = identificacion.Length <= 16 && identificacion.Length > 0;
                if (!verificacion)
                {
                    objCliente.Estado = 1;
                    return;
                }
            }
            //end Validar Identificacion.


            //Begin Validar Nombre Retorna estado =2
            string pnombre = objCliente.P_nombre;
            if (pnombre==null)
            {
                objCliente.Estado = 20;
                return;
            }
            else
            {
                pnombre = objCliente.P_nombre.Trim();
                verificacion = pnombre.Length <= 30 && pnombre.Length > 0;
                if (!verificacion)
                {
                    objCliente.Estado = 2;
                    return;
                }
            }
            //end validar nombre

            //Begin Valida Segundo Nombre Retorna estado =3
            string snombre = objCliente.S_nombre;

            if (snombre != null)
            {
                snombre = objCliente.S_nombre.Trim();
                verificacion = snombre.Length <= 30 && snombre.Length > 0;
                if (!verificacion)
                {
                    objCliente.Estado = 3;
                    return;
                }
            }

            //end Valida Segundo Nombre

            //Begin Valida Primer Apellido  Retorna estado =  4
            string papellido = objCliente.P_apellido;
            if (papellido == null)
            {
                objCliente.Estado = 40;
                return;
            }
            else
            {
                papellido = objCliente.P_apellido.Trim();
                verificacion = papellido.Length <= 30 && papellido.Length > 0;
                if (!verificacion)
                {
                    objCliente.Estado = 4;
                    return;
                }
            }
            //end Valida Primer Apellido

            //Begin Valida Segundo Apellido  Retorna estado =  5
            string sapellido = objCliente.S_apellido;
            if (sapellido != null)
            {
                sapellido = objCliente.S_apellido.Trim();
                verificacion = sapellido.Length <= 30 && sapellido.Length > 0;
                if (!verificacion)
                {
                    objCliente.Estado = 5;
                    return;
                }
            }

            //end Valida Segundo Apellido

            //Begin Valida Direccion Retorna estado =  6
            string direccion = objCliente.Direccion;
            if (direccion == null)
            {
                objCliente.Estado = 60;
                return;
            }
            else
            {
                direccion = objCliente.Direccion.Trim();
                verificacion = direccion.Length <= 250 && direccion.Length > 0;
                if (!verificacion)
                {
                    objCliente.Estado = 6;
                    return;
                }
            }
            //end Valida Direccion

            //Begin Valida Telefono Retorna estado =  7
            string telefono = objCliente.Telefono;
            if (telefono == null)
            {
                objCliente.Estado = 70;
                return;
            }
            else
            {
                telefono = objCliente.Telefono.Trim();
                verificacion = telefono.Length <= 15 && telefono.Length > 0;
                if (!verificacion)
                {
                    objCliente.Estado = 7;
                    return;
                }
            }
            //end Valida Telefono

            //Veficar Duplicidad por clienteId Retorna Estado =8;
            Cliente objClienteAux = new Cliente();
            objClienteAux.ClienteId = objCliente.ClienteId;
            verificacion = !objDataCliente.find(objClienteAux);
            if (!verificacion)
            {
                objCliente.Estado = 8;
                return;
            }
            //end Valida Duplicidad por ClienteId

            //Veficar Duplicidad por identicacion Retorna Estado =8;
            Cliente objClienteAux1 = new Cliente();
            objClienteAux1.Identificacion = objCliente.Identificacion;
            verificacion = !objDataCliente.findClientePorDNI(objClienteAux1);
            if (!verificacion)
            {
                objCliente.Estado = 8;
                return;
            }
            //end Valida Duplicidad por identificacion

            //Si no hay error 
            objCliente.Estado = 99;
            objDataCliente.Create1(objCliente);
            return;
        }

    }
}
