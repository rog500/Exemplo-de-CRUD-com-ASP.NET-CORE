using System;
using System.Collections.Generic;
using System.Text;
using Exercicio3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exercicio3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Condominio> Condominio { get; set; }

        public DbSet<Familia> Familia { get; set; }

        public DbSet<Morador> Morador { get; set; }
    }
}
