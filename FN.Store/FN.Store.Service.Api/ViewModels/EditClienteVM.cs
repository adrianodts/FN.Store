using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FN.Store.Service.Api.ViewModels
{
    public class EditClienteVM
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Range(1, 80, ErrorMessage = "A idade deve ser entre 1 e 80 anos")]
        public byte Idade { get; set; }

        [Range(0, 1, ErrorMessage = "O sexo deve ser 0(Fem) e 1(Masc)")]
        public int Sexo { get; set; }
    }
}