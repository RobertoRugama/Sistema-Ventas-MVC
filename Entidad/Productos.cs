using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public float PrecioUnitario { get; set; }
        public int Estado { get; set; }

        public Producto()
        {

        }
        public Producto(int productoId)
        {
            this.ProductoId = productoId;
        }
        public Producto(int productoId, int categoriaId, string nombre, float precioUnitario)
        {
            this.ProductoId = productoId;
            this.CategoriaId = categoriaId;
            this.Nombre = nombre;
            this.PrecioUnitario = precioUnitario;
        
        }
    }
}
