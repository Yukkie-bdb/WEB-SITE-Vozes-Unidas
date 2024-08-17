using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class forumMVC5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbComentario_tbUsuario_UsuarioId",
                table: "tbComentario");

            migrationBuilder.DropForeignKey(
                name: "FK_tbPost_tbUsuario_UsuarioId",
                table: "tbPost");

            migrationBuilder.AddForeignKey(
                name: "FK_tbComentario_tbUsuario_UsuarioId",
                table: "tbComentario",
                column: "UsuarioId",
                principalTable: "tbUsuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_tbPost_tbUsuario_UsuarioId",
                table: "tbPost",
                column: "UsuarioId",
                principalTable: "tbUsuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbComentario_tbUsuario_UsuarioId",
                table: "tbComentario");

            migrationBuilder.DropForeignKey(
                name: "FK_tbPost_tbUsuario_UsuarioId",
                table: "tbPost");

            migrationBuilder.AddForeignKey(
                name: "FK_tbComentario_tbUsuario_UsuarioId",
                table: "tbComentario",
                column: "UsuarioId",
                principalTable: "tbUsuario",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_tbPost_tbUsuario_UsuarioId",
                table: "tbPost",
                column: "UsuarioId",
                principalTable: "tbUsuario",
                principalColumn: "IdUsuario");
        }
    }
}
