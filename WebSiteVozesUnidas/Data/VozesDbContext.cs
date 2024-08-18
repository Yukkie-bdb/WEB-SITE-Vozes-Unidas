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
        public DbSet<Post> Post { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<CategoriaPost> CategoriaPost { get; set; }


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

            modelBuilder.Entity<Post>()
                .ToTable("tbPost")
                .HasKey(u => u.IdPost);

            modelBuilder.Entity<Comentario>()
                .ToTable("tbComentario")
                .HasKey(u => u.IdComentario);

            modelBuilder.Entity<Post>()
               .HasOne(p => p.Usuario)
               .WithMany(u => u.Posts)
               .HasForeignKey(p => p.UsuarioId)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Comentarios)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CategoriaPost>()
                .ToTable("tbCategoriaPost")
                .HasKey(u => u.IdCategoriaPost);
        }
    }
}