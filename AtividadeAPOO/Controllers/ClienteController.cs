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
    public class ClienteController : Controller
    {
        private ClienteServico clientesServico = new ClienteServico();

        private ActionResult ObterVisaoClientePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Cliente cliente = clientesServico.ObterClientePorId((long)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        private ActionResult GravarCliente(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clientesServico.GravarCliente(cliente);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: Clientes
        public ActionResult Index()
        {
            return View(ClienteServico.ObterClientesClassificadosPorCpf());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

    }

}
    // Terminar esse controller