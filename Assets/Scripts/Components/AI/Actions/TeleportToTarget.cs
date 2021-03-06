﻿using GameComponents;
using UnityEngine;

[CreateAssetMenu(menuName = "GameComponents/AI/Actions/Teleport to target")]
public class TeleportToTarget : Action
{
    public override void Act(AI controller)
    {
        Teleport(controller);
    }

    private void Teleport(AI controller)
    {
        int direction = CustomRnd.GetRnd(0, 7);
        //Set the angle for the chose direction
        float angle = direction * 45f;
        Vector2 target = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle)).normalized * controller.wanderDistance;
        RaycastHit2D[] hits = Physics2D.LinecastAll(controller.rb2d.position, target, controller.floorMask);
        controller.rb2d.position = hits[hits.Length - 1].transform.position;
        //Get al the floor tiles in the unit vecinity
    }
}


