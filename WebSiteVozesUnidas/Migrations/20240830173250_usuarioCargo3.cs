using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class usuarioCargo3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdCandidatoJornalista",
                table: "tbCandidatoJornalista",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdCandidatoJornalista",
                table: "tbCandidatoJornalista",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
