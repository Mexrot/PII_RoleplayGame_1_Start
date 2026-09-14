
public class Dwarf
{
    // Atributos
    public string Name { get; set; }
    public int Health { get; set; }
    private int InitialHealth { get; set; }
    public Weapon Weapon { get; set; }
    public Robe Robe { get; set; }
    public Armor Armor { get; set; }

    public Dwarf(string name)
    {
        Name = name;
        InitialHealth = 120; // Valor inicial por defecto
        Health = InitialHealth;
    }

    // Calcula el ataque total sumando el de todos los objetos equipados
    public int AttackValue
    {
        get
        {
            int total = 0;
            if (Weapon != null) total += Weapon.AttackValue;
            if (Robe != null) total += Robe.AttackValue;
            if (Armor != null) total += Armor.AttackValue;
            return total;
        }
    }

    // Calcula la defensa total sumando la de todos los objetos equipados
    public int DefenseValue
    {
        get
        {
            int total = 0;
            if (Weapon != null) total += Weapon.DefenseValue;
            if (Robe != null) total += Robe.DefenseValue;
            if (Armor != null) total += Armor.DefenseValue;
            return total;
        }
    }

    public void ReceiveAttack(int power)
    {
        int damage = power - DefenseValue;
        if (damage > 0)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }
    }

    public void Cure()
    {
        Health = InitialHealth;
    }
}