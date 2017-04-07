using FoodTruckCerrado.Models;
using Microsoft.Data.Entity;
using System.Configuration;

namespace FoodTruckCerrado.DAO
{
    public class Contexto : DbContext
    {
      
        public DbSet<FoodTruck> FoodTrucks { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Prato> Pratos { get; set; }
        public DbSet<FotosFood> FotosFood { get; set; }
        public DbSet<FotosPrato> FotosPrato { get; set; }
        public DbSet<FotosEventos> FotosEvento { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<LocalizacaoEvento> LocalizacoesEventos { get; set; }
        public DbSet<LocalizacaoFood> LocalizacoesFood { get; set; }
        public DbSet<FoodEvento> FoodEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["FoodTruckConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(stringConexao);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodEvento>().HasKey(fe => new { fe.FoodTruckId, fe.EventoId });
            base.OnModelCreating(modelBuilder);
        }

    }
}