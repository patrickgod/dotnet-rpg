using System.Collections.Generic;
using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(user => user.Role).HasDefaultValue("Player");

            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Fireball", Damage = 30 },
                new Skill { Id = 2, Name = "Frenzy", Damage = 20 },
                new Skill { Id = 3, Name = "Blizzard", Damage = 50 }
            );

            Utility.CreatePasswordHash("123456", out byte[] passwordHash, out byte[] passwordSalt);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "User1" },
                new User { Id = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "User2" }
            );

            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    Name = "Frodo",
                    Class = RpgClass.Knight,
                    HitPoints = 100,
                    Strength = 15,
                    Defense = 10,
                    Intelligence = 10,
                    UserId = 1
                },
                new Character
                {
                    Id = 2,
                    Name = "Raistlin",
                    Class = RpgClass.Mage,
                    HitPoints = 100,
                    Strength = 5,
                    Defense = 5,
                    Intelligence = 20,
                    UserId = 2
                }
            );

            modelBuilder.Entity<Weapon>().HasData(
                new Weapon { Id = 1, Name = "The Master Sword", Damage = 20, CharacterId = 1 },
                new Weapon { Id = 2, Name = "Crystal Wand", Damage = 5, CharacterId = 2 }
            );

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("CharacterSkill")
                .HasData(
                    new { CharactersId = 1, SkillsId = 2 },
                    new { CharactersId = 2, SkillsId = 1 },
                    new { CharactersId = 2, SkillsId = 3 });
        }
    }
}