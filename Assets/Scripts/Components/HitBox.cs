using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallback;

namespace GameComponents
{
    public enum ColliderState
    {
        Closed,
        Open,
        Colliding
    };

    public class HitBox : MonoBehaviour
    {
        public bool useSphere = false;

        public LayerMask HitBoxMasks;

        public Vector3 hitboxSize = Vector3.one;

        public float radius = 0.5f;

        public Color inactiveColor, collisionOpenColor, collidingColor;

        private ColliderState state;

        //Start the call for the damage Event system
        DamageEvent damageEventInfo = new DamageEvent();

        private void Start()
        {
            //Init the collider to inactive when object is spawned
            state = ColliderState.Closed;
            damageEventInfo.eventName = "damageEvent";
        }

        private void Update()
        {
            if (state == ColliderState.Closed) { return; }

            Collider2D[] coll;

            if (useSphere)
            {
                coll = Physics2D.OverlapCircleAll(transform.position, radius, HitBoxMasks);
            }
            else
            {
                coll = Physics2D.OverlapBoxAll(transform.position, hitboxSize, 0, HitBoxMasks);
            }

            if (coll.Length > 0)
            {
                //Change the state of the collider when collisions where detected
                state = ColliderState.Colliding;

                //Work bacwards through the list to remove the collider
                //Working backward through the list ensures us that we do not delete an entry infront and crash the loop while trying to access an entry that does not exist anymore.
                for (int i = coll.Length - 1; i >= 0; i--)
                {


                    //Since the hitbox is a child of the attacker object we need to return the parent object to the event system
                    damageEventInfo.baseGO = transform.parent.gameObject;
                    damageEventInfo.targetGO = coll[i].gameObject;
                    damageEventInfo.FireEvent();
                }

                //We stop checking the colision so we dont register the hit anymore
                stopCheckingCollision();

            }
            else
            {
                state = ColliderState.Open;
            }
        }
        public void startCheckingCollision()
        {
            state = ColliderState.Open;
        }
        public void stopCheckingCollision()
        {
            state = ColliderState.Closed;
        }
    }
}