public class Weapon
{
    public string Name { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }

    public Weapon(string name, int attackValue, int defenseValue = 0)
    {
        Name = name;
        AttackValue = attackValue;
        DefenseValue = defenseValue;
    }
}