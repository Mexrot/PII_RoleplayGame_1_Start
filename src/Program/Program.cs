//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.RolePlayGame
{
    /// <summary>
    /// Programa principal.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main(string[] args)
        {
            Spell fireball = new Spell("Fireball", 30, 0);

            Spell magicShield = new Spell("Magic Shield", 0, 15);

            SpellsBook book = new SpellsBook();

            book.AddSpell(fireball);

            book.AddSpell(magicShield);

            Wizard wizard = new Wizard("Gandalf", 100);

            wizard.EquipSpellsBook(book);

            Console.WriteLine("Wizard: " + wizard.Name);

            Console.WriteLine("Health: " + wizard.Health);

            Console.WriteLine("Attack: " + wizard.CalculateAttack());

            Console.WriteLine("Defense: " + wizard.CalculateDefense());

            Console.WriteLine();

            Console.WriteLine("Gandalf receives an attack of 40.");

            wizard.ReceiveAttack(40);

            Console.WriteLine("Health after attack: " + wizard.Health);

            Console.WriteLine();

            Console.WriteLine("Gandalf is cured.");

            wizard.Cure();

            Console.WriteLine("Health after cure: " + wizard.Health);

            // Creación del enano y de sus equipamientos
            
            Weapon axe = new Weapon("Hacha Pesada", 30, 5);
            Armor armor = new Armor("Armadura de Hierro", 8, 20);

            Dwarf dwarf = new Dwarf("Gimli", 120);

            // Equipamiento del personaje
            dwarf.EquipWeapon(axe);
            dwarf.EquipArmor(armor);

            // Mostrar estadísticas iniciales
            Console.WriteLine("Dwarf: " + dwarf.Name);
            Console.WriteLine("Health: " + dwarf.Health);
            Console.WriteLine("Attack: " + dwarf.CalculateAttack());
            Console.WriteLine("Defense: " + dwarf.CalculateDefense());
            Console.WriteLine();

            // Simulación de ataque recibido
            Console.WriteLine("Gimli receives an attack of 40.");
            dwarf.ReceiveAttack(40);
            Console.WriteLine("Health after attack: " + dwarf.Health);
            Console.WriteLine();

            // Simulación de curación
            Console.WriteLine("Gimli is cured.");
            dwarf.Cure();
            Console.WriteLine("Health after cure: " + dwarf.Health);

            // Creación del elfo y de sus equipamientos
    
            Elf elf = new Elf("Legolas", 90);
            Robe robe = new Robe("Tunica Elfica", 12, 15);

            // Equipamiento del personaje
            elf.EquipSpellsBook(book);
            elf.EquipRobe(robe);

            // Mostrar estadísticas iniciales
            Console.WriteLine("Elf: " + elf.Name);
            Console.WriteLine("Health: " + elf.Health);
            Console.WriteLine("Attack: " + elf.CalculateAttack());
            Console.WriteLine("Defense: " + elf.CalculateDefense());
            Console.WriteLine();

            // Simulación de ataque recibido
            Console.WriteLine("Legolas receives an attack of 40.");
            elf.ReceiveAttack(40);
            Console.WriteLine("Health after attack: " + elf.Health);
            Console.WriteLine();

            // Simulación de curación
            Console.WriteLine("Legolas is cured.");
            elf.Cure();
            Console.WriteLine("Health after cure: " + elf.Health);
        }
    }
}
