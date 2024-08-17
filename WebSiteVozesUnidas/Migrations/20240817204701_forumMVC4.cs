using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class forumMVC4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbComentario_tbUsuario_UsuarioId",
                table: "tbComentario");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "tbComentario",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "tbComentario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbComentario_tbUsuario_UsuarioId",
                table: "tbComentario",
                column: "UsuarioId",
                principalTable: "tbUsuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
