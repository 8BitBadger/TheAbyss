using UnityEngine;

[CreateAssetMenu(menuName = "Components/AI/Actions/Wander")]
public class WanderAction : Action
{
    Vector2 normalizedDir;
    int randomDirectionChanse;
    float newSpeed;

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

            randomDirectionChanse = Random.Range(1, 11);
           
            while (!validPath)
            {
                newPatrolPoint = new Vector2(Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.Obj.transform.position.x), Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.Obj.transform.position.y));

                Vector2 dirToRaycast = (new Vector3(newPatrolPoint.x, newPatrolPoint.y, 0) - controller.Obj.transform.position).normalized;
                //Check if the new patrol point is not collidiing with a wall or other colliders and if it is in the dirrection of its view angle.
                //If the randomDirectionChance is 1 then it will take that path even if it is not in its view path
                if (randomDirectionChanse != 1)
                {
                    if (!Physics2D.Linecast(controller.rb2d.position, newPatrolPoint, controller.obstacleMask) && Vector2.Angle(controller.Obj.transform.right, dirToRaycast) < controller.viewAngle / 2)
                    {
                        validPath = true;
                        controller.wanderPoint = newPatrolPoint;
                    }
                }
                else
                {
                    if (!Physics2D.Linecast(controller.rb2d.position, newPatrolPoint, controller.obstacleMask))
                    {
                        validPath = true;
                        controller.wanderPoint = newPatrolPoint;
                    }
                }
            }
        }
        else
        {
            //Get the normalized vector for the direction of travel
            normalizedDir = (controller.wanderPoint - controller.rb2d.position).normalized;
           
            //Here we calculate the units velocity based on its distance to the target witch slows down the closer it gets to the target and starts movement very fast
            controller.rb2d.velocity = Vector2.Lerp(controller.rb2d.position, normalizedDir, controller.Data.speed * Time.deltaTime);
        }
    }
}
