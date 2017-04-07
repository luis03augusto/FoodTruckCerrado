using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using FoodTruckCerrado.DAO;

namespace FoodTruckCerrado.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20170331145041_data-e-cidade")]
    partial class dataecidade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodTruckCerrado.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cidade");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao");

                    b.Property<string>("FotoCapa");

                    b.Property<string>("Nome");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.FoodEvento", b =>
                {
                    b.Property<int>("FoodTruckId");

                    b.Property<int>("EventoId");

                    b.HasKey("FoodTruckId", "EventoId");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.FoodTruck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Categoria")
                        .IsRequired();

                    b.Property<string>("Cidade");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("FotoCapa")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("ProprietarioId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.FotosEventos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventoId");

                    b.Property<string>("Url");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.FotosFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FoodTruckId");

                    b.Property<string>("Url");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.FotosPrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PratoId");

                    b.Property<string>("Url");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.LocalizacaoEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<int>("EventoId");

                    b.Property<string>("Latitude");

                    b.Property<string>("Logitude");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.LocalizacaoFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataLocalização");

                    b.Property<string>("Descricao");

                    b.Property<int>("FoodTruckId");

                    b.Property<string>("Latitude");

                    b.Property<string>("Logitude");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.Prato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<int>("FoodTruckId");

                    b.Property<string>("FotoPrato");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.Proprietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Sexo");

                    b.Property<string>("Sobrenome");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.FoodEvento", b =>
                {
                    b.HasOne("FoodTruckCerrado.Models.Evento")
                        .WithMany()
                        .HasForeignKey("EventoId");

                    b.HasOne("FoodTruckCerrado.Models.FoodTruck")
                        .WithMany()
                        .HasForeignKey("FoodTruckId");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.FoodTruck", b =>
                {
                    b.HasOne("FoodTruckCerrado.Models.Proprietario")
                        .WithMany()
                        .HasForeignKey("ProprietarioId");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.FotosEventos", b =>
                {
                    b.HasOne("FoodTruckCerrado.Models.Evento")
                        .WithMany()
                        .HasForeignKey("EventoId");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.FotosFood", b =>
                {
                    b.HasOne("FoodTruckCerrado.Models.FoodTruck")
                        .WithMany()
                        .HasForeignKey("FoodTruckId");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.FotosPrato", b =>
                {
                    b.HasOne("FoodTruckCerrado.Models.Prato")
                        .WithMany()
                        .HasForeignKey("PratoId");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.LocalizacaoEvento", b =>
                {
                    b.HasOne("FoodTruckCerrado.Models.Evento")
                        .WithOne()
                        .HasForeignKey("FoodTruckCerrado.Models.LocalizacaoEvento", "EventoId");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.LocalizacaoFood", b =>
                {
                    b.HasOne("FoodTruckCerrado.Models.FoodTruck")
                        .WithMany()
                        .HasForeignKey("FoodTruckId");
                });

            modelBuilder.Entity("FoodTruckCerrado.Models.Prato", b =>
                {
                    b.HasOne("FoodTruckCerrado.Models.FoodTruck")
                        .WithMany()
                        .HasForeignKey("FoodTruckId");
                });
        }
    }
}
