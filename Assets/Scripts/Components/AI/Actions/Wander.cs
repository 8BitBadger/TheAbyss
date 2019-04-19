using Comps;
using UnityEngine;

[CreateAssetMenu(menuName = "Comps/AI/Actions/Wander")]
public class Wander : Action
{
    Vector2 normalizedDir;
    float randomDirectionChanse;

    public override void Act(AI controller)
    {
        Wandering(controller);
    }

    private void Wandering(AI controller)
    {
        if (Vector2.Distance(controller.rb2d.position, controller.wanderPoint) < 0.4f || controller.wanderPoint == Vector2.zero)
        {
            bool validPath = false;

            normalizedDir = Vector2.zero;

            Vector2 newPatrolPoint;

            randomDirectionChanse = Random.Range(controller.wanderDistance - (controller.wanderDistance * 10) / 100, controller.wanderDistance);

            while (!validPath)
            {
                newPatrolPoint = new Vector2(Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.gameObject.transform.position.x), Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.gameObject.transform.position.y));

                Vector2 dirToRaycast = (new Vector3(newPatrolPoint.x, newPatrolPoint.y, 0) - controller.gameObject.transform.position).normalized;
                //Check if the new patrol point is not collidiing with a wall or other colliders and if it is in the dirrection of its view angle.
                //If the randomDirectionChance is 1 then it will take that path even if it is not in its view path
                if (randomDirectionChanse != 1)
                {
                    //if (!Physics2D.CircleCast(controller.rb2d.position, .3f, newPatrolPoint, controller.wanderDistance, controller.obstacleMask) && Vector2.Angle(controller.gameObject.transform.right, dirToRaycast) < controller.viewAngle / 2)
                    if (!Physics2D.Linecast(controller.rb2d.position, newPatrolPoint, controller.obstacleMask) && Vector2.Angle(controller.gameObject.transform.right, dirToRaycast) < controller.viewAngle / 2)
                    {
                        validPath = true;
                        controller.wanderPoint = newPatrolPoint;
                    }
                }
                else
                {   
                    //if(!Physics2D.CircleCast(controller.rb2d.position, .3f, newPatrolPoint, controller.wanderDistance, controller.obstacleMask))
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
            controller.rb2d.MovePosition(controller.rb2d.position + normalizedDir * controller.speed * Time.deltaTime);
        }
    }
}

