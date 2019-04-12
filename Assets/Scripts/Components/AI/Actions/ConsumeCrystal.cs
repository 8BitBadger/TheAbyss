using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallback;

[CreateAssetMenu(menuName ="Components/AI/Actions/Consume Crystal")]
public class ConsumeCrystal : Action
{
    public override void Act(StateController controller)
    {
        Consume(controller);
    }

    private void Consume(StateController controller)
    {
        //NOTE: Call health class or ability and subtract health from it he crystal

        DamageEvent DamageEventInfo = new DamageEvent();
        DamageEventInfo.UnitGO = controller.target.gameObject;
        DamageEventInfo.DamagerGO = controller.Obj;
        DamageEventInfo.FireEvent();
    }
}
