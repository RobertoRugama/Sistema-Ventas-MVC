using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitemaVenta.Controllers
{
    public class VendedorController : Controller
    {
        VendedorNeg objVendedorNeg;

        public VendedorController()
        {
            objVendedorNeg = new VendedorNeg();
        }
        // GET: Vendedor
        [HttpGet]
        public ActionResult Index()
        {

            List<Vendedor> lista = objVendedorNeg.FindAll();
            return View(lista);
        }

        // GET: Vendedor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vendedor/Create
        [HttpGet]
        public ActionResult Create()
        {
            mensajeInicioRegistrar();
            return View();
        }
        public void mensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos del Vendedor y click en Guardar";
        }
        public void mensajeInicioRegistrar(Vendedor objVendedor)
        {
            switch (objVendedor.Estado)
            {
                case 8:
                    ViewBag.MensajeError = "Vendedor [" + objVendedor.Identificacion + "] ya esta registrado en el Sistema";
                    break;
                case 99:
                    ViewBag.MensajeExito = "Vendedor [" + objVendedor.P_nombre + " " + objVendedor.P_apellido + "] Fue Registrado Correctamente";
                    break;
            }

        }

        // POST: Vendedor/Create
        [HttpPost]
        public ActionResult Create(Vendedor objVendedor)
        {
            // TODO: Add insert logic here
            
            mensajeInicioRegistrar();
            objVendedorNeg.create(objVendedor);
            //mensajeInicioRegistrar(objVendedor);         
            return View("Create");
        }

        // GET: Vendedor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vendedor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vendedor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vendedor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
