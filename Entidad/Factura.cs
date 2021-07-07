using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public int MetodoPagoId { get; set; }
        public DateTime Fecha { get; set; }
        public float Iva { get; set; }
        public double Total { get; set; }
        public int Estado { get; set; }

        public Factura()
        {

        }
        public Factura(int facturaId)
        {
            this.FacturaId = facturaId;
        }
        public Factura(int facturaId,int metodopagoId, DateTime fecha, float iva, double total)
        {
            this.FacturaId = facturaId;
            this.MetodoPagoId = metodopagoId;
            this.Fecha = fecha;
            this.Iva = iva;
            this.Total = total;

        }
    }

}
