using UnityEngine;
using StatSystem;

namespace Comps
{
    public class Stats : MonoBehaviour
    {
        //The level of the charecter
        public float level;
        //The health of the unit
        public CharacterStat health;
        //The strength of the unit
        public CharacterStat strength;
        //The dexterity of the unit
        public CharacterStat dexterity;
        //The intelligence of the unit
        public CharacterStat intelligence;

        //The movement speed of the unit
        private float moveSpeed;
        //The attack speed of the unit
        private float attackSpeed;
        //The damage of the unit
        private float damage;

        public float GetMoveSpeed()
        {
            moveSpeed = dexterity.Value * level;
            return moveSpeed;
        }
        public float GetAttackSpeed()
        {
            attackSpeed = dexterity.Value * level;
            return attackSpeed;
        }
        public float GetHealth()
        {
            return health.Value;
        }
        public float GetDamage()
        {
            damage = strength.Value * level;
            return damage;
        }
    }
}

