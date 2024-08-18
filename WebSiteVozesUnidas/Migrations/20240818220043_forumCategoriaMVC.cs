using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class forumCategoriaMVC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaPostId",
                table: "tbPost",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_tbPost_CategoriaPostId",
                table: "tbPost",
                column: "CategoriaPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbPost_tbCategoriaPost_CategoriaPostId",
                table: "tbPost",
                column: "CategoriaPostId",
                principalTable: "tbCategoriaPost",
                principalColumn: "IdCategoriaPost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbPost_tbCategoriaPost_CategoriaPostId",
                table: "tbPost");

            migrationBuilder.DropTable(
                name: "tbCategoriaPost");

            migrationBuilder.DropIndex(
                name: "IX_tbPost_CategoriaPostId",
                table: "tbPost");

            migrationBuilder.DropColumn(
                name: "CategoriaPostId",
                table: "tbPost");
        }
    }
}
