using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallback;

namespace Comps
{
    public class HitDetection : MonoBehaviour
    {
        //Used to ignore the attacker so it doesn't cal damage event on itself
        public LayerMask maskToIngnore;
        private void OnTriggerStay2D(Collider2D other)
        {
            Debug.Log(other.name);
            Debug.Log(other.tag);
           
            //Check if the layer colliding with the trigger is not on the ingone layer mask whitch should be the parent object for the script
            if (other.gameObject.layer != maskToIngnore.value)
            {
                //Start the call for the damage Event system
                DamageEvent damageEventInfo = new DamageEvent();
                //Since the hitbox is a child of the attacker object we need to return the parent object to the event system
                damageEventInfo.baseGO = transform.parent.gameObject;
                damageEventInfo.targetGO = other.gameObject;
                damageEventInfo.FireEvent();
            }

        }
    }
}