using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class forumMVC2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "tbComentario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbComentario_UsuarioId",
                table: "tbComentario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbComentario_tbUsuario_UsuarioId",
                table: "tbComentario",
                column: "UsuarioId",
                principalTable: "tbUsuario",
                principalColumn: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbComentario_tbUsuario_UsuarioId",
                table: "tbComentario");

            migrationBuilder.DropIndex(
                name: "IX_tbComentario_UsuarioId",
                table: "tbComentario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tbComentario");
        }
    }
}
