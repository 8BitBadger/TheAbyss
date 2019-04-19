using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Comps;

namespace EventCallback
{
    public class DamageListener : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            DamageEvent.RegisterListener(OnDamaged);
        }

        // Update is called once per frame
        void OnDestroy()
        {
            DamageEvent.UnregisterListener(OnDamaged);
        }

       void OnDamaged(DamageEvent damage)
        {
            //GO must take damage
            if(damage.targetGO.GetComponent<Health>())
            {
                if(damage.baseGO.GetComponent<PlayerAttack>())
                {
                    damage.targetGO.GetComponent<Health>().TakeDamage(damage.baseGO.GetComponent<PlayerAttack>().damage);
                }
                else if (damage.baseGO.GetComponent<AI>())
                {
                    damage.targetGO.GetComponent<Health>().TakeDamage(damage.baseGO.GetComponent<AI>().damage);
                }
                //NOTE: Still have to determine the amount of damage base object will give
                damage.targetGO.GetComponent<Health>().TakeDamage(1);
            }
     
            //Play sound
            //Run Animation?
            //Particle Effect?
            
            
        }
    }
}
