using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteUBus.Models
{
    public class UBusContexto : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }
        public DbSet<MarcaVeiculo> MarcaVeiculos { get; set; }
        public DbSet<ModeloVeiculo> ModeloVeiculos { get; set; }
        public DbSet<TipoComplemento> TipoComplementos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<ComplementoVeiculo> ComplementosVeiculos { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<Rota> Rotas { get; set; }

        public UBusContexto(DbContextOptions<UBusContexto> options)
                    : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .ToTable("Funcionario")
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Funcionario>()
                .HasMany(x => x.Viagens)
                .WithOne(x => x.Motorista);
            modelBuilder.Entity<Funcionario>()
                .Property(x => x.Endereco)
                .HasMaxLength(100)
                .IsRequired();                

            modelBuilder.Entity<MarcaVeiculo>()
                .ToTable("MarcaVeiculo")
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<ModeloVeiculo>()
                .ToTable("ModeloVeiculo")
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Veiculo>()
                .ToTable("Veiculo")
                .Property(x => x.Placa)
                .HasMaxLength(12)
                .IsRequired();

            modelBuilder.Entity<Veiculo>()
                .HasMany(x => x.Viagens).WithOne(x => x.Veiculo);

            modelBuilder.Entity<Veiculo>()
                .HasMany(x => x.Complementos).WithOne(x => x.Veiculo);



            modelBuilder.Entity<Viagem>()
                .ToTable("Viagem");

            modelBuilder.Entity<Rota>()
                .ToTable("Rota")
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<TipoComplemento>()
                .ToTable("TipoComplemento");

            modelBuilder.Entity<Itinerario>()
                .ToTable("Itinerario")
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Veiculo>()
                .HasMany(x => x.Complementos).WithOne(p => p.Veiculo);

        }
    }
}
