using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallback;

namespace Comps
{
    public class HitDetection : MonoBehaviour
    {
        public LayerMask HitBoxMasks;
        //    private void OnCollisionEnter2D(Collision2D coll)
        //    {
        //        //NOTE: Really need a better way to check for the collisions

        //        //Start the call for the damage Event system
        //        DamageEvent damageEventInfo = new DamageEvent();
        //        //Since the hitbox is a child of the attacker object we need to return the parent object to the event system
        //        damageEventInfo.baseGO = transform.parent.gameObject;
        //        damageEventInfo.targetGO = coll.gameObject;
        //        damageEventInfo.FireEvent();
        //    }

        //private void OnTriggerEnter2D(Collider2D coll)
        //{
        //    //NOTE: Really need a better way to check for the collisions

        //    //Start the call for the damage Event system
        //    DamageEvent damageEventInfo = new DamageEvent();
        //    //Since the hitbox is a child of the attacker object we need to return the parent object to the event system
        //    damageEventInfo.baseGO = transform.parent.gameObject;
        //    damageEventInfo.targetGO = coll.gameObject;
        //    damageEventInfo.FireEvent();
        //}

        public void CheckForHit()
        {
            Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, 2f, 0, HitBoxMasks);

            if(coll.Length > 0)
            {
                Debug.Log("There was a hit");
            }
        }

        private void OnDrawGizmos()
        {
            Debug.Log("Drawing gizmo");
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 2);
        }
    }
}