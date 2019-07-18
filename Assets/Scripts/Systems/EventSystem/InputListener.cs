using System;
using UnityEngine;

namespace EventCallback
{
    public class InputListener : MonoBehaviour
    {
        public event Action<float, float> GetAxis;
        public event Action<Vector3[]> GetTouchPositions;
        public event Action<Vector3> GetMousePos;
        public event Action<bool> GetEscPressed;
        public event Action<bool> GetSpacePressed;
        public event Action<bool> GetLeftMBPressed;
        public event Action<bool> GetRightMBPressed;
        public event Action<bool> GetMidMBPressed;

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

            if (GetEscPressed != null) GetEscPressed(inputEvent.escPressed);
            if (GetSpacePressed != null) GetSpacePressed(inputEvent.spacePressed);
            if (GetLeftMBPressed != null) GetLeftMBPressed(inputEvent.leftMBPressed);
            if (GetRightMBPressed != null) GetRightMBPressed(inputEvent.rightMBPressed);
            if (GetMidMBPressed != null) GetMidMBPressed(inputEvent.midMBPressed);

            if (GetMousePos != null) GetMousePos(inputEvent.mousePos);
            if (GetTouchPositions != null) GetTouchPositions(inputEvent.touchPositions);
            if (GetAxis != null) GetAxis(inputEvent.horizontalAxis, inputEvent.verticalAxis);
        }
    }
}