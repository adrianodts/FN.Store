using FN.Store.Data.EF.Repositories;
using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using FN.Store.Service.WCFApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FN.Store.Service.WCFApp.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClienteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ClienteService.svc or ClienteService.svc.cs at the Solution Explorer and start debugging.
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _data =
            new ClienteRepository();


        public IEnumerable<Models.ClienteDTO> ObterTodos()
        {
            return _data.Obter().Select(c => new ClienteDTO {
                Id = c.Id,
                Nome = c.Nome,
                Idade = c.Idade
            });
        }

        public Models.ClienteDTO ObterPorId(string id)
        {
            ClienteDTO model = null;

            var cliente = _data.Obter(int.Parse(id));
            if (cliente != null)
            {
                model = new ClienteDTO();
                model.Id = cliente.Id;
                model.Nome = cliente.Nome;
                model.Idade = cliente.Idade;
            }

            return model;

        }

        public void Dispose()
        {
            _data.Dispose();
        }
    }
}
