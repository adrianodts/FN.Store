using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts.Repositories
{
    public interface IRepository<T> : IDisposable
        where T : Entity
    {
        T Obter(int id);
        Task<T> ObterAsync(int id);

        IEnumerable<T> Obter();
        Task<IEnumerable<T>> ObterAsync();

        T Adicionar(T entity);
        T Editar(T entity);
        void Excluir(T entity);
    }
}
