using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TesteUBus.Services.Interfaces;
using UBus.ViewModels;

namespace UBus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusServices _busService;

        public BusController(IBusServices busService)
        {
            _busService = busService;
        }

        // GET: api/Viagens
        [HttpGet]
        [Route("Viagens")]
        [ProducesResponseType(typeof(IEnumerable<ViagemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ViagemViewModel>>> GetViagens()
        {
            var result = await _busService.ListarViagensAsync(DateTime.Now.Date);
            return Ok(result);
        }

        [HttpPut]
        [Route("AtualizarMotorista/{viagemId}/{motoristaId}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> AtualizarMotoristaAsync(int viagemId, int motoristaId)
        {
            return await _busService.AtualizarMotoristaAsync(viagemId, motoristaId);
        }

        [HttpGet]
        [Route("ListarItemsAdicionais/{rotaId}")]
        [ProducesResponseType(typeof(IEnumerable<ComplementoVeiculoViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<ComplementoVeiculoViewModel>> ListarComplementosPorRotaAsync(int rotaId)
        {
            return await _busService.ListarComplementosPorRotaAsync(rotaId);
        }

        [HttpGet]
        [Route("ListarMotoristasPorRota/{rotaId}")]
        [ProducesResponseType(typeof(IEnumerable<FuncionarioViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<FuncionarioViewModel>> ListarMotoristasAsync(int rotaId)
        {
            return await _busService.ListarMotoristasAsync(rotaId);
        }

        [HttpGet]
        [Route("ListarMotoristas")]
        [ProducesResponseType(typeof(IEnumerable<FuncionarioViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<FuncionarioViewModel>> ListarMotoristasAsync()
        {
            return await _busService.ListarMotoristasAsync();
        }

        [HttpGet]
        [Route("ListarViagensPorData/{data}")]
        [ProducesResponseType(typeof(IEnumerable<ViagemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<ViagemViewModel>> ListarViagensAsync(DateTime data)
        {
            return await _busService.ListarViagensAsync(data);
        }

        [HttpGet]
        [Route("RemoverComplementoVeiculo/{veiculoId}/{complementoVeiculoId}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> RemoverComplementoVeiculoAsync(int veiculoId, int complementoVeiculoId)
        {
            return await _busService.RemoverComplementoVeiculoAsync(veiculoId, complementoVeiculoId);
        }

        [HttpGet]
        [Route("ListarRotas")]
        [ProducesResponseType(typeof(IEnumerable<RotaViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<RotaViewModel>> ListarRotasAsync()
        {
            return await _busService.ListarRotasAsync();
        }

        [HttpPost]
        [Route("CriarMotorista")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> CriarMotoristaAsync(FuncionarioViewModel funcionario)
        {
            return await _busService.CriarMotoristaAsync(funcionario);
        }
    }
}
