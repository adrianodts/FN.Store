using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Client.Api
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://fnstore.azurewebsites.net/api/clientes").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var clientes = JsonConvert.DeserializeObject<IEnumerable<Cliente>>(json);

                    clientes.ToList().ForEach(c => 
                        Console.WriteLine("Id: {0} - Nome: {1} - Idade: {2}",
                        c.Id, c.Nome, c.Idade));


                }


            }

            Console.ReadLine();

        }
    }


    class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public byte Idade { get; set; }

        public Sexo Sexo { get; set; }
    }

    public enum Sexo { Feminino, Masculino }
}
