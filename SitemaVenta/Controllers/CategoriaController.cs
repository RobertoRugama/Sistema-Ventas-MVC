using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitemaVenta.Controllers
{
    public class CategoriaController:Controller
    {
        CategoriaNeg objCategoriaNeg;

        public CategoriaController()
        {
            objCategoriaNeg = new CategoriaNeg();
        }

        public ActionResult Index()
        {
            List<Categoria> lista = objCategoriaNeg.FindAll();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            MensajeInicioRegistro();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Categoria objCategoria)
        {
            ModelState.Clear();
            objCategoriaNeg.Create(objCategoria);
            MensajeErrorRegistrar(objCategoria);
            return View("Create");
        }

        public void MensajeErrorRegistrar(Categoria objcategoria)
        {
            switch (objcategoria.Estado)
            {
                case 3:
                    ViewBag.MensajeError = "El registro [ "+objcategoria.Nombre+" ] ya existe ";
                    break;
                case 99:
                    ViewBag.MensajeError = "La categoria [ " + objcategoria.Nombre + "] fue creada con Exito";
                    break;
            }
        }

        public void MensajeInicioRegistro()
        {
            ViewBag.MensajeInicio = "Ingrese Datos de la Categoria";
        }

    }
}