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
    //The game manager object
    GameObject gm;
    //The bool to check that the teleport position is in the bound of the map;
    bool inMapBounds;

    public override void Act(AI controller)
    {
        Teleport(controller);
    }

    private void Teleport(AI controller)
    {

        //Check if the gmaemanager object exists and that it has the map manager script
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<MapManager>())
        {
            gm = GameObject.FindGameObjectWithTag("GameManager");
        }
        else
        {
            Debug.LogError("TeleportToTarget - Could not find GameManager object");
        }

        //Gets a random teleport location
        teleportPos = GetRandomLocation();

        //Run through a loop to check if the teleport location is valid, if not we call the getrandom location again
        while (true)
        {


            //If the teleport position is ok then we force an exit out of the loop
            if (CheckPosition(controller))
            {
                Debug.Log("Breaking out of loop due to correct position");
                break;
            }

            //Incriment the amount of tries
            tries++;

            if (tries > 20)
            {
                Debug.Log("Breaking out of loop due to to many tries");
                break;
            }
            
            //Gets a random teleport location
            teleportPos = GetRandomLocation();

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

    private bool CheckPosition(AI controller)
    { //Check if the teleport position is inside of the maps bounds
        inMapBounds = gm.GetComponent<MapManager>().IsInMapBounds(teleportPos);
        if (!Physics2D.Linecast(teleportPos, teleportPos, controller.obstacleMask) && inMapBounds) return true;
        else return false;
    }
}


