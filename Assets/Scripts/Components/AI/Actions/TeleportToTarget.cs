using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/AI/Actions/Teleport to target")]
public class TeleportToTarget : Action
{
    //The position 
    Vector2 teleportPos;

    public override void Act(StateController controller)
    {
        Teleport(controller);
    }

    private void Teleport(StateController controller)
    {
        // Get direction away from player
        Vector2 dirToTeleport = (controller.rb2d.position - new Vector2(controller.target.position.x, controller.target.position.y)).normalized;
        //Get the teleport distance
        float teleportDistance = Random.Range(10, 20);
        //Set the teleport position
        teleportPos = dirToTeleport * teleportDistance;
        //Check if the area is clear
        if (!Physics2D.Linecast(controller.rb2d.position, teleportPos, controller.obstacleMask))
        {
            //If the area is clear teleport the creature to the new target
            controller.rb2d.MovePosition(teleportPos);
        }
    }

}
