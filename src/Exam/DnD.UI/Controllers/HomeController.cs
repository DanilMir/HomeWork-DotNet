using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DnD.UI.Models;

namespace DnD.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client = new();
        public List<Character> Characters { get; set; } = null!;

        public async  Task<IActionResult> Index()
        {
            return View();
        }

        private record FightStartingModel(Character Player, Character Monster);
        private record FightResult(List<string> Log);

        public record FightModel(CalculatedCharacter Character, List<string> Log);
        public async Task<IActionResult> Fight(Character player)
            {
                var q = await _client.GetAsync("https://localhost:8001/GetRandomMonster");
                var monster = await q.Content.ReadFromJsonAsync<Character>();
                var w =
                    await _client.PostAsync("https://localhost:8003/CalculateCharacter", JsonContent.Create(player));
                var calculated = await w.Content.ReadFromJsonAsync<CalculatedCharacter>();
        
                var e = await _client.PostAsync("https://localhost:8003/Fight",
                    JsonContent.Create(new FightStartingModel(player, monster!)));
                var log = (await e.Content.ReadFromJsonAsync<FightResult>())!.Log;
                return View(new FightModel(calculated!, log));
            }
    }
}