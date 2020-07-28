using Hackthon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Hackthon
{
    public class HackthonDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public HackthonDbContext(DbContextOptions<HackthonDbContext> options)
            : base(options)
        {
        }
    }

}