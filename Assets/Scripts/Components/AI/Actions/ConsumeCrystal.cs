using Comps;
using EventCallback;
using UnityEngine;

[CreateAssetMenu(menuName = "Comps/AI/Actions/Consume Crystal")]
public class ConsumeCrystal : Action
{
    
    public override void Act(AI controller)
    {
        Consume(controller);
    }

    private void Consume(AI controller)
    {
        if ((Time.time - controller.timer) > controller.GetComponent<Stats>().attackSpeed.Value)
        {
            //Create a new damage event info
            DamageEvent damageEventInfo = new DamageEvent();
            //The Object that is consuming the target
            damageEventInfo.baseGO = controller.gameObject;
            //The target object that is being consumed
            damageEventInfo.targetGO = controller.target.gameObject;
            //We then fire the event
            damageEventInfo.FireEvent();
            //Reset the timer
            controller.timer = Time.time;
        }
    }
}

