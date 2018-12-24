using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUBus.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UBusContexto(
                serviceProvider.GetRequiredService<
                    DbContextOptions<UBusContexto>>()))
            {
                if (context.Funcionarios.Any()) return;


                var rotas = new[]
                {
                    new Rota { Nome = "Rota 1" },
                    new Rota { Nome = "Rota 2" },
                    new Rota { Nome = "Rota 3" }
                };

                context.Rotas.AddRange(
                   rotas
                );


                var itinerarios = new[]
                {

                    new Itinerario() { Nome = "Itinerário 1", Rota = rotas[0], Valor = 50,
                        HoraInicial = new DateTime(2018, 01, 01, 4, 0, 0),
                        HoraFinal = new DateTime(2018, 01, 01, 7, 0, 0)
                    },
                    new Itinerario()
                    {
                        Nome = "Itinerário 2",
                        Rota = rotas[1],
                        Valor = 50,
                        HoraInicial = new DateTime(2018, 01, 01, 5, 0, 0),
                        HoraFinal = new DateTime(2018, 01, 01, 8, 0, 0)
                    },
                    new Itinerario()
                    {
                        Nome = "Itinerário 3",
                        Rota = rotas[2],
                        Valor = 25,
                        HoraInicial = new DateTime(2018, 01, 01, 8, 0, 0),
                        HoraFinal = new DateTime(2018, 01, 01, 9, 0, 0)
                    }
                };
                context.Itinerarios.AddRangeAsync(
                    itinerarios
                );

                context.ModeloVeiculos.AddRange(new ModeloVeiculo()
                {
                    Nome = "Modelo X"
                }, new ModeloVeiculo()
                {
                    Nome = "Modelo Y"
                });

                context.MarcaVeiculos.AddRange(
                    new MarcaVeiculo() { Nome = "Marca 1" },
                    new MarcaVeiculo() { Nome = "Marca 2" },
                    new MarcaVeiculo() { Nome = "Marca 3" }
                );

                var tiposComplemento = new[]
                {
                    new TipoComplemento() { Nome = "Banheiro", TipoExibicao = TipoExibicao.TeValor },
                    new TipoComplemento() { Nome = "Ar condicionado", TipoExibicao = TipoExibicao.TeSimNao },
                    new TipoComplemento() { Nome = "Wifi", TipoExibicao = TipoExibicao.TeSimNao }
                };
                context.TipoComplementos.AddRange(tiposComplemento
                );

                var complementos = new[]
                {
                    new ComplementoVeiculo()
                    {
                        Tipo = tiposComplemento[0],
                        Valor = "2",
                    },
                    new ComplementoVeiculo()
                    {
                        Tipo = tiposComplemento[1],
                    },
                    new ComplementoVeiculo()
                    {
                        Tipo = tiposComplemento[1],
                    }
                };


                var veiculos = new[] {
                    new Veiculo() { MarcaId = 1, ModeloId = 1, Placa = "ABC123", Tipo = TipoVeiculo.TvMicroOnibus, Complementos = complementos.ToList() },
                    new Veiculo() { MarcaId = 1, ModeloId = 1, Placa = "DEF456", Tipo = TipoVeiculo.TvVan, Complementos = complementos.ToList() }
                };
                context.Veiculos.AddRange(
                    veiculos
                );


                var motoristas = new[] {
                    new Funcionario() { Nome = "Motorista 1", Endereco = "Endereço do motorista 1", Email = "email1@servidor.com" },
                    new Funcionario() { Nome = "Motorista 2", Endereco = "Endereço do motorista 2", Email = "email2@servidor.com" },
                    new Funcionario() { Nome = "Motorista 3", Endereco = "Endereço do motorista 3", Email = "email3@servidor.com" },
                    new Funcionario() { Nome = "Motorista 4", Endereco = "Endereço do motorista 4", Email = "email4@servidor.com" }
                };
                context.Funcionarios.AddRange(
                   motoristas
                );

               // context.SaveChanges();

                context.Viagens.AddRange(
                    new Viagem()
                    {
                        Data = DateTime.Now,
                        Itinerario = itinerarios[0],
                        Motorista = motoristas[0],
                        Veiculo = veiculos[0],                        
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
