using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallback;

namespace Comps
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

    public Color inactiveColor,  collisionOpenColor, collidingColor;

    private ColliderState _state;

    private void Update()
    {
        if (_state == ColliderState.Closed) { return; }

            if(useSphere)
            {
                Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, radius, 0, HitBoxMasks);
            }
            else
            {
                Collider2D[] coll = Physics2D.OverlapBoxAll(transform.position, hitboxSize, 0, HitBoxMasks);
            }

        if (coll.Length > 0)
        {
            _state =  ColliderState.Colliding;
            // We should do something with the colliders
            Debug.Log("There was a hit");
            
        //    //Start the call for the damage Event system
        //    DamageEvent damageEventInfo = new DamageEvent();
        //    //Since the hitbox is a child of the attacker object we need to return the parent object to the event system
        //    damageEventInfo.baseGO = transform.parent.gameObject;
        //    damageEventInfo.targetGO = coll.gameObject;
        //    damageEventInfo.FireEvent();
        }
        else
        {
            _state =  ColliderState.Open;
        }
    }


        public void startCheckingCollision()
        {
            _state = ColliderState.Open;
        }

        public void stopCheckingCollision()
        {
            _state = ColliderState.Closed;
        }

        private void OnDrawGizmos()
        {
            checkGizmoColor()
            if(useSphere)
            {
                Gizmos.DrawWireSphere(transform.position, 2);
            }
            else
            {
                Gizmos.DrawWireSphere(transform.position, 2);
            }
            
        }

        private void checkGizmoColor()
        {
    switch(_state)
    {
        case ColliderState.Closed:
            Gizmos.color = inactiveColor;
        break;

        case ColliderState.Open:
            Gizmos.color = collisionOpenColor;
        break;

        case ColliderState.Colliding:
            Gizmos.color = collidingColor;
        break;
    }
}
    }
}