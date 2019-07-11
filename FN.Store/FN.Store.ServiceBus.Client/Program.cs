using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.ServiceBus.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = "Endpoint=sb://fnstore-fan.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=3tHq5HX8FvPzxMSzDb4jwgb2mKZzgLTq/a+5YjdB5JM=";
            var queue = "produtos";

            var server = QueueClient.CreateFromConnectionString(conn, queue);
            server.OnMessage(msg => {
                Console.WriteLine("recebendo mensagem do servidor...");
                Console.WriteLine("Id: " + msg.MessageId);

                var data = msg.GetBody<string>();
                Console.WriteLine(data);

                var produtos = JsonConvert.DeserializeObject<IEnumerable<Produto>>(data);
                foreach (var item in produtos)
                {
                    Console.WriteLine("Id: {0} - Nome: {1}",item.Id, item.Nome);
                }


                Console.WriteLine("mensagem recebida");
            });

            Console.WriteLine("aguardando mensagem... Pressione ENTER para finalizar");
            Console.ReadLine();
        }
    }

    class Produto 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

}
