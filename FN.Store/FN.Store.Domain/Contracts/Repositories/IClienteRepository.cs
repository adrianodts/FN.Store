using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts.Repositories
{
    public interface IClienteRepository:IRepository<Cliente>
    {
        IEnumerable<Cliente> ObterPorNome(string nome);
        Task<IEnumerable<Cliente>> ObterPorNomeAsync(string nome);
    }
}
