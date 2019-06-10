using Comps;
using UnityEngine;

[CreateAssetMenu(menuName = "Comps/AI/Actions/Wander")]
public class Wander : Action
{
    public override void Act(AI controller)
    {
        Wandering(controller);
    }

    private void Wandering(AI controller)
    {
        if (Vector2.Distance(controller.rb2d.position, controller.wanderPoint) < 0.4f || controller.wanderPoint == Vector2.zero)
        {
            //TODO: Get a random direction to travel in in the 8 direction range
            //Choose one of the random directions
            int direction = CustomRnd.GetRnd(0, 7);
            //Set the angle for the chose direction
            float angle = direction * 45f;
            float maxDistance = 0;
            Vector2 target;
            RaycastHit2D[] hits;

            target = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle)).normalized * controller.wanderDistance;
            //We get where the obstacle is in the chosen direction
            //RaycastHit2D obstacleHit = Physics2D.CircleCast(controller.rb2d.position, .5f, target.normalized, 10, controller.obstacleMask);
            RaycastHit2D obstacleHit = Physics2D.Linecast(controller.rb2d.position, target, 10, controller.obstacleMask);
            Debug.Log("Hit obstacleHit name = " + obstacleHit.transform.name);
            Debug.Log("Hit obstacleHit distance = " + Vector2.Distance(controller.rb2d.position, obstacleHit.transform.position).ToString("F4"));
            //We get all the floor pieces that have been collided with up the the point of obstacleHits collision if there was any
            if (obstacleHit && Vector2.Distance(controller.rb2d.position, obstacleHit.transform.position) >= 1f)
            {
                hits = Physics2D.CircleCastAll(controller.rb2d.position, .5f, obstacleHit.transform.position.normalized, 10, controller.floorMask);
            }
            else
            {
                direction = CustomRnd.GetRnd(0, 7);
                target = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle)).normalized * controller.wanderDistance;
                hits = Physics2D.CircleCastAll(controller.rb2d.position, .5f, target.normalized, 20, controller.floorMask);
            }
            //Have to reset
            maxDistance = 0;

            //We loop through the hit list looking for the farthest of the collided tiles
            for (int i = hits.Length - 1; i > 1; i--)
            {
                Debug.Log("Hit targets name = " + hits[i].transform.name);
                float distance = Vector2.Distance(controller.rb2d.position, hits[i].transform.position);
                Debug.Log("Hit targets distance = " + distance);
                Debug.Log("Hit targets maxDistance = " + maxDistance);


                if (maxDistance < distance)
                {
                    maxDistance = distance;
                }
                else
                {
                    controller.wanderPoint = hits[i].transform.position;
                    break;
                }
            }
        }
         Vector2 normalizedDir = (controller.wanderPoint - controller.rb2d.position).normalized;
        controller.rb2d.MovePosition(controller.rb2d.position + normalizedDir * controller.GetComponent<Stats>().moveSpeed.Value * Time.deltaTime);
    }
}

