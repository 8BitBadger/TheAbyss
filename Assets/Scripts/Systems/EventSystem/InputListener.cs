using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallback
{
    public class InputListener : MonoBehaviour
    {
        public event Action OnMove = delegate{};
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

            if (true)
            {
                OnMove();
            }
            //Play particle animation
            //If it's the player end the game
            Debug.Log("Alerted about death: " + inputEvent.baseGO.name);
            Destroy(inputEvent.baseGO);
        }
    }
}