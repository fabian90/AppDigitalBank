//using AppDigitalBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalBank.ServiceUsuario;


namespace AppDigitalBank.Controllers
{
    public class UsuarioController : Controller
    {
        private ServiceUsuario.UsuarioBusinessClient _serviceClient;
        public UsuarioController()
        {
            _serviceClient = new ServiceUsuario.UsuarioBusinessClient();
        }
        // GET: Usuario
        public ActionResult Index()
        {

            var personas = _serviceClient.Consultar().Result;
            return View(personas);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            var usuario = _serviceClient.ObtenerUsuarioPorId(id).Result;
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioDto usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceClient.Guardar(usuario);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = _serviceClient.ObtenerUsuarioPorId(id).Result;
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioDto usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceClient.Actualizar(usuario);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {

            var usuario = _serviceClient.ObtenerUsuarioPorId(id).Result;
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _serviceClient.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serviceClient.Close();
            }
            base.Dispose(disposing);
        }
    }
}
