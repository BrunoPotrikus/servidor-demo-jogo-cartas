using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServidorDemoJogoCartas.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Simbolo = table.Column<string>(type: "NVARCHAR(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Magia = table.Column<int>(type: "INT", nullable: false),
                    Forca = table.Column<int>(type: "INT", nullable: false),
                    Fogo = table.Column<int>(type: "INT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personagem_Categoria",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Titulo",
                table: "Categoria",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personagem_CategoriaId",
                table: "Personagem",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personagem");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
