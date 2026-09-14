using NUnit.Framework;

[TestFixture]
public class WizardTests
{
    [Test]
    public void CalculateAttack_WizardWithSpellsBook_ReturnsTotalAttack()
    {
        Spell spell1 = new Spell("Fireball", 30, 0);
        Spell spell2 = new Spell("Lightning", 20, 0);

        SpellsBook book = new SpellsBook();
        book.AddSpell(spell1);
        book.AddSpell(spell2);

        Wizard wizard = new Wizard("Gandalf", 100);
        wizard.EquipSpellsBook(book);

        Assert.That(wizard.CalculateAttack(), Is.EqualTo(50));
    }

    [Test]
    public void CalculateDefense_WizardWithSpellsBook_ReturnsTotalDefense()
    {
        Spell spell1 = new Spell("Shield", 0, 20);
        Spell spell2 = new Spell("Magic Barrier", 0, 15);

        SpellsBook book = new SpellsBook();
        book.AddSpell(spell1);
        book.AddSpell(spell2);

        Wizard wizard = new Wizard("Gandalf", 100);
        wizard.EquipSpellsBook(book);

        Assert.That(wizard.CalculateDefense(), Is.EqualTo(35));
    }

    [Test]
    public void ReceiveAttack_AttackGreaterThanDefense_ReducesHealth()
    {
        Spell shield = new Spell("Shield", 0, 20);

        SpellsBook book = new SpellsBook();
        book.AddSpell(shield);

        Wizard wizard = new Wizard("Gandalf", 100);
        wizard.EquipSpellsBook(book);

        wizard.ReceiveAttack(50);

        Assert.That(wizard.Health, Is.EqualTo(70));
    }

    [Test]
    public void ReceiveAttack_DefenseGreaterThanAttack_DoesNotReduceHealth()
    {
        Spell shield = new Spell("Shield", 0, 30);

        SpellsBook book = new SpellsBook();
        book.AddSpell(shield);

        Wizard wizard = new Wizard("Gandalf", 100);
        wizard.EquipSpellsBook(book);

        wizard.ReceiveAttack(20);

        Assert.That(wizard.Health, Is.EqualTo(100));
    }

    [Test]
    public void ReceiveAttack_DamageGreaterThanHealth_HealthDoesNotGoBelowZero()
    {
        Wizard wizard = new Wizard("Gandalf", 100);

        wizard.ReceiveAttack(150);

        Assert.That(wizard.Health, Is.EqualTo(0));
    }

    [Test]
    public void Cure_DamagedWizard_RestoresMaxHealth()
    {
        Wizard wizard = new Wizard("Gandalf", 100);

        wizard.ReceiveAttack(40);
        wizard.Cure();

        Assert.That(wizard.Health, Is.EqualTo(100));
    }
}