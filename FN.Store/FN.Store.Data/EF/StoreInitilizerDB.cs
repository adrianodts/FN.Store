using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FN.Store.Domain.Entities;

namespace FN.Store.Data.EF
{
    class StoreInitilizerDB : DropCreateDatabaseIfModelChanges<StoreDataContext>
    {

        protected override void Seed(StoreDataContext context)
        {
            context.Clientes.AddRange(new List<Cliente> {
            
                new Cliente{Nome="Fabiano Nalin", Sexo=Sexo.Masculino,Idade=38,Telefones=new List<Telefone>{
                    new Telefone{NTel="1166665858"},
                    new Telefone{NTel="11966665544"}
                }},
                new Cliente{Nome="Raphael Nalin",Sexo=Sexo.Masculino, Idade=18},
                new Cliente{Nome="Priscila Nalin",Sexo=Sexo.Feminino, Idade=39},
                new Cliente{Nome="Isabel Aparecida", Sexo=Sexo.Feminino,Idade=60},
            
            });

            context.Funcionarios.AddRange(new List<Funcionario> { 
            
                new Funcionario{Nome="Tospericageja"},
                new Funcionario{Nome="Novembrina"},
                new Funcionario{Nome="Creide"},

            });


            context.Produtos.AddRange(new List<Produto> {
                new Produto{Nome="Camiseta", Preco=100.99M},
                new Produto{Nome="Bone", Preco=10.99M},
                new Produto{Nome="Tenis", Preco=200.19M}
            });

            context.SaveChanges();
        }

    }

}
