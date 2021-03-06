﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteUBus.Services.Interfaces;

namespace UBus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagemController : ControllerBase
    {
        private IBusServices _busService;

        public ViagemController(IBusServices busServices)
        {
            _busService = busServices;
        }

        // GET: api/Viagem
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var s = await _busService.ListarViagensAsync();
            return new string[] { "value1", "value2" };
        }

        // GET: api/Viagem/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Viagem
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Viagem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
