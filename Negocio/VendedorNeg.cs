using DAO;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VendedorNeg
    {
        private DataVendedor objdataVendedor;

        public VendedorNeg()
        {
            objdataVendedor = new DataVendedor();
        }

        public List<Vendedor> FindAll()
        {
            return objdataVendedor.findAll();
        }

        public void create(Vendedor objVendedor)
        {
            bool verificacion = true;

            string identificacion = objVendedor.Identificacion;
            if (identificacion == null)
            {
                objVendedor.Estado = 10;
                return;
            }
            else
            {
                identificacion = objVendedor.Identificacion.Trim();
                verificacion = identificacion.Length <= 16 && identificacion.Length > 0;
                if (!verificacion)
                {
                    objVendedor.Estado = 1;
                    return;
                }
            }

            string primerNombre = objVendedor.P_nombre;
            if (primerNombre == null)
            {
                objVendedor.Estado = 20;
                return;
            }
            else
            {
                primerNombre = objVendedor.P_nombre.Trim();
                verificacion = primerNombre.Length <= 30 && primerNombre.Length > 0;
                if (!verificacion)
                {
                    objVendedor.Estado = 2;
                    return;
                }
            }

            string segundoNombre = objVendedor.S_nombre;
            if (segundoNombre != null)
            {
                segundoNombre = objVendedor.S_nombre.Trim();
                verificacion = segundoNombre.Length <= 30 && segundoNombre.Length > 0;
                if (!verificacion)
                {
                    objVendedor.Estado = 3;
                    return;
                }
            }

            string primerApellido = objVendedor.P_apellido;
            if (primerApellido == null)
            {
                objVendedor.Estado = 40;
                return;
            }
            else
            {
                primerApellido = objVendedor.P_apellido.Trim();
                verificacion = primerApellido.Length <= 30 && primerApellido.Length > 0;
                if (!verificacion)
                {
                    objVendedor.Estado = 4;
                    return;
                }

            }

            string segundoApellido = objVendedor.S_apellido;
            if (segundoApellido != null)
            {
                segundoApellido = objVendedor.S_apellido.Trim();
                verificacion = segundoApellido.Length <= 30 && segundoApellido.Length > 0;
                if (!verificacion)
                {
                    objVendedor.Estado = 5;
                    return;
                }
            }

            string telefono = objVendedor.Telefono;
            if (telefono == null)
            {
                objVendedor.Estado = 60;
                return;
            }
            else
            {
                telefono = objVendedor.Telefono.Trim();
                verificacion = telefono.Length <= 30 && telefono.Length > 0;
                if (!verificacion)
                {
                    objVendedor.Estado = 6;
                    return;
                }
            }

            Vendedor objVendedorAux = new Vendedor();
            objVendedorAux.VendedorID = objVendedor.VendedorID;
            verificacion = !objdataVendedor.find(objVendedorAux);
            if (!verificacion)
            {
                objVendedor.Estado = 7;
                return;
            }

            Vendedor objVendedorAux1 = new Vendedor();
            objVendedorAux1.Identificacion = objVendedor.Identificacion;
            verificacion = !objdataVendedor.findVendedorPorDNI(objVendedorAux1);
            if (!verificacion)
            {
                objVendedor.Estado = 8;
                return;
            }

            objVendedor.Estado = 99;
            objdataVendedor.create(objVendedor);



        }
    }
}
   
