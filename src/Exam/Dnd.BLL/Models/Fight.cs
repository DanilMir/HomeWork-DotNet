using System;
using System.Collections.Generic;
using Dnd.BLL.Services;

namespace Dnd.BLL.Models
{
    public class Fight
    {
        public Guid FightId { get; set; }
        public CalculatedCharacterModel Player { get; set; }
        public CalculatedCharacterModel Monster { get; set; }
        // public bool? PlayerWon { get; set; }
        public FightStatus FightStatus { get; set; }
        
        public List<string> Log { get; set; }
    }
}