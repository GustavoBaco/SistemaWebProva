using Prova.Context;
using Prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Prova.Controllers
{
    public class ClienteController : Controller
    {
        private readonly Contexto _contexto = new Contexto();
        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = _contexto.Cliente.ToList();
            return View(cliente);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _contexto.Cliente.Add(cliente);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public ActionResult Delete(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteModel clienteModel = _contexto.Cliente.Find(id);
            if(clienteModel == null)
            {
                return HttpNotFound();
            }

            return View(clienteModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ClienteModel clienteModel = _contexto.Cliente.Find(id);
            _contexto.Cliente.Remove(clienteModel);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}