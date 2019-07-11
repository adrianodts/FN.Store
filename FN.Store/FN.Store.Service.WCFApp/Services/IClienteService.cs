using FN.Store.Service.WCFApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FN.Store.Service.WCFApp.Services
{
    [ServiceContract]
    public interface IClienteService : IDisposable
    {
        [OperationContract]
        [WebGet(UriTemplate="clientes",ResponseFormat=WebMessageFormat.Json)]
        IEnumerable<ClienteDTO> ObterTodos();

        [OperationContract]
        [WebGet(UriTemplate = "clientes/{id}", ResponseFormat = WebMessageFormat.Json)]
        ClienteDTO ObterPorId(string id);

    }
}
