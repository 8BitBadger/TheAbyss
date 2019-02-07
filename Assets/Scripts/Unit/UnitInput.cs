using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitInput : ScriptableObject
{    
    //The variables that will be read for the input
    public Vector2 force { get; }
    public float rotation { get; }

    //We get the input fro meither keyboard or ai calculations and then set the new vector movement ad rotation
    public abstract void GetInput();

}
