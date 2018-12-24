using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBus.ViewModels
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome do funcionário")]
        public string Nome { get; set; }
        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Informe o endereço do funcionário")]
        public string Endereco { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }

    }
}
