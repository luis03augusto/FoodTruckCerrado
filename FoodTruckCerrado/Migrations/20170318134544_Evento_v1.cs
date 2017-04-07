using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace FoodTruckCerrado.Migrations
{
    public partial class Evento_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Evento_FoodTruck_FoodTruckId", table: "Evento");
            migrationBuilder.DropForeignKey(name: "FK_FoodTruck_Proprietario_ProprietarioId", table: "FoodTruck");
            migrationBuilder.DropForeignKey(name: "FK_FotosEventos_Evento_EventoId", table: "FotosEventos");
            migrationBuilder.DropForeignKey(name: "FK_FotosFood_FoodTruck_FoodTruckId", table: "FotosFood");
            migrationBuilder.DropForeignKey(name: "FK_FotosPrato_Prato_PratoId", table: "FotosPrato");
            migrationBuilder.DropForeignKey(name: "FK_LocalizacaoFood_FoodTruck_FoodTruckId", table: "LocalizacaoFood");
            migrationBuilder.DropForeignKey(name: "FK_Prato_FoodTruck_FoodTruckId", table: "Prato");
            migrationBuilder.DropColumn(name: "FoodTruckId", table: "Evento");
            migrationBuilder.CreateTable(
                name: "FoodEvento",
                columns: table => new
                {
                    FoodTruckId = table.Column<int>(nullable: false),
                    EventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodEvento", x => new { x.FoodTruckId, x.EventoId });
                    table.ForeignKey(
                        name: "FK_FoodEvento_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodEvento_FoodTruck_FoodTruckId",
                        column: x => x.FoodTruckId,
                        principalTable: "FoodTruck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "FoodTruck",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "FotoCapa",
                table: "FoodTruck",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "FoodTruck",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "FoodTruck",
                nullable: false);
            migrationBuilder.AddForeignKey(
                name: "FK_FoodTruck_Proprietario_ProprietarioId",
                table: "FoodTruck",
                column: "ProprietarioId",
                principalTable: "Proprietario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_FotosEventos_Evento_EventoId",
                table: "FotosEventos",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_FotosFood_FoodTruck_FoodTruckId",
                table: "FotosFood",
                column: "FoodTruckId",
                principalTable: "FoodTruck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_FotosPrato_Prato_PratoId",
                table: "FotosPrato",
                column: "PratoId",
                principalTable: "Prato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_LocalizacaoFood_FoodTruck_FoodTruckId",
                table: "LocalizacaoFood",
                column: "FoodTruckId",
                principalTable: "FoodTruck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Prato_FoodTruck_FoodTruckId",
                table: "Prato",
                column: "FoodTruckId",
                principalTable: "FoodTruck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_FoodTruck_Proprietario_ProprietarioId", table: "FoodTruck");
            migrationBuilder.DropForeignKey(name: "FK_FotosEventos_Evento_EventoId", table: "FotosEventos");
            migrationBuilder.DropForeignKey(name: "FK_FotosFood_FoodTruck_FoodTruckId", table: "FotosFood");
            migrationBuilder.DropForeignKey(name: "FK_FotosPrato_Prato_PratoId", table: "FotosPrato");
            migrationBuilder.DropForeignKey(name: "FK_LocalizacaoFood_FoodTruck_FoodTruckId", table: "LocalizacaoFood");
            migrationBuilder.DropForeignKey(name: "FK_Prato_FoodTruck_FoodTruckId", table: "Prato");
            migrationBuilder.DropTable("FoodEvento");
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "FoodTruck",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "FotoCapa",
                table: "FoodTruck",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "FoodTruck",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "FoodTruck",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "FoodTruckId",
                table: "Evento",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Evento_FoodTruck_FoodTruckId",
                table: "Evento",
                column: "FoodTruckId",
                principalTable: "FoodTruck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_FoodTruck_Proprietario_ProprietarioId",
                table: "FoodTruck",
                column: "ProprietarioId",
                principalTable: "Proprietario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_FotosEventos_Evento_EventoId",
                table: "FotosEventos",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_FotosFood_FoodTruck_FoodTruckId",
                table: "FotosFood",
                column: "FoodTruckId",
                principalTable: "FoodTruck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_FotosPrato_Prato_PratoId",
                table: "FotosPrato",
                column: "PratoId",
                principalTable: "Prato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_LocalizacaoFood_FoodTruck_FoodTruckId",
                table: "LocalizacaoFood",
                column: "FoodTruckId",
                principalTable: "FoodTruck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Prato_FoodTruck_FoodTruckId",
                table: "Prato",
                column: "FoodTruckId",
                principalTable: "FoodTruck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
