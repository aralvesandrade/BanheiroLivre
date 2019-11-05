using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace banheiro_livre.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banheiro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banheiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LimpezaBanheiro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    BanheiroId = table.Column<int>(nullable: false),
                    Dia = table.Column<string>(maxLength: 3, nullable: false),
                    Serviço = table.Column<int>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Final = table.Column<DateTime>(nullable: false),
                    ResponsavelLimpeza = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimpezaBanheiro", x => new { x.Id, x.BanheiroId, x.Dia });
                    table.ForeignKey(
                        name: "FK_LimpezaBanheiro_Banheiro_BanheiroId",
                        column: x => x.BanheiroId,
                        principalTable: "Banheiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LimpezaBanheiro_BanheiroId",
                table: "LimpezaBanheiro",
                column: "BanheiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LimpezaBanheiro");

            migrationBuilder.DropTable(
                name: "Banheiro");
        }
    }
}
