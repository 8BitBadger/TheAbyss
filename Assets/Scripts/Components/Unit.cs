using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/Unit")]
public class Unit : ComponentSystem.Component
{
    public float speed = 50;

    public override void Init(GameObject _obj)
    {
        throw new System.NotImplementedException();
    }

    public override void Think()
    {
        throw new System.NotImplementedException();
    }

}
