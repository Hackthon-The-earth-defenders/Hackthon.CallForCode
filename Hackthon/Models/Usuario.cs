using Hackthon.Models.Enums;
using Hackthon.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [MaxLength(200, ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.MaxLength))]
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [Display(Name = "Tipo de Cadastro")]
        public TipoUsuario TipoCadastro { get; set; }

        [MaxLength(200, ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.MaxLength))]
        [Display(Name = "Nome fantasia")]
        public string NomeFantasia { get; set; }

        [MaxLength(20, ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.MaxLength))]
        [Display(Name = "CPF ou CNPJ")]
        //se TipoCadastro=usuario então CPF
        public string CpfCnpj { get; set; }

        [MaxLength(200, ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.MaxLength))]
        [Display(Name = "Atividade Economica")]
        public string AtividadeEconomica { get; set; }

        [JsonIgnore]
        public ICollection<Projeto> Projetos { get; set; }

    }
}
