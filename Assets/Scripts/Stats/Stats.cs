using UnityEngine;

namespace GameComponents
{
    public class Stats : MonoBehaviour
    {
        //The level of the charecter
        public float level;

        //The strength of the unit
        public CharacterStat strength;
        //The dexterity of the unit
        public CharacterStat dexterity;
        //The intelligence of the unit
        public CharacterStat intelligence;

        //THe move speed of the charecter
        [HideInInspector]
        public CharacterStat moveSpeed;
        //The attack speed of the unit
        [HideInInspector]
        public CharacterStat attackSpeed;
        //The damage the unit does
        [HideInInspector]
        public CharacterStat damage;
        //The health of the unit
        [HideInInspector]
        public CharacterStat health;

        private void Start()
        {
            //Set the base value for the move speed
            moveSpeed.baseValue = dexterity.Value * level;
            //Set the base value for the attack speed
            attackSpeed.baseValue = dexterity.Value * level;
            //Set the base value for the damage
            damage.baseValue = strength.Value * level;
            //Set the value of the health
            health.baseValue = strength.baseValue * level + 20; 
        }
    }
}

