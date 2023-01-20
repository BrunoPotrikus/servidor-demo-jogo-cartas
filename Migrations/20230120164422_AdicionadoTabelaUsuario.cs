using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServidorDemoJogoCartas.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Apelido = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPersonagem",
                columns: table => new
                {
                    PersonagemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPersonagem", x => new { x.PersonagemId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_UsuarioPersonagem_PersoangemId",
                        column: x => x.PersonagemId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPersonagem_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Personagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPersonagem_UsuarioId",
                table: "UsuarioPersonagem",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioPersonagem");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
