
public class Elf
{
    // Atributos privados

    private string _name;
    private int _health;
    private int _maxHealth;

    // Equipamiento actual del elfo
    private SpellsBook _spellsBook;
    private Weapon _weapon;
    private Robe _robe;
    private Armor _armor;

    // Constructor
    public Elf(string name, int initialHealth)
    {
        this._name = name;
        this._maxHealth = initialHealth;
        this._health = initialHealth;
        this._spellsBook = null;
        this._weapon = null;
        this._robe = null;
        this._armor = null;
    }
    //Propiedades Públicas
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
     public Weapon Weapon
    {
        get { return this._weapon; }
    }
    public Robe Robe
    {
        get { return this._robe; }
    }

    public Armor Armor
    {
        get { return this._armor; }
    }
    // Método que suma el ataque de todos los elementos equipados
     public int CalculateAttack()
    {
        int totalAttack = 0;

        if (this._spellsBook != null)
        {
            totalAttack += this._spellsBook.CalculateAttack();
        }

        if (this._weapon != null)
        {
            totalAttack += this._weapon.AttackValue;
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
    // Método que suma la defensa de todos los elementos equipados.
    public int CalculateDefense()
    {
        int totalDefense = 0;

        if (this._spellsBook != null)
        {
            totalDefense += this._spellsBook.CalculateDefense();
        }

        if (this._weapon != null)
        {
            totalDefense += this._weapon.DefensiveValue;
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

    //Gestión de equipamiento

    public void EquipSpellsBook(SpellsBook spellsBook)
    {
        this._spellsBook = spellsBook;
    }

    public void RemoveSpellsBook()
    {
        this._spellsBook = null;
    }
    public void EquipWeapon(Weapon weapon)
    {
        this._weapon = weapon;
    }

    public void RemoveWeapon()
    {
        this._weapon = null;
    }
    public void EquipRobe(Robe robe)
    {
        this._robe = robe;

        // Armor y Robe son mutuamente excluyentes
        this._armor = null;
    }
    public void RemoveRobe()
    {
        this._robe = null;
    }
    public void EquipArmor(Armor armor)
    {
        this._armor = armor;

        // Armor y Robe son mutuamente excluyentes
        this._robe = null;
    }

    public void RemoveArmor()
    {
        this._armor = null;
    }
    // Método que recibe un ataque y reduce la vida del elfo según su defensa.
    public void ReceiveAttack(int power)
    {
        int damage = power - this.CalculateDefense();

        // Si la defensa supera o iguala al ataque, el daño es 0
        if (damage < 0)
        {
            damage = 0;
        }
        //Evita que la salud del elfo sea negativa.
        this._health -= damage;

        if (this._health < 0)
        {
            this._health = 0;
        }
    }
    //Restaura la salud actual del elfo a su nivel máximo inicial
    public void Cure()
    {
        this._health = this._maxHealth;
    }
}