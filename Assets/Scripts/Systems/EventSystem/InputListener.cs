using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallback
{
    public class InputListener : MonoBehaviour
    {
        //public event Action OnMove = delegate{};
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
                //OnMove();
            }
        }
    }
}