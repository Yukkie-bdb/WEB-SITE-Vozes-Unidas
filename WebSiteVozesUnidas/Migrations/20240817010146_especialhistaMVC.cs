using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class especialhistaMVC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbMaterialDidatico",
                newName: "IdMaterialDidatico");

            migrationBuilder.AddColumn<Guid>(
                name: "EspecialhistaId",
                table: "tbAvaliacaoEspecialhista",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tbEspecialhista",
                columns: table => new
                {
                    IdEspecialhista = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialhidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEspecialhista", x => x.IdEspecialhista);
                    table.ForeignKey(
                        name: "FK_tbEspecialhista_tbUsuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "tbUsuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbAvaliacaoEspecialhista_EspecialhistaId",
                table: "tbAvaliacaoEspecialhista",
                column: "EspecialhistaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbEspecialhista_UsuarioIdUsuario",
                table: "tbEspecialhista",
                column: "UsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_tbAvaliacaoEspecialhista_tbEspecialhista_EspecialhistaId",
                table: "tbAvaliacaoEspecialhista",
                column: "EspecialhistaId",
                principalTable: "tbEspecialhista",
                principalColumn: "IdEspecialhista",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbAvaliacaoEspecialhista_tbEspecialhista_EspecialhistaId",
                table: "tbAvaliacaoEspecialhista");

            migrationBuilder.DropTable(
                name: "tbEspecialhista");

            migrationBuilder.DropIndex(
                name: "IX_tbAvaliacaoEspecialhista_EspecialhistaId",
                table: "tbAvaliacaoEspecialhista");

            migrationBuilder.DropColumn(
                name: "EspecialhistaId",
                table: "tbAvaliacaoEspecialhista");

            migrationBuilder.RenameColumn(
                name: "IdMaterialDidatico",
                table: "tbMaterialDidatico",
                newName: "Id");
        }
    }
}
