using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/AI/Decisions/In range of target")]
public class InRangeOfTarget : Decision
{
    public float range;

    public override bool Decide(StateController controller)
    {
        return InRange(controller);
    }

    private bool InRange(StateController controller)
    {
        if (Vector2.Distance(controller.rb2d.position, controller.target.position) < range)
        {
            return true;
        }

        return false;
    }
}
