using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            DataCadastro = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
