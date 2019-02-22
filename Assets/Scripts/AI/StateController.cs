using System.Collections.Generic;
using UnityEngine;

public class StateController : Component
{
    //Data for the enemies
    [SerializeField] private UnitData data;
    public UnitData Data { get => data; }
    //The game object the component is attached to
    private GameObject obj;
    public GameObject Obj { get => obj; }
    //The Rigidbody2d for the game object
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
    [HideInInspector] Vector2 targetLastPosition; 


    public override void Init(GameObject _obj)
    {
        //Set the components parent object
        obj = _obj;
        //Set up the rigidbody for the AI
        rb2d = Obj.GetComponent<Rigidbody2D>();
    }

    public override void Think()
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
        Destroy(Obj);
    }

    void DropCrystal()
    {
        //TODO: detirmine the crystel worth according to the monster stats
    }

}