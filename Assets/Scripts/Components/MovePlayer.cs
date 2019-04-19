using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Comps
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovePlayer : MonoBehaviour
    {
        //THe rigidbody for the object the asset is attached to
        private Rigidbody2D rb2d;
        //THe speed the keyboard is moved at
        public float speed;

        private void Start()
        {
            //Setting the game object the component is attached to as scriptable object do not contain that link as monobehaviour does

            //Checking if the game object has a Rigidbody2D component 
            if (GetComponent<Rigidbody2D>())
            {
                //Gets the rigibody2D of the object do it can be accessed by the class
                rb2d = GetComponent<Rigidbody2D>();
                //Set the rigibody2d to kenematic so we have physics emulation
                rb2d.isKinematic = true;
            }
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            //Sets the velocity of the objects rigidbody
            rb2d.MovePosition(rb2d.position + new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime);
        }
    }
}
