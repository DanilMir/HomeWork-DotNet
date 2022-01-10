using System.Collections.Generic;
using System.Threading.Tasks;
using Dnd.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Dnd.DB.Repository
{
    public class MonsterRepository
    {
        private readonly AppContext _context;

        public MonsterRepository(AppContext context) =>
            _context = context;

        public async Task<IEnumerable<Monster?>> GetAllMonsters() =>
            await _context.Monsters.ToListAsync();

        public async Task<Monster?> GetMonsterAsync(int id) =>
            await _context.Monsters.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Monster?> GetMonsterAsync(string name) =>
            await _context.Monsters.FirstOrDefaultAsync(c => c.Name == name);

        public async Task AddMonsterAsync(Monster monster)
        {
            _context.Monsters.Add(monster);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMonsterAsync(Monster monster)
        {
            _context.Monsters.Remove(monster);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMonsterAsync(Monster monster)
        {
            _context.Monsters.Update(monster);
            await _context.SaveChangesAsync();
        }
    }
}