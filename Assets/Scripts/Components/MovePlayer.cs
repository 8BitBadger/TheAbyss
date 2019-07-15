using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallback;

namespace GameComponents
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Stats))]
    public class MovePlayer : MonoBehaviour
    {
        //The rigidbody for the object the asset is attached to
        private Rigidbody2D rb2d;
        //The movement on the x and y axis value is from 0 -1f
        float x, y;

        private void Start()
        {
            //Checking if the game object has a Rigidbody2D component 
            if (GetComponent<Rigidbody2D>())
            {
                //Gets the rigibody2D of the object do it can be accessed by the class
                rb2d = GetComponent<Rigidbody2D>();
                //Set the rigibody2d to kenematic so we have physics emulation
                rb2d.isKinematic = true;
            }

            GetComponent<InputListener>().GetAxis += Move;
            
        }
        
        void Move(float x, float y)
        {
            Debug.Log("Calling Move from event system");
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            
            //Sets the velocity of the objects rigidbody
            rb2d.MovePosition(rb2d.position + new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * GetComponent<Stats>().moveSpeed.Value * Time.deltaTime);
        }
    }
}
