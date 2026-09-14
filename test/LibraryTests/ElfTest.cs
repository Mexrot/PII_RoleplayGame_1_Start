using NUnit.Framework;

[TestFixture]
public class ElfTests
{
    [Test]
    public void CalculateAttack_ElfWithSpellsBookAndRobe_ReturnsTotalAttack()
    {
        Spell spell1 = new Spell("Fireball", 30, 0);
        Spell spell2 = new Spell("Lightning", 20, 0);

        SpellsBook book = new SpellsBook();
        book.AddSpell(spell1);
        book.AddSpell(spell2);
        // Una tunica elfica: 12 de ataque y 15 de defensa
        Robe robe = new Robe("Tunica elfica", 12, 15);
        Elf elf = new Elf("Legolas", 100);
        elf.EquipSpellsBook(book);
        elf.EquipRobe(robe);

        // Ataque esperado: 50 (SpellBook) + 12 (Robe) = 62
        Assert.That(elf.CalculateAttack(), Is.EqualTo(62));

    }

    [Test]
    public void CalculateDefense_ElfWithEquippedItems_ReturnsTotalDefense()
    {
        Robe robe = new Robe("Tunica Elfica", 12, 15);
        Spell spell1 = new Spell("Shield", 0, 20);
        Spell spell2 = new Spell("Magic Barrier", 0, 15);

        SpellsBook book = new SpellsBook();
        book.AddSpell(spell1);
        book.AddSpell(spell2);

        Elf elf = new Elf("Legolas", 90);
        elf.EquipSpellsBook(book);
        elf.EquipRobe(robe);

        // Defensa esperada: 35 (SpellBook) + 15 (Robe) = 50
        Assert.That(elf.CalculateDefense(), Is.EqualTo(50));
    }

    [Test]
    public void ReceiveAttack_AttackGreaterThanDefense_ReducesHealth()
    {
        Spell shield = new Spell("Shield", 0, 20);

        SpellsBook book = new SpellsBook();
        book.AddSpell(shield);

        Robe robe = new Robe("Tunica Rota", 0, 10);
        Elf elf = new Elf("Legolas", 90);
        elf.EquipSpellsBook(book);
        elf.EquipRobe(robe);

        // Recibe ataque de 45. Daño neto = 45 - 30 (Defensa) = 15
        elf.ReceiveAttack(45);

        // Salud esperada: 90 - 15 = 75
        Assert.That(elf.Health, Is.EqualTo(75));
    }

    [Test]
    public void ReceiveAttack_DefenseGreaterThanAttack_DoesNotReduceHealth()
    {
        Robe robe = new Robe("Tunica Magica", 0, 30);

        Elf elf = new Elf("Legolas", 90);
        elf.EquipRobe(robe);

        // Recibe ataque de 20. Al tener 30 de defensa, el daño es 0
        elf.ReceiveAttack(20);

        Assert.That(elf.Health, Is.EqualTo(90));
    }

    [Test]
    public void ReceiveAttack_DamageGreaterThanHealth_HealthDoesNotGoBelowZero()
    {
        Elf elf = new Elf("Legolas", 90);

        // Recibe un ataque fatal sin armadura equipada
        elf.ReceiveAttack(150);

        Assert.That(elf.Health, Is.EqualTo(0));
    }

    [Test]
    public void Cure_DamagedDwarf_RestoresMaxHealth()
    {
        Elf elf = new Elf("Legolas", 90);

        elf.ReceiveAttack(40); // Salud baja a 50
        elf.Cure();

        Assert.That(elf.Health, Is.EqualTo(90));
    }

    [Test]
    public void EquipArmor_WhenRobeIsEquipped_UnequipsRobe()
    {
        Robe robe = new Robe("Túnica", 5, 10);
        Armor armor = new Armor("Placas", 0, 25);

        Dwarf dwarf = new Dwarf("Gimli", 120);
        dwarf.EquipRobe(robe);
        
        // Al equipar armadura, se desequipa la túnica
        dwarf.EquipArmor(armor);

        Assert.That(dwarf.Robe, Is.Null);
        Assert.That(dwarf.Armor, Is.EqualTo(armor));
    }
}