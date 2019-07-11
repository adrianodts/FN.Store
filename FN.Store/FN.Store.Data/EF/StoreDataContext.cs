using FN.Store.Data.EF.Maps;
using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FN.Store.Data.EF
{
    public class StoreDataContext:DbContext
    {
        public StoreDataContext():base("StoreConn")
        {
            Database.SetInitializer(new StoreInitilizerDB());
            //desativado o lazyloading => eager loading
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new FuncionarioMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
        }

    }
}
