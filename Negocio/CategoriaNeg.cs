using DAO;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNeg
    {
        private DataCategoria objDataCategoria;

        public CategoriaNeg(){
            objDataCategoria = new DataCategoria();
        }

        public List<Categoria> FindAll()
        {
            return objDataCategoria.findAll();

        }

        public void Create(Categoria objcategoria)
        {
            bool verificacion = true;
            string nombre = objcategoria.Nombre;
            if (nombre == null)
            {
                objcategoria.Estado = 10;
                return;
            }
            else
            {
                nombre = objcategoria.Nombre.Trim();
                verificacion = nombre.Length <= 30;
                if (!verificacion)
                {
                    objcategoria.Estado = 1;
                    return;
                }

            }

            string descripcion = objcategoria.Descripcion;
            if (descripcion == null)
            {
                objcategoria.Estado = 20;
                return;
            }
            else {
                descripcion = objcategoria.Descripcion.Trim();
                verificacion = descripcion.Length <= 250;
                if (!verificacion)
                {
                    objcategoria.Estado = 2;
                    return;
                }
            }

            Categoria categoriaaux = new Categoria();
            categoriaaux.Descripcion = objcategoria.Descripcion;
            verificacion = !objDataCategoria.BuscarCategoriaPorNombre(categoriaaux);
            if (!verificacion)
            {
                objcategoria.Estado = 3;
                return;
            }
            else
            {
                objcategoria.Estado = 99;
                objDataCategoria.create(objcategoria);
            }

        }

    }
}
