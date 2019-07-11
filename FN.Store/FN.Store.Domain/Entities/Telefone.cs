using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    public class Telefone : Entity
    {
        public string NTel { get; set; }

        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

    }
}
