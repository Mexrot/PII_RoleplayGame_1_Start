public class Armor
{
    public string Name { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }

    public Armor(string name, int defenseValue, int attackValue)
    {
        Name = name;
        DefenseValue = defenseValue;
        AttackValue = attackValue;
    }
}