using UnityEngine;
using Comps;

[CreateAssetMenu(menuName = "Comps/AI/Decisions/Look for creatures")]
    public class LookForCreatures : Decision
    {
        public override bool Decide(AI controller)
        {
            return Look(controller);
        }

        private bool Look(AI controller)
        {
            //Cast a collision circle only in the raduised area and on the target target mask, this is to check if the target is in the raduis to be able to pick it up
            Collider2D[] targetInViewRaduis = Physics2D.OverlapCircleAll(controller.rb2d.position, controller.viewRadius, controller.creatureMask);

            //Loop through the targets that are in range of the fow
            for (int i = 0; i < targetInViewRaduis.Length; i++)
            {
                Transform rayCastTarget = targetInViewRaduis[i].transform;
                Vector2 dirToRaycast = (rayCastTarget.position - controller.gameObject.transform.position).normalized;

                if (Vector2.Angle(controller.gameObject.transform.right, dirToRaycast) < controller.viewAngle / 2)
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
            return false;
        }
    }
