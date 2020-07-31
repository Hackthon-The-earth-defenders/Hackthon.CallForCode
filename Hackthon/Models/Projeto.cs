using Hackthon.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hackthon.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        [Display(Name = "Empresa")]
        public Guid EmpresaId { get; set; }
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(200, ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.MaxLength))]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(EmpresaId))]
        public virtual Usuario Usuario { get; set; }
    }
}
