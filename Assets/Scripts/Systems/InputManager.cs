using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallback;

public class InputManager : MonoBehaviour
{
    //The width of the screen used for touch calculations
    private float width;
    //The height of the screen used for touch calculations
    private float height;
    //A refference of the camera used for mouse movement calculations
    private Camera cam;

    private void Awake()
    {
        //Setting the refference for the camera to the main camera feed
        cam = Camera.main;

        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }
    
    private void Update()
    {
        InputEvent inputEventInfo = new InputEvent();

        if (Input.touchSupported)
        {
            //Size the list of vector3 for the touch inputs to the amount of touches on the screen 
            inputEventInfo.touchPositions = new Vector3[Input.touchCount];

            // Check for the amount of touches
            if (Input.touchCount > 0)
            {
                //Go through the ist of touchs
                for (int i = 0; i < Input.touchCount; i++)
                {
                    //Set the current touch variable to the current touch in the que
                    Touch touch = Input.GetTouch(i);
                    //Get the position of the touh
                    if (touch.phase == TouchPhase.Moved)
                    {
                        Vector2 pos = touch.position;
                        pos.x = (pos.x - width) / width;
                        pos.y = (pos.y - height) / height;
                        inputEventInfo.touchPositions[i] = new Vector3(-pos.x, pos.y, 0.0f);
                    }
                }
            }
        }

        //Get the mouse position
        inputEventInfo.mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Get the axis input from the keyboard
        inputEventInfo.verticalAxis = Input.GetAxis("Vertical");
        inputEventInfo.horizontalAxis = Input.GetAxis("Horizontal");
        inputEventInfo.escPressed = Input.GetKey("escape");
        inputEventInfo.spacePressed = Input.GetKey("space");
        inputEventInfo.leftMBPressed = Input.GetMouseButton(0);
        inputEventInfo.rightMBPressed = Input.GetMouseButton(1);
        inputEventInfo.midMBPressed = Input.GetMouseButton(2);

        inputEventInfo.FireEvent();
    }

}
