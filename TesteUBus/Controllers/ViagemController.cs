using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UBus.ViewModels;

namespace TesteUBus.Controllers
{
    public class ViagemController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ViagemController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var result = JsonConvert.DeserializeObject<IEnumerable<ViagemViewModel>>(await _httpClientFactory
                .CreateClient("UBus API")
                .GetStringAsync("Viagens"));

            return View(result);
        }
    }
}