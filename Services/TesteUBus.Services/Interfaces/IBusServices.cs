using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBus.ViewModels;

namespace TesteUBus.Services.Interfaces
{
    public interface IBusServices
    {
        Task<IEnumerable<ViagemViewModel>> ListarViagensAsync(DateTime data);
        Task<bool> AtualizarMotoristaAsync(int viagemId, int motoristaId);
        Task<bool> RemoverComplementoVeiculoAsync(int veiculoId, int complementoVeiculoId);
        Task<IEnumerable<FuncionarioViewModel>> ListarMotoristasAsync(int rotaId);
        Task<IEnumerable<FuncionarioViewModel>> ListarMotoristasAsync();
        Task<IEnumerable<ComplementoVeiculoViewModel>> ListarComplementosPorRotaAsync(int idRota);
        Task<IEnumerable<RotaViewModel>> ListarRotasAsync();
        Task<bool> CriarMotoristaAsync(FuncionarioViewModel funcionario);
    }
}
