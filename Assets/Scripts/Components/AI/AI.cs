using System.Collections.Generic;
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


        [HideInInspector]
        public float timer = 0;
        [HideInInspector]
        public float attackTimer = 0;

        //Used to check if the creature is being attacked
        [HideInInspector]
        public GameObject attacker = null;

        //The hitbox used for attacks
        [HideInInspector]
        public GameObject weaponHitBox;

        private void Start()
        {
            //Set up the rigidbody for the AI
            rb2d = GetComponent<Rigidbody2D>();

            if (transform.GetChild(0).GetComponent<HitBox>())
            {
                //Get the game object that the hitbox is atached to
                weaponHitBox = transform.GetChild(0).gameObject;
            }
            else
            {
                Debug.LogError("AttackAction - No weapon hitbox child object detected. Make sure child object is present");
            }
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