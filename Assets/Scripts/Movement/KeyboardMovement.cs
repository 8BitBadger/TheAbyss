using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Makes sure that the boject we are attaching the script to has a rigidbody2d component to it
[RequireComponent(typeof(Rigidbody2D))]
public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] private UnitData data;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        //Gets the rigibody2D of the object do it can be accessed by the class
        rb2d = GetComponent<Rigidbody2D>();
        //Set the rigibody2d to kenematic so we have physics emulation
        rb2d.isKinematic = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Moves the 
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * data.speed * Time.deltaTime;
    }
}