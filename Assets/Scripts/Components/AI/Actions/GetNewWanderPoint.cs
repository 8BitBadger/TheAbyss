using Comps;
using UnityEngine;

[CreateAssetMenu(menuName = "Comps/AI/Decisions/New Wander Point")]
public class GetNewWanderPoint : Decision
{
    public override bool Decide(AI controller)
    {
        return NewWanderPoint(controller);
    }

    private bool NewWanderPoint(AI controller)
    {
        //TODO: Get a random direction to travel in in the 8 direction range
        //Choose one of the random directions
        Random.InitState(Mathf.RoundToInt(Time.time));
        int direction = Random.Range(0, 7);
        //Set the angle for the chose direction
        float angle = direction * 45f;
        float maxDistance = 0;
        Vector2 target;
        RaycastHit2D[] hits;

        target = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle)).normalized * controller.wanderDistance;
        //We get where the obstacle is in the chosen direction
        RaycastHit2D obstacleHit = Physics2D.CircleCast(controller.rb2d.position, .5f, target.normalized, 20, controller.obstacleMask);
        Debug.Log("Hit obstacleHit name = " + obstacleHit.transform.name);
        Debug.Log("Hit obstacleHit distance = " + Vector2.Distance(controller.rb2d.position, obstacleHit.transform.position).ToString("F4"));
        //We get all the floor pieces that have been collided with up the the point of obstacleHits collision if there was any
        if (obstacleHit && Vector2.Distance(controller.rb2d.position, obstacleHit.transform.position) >= 1f)
        {
            hits = Physics2D.CircleCastAll(controller.rb2d.position, .5f, obstacleHit.transform.position.normalized, 20, controller.floorMask);
        }
        else
        {
            direction = Random.Range(0, 7);
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

            if (maxDistance < distance)
            {
                maxDistance = distance;
            }
            else
            {
                controller.wanderPoint = hits[i].transform.position;
                return true;
            }
        }
        return false;

        //Vector3 newPatrolPoint;

        //while (true)
        //{
        //    newPatrolPoint = new Vector3(Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.gameObject.transform.position.x), Mathf.RoundToInt(Random.Range(-(controller.wanderDistance + 1), controller.wanderDistance) + controller.gameObject.transform.position.y), 0f);

        //    Vector2 dirToRaycast = (newPatrolPoint - controller.gameObject.transform.position).normalized;

        //    if (!Physics2D.Linecast(controller.rb2d.position, newPatrolPoint, controller.obstacleMask) && Vector2.Angle(controller.gameObject.transform.right, dirToRaycast) < controller.viewAngle / 2)
        //    {
        //        controller.gotNewDirection = true;
        //        controller.wanderPoint = newPatrolPoint;
        //        return true;
        //    }
        //}
    }
}