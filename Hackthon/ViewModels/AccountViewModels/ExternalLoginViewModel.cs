using System.ComponentModel.DataAnnotations;


namespace HackthAccountViewModelson.ViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
