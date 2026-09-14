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
        }
    }
}
