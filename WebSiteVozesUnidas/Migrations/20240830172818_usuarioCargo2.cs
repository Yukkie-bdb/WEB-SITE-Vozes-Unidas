using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class usuarioCargo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "tbUsuario");

            migrationBuilder.AddColumn<int>(
                name: "Cargo",
                table: "tbCandidato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbCandidatoJornalista",
                columns: table => new
                {
                    IdCandidatoJornalista = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_tbCandidatoJornalista_CandidatoId",
                table: "tbCandidatoJornalista",
                column: "CandidatoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCandidatoJornalista");

            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "tbCandidato");

            migrationBuilder.AddColumn<int>(
                name: "Cargo",
                table: "tbUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
