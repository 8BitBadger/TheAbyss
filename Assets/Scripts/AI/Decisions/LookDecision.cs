using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return Look(controller);
    }

    private bool Look(StateController controller)
    {
        //Cast a collision circle only in the raduised area and on the target target mask, this is to check if the target is in the raduis to be able to pick it up
        Collider2D[] targetInViewRaduis = Physics2D.OverlapCircleAll(controller.rb2d.position, controller.Data.viewRadius, controller.Data.targetLayer);

        //Loop through the targets that are in range of the fow
        for (int i = 0; i < targetInViewRaduis.Length; i++)
        {
            Transform rayCastTarget = targetInViewRaduis[i].transform;
            Vector2 dirToRaycast = (rayCastTarget.position - controller.Obj.transform.position).normalized;

            if (Vector2.Angle(controller.Obj.transform.right, dirToRaycast) < controller.Data.viewAngle / 2)
            {
                float distanceToTarget = Vector2.Distance(controller.Obj.transform.position, rayCastTarget.position);

                if (!Physics2D.Raycast(controller.rb2d.position, dirToRaycast, distanceToTarget, controller.Data.obstacleMask))
                {
                    controller.Data.chaseTarget = rayCastTarget;
                    controller.Data.lastSeenPoint = controller.Data.chaseTarget.position;

                    return true;
                }
            }
        }
        return false;
    }
}