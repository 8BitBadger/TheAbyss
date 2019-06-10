using Comps;
using UnityEngine;

public static class GetWanderPoint
{
    public static Vector2 NewPoint(AI controller)
    {
        //TODO: Get a random direction to travel in in the 8 direction range
        //Choose one of the random directions
        int direction = CustomRnd.GetRnd(0, 7);
        //Set the angle for the chose direction
        float angle = direction * 45f;
        //The maximum distance of the hit for the walk collider
        float maxDistance = 0;
        //The new target to travel to
        Vector2 target;
        //The hit array for the circle casts 
        RaycastHit2D[] hits;

        //We convert the angle from degrees to a vector we can use for casting
        target = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle)).normalized * controller.wanderDistance;
        //We get where the obstacle is in the chosen direction
        RaycastHit2D obstacleHit = Physics2D.CircleCast(controller.rb2d.position, .5f, target, 10, controller.obstacleMask);
        Debug.Log("Hit obstacleHit name = " + obstacleHit.transform.name);
        Debug.Log("Hit obstacleHit distance = " + Vector2.Distance(controller.rb2d.position, obstacleHit.transform.position).ToString("F4"));
        //If the distance from the collider is greater than one
        if(Vector2.Distance(controller.rb2d.position, obstacleHit.transform.position) >= 1f)
        {
            //We get all the floor pieces that have been collided with up the the point of obstacleHits collision if there was any
            if (obstacleHit)
            {
                hits = Physics2D.CircleCastAll(controller.rb2d.position, .5f, obstacleHit.transform.position.normalized, 20, controller.floorMask);
            }
            else
            {
                direction = CustomRnd.GetRnd(0, 7);
                target = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle)).normalized * controller.wanderDistance;
                hits = Physics2D.CircleCastAll(controller.rb2d.position, .5f, target.normalized, 20, controller.floorMask);
            }
        }
        else
        {
            
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
    }
}