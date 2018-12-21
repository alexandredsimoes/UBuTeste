using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteUBus.Models
{
    public class UBusContexto : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        //public DbSet<ComplementoVeiculo> Complemenot { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }
        public DbSet<MarcaVeiculo> MarcaVeiculos { get; set; }
        public DbSet<ModeloVeiculo> ModeloVeiculos { get; set; }
        public DbSet<TipoComplemento> TipoComplementos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Viagem> Viagens { get; set; }


        public UBusContexto()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<MarcaVeiculo>()
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<ModeloVeiculo>()
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();
            
        }
    }
}
