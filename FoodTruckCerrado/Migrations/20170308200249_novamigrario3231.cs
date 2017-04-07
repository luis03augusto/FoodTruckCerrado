using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace FoodTruckCerrado.Migrations
{
    public partial class novamigrario3231 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodTruck",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categoria = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    FotoCapa = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTruck", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "LocalizacaoEvento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    EventoId = table.Column<int>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Logitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizacaoEvento", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "FotosFood",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodTruckId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotosFood_FoodTruck_FoodTruckId",
                        column: x => x.FoodTruckId,
                        principalTable: "FoodTruck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "LocalizacaoFood",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    FoodTruckId = table.Column<int>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Logitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizacaoFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalizacaoFood_FoodTruck_FoodTruckId",
                        column: x => x.FoodTruckId,
                        principalTable: "FoodTruck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Prato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    FoodTruckId = table.Column<int>(nullable: false),
                    FotoPrato = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prato_FoodTruck_FoodTruckId",
                        column: x => x.FoodTruckId,
                        principalTable: "FoodTruck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(nullable: true),
                    FoodTruckId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sexo = table.Column<char>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proprietario_FoodTruck_FoodTruckId",
                        column: x => x.FoodTruckId,
                        principalTable: "FoodTruck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    FoodTruckId = table.Column<int>(nullable: false),
                    LocalizacaoEventoId = table.Column<int>(nullable: true),
                    LocalizacaoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evento_FoodTruck_FoodTruckId",
                        column: x => x.FoodTruckId,
                        principalTable: "FoodTruck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evento_LocalizacaoEvento_LocalizacaoEventoId",
                        column: x => x.LocalizacaoEventoId,
                        principalTable: "LocalizacaoEvento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "FotosPrato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PratoId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosPrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotosPrato_Prato_PratoId",
                        column: x => x.PratoId,
                        principalTable: "Prato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "FotosEventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventoId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotosEventos_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("FotosEventos");
            migrationBuilder.DropTable("FotosFood");
            migrationBuilder.DropTable("FotosPrato");
            migrationBuilder.DropTable("LocalizacaoFood");
            migrationBuilder.DropTable("Proprietario");
            migrationBuilder.DropTable("Evento");
            migrationBuilder.DropTable("Prato");
            migrationBuilder.DropTable("LocalizacaoEvento");
            migrationBuilder.DropTable("FoodTruck");
        }
    }
}
