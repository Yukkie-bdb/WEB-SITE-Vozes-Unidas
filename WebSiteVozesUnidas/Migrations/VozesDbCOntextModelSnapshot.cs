﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSiteVozesUnidas.Data;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    [DbContext(typeof(VozesDbContext))]
    partial class VozesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Estrelas")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdAvaliacaoEspecialhis");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbAvaliacaoEspecialhista", (string)null);
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
                    b.HasOne("WebSiteVozesUnidas.Models.Usuario", "Usuario")
                        .WithMany("AvaliacoesEspecialhistas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
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

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Usuario", b =>
                {
                    b.Navigation("AvaliacoesEspecialhistas");

                    b.Navigation("Noticias");
                });
#pragma warning restore 612, 618
        }
    }
}
