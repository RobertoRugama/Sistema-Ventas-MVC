using DAO;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoNeg
    {
        private DataProducto objdataProductos;

        public ProductoNeg()
        {
            objdataProductos = new DataProducto();
        }

        public List<Producto> FindAll()
        {
            return objdataProductos.findAll();
        }

        public void Create(Producto objproducto)
        {
            bool verificacion = true;
            // Begin Valida Identificacion si es OK Retorna Estado = 1 si no retorna 10
            int CategoriaId = objproducto.CategoriaId;
            if (CategoriaId.Equals(""))
            {
                objproducto.Estado = 10;
                return;

            }
            else
            {
                CategoriaId = objproducto.CategoriaId;
                verificacion = CategoriaId > 0;
                if (!verificacion)
                {
                    objproducto.Estado = 1;
                    return;
                }
             
            }
            //End Validar Categoria.

            // BEgin Validar Nombre producto si es OK retorna estado 1 si no estado 20
            string Nombre = objproducto.Nombre;
            if (Nombre == null)
            {
                objproducto.Estado = 20;
                return;
            }
            else
            {
                Nombre = objproducto.Nombre;
                verificacion = Nombre.Length > 0 && Nombre.Length <= 50;
                if (!verificacion)
                {
                    objproducto.Estado = 1;
                    return;
                }
            }
            //End Validar Nombre Producto

            // Begin Valida Monto de precio unitario si es OK retorna 3 si no retorna 30
            float PrecioUnitario = objproducto.PrecioUnitario;
            if (PrecioUnitario.Equals(""))
            {
                objproducto.Estado = 30;
                return;
            }
            else
            {
                PrecioUnitario = objproducto.PrecioUnitario;
                verificacion = PrecioUnitario > 0;
                if (!verificacion)
                {
                    objproducto.Estado = 3;
                    return;

                }                             
            }
            //end Valida monto

            //Validar Producto Duplicado
            Producto prod1 = new Producto();
            prod1.Nombre = objproducto.Nombre;
            verificacion = !objdataProductos.FindProductNombre(prod1);
            if (!verificacion)
            {
                objproducto.Estado = 4;
                return;
            }
            //End Validar Duplicidad

            //si no hay Error
            objproducto.Estado = 99;
            objdataProductos.create(objproducto);
            return;
            
        }
    }
}
