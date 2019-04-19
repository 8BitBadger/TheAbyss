using Comps;
using EventCallback;
using UnityEngine;

[CreateAssetMenu(menuName = "Comps/AI/Actions/Consume Crystal")]
public class ConsumeCrystal : Action
{
    //The inteval at which the crystal must be consumed, this will stay the same and wil not be sped up by any stat modification
    public float consumeSpeed;

    public override void Act(AI controller)
    {
        Consume(controller);
    }

    private void Consume(AI controller)
    {
        //NOTE: Call health class or ability and subtract health from it he crystal
        if ((Time.time - controller.ConsumeSpeed) > consumeSpeed)
        {
            //Create a new damage event info
            DamageEvent damageEventInfo = new DamageEvent();
            //The target object that is being consumed
            damageEventInfo.targetGO = controller.target.gameObject;
            //The Object that is consuming the target
            damageEventInfo.baseGO = controller.gameObject;
            //We then fire the event
            damageEventInfo.FireEvent();
            //Reset the timer
            controller.ConsumeSpeed = Time.time;
        }
    }
}

