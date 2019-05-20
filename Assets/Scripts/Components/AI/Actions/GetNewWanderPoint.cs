using Comps;
using UnityEngine;

[CreateAssetMenu(menuName = "Comps/AI/Actions/New Wander Point")]
public class GetNewWanderPoint : Action
{
    public override void Act(AI controller)
    {
        NewWanderPoint(controller);
    }

    private void NewWanderPoint(AI controller)
    {
        if (controller.gotNewDirection == false)
        {
            bool validPath = false;

            Vector2 newPatrolPoint;

            while (!validPath)
            {
                newPatrolPoint = new Vector2(Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.gameObject.transform.position.x), Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.gameObject.transform.position.y));

                Vector2 dirToRaycast = (new Vector3(newPatrolPoint.x, newPatrolPoint.y, 0) - controller.gameObject.transform.position).normalized;

                if (!Physics2D.Linecast(controller.rb2d.position, newPatrolPoint, controller.obstacleMask) && Vector2.Angle(controller.gameObject.transform.right, dirToRaycast) < controller.viewAngle / 2)
                {
                    controller.gotNewDirection = true;
                    validPath = true;
                    controller.wanderPoint = newPatrolPoint;
                }
            }
        }
    }
}

