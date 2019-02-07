using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatSystem;

public class Item : MonoBehaviour
{
    public void Equip(Character character)
    {
        character.Strength.AddModifier(new StatModifier(10, StatModType.Flat, this));
        character.Strength.AddModifier(new StatModifier(.1f, StatModType.PercentMult, this));
    }

    public void Unequip(Character character)
    {
        character.Strength.RemoveAllModifiersFromSource(this);
    }
}
