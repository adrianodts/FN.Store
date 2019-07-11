using FN.Store.Data.EF;
using FN.Store.Data.EF.Repositories;
using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.ConsoleUI
{
    class Program
    {
        private static IRepository<Cliente> _repCli = new Repository<Cliente>();
        private static IRepository<Funcionario> _repFunc = new Repository<Funcionario>();

        static void Main(string[] args)
        {
            ObterCliente(1);
            ObterTodos();
            Adicionar("Nome do cliente " + Guid.NewGuid(), Sexo.Masculino, 20);

            ObterTodosFuncs();

            Console.WriteLine("Fim da Execução.");
            Console.ReadLine();
            _repCli.Dispose();
            _repFunc.Dispose();
        }

        private static void ObterTodosFuncs()
        {
            Console.WriteLine("Obtendo todos...");
            _repFunc.Obter().ToList().ForEach(c => Console.WriteLine("Id: {0} - Nome: {1} - CodFunc: {2} - Data: {3}",
                c.Id, c.Nome, c.CodFunc, c.DataCadastro));
        }

        private static void Adicionar(string nome, Sexo sexo, byte idade)
        {
            var novo = _repCli.Adicionar(new Cliente { Nome=nome, Sexo = sexo, Idade= idade});
            Console.WriteLine("Id: {0} - Nome: {1} - Sexo: {2} - Idade:{3}",
                novo.Id, novo.Nome, novo.Sexo, novo.Idade);
        }

        private static void ObterTodos()
        {
            Console.WriteLine("Obtendo todos...");
            _repCli.Obter().ToList().ForEach(c => Console.WriteLine("Id: {0} - Nome: {1} - Sexo: {2} - Idade:{3}",
                c.Id, c.Nome, c.Sexo, c.Idade));
        }

        private static void ObterCliente(int id)
        {
            Console.WriteLine("Obtendo o cliente " + id);
            var cliente = _repCli.Obter(id);
            Console.WriteLine("Id: {0} - Nome: {1} - Sexo: {2} - Idade:{3}",
                cliente.Id, cliente.Nome, cliente.Sexo, cliente.Idade);
        }
    }
}
