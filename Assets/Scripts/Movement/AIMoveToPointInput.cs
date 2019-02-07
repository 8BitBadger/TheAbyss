using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI Move To Point Input", menuName = "Input/AI Move To Point Input")]
public class AIMoveToPointInput : UnitInput
{
    public Vector2 force { get; private set; }
    public float rotation { get; private set; }

    //The position of the object moving and the target to witch it is moving
    private Vector3 pos, target;
    //The distance fro mthe target to stop
    private float distance;

    //Assign a target to the movement script
    public void SetTarget(Vector3 _pos, Vector3 _target, float _distance)
    {
        pos = _pos;
        target = _target;
        distance = _distance;
    }

    public override void GetInput()
    {
        if (target != null)
        {
            if (Vector2.Distance(pos, target) > distance || Vector2.Distance(pos, target) < .4)
            {
                force = (target - pos).normalized;
            }
        }
    }

}
