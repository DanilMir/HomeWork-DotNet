using System;
using Dnd.BLL.Models;
using Dnd.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.BLL.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class FightsController : Controller
    {
        public record FightInput(CharacterModel Player, MonsterModel Monster);

        [HttpPost]
        public IActionResult StartFight(FightInput input)
        {
            var (player, monster) = input;
            return Ok(FightDecider.CreateFight(player, monster));
        }
        
        [HttpPost]
        public IActionResult MakeTurn([FromQuery]Guid fightId) =>
            new JsonResult(FightDecider.MakeTurnNew(fightId));
    }
}