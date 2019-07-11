using FN.Store.Data.EF.Repositories;
using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using FN.Store.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FN.Store.UI.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepository<Cliente> _repCli =
            new Repository<Cliente>();

        public ActionResult Index()
        {
            var clientes = _repCli.Obter();
            return View(clientes);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(AddEditClienteVM cliente)
        {
            if (ModelState.IsValid)
            {
                var cliDb = new Cliente
                {
                    Nome = cliente.Nome,
                    Idade = (byte)cliente.Idade,
                    Sexo = (Domain.Entities.Sexo)cliente.Sexo
                };

                try
                {
                    _repCli.Adicionar(cliDb);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                }

                return RedirectToAction("Index");
            }
            return View("Novo");
        }


        protected override void Dispose(bool disposing)
        {
            _repCli.Dispose();
        }

    }
}