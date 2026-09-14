public class Spell
{
    private string _name;

    private int _defensiveValue;

    private int _attackValue;

    public Spell(string name, int attackValue, int defensiveValue)
    {
        this._name = name;
        this._attackValue = attackValue;
        this._defensiveValue = defensiveValue;
    }

    public string Name
    {
        get { return this._name; }
    }

    public int DefensiveValue
    {
        get { return this._defensiveValue; }
    }

    public int AttackValue
    {
        get { return this._attackValue; }
    }
}