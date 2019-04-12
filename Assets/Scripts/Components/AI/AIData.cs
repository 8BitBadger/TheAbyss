using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatSystem;

//[CreateAssetMenu(fileName = "Data", menuName = "StateControllerData")]

public class AIData : ScriptableObject
{
    public int level = 1;

    public CharacterStat strength = new CharacterStat(10);

    public float health = 10;

    public Vector2 randomWanderPoint = Vector2.zero;
    public Vector2 lastSeenPoint = Vector2.zero;
    public Vector2 lastPosition = Vector2.zero;
    public float lastTimeMoved;
    //The target to chase
    public Transform chaseTarget;

    //The walk speed of the actor
    public float speed = 2;

    //The wander distance of the AI
    public float wanderDistance = 10f;

    //Attack range used for the player as well as the ai
    public float attackRange = 5f;
    //The times the player or StateControllercan attack in a certain time
    public float attackInterval = 1f;

    //Used for the fow script
    public float viewRadius = 90f;
    public float viewAngle = 90f;
    public float viewDistance = 10; //Used for the players field of view
    public LayerMask obstacleMask;
    public LayerMask targetLayer;

    
}
