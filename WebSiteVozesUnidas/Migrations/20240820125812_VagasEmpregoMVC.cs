using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class VagasEmpregoMVC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbVagaEmprego",
                columns: table => new
                {
                    IdVagaEmprego = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbVagaEmprego", x => x.IdVagaEmprego);
                    table.ForeignKey(
                        name: "FK_tbVagaEmprego_tbEmpresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "tbEmpresa",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbCandidaturaVagamprego",
                columns: table => new
                {
                    IdCandidaturaVagamprego = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VagaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCandidaturaVagamprego", x => x.IdCandidaturaVagamprego);
                    table.ForeignKey(
                        name: "FK_tbCandidaturaVagamprego_tbCandidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "tbCandidato",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbCandidaturaVagamprego_tbVagaEmprego_VagaId",
                        column: x => x.VagaId,
                        principalTable: "tbVagaEmprego",
                        principalColumn: "IdVagaEmprego",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbCandidaturaVagamprego_CandidatoId",
                table: "tbCandidaturaVagamprego",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCandidaturaVagamprego_VagaId",
                table: "tbCandidaturaVagamprego",
                column: "VagaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbVagaEmprego_EmpresaId",
                table: "tbVagaEmprego",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCandidaturaVagamprego");

            migrationBuilder.DropTable(
                name: "tbVagaEmprego");
        }
    }
}
