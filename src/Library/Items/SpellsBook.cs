using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ucu.Poo.RoleplayGame;

public class SpellsBook: IMagicalAttackItem, IMagicalDefenseItem
{
    private List<ISpell> spells = new List<ISpell>();
    
    public ReadOnlyCollection<ISpell> Spells
    {
        get { return this.spells.AsReadOnly(); }
    }

    public int AttackValue
    {
        get
        {
            int value = 0;
            foreach (ISpell spell in this.spells)
            {
                value += spell.AttackValue;
            }
            return value;
        }
    }

    public int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (ISpell spell in this.spells)
            {
                value += spell.DefenseValue;
            }
            return value;
        }
    }

    public void AddSpell(ISpell spell)
    {
        this.spells.Add(spell);
    }

    public void RemoveSpell(ISpell spell)
    {
        this.spells.Remove(spell);
    }
}
