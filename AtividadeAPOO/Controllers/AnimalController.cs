using Modelo.Cadastros;
using Servico.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AtividadeAPOO.Controllers
{
    public class AnimalController : Controller
    {
        private EspecieServico especiesServico = new EspecieServico();

                private ActionResult ObterVisaoEspeciePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Especie especie = especiesServico.ObterEspeciePorId((long)id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }
        private ActionResult GravarEspecie(Especie especie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    especiesServico.GravarEspecie(especie);
                    return RedirectToAction("Index");
                }
                return View(especie);
            }
            catch
            {
                return View(especie);
            }
        }

        // GET: Animal
        public ActionResult Index()
        {
            return View(especiesServico.ObterEspeciesClassificadosPorNome());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Especie especie)
        {
            return GravarEspecie(especie);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoEspeciePorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Especie especie)
        {
            return GravarEspecie(especie);
        }

        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoEspeciePorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoEspeciePorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Especie especie = especiesServico.EliminarEspeciePorId(id);
                TempData["Message"] = "Especie " + especie.Cpf.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}