using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Client.WCFApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var proxy =new ClienteProxy.ClienteServiceClient())
            {
                var clientes = proxy.ObterTodos();
                foreach (var cli in clientes)
                {
                    Console.WriteLine("Id: {0} - Nome: {1} - Idade: {2}",
                        cli.Id, cli.Nome, cli.Idade);
                }
            }
            Console.ReadLine();
        }
    }
}
