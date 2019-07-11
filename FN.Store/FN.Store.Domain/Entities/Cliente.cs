using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    public class Cliente : Entity
    {

        public Cliente()
        {
            Telefones = new List<Telefone>();
        }

        public string Nome { get; set; }

        public byte Idade { get; set; }

        public Sexo Sexo { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }

        public void Alterar(string nome, byte idade, Sexo sexo)
        {
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
        }


    }

    public enum Sexo{ Feminino, Masculino }

}
