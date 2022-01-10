using Dnd.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Dnd.DB.Repository
{
    public class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=dnd;Integrated Security=True");
        }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monster>().HasData(new Monster { 
                Id = 1,
                Name = "Лемур",
                HitPoints = 13,
                AttackModifier = 3,
                AttackPerRound = 1,
                Damage = 1,
                DiceType = 4,
                DamageModifier = 0,
                Weapon = 0,
                ArmorClass = 7
            });
            
            modelBuilder.Entity<Monster>().HasData(new Monster { 
                Id = 2,
                Name = "Мамонт",
                HitPoints = 126,
                AttackModifier = 10,
                AttackPerRound = 1,
                Damage = 4,
                DiceType = 8,
                DamageModifier = 7,
                Weapon = 0,
                ArmorClass = 13
            });
            
            modelBuilder.Entity<Monster>().HasData(new Monster { 
                Id = 3,
                Name = "Аболет",
                HitPoints = 135,
                AttackModifier = 9,
                AttackPerRound = 3,
                Damage = 2,
                DiceType = 6,
                DamageModifier = 5,
                Weapon = 0,
                ArmorClass = 17
            });
        }
    }
}