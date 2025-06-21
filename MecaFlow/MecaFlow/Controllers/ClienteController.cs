using MecaFlow.Helpers.Interfaces;
using MecaFlow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MecaFlow.Controllers
{
    public class ClienteController : Controller
    {
        IClienteHelper _clienteHelper;


        public ClienteController(IClienteHelper clienteHelper)
        {
            _clienteHelper = clienteHelper;
        }


        // GET: ClienteController1
        public ActionResult Index()
        {
            var result = _clienteHelper.GetClientes();
            return View(result);
        }

        // GET: ClienteController1/Details/5
        public ActionResult Details(int id)
        {
            var result = _clienteHelper.GetCliente(id);
            return View(result);
        }

        // GET: ClienteController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            try
            {
                _clienteHelper.Add(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController1/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _clienteHelper.GetCliente(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: ClienteController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteViewModel cliente)
        {
            try
            {
                if (id != cliente.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _clienteHelper.Update(cliente);
                    return RedirectToAction(nameof(Index));
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);

            }
        }

        // GET: ClienteController1/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _clienteHelper.GetCliente(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: ClienteController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ClienteViewModel cliente)
        {
            try
            {
                _clienteHelper.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cliente);
            }
        }
    }
}