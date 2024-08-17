using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class forumMVC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbPost",
                columns: table => new
                {
                    IdPost = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgPost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPost", x => x.IdPost);
                    table.ForeignKey(
                        name: "FK_tbPost_tbUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbUsuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "tbComentario",
                columns: table => new
                {
                    IdComentario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbComentario_PostId",
                table: "tbComentario",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_tbPost_UsuarioId",
                table: "tbPost",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbComentario");

            migrationBuilder.DropTable(
                name: "tbPost");
        }
    }
}
