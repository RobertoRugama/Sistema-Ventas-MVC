using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public DateTime Fecha { get; set; }
        public float Iva { get; set; }
        public decimal Comision { get; set; }
        public double  Total { get; set; }

        public Venta()
        {

        }
        public Venta(int ventaId)
        {
            this.VentaId = ventaId;
        
        }
        public Venta(int ventaid,int clienteid,int vendedorid, DateTime fecha, float iva, decimal comision,double total)
        {
            this.VentaId = ventaid;
            this.ClienteId = clienteid;
            this.VendedorId = vendedorid;
            this.Fecha = fecha;
            this.Iva = iva;
            this.Comision = comision;
            this.Total = total;
        }
    }
}
