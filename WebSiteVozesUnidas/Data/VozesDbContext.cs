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
        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<AvaliacaoEspecialhista> AvaliacaoEspecialhista { get; set; }
        public DbSet<MaterialDidatico> MaterialDidatico { get; set; }
        public DbSet<CategoriaMaterial> CategoriaMaterial { get; set; }
        public DbSet<Especialhista> Especialhista { get; set; }


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

            modelBuilder.Entity<Noticia>()
                .ToTable("tbNoticia");

            modelBuilder.Entity<AvaliacaoEspecialhista>()
                .ToTable("tbAvaliacaoEspecialhista")
                .HasKey(u => u.IdAvaliacaoEspecialhis);

            modelBuilder.Entity<MaterialDidatico>()
                .ToTable("tbMaterialDidatico")
                .HasKey(u => u.IdMaterialDidatico);


            modelBuilder.Entity<CategoriaMaterial>()
                .ToTable("tbCategoriaMaterial")
                .HasKey(u => u.IdCategoriaMaterial);

            modelBuilder.Entity<Especialhista>()
                .ToTable("tbEspecialhista")
                .HasKey(u => u.IdEspecialhista);
        }
    }
}