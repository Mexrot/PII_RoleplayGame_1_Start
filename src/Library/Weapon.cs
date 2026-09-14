public class Weapon
{
    // Atributos privados
    private string _name;
    private int _attackValue;
    private int _defensiveValue;

    // Constructor que recibe tanto el valor de ataque como el valor defensivo
    public Weapon(string name, int attackValue, int defensiveValue)
    {
        this._name = name;
        this._attackValue = attackValue;
        this._defensiveValue = defensiveValue;
    }

    // Getters públicos de solo lectura
    public string Name
    {
        get { return this._name; }
    }

    public int AttackValue
    {
        get { return this._attackValue; }
    }

    public int DefensiveValue
    {
        get { return this._defensiveValue; }
    }
}