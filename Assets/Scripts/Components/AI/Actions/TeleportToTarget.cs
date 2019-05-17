using Comps;
using UnityEngine;

[CreateAssetMenu(menuName = "Comps/AI/Actions/Teleport to target")]
public class TeleportToTarget : Action
{
    //The position 
    Vector2 teleportPos;
    //If the position has not been found after 20 tries
    int tries;
    //Exit the loop
    bool exitLoop = false;

    public override void Act(AI controller)
    {
        Teleport(controller);
    }

    private void Teleport(AI controller)
    {
        //Set the fist teleport location
        teleportPos = GetRandomLocation();

        //Run through a loop to check if the teleport location is valid, if not we call the getrandom location again
        while (Physics2D.Linecast(teleportPos, teleportPos, controller.obstacleMask) || !exitLoop)
        {
            //Gets a random teleport location
            teleportPos = GetRandomLocation();
            //Incriment the amount of tries
            tries++;

            if (tries > 20) exitLoop = true;

        }

        controller.rb2d.MovePosition(teleportPos);
        //Resets the tries for locating a valid teleport location;
        tries = 0;
        exitLoop = false;

        //}

        //if (!Physics2D.CircleCast(controller.rb2d.position, .3f, teleportPos, controller.wanderDistance, controller.obstacleMask) && Vector2.Angle(controller.gameObject.transform.right, teleportPos.normalized) < controller.viewAngle / 2)
        //{

        //If the area is clear teleport the creature to the new target
        //controller.rb2d.MovePosition(teleportPos);
        //}
        //else
        //{
        //if (!Physics2D.CircleCast(controller.rb2d.position, .3f, new Vector2(Random.Range(10, 15),Random.Range(10, 15)), controller.wanderDistance, controller.obstacleMask))
        //{
        //If the area is clear teleport the creature to the new target
        //controller.rb2d.MovePosition(teleportPos);
        //}
        //}
    }

    private Vector2 GetRandomLocation()
    {
        // Get direction away from player
        //Vector2 dirToTeleport = (controller.rb2d.position - new Vector2(controller.target.position.x, controller.target.position.y)).normalized;
        Vector2 dirToTeleport = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
        //Get the teleport distance
        float teleportDistance = Random.Range(10, 20);
        //Set the teleport position
        return dirToTeleport * teleportDistance;
    }
}


