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
        [HttpPost]
        public IActionResult StartFight(MonsterModel monster, CharacterModel character) => 
            Ok(FightDecider.CreateFight(character, monster));

        [HttpPost]
        public IActionResult MakeTurn([FromQuery]Guid fightId) =>
            new JsonResult(FightDecider.MakeTurnNew(fightId));
    }
}