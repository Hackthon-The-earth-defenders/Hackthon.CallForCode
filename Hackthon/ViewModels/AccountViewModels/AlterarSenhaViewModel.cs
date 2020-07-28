using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace HackthAccountViewModelson.ViewModels
{
    public class AlterarSenhaViewModel
    {
        public Guid UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string SenhaAtual { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais!")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }
    }
}
