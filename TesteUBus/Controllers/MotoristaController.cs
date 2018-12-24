using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using UBus.ViewModels;

namespace TesteUBus.Controllers
{
    public class MotoristaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MotoristaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Motorista
        public async Task<ActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("UBus API");
            var rotas = JsonConvert.DeserializeObject<IEnumerable<RotaViewModel>>(
                await client.GetStringAsync("ListarRotas"));


            var motoristas = JsonConvert.DeserializeObject<IEnumerable<FuncionarioViewModel>>(
                await client.GetStringAsync($"ListarMotoristas"));

            ViewBag.RotaId = new SelectList(rotas, "Id", "Nome");
            return View(motoristas);
        }

        [HttpPost]
        public async Task<ActionResult> Index(string rotaId)
        {
            if (String.IsNullOrWhiteSpace(rotaId))
                return RedirectToAction("Index");

            var client = _httpClientFactory.CreateClient("UBus API");
            var rotas = JsonConvert.DeserializeObject<IEnumerable<RotaViewModel>>(
                await client.GetStringAsync("ListarRotas"));


            var motoristas = JsonConvert.DeserializeObject<IEnumerable<FuncionarioViewModel>>(
                await client.GetStringAsync($"ListarMotoristasPorRota/{rotaId}"));

            ViewBag.RotaId = new SelectList(rotas, "Id", "Nome", rotaId);            
            return View(motoristas);
        }

        // GET: Motorista/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Motorista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motorista/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuncionarioViewModel funcionario)
        {
            if (ModelState.IsValid)
            {
                var result = _httpClientFactory.CreateClient("UBus API")
                    .PostAsJsonAsync("CriarMotorista", funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        // GET: Motorista/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Motorista/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Motorista/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Motorista/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}