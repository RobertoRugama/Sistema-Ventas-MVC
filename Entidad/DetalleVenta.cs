using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }
        public int FacturaId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Descuento { get; set; }
        public int Cantidad { get; set; }
        public decimal  Subtotal { get; set; }

        public DetalleVenta()
        {

        }
        public DetalleVenta(int detalleventaId)
        {
            this.DetalleVentaId = detalleventaId;
        }
        public DetalleVenta(int detalleventaId, int factuaId, int ventaId, int productoId, decimal descuento,int catidad,decimal subtotal)
        {
            this.DetalleVentaId = detalleventaId;
            this.FacturaId = factuaId;
            this.VentaId = ventaId;
            this.ProductoId = productoId;
            this.Descuento = descuento;
            this.Cantidad = catidad;
            this.Subtotal = subtotal;
        }
    }

}
