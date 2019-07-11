using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FN.Store.Data.EF.Repositories
{
    public class ClienteRepository: Repository<Cliente>, IClienteRepository
    {

        public IEnumerable<Cliente> ObterPorNome(string nome)
        {
            return _ctx.Clientes.Where(x => x.Nome == nome);
        }

        public async Task<IEnumerable<Cliente>> ObterPorNomeAsync(string nome)
        {
            return await _ctx.Clientes.Where(x => x.Nome == nome).ToListAsync();
        }

    }
}
