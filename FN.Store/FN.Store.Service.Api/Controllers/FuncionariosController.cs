using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FN.Store.Service.Api.Controllers
{
    public class FuncionariosController:ApiController
    {
        private IFuncionarioRepository _funcRep;

        public FuncionariosController(IFuncionarioRepository funcRep)
        {
            _funcRep = funcRep;
        }

        //public HttpResponseMessage Get()
        //{
        //    var data = _funcRep.Obter();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}

        [Queryable]
        public IQueryable<Funcionario> Get()
        {
            return _funcRep.ObterOData();
        }

    }
}