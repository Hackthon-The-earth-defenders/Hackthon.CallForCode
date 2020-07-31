using Hackthon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Hackthon
{
    public class HackthonDbContext : IdentityDbContext<Usuario, Funcao, Guid>
    {
        public HackthonDbContext(DbContextOptions<HackthonDbContext> options)
            : base(options)
        {
        }
        public DbSet<Projeto> Projeto { get; set; }
    }

}