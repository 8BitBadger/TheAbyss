﻿using System.Collections.Generic;
using UnityEngine;

namespace Comps
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AI : MonoBehaviour
    {
        //The Rigidbody2d for the game object
        [HideInInspector]
        public Rigidbody2D rb2d;
        //Hold the current state
        public State currentState;
        //The state to remain in when the decision class returns false
        public State remainState;
        //Built in timer for the StateControllerstates to run a certain time
        [HideInInspector] public float stateTimeElapsed;

        //The target the AI is chasing
        [HideInInspector] public Transform target;
        //The position the tartget was last seen at
        [HideInInspector] public Vector2 targetLastPosition;

        //The view cone size for the unit inside the viewraduis collider circle, setting the range limiter to 360 max and 0 min
        [Range(0, 360)]
        public int viewAngle;
        //The raduis size of the circle collider for the unit
        [Range(0, 1000)]
        public int viewRadius;
        //The layer the target is on
        public LayerMask playerMask;
        //Layer mask for other creatures
        public LayerMask creatureMask;
        //The layer for the obstacls like walls and other items
        public LayerMask obstacleMask;
        //The layer mask for crystals in the game
        public LayerMask crystalMask;

        //How far will the monster wander
        public float wanderDistance;
        //The waypoint where the unit will wander to
        [HideInInspector]
        public Vector2 wanderPoint;


        //The speed of the AI unit
        public float speed;

//The attack speed for now is a value entered into the interface, later they must be calculated
        public float attackSpeed;
        //How fast the creature consumes, nothing to do with consume damage
        [HideInInspector]
        public float ConsumeSpeed = 0;

        private void Start()
        {
            //Set up the rigidbody for the AI
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            currentState.UpdateState(this);
        }

        public void TransitionToState(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
                OnExitState();
            }
        }

        public bool CheckIfCountDownElapsed(float duration)
        {
            stateTimeElapsed += Time.deltaTime;
            return (stateTimeElapsed >= duration);
        }

        private void OnExitState()
        {
            stateTimeElapsed = 0;
        }
    }
}