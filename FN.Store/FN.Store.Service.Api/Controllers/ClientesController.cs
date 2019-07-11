using FN.Store.Data.EF.Repositories;
using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using FN.Store.Service.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FN.Store.Service.Api.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteRepository _repCli;

        public ClientesController(IClienteRepository repCli)
        {
            _repCli = repCli;
        }



        public async Task<HttpResponseMessage> Get()
        {
            var dados = await _repCli.ObterAsync();

            if (dados.Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, dados);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> ByName(string nome)
        {
            var dados = await _repCli.ObterPorNomeAsync(nome);

            if (dados.Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, dados);
        }

        public async  Task<HttpResponseMessage> Get(int id)
        {
            var cliente = await _repCli.ObterAsync(id);

            if (cliente == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, cliente);
        }

        public HttpResponseMessage Post(AddClienteVM cliVM)
        {

            if (!ModelState.IsValid)
            {
                return
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            //Ver Automapper p/ mapear de forma automática um obj para outro
            var novoCliente =
                new Cliente
                {
                    Nome = cliVM.Nome,
                    Idade = cliVM.Idade,
                    Sexo = (Sexo)cliVM.Sexo
                };
            var resposta = _repCli.Adicionar(novoCliente);
            return Request.CreateResponse(HttpStatusCode.Created, resposta);
        }


        public HttpResponseMessage Put(int id, EditClienteVM cliVM)
        {
            if (id == 0)
                return
                    Request
                    .CreateResponse(HttpStatusCode.BadRequest,
                                new { msg = "Id inválido" });

            if (!ModelState.IsValid)
            {
                return
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var cliente = _repCli.Obter(id);

            if (cliente == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "cliente não existe");

            cliente.Alterar(cliVM.Nome, cliVM.Idade, (Sexo)cliVM.Sexo);

            _repCli.Editar(cliente);

            return Request.CreateResponse(HttpStatusCode.NoContent);

        }

        public HttpResponseMessage Delete(int id)
        {
            var cliente = _repCli.Obter(id);

            if (cliente == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            try
            {
                _repCli.Excluir(cliente);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "erro inesperado");
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);

        }

        protected override void Dispose(bool disposing)
        {
            _repCli.Dispose();
        }

    }
}