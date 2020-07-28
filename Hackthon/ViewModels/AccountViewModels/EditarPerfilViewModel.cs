using Hackthon.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
namespace HackthAccountViewModelson.ViewModels
{
    public class PerfilViewModel
    {
        public PerfilViewModel()
        {

        }

        public PerfilViewModel(Usuario esteUsuario)
        {

            Nome = esteUsuario.Nome;
        }

        [Display(Name = "Nome Completo")]
        [Required]
        [MaxLength]
        public string Nome { get; set; }

    }
}
