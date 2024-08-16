using Microsoft.EntityFrameworkCore;
using WebSiteVozesUnidas.Models;
using WebSiteVozesUnidas.ViewModels;

namespace WebSiteVozesUnidas.Data
{
    public class VozesDbContext : DbContext
    {
        public VozesDbContext(DbContextOptions<VozesDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Candidato> Candidato { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .ToTable("tbUsuario")
                .HasKey(u => u.IdUsuario);

            modelBuilder.Entity<Empresa>()
                .ToTable("tbEmpresa")
                .HasBaseType<Usuario>();

            modelBuilder.Entity<Candidato>()
                .ToTable("tbCandidato")
                .HasBaseType<Usuario>();
        }
    }
}