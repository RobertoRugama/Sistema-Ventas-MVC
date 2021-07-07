using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitemaVenta.Controllers
{
    public class ClienteController: Controller
    {
        ClienteNeg objClienteNeg;

        public ClienteController()
        {
            objClienteNeg = new ClienteNeg();

        }
        //GET : Cliente
        public ActionResult Index()
        {
            List<Cliente> lista = objClienteNeg.FindALL();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Create()
        {
            mensajeInicioRegistrar();
            return View();
        }

        [HttpPost]
        public ActionResult Create( Cliente objCliente)
        {
            ModelState.Clear();
            mensajeInicioRegistrar();
            objClienteNeg.create(objCliente);
            mensajeErrorRegistrar(objCliente);
            return View("Create");
        }

        public void mensajeErrorRegistrar(Cliente objCliente)
        {
            switch (objCliente.Estado)
            {
                case 10://campo vacio
                    ViewBag.mensajeError = "Ingrese la Identicacion del cliente";
                    break;
                case 1://Error Identificacion
                    ViewBag.mensajeError = "No se permite mas de 16 caracteres en el Campo Identificacion";
                    break;
                case 20://campo vacio Primer Nombre
                    ViewBag.mensajeError = "Ingrese Primer Nombre del cliente";
                    break;
                case 2:// Error Primer Nombre
                    ViewBag.mensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;
                //case 30:// campo Segundo Nombre
                //    ViewBag.mensajeError = "Ingrese Segundo Nombre del cliente";
                //    break;
                case 3:// Error Segundo Nombre 
                    ViewBag.mensajeError = "No se permite mas de 30 caracteres en el campo Segundo Nombre";
                    break;
                case 40:// Campo Primer Apellido
                    ViewBag.mensajeError = "Ingrese Primer Apellido del cliente";
                    break;
                case 4:// Error Primer Apellido
                    ViewBag.mensajeError = "No se permite mas de 30 caracteres en campo Primer Apellido";
                    break;
                //case 50:// Campo Segundo Apellido
                //    ViewBag.mensajeError = "Ingrese Segundo Apellido del cliente";
                //    break;
                case 5:// Campo Segundo Apellido
                    ViewBag.mensajeError = "No se permite mas de 30 caracteres en el campo Segundo Apellido";
                    break;
                case 60:// Campo Direccion
                    ViewBag.mensajeError = "Ingrese la Direccion del cliente";
                    break;
                case 6:// Error Direccion
                    ViewBag.mensajeError = "No se permite mas de 250 caracteres en el campo Direccion";
                    break;
                case 70:// Campo Telefono
                    ViewBag.mensajeError = "Ingrese Numero de Telefono del cliente";
                    break;
                case 7:// Error Telefono
                    ViewBag.mensajeError = "No se premite mas de 15 caracteres en el campo Telefono";
                    break;
                case 8://Error en duplicidad
                    ViewBag.MensajeError = "Cliente [" + objCliente.ClienteId + "] ya esta Registrado en el sistema";
                    break;
                case 9:
                    ViewBag.mensajeError = "Numero de Identificacion [" + objCliente.Identificacion + "] ya esta Asignado a un cliente";
                    break;
                case 99:
                    ViewBag.mensajeError = "Cliente [" + objCliente.P_nombre + " " + objCliente.P_apellido + "] fue registrado en el Sistema";
                    break;
            }
        }

        public void mensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos del Cliente y click en Guardar";
        }
    }
}