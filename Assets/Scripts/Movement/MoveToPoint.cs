using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    //The data container for the movement scropt to make in game adjustments easier
    public MovementData data;

    private void OnEnable()
    {
        data.target = null;
        //Movement script loks up if we have a rigibody2d already atteched to the gameobject
        if (GetComponent<Rigidbody2D>())
        {
            data.rb2d = GetComponent<Rigidbody2D>();
        }
        else //We add the Rigidbody2d to the game object and set the kenematic flag to true
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
        //Set the rigibody2d to kenematic so we have physics emulation
        data.rb2d.isKinematic = true;
        //For now I want to freeze the ratation of the gameobject
        data.rb2d.freezeRotation = true;
    }

    //Move close to a position or object, distance can be set
    public void Move(Transform _target)
    {
        //The target and distance for the game object
        data.target = _target;
    }

    //Here we could use the fixed update or create a seperat function that will be called 

    public void FixedUpdate()
    {
        if (data.target != null)
        {
            if (Vector2.Distance(transform.position, data.target.position) > data.distance || Vector2.Distance(transform.position, data.target.position) < .4)
            {
                data.rb2d.velocity = (data.target.position - transform.position).normalized * data.speed * Time.deltaTime;
            }
        }
    }
}