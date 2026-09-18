using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _0_InventáriodeEquipamentosdeRede.Migrations
{
    /// <inheritdoc />
    public partial class MudandoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "arquivo");

            migrationBuilder.CreateTable(
                name: "equipamentos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDescricao = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Fabricante = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    IP = table.Column<string>(type: "TEXT", nullable: true),
                    Localizacao = table.Column<string>(type: "TEXT", nullable: false),
                    DataInstalacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Statu = table.Column<int>(type: "INTEGER", nullable: false),
                    DataUltimaManutencao = table.Column<string>(type: "TEXT", nullable: true),
                    Observacao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipamentos", x => x.Codigo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipamentos");

            migrationBuilder.CreateTable(
                name: "arquivo",
                columns: table => new
                {
                    UltimoRegistro = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
