using System.Threading.Tasks;
using Dnd.DB.Models;
using Dnd.DB.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.DB.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("[action]")]
    public class MonsterController : Controller
    {
        private readonly MonsterRepository _repository;

        public MonsterController(MonsterRepository repository) =>
            _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAllMonsters() =>
            new JsonResult(await _repository.GetAllMonsters());

        [HttpGet]
        public async Task<IActionResult> GetMonsterById([FromQuery] int id) =>
            new JsonResult(await _repository.GetMonsterAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddMonster(Monster newMonster)
        {
            var monster = await _repository.GetMonsterAsync(newMonster.Name);
            if (monster != null)
                return BadRequest($"Monster {newMonster.Name} already exists");

            monster = Utils.GetNew(newMonster);

            await _repository.AddMonsterAsync(monster);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveMonster(int id)
        {
            var monster = await _repository.GetMonsterAsync(id);
            if (monster is null)
                return BadRequest($"Monster with id={id} isn't exists");

            await _repository.RemoveMonsterAsync(monster);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMonster([FromBody] Monster updatedMonster)
        {
            var monster = await _repository.GetMonsterAsync(updatedMonster.Id);
            if (monster is null)
                return BadRequest($"Monster with id={updatedMonster.Id} isn't exists");

            monster = Utils.GetNew(updatedMonster);

            await _repository.UpdateMonsterAsync(monster);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomMonster()
        {
            return new JsonResult(await _repository.GetRandomMonster());
        }
    }

    internal static class Utils
    {
        public static Monster GetNew(Monster newMonster)
        {
            return new Monster
            {
                Name = newMonster.Name,
                AttackModifier = newMonster.AttackModifier,
                AttackPerRound = newMonster.AttackPerRound,
                ArmorClass = newMonster.ArmorClass,
                Damage = newMonster.Damage,
                DamageModifier = newMonster.DamageModifier,
                DiceType = newMonster.DiceType,
                HitPoints = newMonster.HitPoints,
                Weapon = newMonster.Weapon
            };
        }
    }
}