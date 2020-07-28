#region Using

using Hackthon.Models;
using System.ComponentModel.DataAnnotations;

#endregion

namespace HackthAccountViewModelson.ViewModels
{
    public class RegisterViewModel : Usuario
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "senha ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme senha")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
