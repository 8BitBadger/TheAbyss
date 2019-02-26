using UnityEngine;


[CreateAssetMenu(menuName = "Components/AI/Actions/Wander")]
public class WanderAction : Action
{
    Vector2 normalizedDir;

    public override void Act(StateController controller)
    {
        Wander(controller);
    }

    private void Wander(StateController controller)
    {  
        if (Vector2.Distance(controller.rb2d.position, controller.wanderPoint) < 0.4f || controller.wanderPoint == Vector2.zero)
        {
            bool validPath = false;

            normalizedDir = Vector2.zero;

            Vector2 newPatrolPoint;

            while (!validPath)
            {
                newPatrolPoint = new Vector2(Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.Obj.transform.position.x), Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.Obj.transform.position.y));

                if (!Physics2D.Linecast(controller.rb2d.position, newPatrolPoint, controller.obstacleMask))
                {
                    validPath = true;
                    controller.wanderPoint = newPatrolPoint;
                }
            }

        }
        else
        {
            normalizedDir = (controller.wanderPoint - controller.rb2d.position).normalized;

            controller.rb2d.velocity = new Vector2(Mathf.Lerp(0, normalizedDir.x * controller.Data.speed, 0.8f), Mathf.Lerp(0, normalizedDir.y * controller.Data.speed, 0.8f));
        }
    }
}
