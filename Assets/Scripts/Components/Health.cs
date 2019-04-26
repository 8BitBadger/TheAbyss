using UnityEngine;
using EventCallback;

namespace Comps
{
    public class Health : MonoBehaviour
    {
        //The base health unmodified
        public float baseHealth;
        //The helath after modifiers have been applied
        public float health;

        //Heals the object with this script added to it
        public void Heal(float heal)
        {
            health += heal;
        }
        //Deals damage to this object
        public void TakeDamage(float damage)
        {
            health -= damage;
            CheckHealth();
        }

        public void CheckHealth()
        {
            if (health <= 0)
            {
                DeathEvent deathEventInfo = new DeathEvent();
                deathEventInfo.baseGO = gameObject;
                deathEventInfo.FireEvent();
            }
        }
    }
}