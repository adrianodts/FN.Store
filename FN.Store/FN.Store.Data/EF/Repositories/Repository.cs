using FN.Store.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FN.Store.Domain.Entities;
using System.Data.Entity;

namespace FN.Store.Data.EF.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        protected readonly StoreDataContext _ctx = new StoreDataContext();

        public T Obter(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public IEnumerable<T> Obter()
        {
            return _ctx.Set<T>().ToList();
        }

        public T Adicionar(T entity)
        {
            _ctx.Set<T>().Add(entity);
            salvar();
            return entity;
        }

        public T Editar(T entity)
        {
            //Sem o Entry
            //var editar = Obter(entity.Id);
            //editar.Nome = cliente.Nome;
            //..

            _ctx.Entry(entity).State = EntityState.Modified;
            salvar();
            return entity;
        }

        public void Excluir(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            salvar();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }


        private void salvar()
        {
            _ctx.SaveChanges();
        }


        public async Task<IEnumerable<T>> ObterAsync()
        {
            return await _ctx.Set<T>().ToListAsync();
        }


        public Task<T> ObterAsync(int id)
        {
            return _ctx.Set<T>().FindAsync(id);
        }
    }
}
