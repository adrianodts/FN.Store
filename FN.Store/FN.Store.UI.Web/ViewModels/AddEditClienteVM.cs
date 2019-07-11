using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FN.Store.UI.Web.ViewModels
{
    public class AddEditClienteVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage="O nome é obrigatório")]
        public string Nome { get; set; }
        [Range(18,60,ErrorMessage="A idade deve ser entre {0} e {1}")]
        public int Idade { get; set; }
        public Sexo Sexo { get; set; }
    }

    public enum Sexo { Feminino, Masculino }
}