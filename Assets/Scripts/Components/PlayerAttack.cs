using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallback;

namespace Comps
{
    public class PlayerAttack : MonoBehaviour
    {
        //Used for the interval of the attacks, keeps track of last attack time
        private float timer;
        //The speed at witch the attacks repeat, will be calculater based on the agility and level of the player
        public float attackSpeed;
        //The damage the player does on each attack, will later be calculated by the charecters strenght and level
        //The layer the players are on
        public LayerMask creatures;
        //The layer the obstacles are on
        public LayerMask obstacles;

        void Update()
        {
            //Get the mouse input
            if (Input.GetMouseButton(0))
            {
                //Calculate the attackSpeed from the units stats
                attackSpeed = gameObject.GetComponent<Stats>().dexterity.Value * gameObject.GetComponent<Stats>().level;
                //Check the timer if it is time to attack
                if ((Time.time - timer) > attackSpeed)
                {
                    //Get the collision on the target in a circle
                    Collider2D hit = Physics2D.OverlapCircle(transform.position, 1, creatures);
                    if (hit != null)
                    {
                        //Create a new damage event information for this attack instance
                        DamageEvent damageEventInfo = new DamageEvent();
                        //Popu;ate the damage information with the target and attacker object
                        damageEventInfo.targetGO = hit.gameObject;
                        damageEventInfo.baseGO = gameObject;
                        //Fire of the damage event
                        damageEventInfo.FireEvent();

                        //Reset the timer for the next attack time check
                        timer = Time.time;
                    }
                }
            }
        }
    }
}