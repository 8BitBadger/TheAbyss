using System;
using UnityEngine;

namespace EventCallback
{
    public class InputListener : MonoBehaviour
    {
        public event Action OnEscapePressed = delegate{ };
        void Start()
        {
            InputEvent.RegisterListener(On_Input);
        }

        void OnDestroy()
        {
            InputEvent.UnregisterListener(On_Input);
        }

        void On_Input(InputEvent inputEvent)
        {

            if (inputEvent.escPressed)
            {
                OnEscapePressed();
            }
        }
    }
}