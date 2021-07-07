using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class MetodoPago
    {
        public int MetodoPagoId { get; set; }
        public  string Descripcion { get; set; }
        public string Otros { get; set; }
        public int Estado { get; set; }

        public MetodoPago()
        {

        }
        public MetodoPago(int metodoPagoId)
        {
            this.MetodoPagoId = metodoPagoId;
        }
        public MetodoPago(int metodopagoId, string descripcion, string otros)
        {
            this.MetodoPagoId = metodopagoId;
            this.Descripcion = descripcion;
            this.Otros = otros;

        }
    }
}
