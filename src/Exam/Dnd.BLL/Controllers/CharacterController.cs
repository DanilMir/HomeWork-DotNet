using Dnd.BLL.Models;
using Dnd.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.BLL.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CharacterController : Controller
    {
        [HttpPost]
        public IActionResult CalculateCharacter([FromBody]CharacterModel character) => 
            new JsonResult(CharacterCalculator.CalculateCharacter(character));

}