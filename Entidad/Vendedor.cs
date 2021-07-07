using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Vendedor
    {
        [Display(Name = "Codigo de Vendedor")]
        public int VendedorID { get; set; }
        [Required(ErrorMessage ="Este campo es requerido")]
        [Display(Name ="Numero Identificacion")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Primer Nombre")]
        public string P_nombre { get; set; }
        [Display (Name ="Segundo Nombre")]
        public string S_nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Primer Apellido")]
        public string P_apellido { get; set; }
        [Display(Name ="Segundo Apellido")]
        public string S_apellido { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string  Telefono { get; set; }
        public int Estado { get; set; }

        public Vendedor()
        {

        }
        public Vendedor(int VendedorID)
        {
            this.VendedorID = VendedorID;
        }

        public Vendedor(int vendedorId, string identificacion, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string telefono)
        {
            this.VendedorID = vendedorId;
            this.Identificacion = identificacion;
            this.P_nombre = p_nombre;
            this.P_apellido = p_apellido;
            this.S_apellido = s_apellido;
            this.Telefono = telefono;
        }
    }
}
