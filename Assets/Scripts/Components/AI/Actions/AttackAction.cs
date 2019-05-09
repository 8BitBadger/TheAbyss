﻿using UnityEngine;
using Comps;
using EventCallback;

[CreateAssetMenu(menuName = "Comps/AI/Actions/Attack")]
public class AttackAction : Action
{

    public override void Act(AI controller)
    {
        //TODO: Make it so sprite is showing in the general direction of the player

        Attack(controller);
    }

    private void Attack(AI controller)
    {
        if ((Time.time - controller.attackTimer) > controller.GetComponent<Stats>().attackSpeed.Value)
        {

            //We enable the hitbox to check for collisions for the weapon
            controller.weaponHitBox.SetActive(true);

            //NOTE: play attack animation from here

            //Call to the attack event callback system
            AttackEvent attackEventInfo = new AttackEvent();
            attackEventInfo.baseGO = controller.gameObject;
            attackEventInfo.FireEvent();
            //Reset the timer for the next attack time check
            controller.attackTimer = Time.time;
        }
        //Check the timer if it is time to attack
        if ((Time.time - controller.attackTimer) > controller.gameObject.GetComponent<Stats>().attackSpeed.Value)
        {
            //We disable the hitbox when the timer for the attack has run down
            controller.weaponHitBox.SetActive(false);
        }
    }
}

