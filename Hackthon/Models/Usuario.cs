using Hackthon.Models.Enums;
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

        public TipoUsuario TipoCadastro { get; set; }

        public string NomeFantasia { get; set; }

        //se TipoCadastro=usuario então CPF
        public string CpfCnpj { get; set; }

        [MaxLength(200, ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.MaxLength))]
        public string AtividadeEconomica { get; set; }

    }
}
