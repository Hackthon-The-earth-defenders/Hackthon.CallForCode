#region Using

using System.ComponentModel.DataAnnotations;

#endregion

namespace HackthAccountViewModelson.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
