using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Categoria
    {

        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public Categoria()
        {

        }
        public Categoria(int categoriaId)
        {
            this.CategoriaId = categoriaId;
        }
        public Categoria(int categoriaId,string nombre, string descripcion )
        {
            this.CategoriaId = categoriaId;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }
    }
}
