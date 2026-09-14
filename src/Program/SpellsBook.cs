using System.Collections.Generic;

public class SpellsBook
{
    private List<Spell> _spells;
    public SpellsBook()
    {
        this._spells = new List<Spell>();
    }
    public List<Spell> Spells
    {
        get { return this._spells; }
    }
    public int CalculateAttack()
    {
        int totalAttack = 0;
        foreach (Spell spell in this._spells)
        {
            totalAttack += spell.AttackValue;
        }
        return totalAttack;
    }
    public int CalculateDefense()
    {
        int totalDefense = 0;
        foreach (Spell spell in this._spells)
        {
            totalDefense += spell.DefensiveValue;
        }
        return totalDefense;
    }
    public void AddSpell(Spell spell)
    {
        this._spells.Add(spell);
    }
    public void RemoveSpell(Spell spell)
    {
        this._spells.Remove(spell);
    }

}