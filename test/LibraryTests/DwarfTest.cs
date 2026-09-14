using NUnit.Framework;

[TestFixture]
public class DwarfTests
{
    [Test]
    public void CalculateAttack_DwarfWithWeaponAndArmor_ReturnsTotalAttack()
    {
        // Un hacha con 30 de ataque y 5 de defensa
        Weapon axe = new Weapon("Hacha Pesada", 30, 5);
        // Una armadura con pinchos: 8 de ataque y 20 de defensa
        Armor armor = new Armor("Armadura de Pinchos", 8, 20);

        Dwarf dwarf = new Dwarf("Gimli", 120);
        dwarf.EquipWeapon(axe);
        dwarf.EquipArmor(armor);

        // Ataque esperado: 30 (Weapon) + 8 (Armor) = 38
        Assert.That(dwarf.CalculateAttack(), Is.EqualTo(38));
    }

    [Test]
    public void CalculateDefense_DwarfWithEquippedItems_ReturnsTotalDefense()
    {
        Weapon axe = new Weapon("Hacha Pesada", 30, 5);
        Armor armor = new Armor("Armadura de Hierro", 0, 25);

        Dwarf dwarf = new Dwarf("Gimli", 120);
        dwarf.EquipWeapon(axe);
        dwarf.EquipArmor(armor);

        // Defensa esperada: 5 (Weapon.DefensiveValue) + 25 (Armor.DefensiveValue) = 30
        Assert.That(dwarf.CalculateDefense(), Is.EqualTo(30));
    }

    [Test]
    public void ReceiveAttack_AttackGreaterThanDefense_ReducesHealth()
    {
        Armor armor = new Armor("Escudo de Madera", 0, 15);

        Dwarf dwarf = new Dwarf("Gimli", 120);
        dwarf.EquipArmor(armor);

        // Recibe ataque de 45. Daño neto = 45 - 15 (Defensa) = 30
        dwarf.ReceiveAttack(45);

        // Salud esperada: 120 - 30 = 90
        Assert.That(dwarf.Health, Is.EqualTo(90));
    }

    [Test]
    public void ReceiveAttack_DefenseGreaterThanAttack_DoesNotReduceHealth()
    {
        Armor armor = new Armor("Armadura Pesada", 0, 40);

        Dwarf dwarf = new Dwarf("Gimli", 120);
        dwarf.EquipArmor(armor);

        // Recibe ataque de 20. Al tener 40 de defensa, el daño es 0
        dwarf.ReceiveAttack(20);

        Assert.That(dwarf.Health, Is.EqualTo(120));
    }

    [Test]
    public void ReceiveAttack_DamageGreaterThanHealth_HealthDoesNotGoBelowZero()
    {
        Dwarf dwarf = new Dwarf("Gimli", 120);

        // Recibe un ataque fatal sin armadura equipada
        dwarf.ReceiveAttack(200);

        Assert.That(dwarf.Health, Is.EqualTo(0));
    }

    [Test]
    public void Cure_DamagedDwarf_RestoresMaxHealth()
    {
        Dwarf dwarf = new Dwarf("Gimli", 120);

        dwarf.ReceiveAttack(50); // Salud baja a 70
        dwarf.Cure();

        Assert.That(dwarf.Health, Is.EqualTo(120));
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