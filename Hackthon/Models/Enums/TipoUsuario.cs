using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hackthon.Models.Enums
{
    public enum TipoUsuario : byte
    {
        [Display(Name = "Nenhum")]
        Nenhum = 0,
        [Display(Name = "Empresa")]
        Empresa = 1,
        [Display(Name = "Ong")]
        Ong = 2,
        [Display(Name = "Usuário Final")]
        Usuario = 3,
    }
}
