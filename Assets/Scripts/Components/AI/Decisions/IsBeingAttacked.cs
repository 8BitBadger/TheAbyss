using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameComponents;
using System;

[CreateAssetMenu(menuName = "GameComponents/AI/Decisions/Is being attacked")]
public class IsBeingAttacked : Decision
{
    public override bool Decide(AI controller)
    {
        return BeingAttacked(controller);
    }

    private bool BeingAttacked(AI controller)
    {
        //Check if the attacker is not null, if it isn't then the AI knows it is being attacked
        //The attacker value is set in the damage event that is how we know we are being attacked
        if(controller.attacker != null)
        {
            return true;
        }
        return false;
    }
}
