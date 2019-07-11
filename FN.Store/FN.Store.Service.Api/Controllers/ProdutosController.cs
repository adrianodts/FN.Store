using FN.Store.Domain.Contracts.Repositories;
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
    public class ProdutosController:ApiController
    {
        private readonly IProdutoRepository _repo;
        public ProdutosController(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public async Task<HttpResponseMessage> Get() 
        {
            var data = await _repo.ObterAsync();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        public async Task<HttpResponseMessage> Get(int id) 
        {
            var data = await _repo.ObterAsync(id);

            if(data==null)
                return Request.CreateResponse(HttpStatusCode.NotFound);


            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}