﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSiteVozesUnidas.Data;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    [DbContext(typeof(VozesDbContext))]
    [Migration("20240817200103_TudoAqui")]
    partial class TudoAqui
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebSiteVozesUnidas.Models.AvaliacaoEspecialhista", b =>
                {
                    b.Property<Guid>("IdAvaliacaoEspecialhis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EspecialhistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Estrelas")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdAvaliacaoEspecialhis");

                    b.HasIndex("EspecialhistaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbAvaliacaoEspecialhista", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CategoriaMaterial", b =>
                {
                    b.Property<Guid>("IdCategoriaMaterial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoriaMaterial");

                    b.ToTable("tbCategoriaMaterial", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Comentario", b =>
                {
                    b.Property<Guid>("IdComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdComentario");

                    b.HasIndex("PostId");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("tbComentario", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Especialhista", b =>
                {
                    b.Property<Guid>("IdEspecialhista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especialhidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UsuarioIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdEspecialhista");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("tbEspecialhista", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.MaterialDidatico", b =>
                {
                    b.Property<Guid>("IdMaterialDidatico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgMaterial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMaterialDidatico");

                    b.HasIndex("CategoriaId");

                    b.ToTable("tbMaterialDidatico", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Noticia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgCapa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Publicacao")
                        .HasColumnType("date");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbNoticia", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Post", b =>
                {
                    b.Property<Guid>("IdPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImgPost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdPost");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbPost", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.ToTable("tbUsuario", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Candidato", b =>
                {
                    b.HasBaseType("WebSiteVozesUnidas.Models.Usuario");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("tbCandidato", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Empresa", b =>
                {
                    b.HasBaseType("WebSiteVozesUnidas.Models.Usuario");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("tbEmpresa", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.AvaliacaoEspecialhista", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.Especialhista", "Especialhista")
                        .WithMany("AvaliacoesEspecialhistas")
                        .HasForeignKey("EspecialhistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSiteVozesUnidas.Models.Usuario", "Usuario")
                        .WithMany("AvaliacoesEspecialhistas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialhista");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Comentario", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.Post", "Post")
                        .WithMany("Comentarios")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSiteVozesUnidas.Models.Usuario", null)
                        .WithMany("Comentarios")
                        .HasForeignKey("UsuarioIdUsuario");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Especialhista", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.Usuario", null)
                        .WithMany("Especialhistas")
                        .HasForeignKey("UsuarioIdUsuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.MaterialDidatico", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.CategoriaMaterial", "Categoria")
                        .WithMany("MaterialDidaticos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Noticia", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.Usuario", "Usuario")
                        .WithMany("Noticias")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Post", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.Usuario", "Usuario")
                        .WithMany("Posts")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Candidato", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.Usuario", null)
                        .WithOne()
                        .HasForeignKey("WebSiteVozesUnidas.Models.Candidato", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Empresa", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.Usuario", null)
                        .WithOne()
                        .HasForeignKey("WebSiteVozesUnidas.Models.Empresa", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CategoriaMaterial", b =>
                {
                    b.Navigation("MaterialDidaticos");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Especialhista", b =>
                {
                    b.Navigation("AvaliacoesEspecialhistas");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Post", b =>
                {
                    b.Navigation("Comentarios");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Usuario", b =>
                {
                    b.Navigation("AvaliacoesEspecialhistas");

                    b.Navigation("Comentarios");

                    b.Navigation("Especialhistas");

                    b.Navigation("Noticias");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
