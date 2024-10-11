using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkYoutub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCategoriaMaterial",
                columns: table => new
                {
                    IdCategoriaMaterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoriaMaterial", x => x.IdCategoriaMaterial);
                });

            migrationBuilder.CreateTable(
                name: "tbCategoriaPost",
                columns: table => new
                {
                    IdCategoriaPost = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoriaPost", x => x.IdCategoriaPost);
                });

            migrationBuilder.CreateTable(
                name: "tbUsuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagemPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUsuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "tbMaterialDidatico",
                columns: table => new
                {
                    IdMaterialDidatico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImgMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkYoutube = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMaterialDidatico", x => x.IdMaterialDidatico);
                    table.ForeignKey(
                        name: "FK_tbMaterialDidatico_tbCategoriaMaterial_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tbCategoriaMaterial",
                        principalColumn: "IdCategoriaMaterial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbCandidato",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCandidato", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_tbCandidato_tbUsuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tbUsuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbEmpresa",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEmpresa", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_tbEmpresa_tbUsuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tbUsuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbEspecialhista",
                columns: table => new
                {
                    IdEspecialhista = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialhidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEspecialhista", x => x.IdEspecialhista);
                    table.ForeignKey(
                        name: "FK_tbEspecialhista_tbUsuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "tbUsuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "tbNoticia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgCapa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publicacao = table.Column<DateOnly>(type: "date", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbNoticia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbNoticia_tbUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbUsuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbPost",
                columns: table => new
                {
                    IdPost = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgPost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoriaPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPost", x => x.IdPost);
                    table.ForeignKey(
                        name: "FK_tbPost_tbCategoriaPost_CategoriaPostId",
                        column: x => x.CategoriaPostId,
                        principalTable: "tbCategoriaPost",
                        principalColumn: "IdCategoriaPost");
                    table.ForeignKey(
                        name: "FK_tbPost_tbUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbUsuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tbCandidatoJornalista",
                columns: table => new
                {
                    IdCandidatoJornalista = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCandidatoJornalista", x => x.IdCandidatoJornalista);
                    table.ForeignKey(
                        name: "FK_tbCandidatoJornalista_tbCandidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "tbCandidato",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbVagaEmprego",
                columns: table => new
                {
                    IdVagaEmprego = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbVagaEmprego", x => x.IdVagaEmprego);
                    table.ForeignKey(
                        name: "FK_tbVagaEmprego_tbEmpresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "tbEmpresa",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbAvaliacaoEspecialhista",
                columns: table => new
                {
                    IdAvaliacaoEspecialhis = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estrelas = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EspecialhistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAvaliacaoEspecialhista", x => x.IdAvaliacaoEspecialhis);
                    table.ForeignKey(
                        name: "FK_tbAvaliacaoEspecialhista_tbEspecialhista_EspecialhistaId",
                        column: x => x.EspecialhistaId,
                        principalTable: "tbEspecialhista",
                        principalColumn: "IdEspecialhista",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbAvaliacaoEspecialhista_tbUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbUsuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbComentario",
                columns: table => new
                {
                    IdComentario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbComentario", x => x.IdComentario);
                    table.ForeignKey(
                        name: "FK_tbComentario_tbPost_PostId",
                        column: x => x.PostId,
                        principalTable: "tbPost",
                        principalColumn: "IdPost",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbComentario_tbUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbUsuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tbCandidaturaVagamprego",
                columns: table => new
                {
                    IdCandidaturaVagamprego = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VagaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCandidaturaVagamprego", x => x.IdCandidaturaVagamprego);
                    table.ForeignKey(
                        name: "FK_tbCandidaturaVagamprego_tbCandidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "tbCandidato",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbCandidaturaVagamprego_tbVagaEmprego_VagaId",
                        column: x => x.VagaId,
                        principalTable: "tbVagaEmprego",
                        principalColumn: "IdVagaEmprego",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbAvaliacaoEspecialhista_EspecialhistaId",
                table: "tbAvaliacaoEspecialhista",
                column: "EspecialhistaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbAvaliacaoEspecialhista_UsuarioId",
                table: "tbAvaliacaoEspecialhista",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCandidatoJornalista_CandidatoId",
                table: "tbCandidatoJornalista",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCandidaturaVagamprego_CandidatoId",
                table: "tbCandidaturaVagamprego",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCandidaturaVagamprego_VagaId",
                table: "tbCandidaturaVagamprego",
                column: "VagaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbComentario_PostId",
                table: "tbComentario",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_tbComentario_UsuarioId",
                table: "tbComentario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbEspecialhista_UsuarioIdUsuario",
                table: "tbEspecialhista",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tbMaterialDidatico_CategoriaId",
                table: "tbMaterialDidatico",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbNoticia_UsuarioId",
                table: "tbNoticia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbPost_CategoriaPostId",
                table: "tbPost",
                column: "CategoriaPostId");

            migrationBuilder.CreateIndex(
                name: "IX_tbPost_UsuarioId",
                table: "tbPost",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbVagaEmprego_EmpresaId",
                table: "tbVagaEmprego",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbAvaliacaoEspecialhista");

            migrationBuilder.DropTable(
                name: "tbCandidatoJornalista");

            migrationBuilder.DropTable(
                name: "tbCandidaturaVagamprego");

            migrationBuilder.DropTable(
                name: "tbComentario");

            migrationBuilder.DropTable(
                name: "tbMaterialDidatico");

            migrationBuilder.DropTable(
                name: "tbNoticia");

            migrationBuilder.DropTable(
                name: "tbEspecialhista");

            migrationBuilder.DropTable(
                name: "tbCandidato");

            migrationBuilder.DropTable(
                name: "tbVagaEmprego");

            migrationBuilder.DropTable(
                name: "tbPost");

            migrationBuilder.DropTable(
                name: "tbCategoriaMaterial");

            migrationBuilder.DropTable(
                name: "tbEmpresa");

            migrationBuilder.DropTable(
                name: "tbCategoriaPost");

            migrationBuilder.DropTable(
                name: "tbUsuario");
        }
    }
}
