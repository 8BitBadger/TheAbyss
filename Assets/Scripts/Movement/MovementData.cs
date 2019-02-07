using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New MovementData", menuName = "Movement/Create new movement data")]
public class MovementData : ScriptableObject
{ 
    [Range(0, 500)]
    //The base speed befor mods have been applied, mods to come
    public float baseSpeed;
    //The speed of the unit after the modifiers have been applied
    [HideInInspector]
    public float speed;
    [HideInInspector]
    //Need to import speed variable and max speed to clamp max velocity for movement
    public Rigidbody2D rb2d;
    //The distance from the target the game object needs to stop
    public float distance = 0;
    [HideInInspector]
    //The target that must be followed
    public Transform target;
    [HideInInspector]
    //The movement variables for keyboard movment
    public float forwardBackward;
    [HideInInspector]
    public float leftRight;
}
