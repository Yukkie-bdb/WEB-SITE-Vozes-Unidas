using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class TesteFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemPerfil",
                table: "tbUsuario",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemPerfil",
                table: "tbUsuario");
        }
    }
}
