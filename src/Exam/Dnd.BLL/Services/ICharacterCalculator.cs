using Dnd.BLL.Models;

namespace Dnd.BLL.Services
{
    public interface ICharacterCalculator
    {
        public CalculatedCharacterModel CalculateCharacter(CharacterModel character);
    }
}