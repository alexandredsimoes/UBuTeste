using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteUBus.Models;
using TesteUBus.Services.Interfaces;
using UBus.ViewModels;

namespace TesteUBus.Services.Services
{
    public class BusServices : IBusServices
    {
        private readonly UBusContexto _contexto;
        private readonly IMapper _mapper;

        public BusServices(UBusContexto contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarMotoristaAsync(int viagemId, int motoristaId)
        {
            var viagem = await _contexto.FindAsync<Viagem>(viagemId);

            if (viagem == null) return false;
            viagem.MotoristaId = motoristaId;
            _contexto.Entry(viagem).State = EntityState.Modified;

            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> CriarMotoristaAsync(FuncionarioViewModel funcionario)
        {
            var model = _mapper.Map<Funcionario>(funcionario);
            _contexto.Funcionarios.Add(model);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ComplementoVeiculoViewModel>> ListarComplementosPorRotaAsync(int rotaId)
        {
            return await _contexto.ComplementosVeiculos
                .Where(x => x.Veiculo.Viagens.Any(r => r.Itinerario.RotaId == rotaId))
                .Select(x => new ComplementoVeiculoViewModel()
                {
                    Id = x.Id,
                    TipoComplementoId = x.TipoComplementoId,
                    TipoComplementoNome = x.Tipo.Nome,
                    VeiculoId = x.VeiculoId,
                    VeiculoModeloId = x.Veiculo.ModeloId,
                    VeiculoModeloNome = x.Veiculo.Modelo.Nome,
                    VeiculoPlaca = x.Veiculo.Placa
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<FuncionarioViewModel>> ListarMotoristasAsync(int rotaId)
        {
            return await _contexto.Funcionarios
                            .Where(x => x.Viagens.Any(r => r.Itinerario.RotaId == rotaId))
                            .Select(x => new FuncionarioViewModel()
                            {
                                Id = x.Id,
                                Nome = x.Nome,
                                Email = x.Email,
                                Endereco = x.Endereco
                            })
                            .ToListAsync();
        }

        public async Task<IEnumerable<FuncionarioViewModel>> ListarMotoristasAsync()
        {
            return await _contexto.Funcionarios
                            
                            .Select(x => new FuncionarioViewModel()
                            {
                                Id = x.Id,
                                Nome = x.Nome,
                                Email = x.Email,
                                Endereco = x.Endereco
                            })
                            .ToListAsync();
        }

        public async Task<IEnumerable<RotaViewModel>> ListarRotasAsync()
        {
            return await _contexto.Rotas
                            .OrderBy(x=>x.Nome)
                            .Select(x => new RotaViewModel()
                            {
                                Id = x.Id,
                                Nome = x.Nome
                            })
                            .ToListAsync();
        }

        public async Task<IEnumerable<ViagemViewModel>> ListarViagensAsync(DateTime data)
        {
            return await _contexto.Viagens
                .Where(x => x.Data.Date == data.Date)
                .Select(x => new ViagemViewModel()
                {
                    Id = x.Id,
                    Data = x.Data,
                    ItinerarioId = x.ItinerarioId,
                    ItinerarioNome = x.Itinerario.Nome,
                    MotoristaId = x.MotoristaId,
                    MotoristaNome = x.Motorista.Nome,
                    VeiculoId = x.VeiculoId,
                    VeiculoPlaca = x.Veiculo.Placa
                })
                .ToListAsync();
        }

        public async Task<bool> RemoverComplementoVeiculoAsync(int veiculoId, int complementoVeiculoId)
        {
            var complemento = await _contexto.ComplementosVeiculos.FindAsync(complementoVeiculoId);
            if (complemento == null)
            {
                return false;
            }

            _contexto.ComplementosVeiculos.Remove(complemento);
            return await _contexto.SaveChangesAsync() > 0;
        }
    }
}
