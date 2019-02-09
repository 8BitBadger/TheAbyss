using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveToPoint : MonoBehaviour
{
    //The data container for the movement scropt to make in game adjustments easier
    private UnitData data;
    //The rigidbody used for physics and movement
    private Rigidbody2D rb2d;
    //The target to move to
    private Vector3 target;
    //The distance fro mthe target to stop from
    private float distance = 0f;

    private void OnEnable()
    {
        //Gets the rigibody2D of the object do it can be accessed by the class
        rb2d = GetComponent<Rigidbody2D>();
        //Set the rigibody2d to kenematic so we have physics emulation
        rb2d.isKinematic = true;
    }

    //Move close to a position or object, distance can be set
    public void Move(Vector3 _target, float _distance)
    {
        //The target and distance for the game object
        target = _target;
        //Distance to stop from target
        distance = _distance;
    }

    //Here we could use the fixed update or create a seperat function that will be called 

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target) > distance || Vector2.Distance(transform.position, target) < .4)
            {
                rb2d.velocity = (target - transform.position).normalized * data.speed * Time.deltaTime;
            }
        }
    }
}