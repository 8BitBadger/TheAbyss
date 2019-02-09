using System.Collections.Generic;
using UnityEngine;

namespace AiLogic
{
    public class StateController : MonoBehaviour
    {
        //Data for the enemies
        public AIData data;
        //Hold the current state
        public State currentState;
        //
        public State remainState;
        //Built in timer for the StateControllerstates to run a certain time
        [HideInInspector] public float stateTimeElapsed;
        //The rigidbody for the enemy AI
        [HideInInspector] public Rigidbody2D rb2d;
        //Stores the time of hte last attack. Used for 
        [HideInInspector] public float timeSinceLastAttack;

        void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();

            timeSinceLastAttack = Time.time;

            GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);

            //data.targetLayer = LayerMask.NameToLayer("Player");
            //data.obstacleMask = LayerMask.NameToLayer("Obstacles");
        }

        void Update()
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

        void Die()
        {
            //Play death animation
            //Drop crystal
            Destroy(gameObject);
        }

        void DropCrystal()
        {
            //TODO: detirmine the crystel worth according to the monster stats
        }
    }
}