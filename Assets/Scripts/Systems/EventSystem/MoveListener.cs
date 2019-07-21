using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameComponents;
using System;


namespace EventCallback
{
    public class MoveListener : MonoBehaviour
    {
        public event Action<GameObject> PlaySound;
        //Play the particle for the death event
        public event Action<GameObject> PlayParticle;
        //Play the death animation for the object
        public event Action<GameObject> PlayAnimation;

        private void Start()
        {
            MoveEvent.RegisterListener(OnMove);
        }

        private void OnDestroy()
        {
            MoveEvent.UnregisterListener(OnMove);
        }

        private void OnMove(MoveEvent moveEvent)
        {
            //Play the soundfor the attack
            if (PlaySound != null) PlaySound(moveEvent.baseGO);
            //Playt the particle for the attack
            if (PlayParticle != null) PlayParticle(moveEvent.baseGO);
            //Play the aanimation for the attack
            if (PlayAnimation != null) PlayAnimation(moveEvent.baseGO);
        }
    }
}
