using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    public class Funcionario:Entity
    {
        public Funcionario()
        {
            CodFunc = Guid.NewGuid();
        }

        public Guid CodFunc { get; private set; }
        public string Nome { get; set; }
    }
}
