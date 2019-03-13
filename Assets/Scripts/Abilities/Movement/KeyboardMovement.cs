using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/Keyboard Movement Component")]
//Makes sure that the boject we are attaching the script to has a rigidbody2d component to it
[RequireComponent(typeof(Rigidbody2D))]
public class KeyboardMovement : Ability
{
    //The object the component is connected to
    GameObject obj;
    //THe rigidbody for the object the asset is attached to
    private Rigidbody2D rb2d;

    public override void Init(GameObject _obj)
    {
        obj = _obj;
        //Gets the rigibody2D of the object do it can be accessed by the class
        rb2d = obj.GetComponent<Rigidbody2D>();
        //Set the rigibody2d to kenematic so we have physics emulation
        rb2d.isKinematic = true;
    }

    // Update is called once per frame
    public override void Think()
    {
        //Sets the velocity of the objects rigidbody
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * obj.GetComponent<Unit>().Data.speed * Time.deltaTime;
    }
}