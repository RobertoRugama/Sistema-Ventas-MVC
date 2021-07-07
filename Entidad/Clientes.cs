using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cliente
    {
        [Display(Name = "Codigo de Cliente")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name ="Numero de identificacion")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage ="Este campo es requerido")]
        [Display(Name ="Primer Nombre")]
        public string P_nombre { get; set; }
        [Display(Name = "Segundo Nombre")]
        public string S_nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Primer Apellido")]
        public string P_apellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public  string S_apellido { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public List<Venta> Ventas { get; set; }
        public int Estado { get; set; }

        public Cliente()
        {

        }

        public Cliente(int ClienteId)
        {
            this.ClienteId = ClienteId;
        }
        public Cliente(int clienteId, string Identificacion, string P_nombre, string S_nombre, string P_apellido, string S_apellido, string Direccion, string telefono)
        {
            this.ClienteId = clienteId;
            this.Identificacion = Identificacion;
            this.P_nombre = P_nombre;
            this.S_nombre = S_nombre;
            this.P_apellido = P_apellido;
            this.S_apellido = S_apellido;
            this.Direccion = Direccion;
            this.Telefono = telefono;


        }
    }

}
