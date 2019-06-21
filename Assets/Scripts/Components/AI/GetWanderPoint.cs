using Comps;
using UnityEngine;

public static class GetWanderPoint
{
    public static Vector2 NewPoint(AI controller)
    {
        //TODO: Get a random direction to travel in in the 8 direction range
        //Direction for traveling
        int direction;
        //The angle of travel
        float angle;
        //The new target to travel to
        Vector2 target;
        //The hit array for the circle casts 
        RaycastHit2D hit;
        //The collision for the obstical checker
        RaycastHit2D obstacleHit;

        while (true)
        {
            //Get a direction for travel
            direction = CustomRnd.GetRnd(0, 7);
            //Set the angle for the chose direction
            angle = direction * 45f;
            Debug.Log("Angle = " + angle);
            //We convert the angle from degrees to a vector we can use for casting
            target = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle)).normalized;
            Debug.Log("Target = " + target);
            //We get where the obstacle is in the chosen direction
            //obstacleHit = Physics2D.CircleCast(controller.rb2d.position, .2f, target, controller.wanderDistance , controller.obstacleMask);
            obstacleHit = Physics2D.Linecast(controller.rb2d.position, target * controller.wanderDistance, controller.obstacleMask);
            //If the distance from the collider is greater than one we have a valid hit so we can exit out of the loop
            if (obstacleHit)
            {
                if (Vector2.Distance(controller.rb2d.position, obstacleHit.transform.position) >= 1f)
                {
                    //We know we hit ab obstacle so we raycast from the obstacle back to the player and get the first valid tile
                    //hit = Physics2D.CircleCast(obstacleHit.transform.position, .2f, controller.rb2d.position.normalized, controller.wanderDistance, controller.floorMask);
                    hit = Physics2D.Linecast(obstacleHit.transform.position, controller.rb2d.position, controller.floorMask);
                }
                break;
            }
            else
            {
                //If we didn't hit an obstacle we go in the direction of te target at the max wander distance for the unit
                //hit = Physics2D.CircleCast(target * controller.wanderDistance, .2f, controller.rb2d.position.normalized, controller.wanderDistance, controller.floorMask);
                hit = Physics2D.Linecast(target * controller.wanderDistance, controller.rb2d.position, controller.floorMask);
                break;
            }
        }
        //return hit.transform.position;
        return Vector2.zero;
    }
}
