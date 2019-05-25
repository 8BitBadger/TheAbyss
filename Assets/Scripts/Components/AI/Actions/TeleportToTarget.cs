using Comps;
using UnityEngine;

[CreateAssetMenu(menuName = "Comps/AI/Actions/Teleport to target")]
public class TeleportToTarget : Action
{
    public override void Act(AI controller)
    {
        Teleport(controller);
    }

    private void Teleport(AI controller)
    {
        //Seeds the random number generator to not give the same random result every time
        Random.InitState(Mathf.RoundToInt(Time.time));
        //Choose one of the random directions
        int direction = Random.Range(0, 7);
        //Set the angle for the chose direction
        float angle = direction * 45f;
        Vector2 target = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle)).normalized * controller.wanderDistance;
        RaycastHit2D[] hits = Physics2D.LinecastAll(controller.rb2d.position, target, controller.floorMask);
        controller.rb2d.position = hits[hits.Length - 1].transform.position;
        //Get al the floor tiles in the unit vecinity


        //NOTE: Later theis must be modified to teleport in the direction it was looking in
        //Collider2D[] floorColls =  Physics2D.OverlapCircleAll(controller.transform.position, 20, controller.floorMask);


        //Go through the tile until we get one that is more than 15 units away and then set the units position to that floor tiles position
        //for (int i = floorColls.Length - 1; i > 0 ; i--)
        //{
        //    if (Vector2.Distance(controller.transform.position, floorColls[i].transform.position) > 15)
        //    {
        //        controller.rb2d.position = floorColls[i].transform.position;
        //    }
        //}
    }
}


