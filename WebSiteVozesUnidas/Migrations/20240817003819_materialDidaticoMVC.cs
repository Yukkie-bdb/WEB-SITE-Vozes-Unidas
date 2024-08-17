using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class materialDidaticoMVC : Migration
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
                name: "tbMaterialDidatico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImgMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMaterialDidatico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbMaterialDidatico_tbCategoriaMaterial_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tbCategoriaMaterial",
                        principalColumn: "IdCategoriaMaterial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbMaterialDidatico_CategoriaId",
                table: "tbMaterialDidatico",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbMaterialDidatico");

            migrationBuilder.DropTable(
                name: "tbCategoriaMaterial");
        }
    }
}
