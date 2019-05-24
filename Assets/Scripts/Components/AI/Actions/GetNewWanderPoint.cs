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
        if (controller.gotNewDirection == true) return;
   
            Vector2 newPatrolPoint;

            while (true)
            {
                newPatrolPoint = new Vector3(Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.gameObject.transform.position.x), Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.gameObject.transform.position.y),0f);

<<<<<<< HEAD
                Vector2 dirToRaycast = (newPatrolPoint - new Vector2(controller.gameObject.transform.position.x, controller.gameObject.transform.position.x)).normalized;
=======
                Vector2 dirToRaycast = (newPatrolPoint - controller.gameObject.transform.position).normalized;
>>>>>>> e8068b526ea8e40d88b9083bee04569e38e48dc6

                if (!Physics2D.Linecast(controller.rb2d.position, newPatrolPoint, controller.obstacleMask) && Vector2.Angle(controller.gameObject.transform.right, dirToRaycast) < controller.viewAngle / 2)
                {
                    controller.gotNewDirection = true;
                    controller.wanderPoint = newPatrolPoint;
                    break;
                }
            }
    }
}