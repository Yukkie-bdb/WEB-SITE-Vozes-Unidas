using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class usuarioCargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cargo",
                table: "tbUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "tbUsuario");
        }
    }
}
