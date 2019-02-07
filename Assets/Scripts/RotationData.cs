using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RotationData", menuName = "Movement/Create new rotation data")]
public class RotationData : ScriptableObject
{
    [Range(0, 50)]
    //The base speed befor mods have been applied, mods to come
    public float baseSpeed;
    //The speed of the unit after the modifiers have been applied
    [HideInInspector]
    public float speed;
    [HideInInspector]
    //The direction the gameobject needs to face
    public Vector2 dir;
    [HideInInspector]
    //The mouse position on the screen
    public Vector3 target;
    //Set the bool to false to stop rotation of the object
    public bool rotate;
}