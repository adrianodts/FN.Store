using FN.Store.Data.EF.Repositories;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.ServiceBus.Server
{
    class Program
    {
        static void Main(string[] args)
        {

            var conn = "Endpoint=sb://fnstore-fan.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=3tHq5HX8FvPzxMSzDb4jwgb2mKZzgLTq/a+5YjdB5JM=";
            var queue = "produtos";

            var server = QueueClient.CreateFromConnectionString(conn, queue);


            var reenviar = true;
            while (reenviar)
            {
                //var msg = "Teste - " + DateTime.Now.ToShortTimeString();

                var repo = new ProdutoRepository();
                var produtos = repo.Obter().Select(x => new { Id = x.Id, Nome=x.Nome });
                
                server.Send(new BrokeredMessage(JsonConvert.SerializeObject(produtos)));

                Console.WriteLine("Dado transmitido c/ sucesso!");
                Console.WriteLine("Deseja enviar uma nova mensagem? (S/N)");
                if (Console.ReadLine().ToString() != "S")
                    reenviar = false;
            }


            Console.ReadLine();
        }
    }
}
