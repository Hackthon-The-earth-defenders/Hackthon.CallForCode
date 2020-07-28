using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hackthon.Models
{
    public class UsuarioMetadata
    {
        [Display(Name = "Login")]
        public string UserName { get; set; }
    }

    [ModelMetadataType(typeof(UsuarioMetadata))]
    public class Usuario : IdentityUser<Guid>
    {
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }
    }
}
