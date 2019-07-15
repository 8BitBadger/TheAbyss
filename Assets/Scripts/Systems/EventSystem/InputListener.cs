using System;
using UnityEngine;

namespace EventCallback
{
    public class InputListener : MonoBehaviour
    {
        [HideInInspector]
        //Bool to hold button press checks
        public bool escPressed, spacePressed, leftMBPressed, rightMBPressed, midMBPressed;
        [HideInInspector]
        //The position of the mouse after screenToorldPosition already calculated
        public Vector3 mousePos;
        [HideInInspector]
        //The touch positions if a touh screen is used, error checking done by input manager
        public Vector3[] touchPositions;
        [HideInInspector]
        //The vertical and horizontal axis change from keyboard or controller
        public float verticalAxis, horizontalAxis;

        void Start()
        {
            InputEvent.RegisterListener(OnInput);
        }

        void OnDestroy()
        {
            InputEvent.UnregisterListener(OnInput);
        }

        void OnInput(InputEvent inputEvent)
        {
            escPressed = inputEvent.escPressed;
            spacePressed = inputEvent.spacePressed;
            leftMBPressed = inputEvent.leftMBPressed;
            rightMBPressed = inputEvent.rightMBPressed;
            midMBPressed = inputEvent.midMBPressed;
            //The position of the mouse after screenToorldPosition already calculated
            mousePos = inputEvent.mousePos;
            //The touch positions if a touh screen is used, error checking done by input manager
            touchPositions = inputEvent.touchPositions;
            //The vertical and horizontal axis change from keyboard or controller
            verticalAxis = inputEvent.verticalAxis;
            horizontalAxis = inputEvent.horizontalAxis;
        }
    }
}