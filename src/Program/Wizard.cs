public class Wizard
{
    private string _name;
    private int _health;
    private int _maxHealth;
    private SpellsBook _spellsBook;
    private Robe _robe;
    private Armor _armor;

    public Wizard(string name, int maxHealth)
    {
        this._name = name;
        this._maxHealth = maxHealth;
        this._health = maxHealth;
        this._spellsBook = null;
        this._robe = null;
        this._armor = null;
    }

    public string Name
    {
        get { return this._name; }
    }

    public int Health
    {
        get { return this._health; }
    }

    public int MaxHealth
    {
        get { return this._maxHealth; }
    }

    public SpellsBook SpellsBook
    {
        get { return this._spellsBook; }
    }

    public Robe Robe
    {
        get { return this._robe; }
    }

    public Armor Armor
    {
        get { return this._armor; }
    }

    public int CalculateAttack()
    {
        int totalAttack = 0;

        if (this._spellsBook != null)
        {
            totalAttack += this._spellsBook.CalculateAttack();
        }

        if (this._robe != null)
        {
            totalAttack += this._robe.AttackValue;
        }

        if (this._armor != null)
        {
            totalAttack += this._armor.AttackValue;
        }

        return totalAttack;
    }

    public int CalculateDefense()
    {
        int totalDefense = 0;

        if (this._spellsBook != null)
        {
            totalDefense += this._spellsBook.CalculateDefense();
        }

        if (this._robe != null)
        {
            totalDefense += this._robe.DefensiveValue;
        }

        if (this._armor != null)
        {
            totalDefense += this._armor.DefensiveValue;
        }

        return totalDefense;
    }

    public void EquipSpellsBook(SpellsBook spellsBook)
    {
        this._spellsBook = spellsBook;
    }

    public void RemoveSpellsBook()
    {
        this._spellsBook = null;
    }

    public void EquipRobe(Robe robe)
    {
        this._robe = robe;

        // Armor y Robe ocupan el mismo espacio de equipamiento.
        this._armor = null;
    }

    public void RemoveRobe()
    {
        this._robe = null;
    }

    public void EquipArmor(Armor armor)
    {
        this._armor = armor;

        // Armor y Robe ocupan el mismo espacio de equipamiento.
        this._robe = null;
    }

    public void RemoveArmor()
    {
        this._armor = null;
    }

    public void ReceiveAttack(int power)
    {
        // La defensa total del personaje reduce el daño recibido.
        int damage = power - this.CalculateDefense();

        if (damage < 0)
        {
            damage = 0;
        }

        this._health -= damage;

        if (this._health < 0)
        {
            this._health = 0;
        }
    }

    public void Cure()
    {
        // MaxHealth permite recuperar exactamente la vida inicial.
        this._health = this._maxHealth;
    }
}