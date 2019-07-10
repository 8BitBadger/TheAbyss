using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatSystem;
using GameComponents;

public class Item : MonoBehaviour
{
    public void Equip(Stats character)
    {
        character.strength.AddModifier(new StatModifier(10, StatModType.Flat, this));
        character.strength.AddModifier(new StatModifier(.1f, StatModType.PercentMult, this));
    }

    public void Unequip(Stats character)
    {
        character.strength.RemoveAllModifiersFromSource(this);
    }
}
