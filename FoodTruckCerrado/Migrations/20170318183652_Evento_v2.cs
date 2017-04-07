using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace FoodTruckCerrado.Migrations
{
    public partial class Evento_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Evento_LocalizacaoEvento_LocalizacaoEventoId", table: "Evento");
            migrationBuilder.DropForeignKey(name: "FK_FoodEvento_Evento_EventoId", table: "FoodEvento");
            migrationBuilder.DropForeignKey(name: "FK_FoodEvento_FoodTruck_FoodTruckId", table: "FoodEvento");
            migrationBuilder.DropForeignKey(name: "FK_FoodTruck_Proprietario_ProprietarioId", table: "FoodTruck");
            migrationBuilder.DropForeignKey(name: "FK_FotosEventos_Evento_EventoId", table: "FotosEventos");
            migrationBuilder.DropForeignKey(name: "FK_FotosFood_FoodTruck_FoodTruckId", table: "FotosFood");
            migrationBuilder.DropForeignKey(name: "FK_FotosPrato_Prato_PratoId", table: "FotosPrato");
            migrationBuilder.DropForeignKey(name: "FK_LocalizacaoFood_FoodTruck_FoodTruckId", table: "LocalizacaoFood");
            migrationBuilder.DropForeignKey(name: "FK_Prato_FoodTruck_FoodTruckId", table: "Prato");
            migrationBuilder.DropColumn(name: "LocalizacaoEventoId", table: "Evento");
            migrationBuilder.DropColumn(name: "LocalizacaoId", table: "Evento");
            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Evento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(
                name: "FotoCapa",
                table: "Evento",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_FoodEvento_Evento_EventoId",
                table: "FoodEvento",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_FoodEvento_FoodTruck_FoodTruckId",
                table: "FoodEvento",
                column: "FoodTruckId",
                principalTable: "FoodTruck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_LocalizacaoEvento_Evento_EventoId",
                table: "LocalizacaoEvento",
                column: "EventoId",
                principalTable: "Evento",
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
            migrationBuilder.DropForeignKey(name: "FK_FoodEvento_Evento_EventoId", table: "FoodEvento");
            migrationBuilder.DropForeignKey(name: "FK_FoodEvento_FoodTruck_FoodTruckId", table: "FoodEvento");
            migrationBuilder.DropForeignKey(name: "FK_FoodTruck_Proprietario_ProprietarioId", table: "FoodTruck");
            migrationBuilder.DropForeignKey(name: "FK_FotosEventos_Evento_EventoId", table: "FotosEventos");
            migrationBuilder.DropForeignKey(name: "FK_FotosFood_FoodTruck_FoodTruckId", table: "FotosFood");
            migrationBuilder.DropForeignKey(name: "FK_FotosPrato_Prato_PratoId", table: "FotosPrato");
            migrationBuilder.DropForeignKey(name: "FK_LocalizacaoEvento_Evento_EventoId", table: "LocalizacaoEvento");
            migrationBuilder.DropForeignKey(name: "FK_LocalizacaoFood_FoodTruck_FoodTruckId", table: "LocalizacaoFood");
            migrationBuilder.DropForeignKey(name: "FK_Prato_FoodTruck_FoodTruckId", table: "Prato");
            migrationBuilder.DropColumn(name: "Data", table: "Evento");
            migrationBuilder.DropColumn(name: "FotoCapa", table: "Evento");
            migrationBuilder.AddColumn<int>(
                name: "LocalizacaoEventoId",
                table: "Evento",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "LocalizacaoId",
                table: "Evento",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Evento_LocalizacaoEvento_LocalizacaoEventoId",
                table: "Evento",
                column: "LocalizacaoEventoId",
                principalTable: "LocalizacaoEvento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_FoodEvento_Evento_EventoId",
                table: "FoodEvento",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_FoodEvento_FoodTruck_FoodTruckId",
                table: "FoodEvento",
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
