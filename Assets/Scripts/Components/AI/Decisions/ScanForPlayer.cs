using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Comps;

    [CreateAssetMenu(menuName = "Comps/AI/Decisions/Scan")]
    public class ScanForPlayer : Decision
    {
        float currentAngle = 36;

        public override bool Decide(AI controller)
        {
            return Scan(controller);
        }

        private bool Scan(AI controller)
        {
            //Scan 360 degrees around the unit for the target

            //Cast a collision circle only in the raduised area and on the target target mask, this is to check if the target is in the raduis to be able to pick it up
            Collider2D[] targetInViewRaduis = Physics2D.OverlapCircleAll(controller.rb2d.position, controller.viewRadius, controller.playerMask);

            for (int i = 0; i < currentAngle; i++)
            {
                if(i == 35)
                {
                    currentAngle = 0;
                }

            Transform rayCastTarget = targetInViewRaduis[i].transform;
            Vector2 dirToRaycast = (rayCastTarget.position - controller.gameObject.transform.position).normalized;
//Rotate the units view 
            if (Vector2.Angle(controller.gameObject.transform.right, dirToRaycast) < (controller.viewAngle + i * 10) / 2)
            {
                float distanceToTarget = Vector2.Distance(controller.gameObject.transform.position, rayCastTarget.position);

                if (!Physics2D.Raycast(controller.rb2d.position, dirToRaycast, distanceToTarget, controller.obstacleMask))
                {
                    controller.target = rayCastTarget;
                    controller.targetLastPosition = controller.target.position;

                    return true;
                }
            }
            }

            //Change animation of unit as his rotation changes
            //just put this in as a place holder
            return false;
        }
    }

