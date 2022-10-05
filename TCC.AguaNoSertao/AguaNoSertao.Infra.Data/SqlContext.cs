using AguaNoSertao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaNoSertao.Infra.Data
{
    public class SqlContext : DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<ContatoForm> ContatoForms{ get; set; }


        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasOne(e => e.Endereco).WithOne(e => e.Usuario).HasForeignKey<Endereco>(e => e.UsuarioId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlContext).Assembly);
        }
    }
}
