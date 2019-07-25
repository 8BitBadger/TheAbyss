using UnityEngine;
using EventCallback;

namespace GameComponents
{
    [RequireComponent(typeof(Stats))]
    public class Health : MonoBehaviour
    {
        //We keep track of the damage that was dealt to the unit 
        float damage;

        //Allows us to quickly reset the health to the original value if the player levels up 
        public void ResetHealth()
        {
            damage = 0;
        }
        //Heals the object with this script added to it
        public void Heal(float heal)
        {
            if (damage > 0)
            {
                damage -= heal;
            }
        }
        //Deals damage to this object
        public void TakeDamage(float _damage)
        {
            damage += _damage;
            CheckHealth();
        }

        public void CheckHealth()
        {
            if (GetComponent<Stats>().health.Value - damage <= 0)
            {
                DeathEvent deathEventInfo = new DeathEvent();
                deathEventInfo.baseGO = gameObject;
                deathEventInfo.FireEvent();
            }
            //Send the callback event for the amount of health 
        }
    }
}