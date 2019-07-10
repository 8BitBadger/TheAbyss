using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private Vector3 touchPosition;
    Vector3 mousePosition;
    float VerticalAxis;
    float HorizontalAxis;
    private float width;
    private float height;
    Camera cam;



    private void Awake()
    {
        cam = Camera.main;

        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        touchPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }
    private void Update()
    {

        //Get the mouse position
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        //Get the axis input from the keyboard
        VerticalAxis = Input.GetAxis("Vertical");
        HorizontalAxis = Input.GetAxis("Horizontal");

        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                touchPosition = new Vector3(-pos.x, pos.y, 0.0f);

                // Position the cube.
                transform.position = touchPosition;
            }

            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began)
                {
                    // Halve the size of the cube.
                    transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    // Restore the regular size of the cube.
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
        }

        if (Input.GetKey("escape"))
        {

        }
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }
        if (Input.GetKeyUp("space"))
        {
            print("Space key was released");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Pressed left click.");
        }
        if (Input.GetMouseButton(1))
        {
            Debug.Log("Pressed right click.");
        }
        if (Input.GetMouseButton(2))
        {
            Debug.Log("Pressed middle click.");
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button.");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed secondary button.");
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Pressed middle click.");
        }

    }

}
