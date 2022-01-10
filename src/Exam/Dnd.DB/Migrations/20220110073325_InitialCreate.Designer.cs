﻿// <auto-generated />
using Dnd.DB.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dnd.DB.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20220110073325_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dnd.DB.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArmorClass")
                        .HasColumnType("int");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("int");

                    b.Property<int>("AttackPerRound")
                        .HasColumnType("int");

                    b.Property<int>("CountOfAttack")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("int");

                    b.Property<int>("DiceType")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weapon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Dnd.DB.Models.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArmorClass")
                        .HasColumnType("int");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("int");

                    b.Property<int>("AttackPerRound")
                        .HasColumnType("int");

                    b.Property<int>("CountOfAttack")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("int");

                    b.Property<int>("DiceType")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weapon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Monsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmorClass = 7,
                            AttackModifier = 3,
                            AttackPerRound = 1,
                            CountOfAttack = 0,
                            Damage = 1,
                            DamageModifier = 0,
                            DiceType = 4,
                            HitPoints = 13,
                            Name = "Лемур",
                            Weapon = 0
                        },
                        new
                        {
                            Id = 2,
                            ArmorClass = 13,
                            AttackModifier = 10,
                            AttackPerRound = 1,
                            CountOfAttack = 0,
                            Damage = 4,
                            DamageModifier = 7,
                            DiceType = 8,
                            HitPoints = 126,
                            Name = "Мамонт",
                            Weapon = 0
                        },
                        new
                        {
                            Id = 3,
                            ArmorClass = 17,
                            AttackModifier = 9,
                            AttackPerRound = 3,
                            CountOfAttack = 0,
                            Damage = 2,
                            DamageModifier = 5,
                            DiceType = 6,
                            HitPoints = 135,
                            Name = "Аболет",
                            Weapon = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
