using Comps;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace EventCallback
{
    public class DamageListener : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            DamageEvent.RegisterListener(On_Damaged);
        }

        // Update is called once per frame
        void OnDestroy()
        {
            DamageEvent.UnregisterListener(On_Damaged);
        }

        private void On_Damaged(DamageEvent damageEvent)
        {
            //Check if the target object has the health script attached
            if (damageEvent.targetGO.GetComponent<Health>())
            {
                if (damageEvent.baseGO.tag == "Player")
                {
                    //damage.targetGO.GetComponent<Health>().TakeDamage(damage.baseGO.GetComponent<PlayerAttack>().damage);
                }
                else if (damageEvent.baseGO.tag == "Creature")
                {
                    //damage.targetGO.GetComponent<Health>().TakeDamage(damage.baseGO.GetComponent<AI>().damage);
                }
                //NOTE: Still have to determine the amount of damage base object will give
                //damageEvent.targetGO.GetComponent<Health>().TakeDamage(1);
            }
            else
            {
                Debug.LogError("The targe tobject does not have a Health script on it");
            }

            //Play sound
            //Run Animation?
            //Particle Effect?


        }
    }
}
