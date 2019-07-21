using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameComponents;

namespace EventCallback
{
    public class AttackListener : MonoBehaviour
    {
        //The reference to the game manager game object
        GameObject gameManager;
        //Handles the playing of sounds and music for the game
        ParticleManager particleManager;
        //The action for playing a sound from the sound manager
        public event Action<GameObject> PlaySound;
        //Play the particle for the death event
        public event Action<GameObject> PlayParticle;
        //Play the death animation for the object
        public event Action<GameObject> PlayAnimation;

        private void Start()
        {
            AttackEvent.RegisterListener(OnAttack);
        }

        private void OnDestroy()
        {
            AttackEvent.UnregisterListener(OnAttack);
        }

        private void OnAttack(AttackEvent attackEvent)
        {
            //Play the soundfor the attack
            if (PlaySound != null) PlaySound(attackEvent.baseGO);
            //Playt the particle for the attack
            if(PlayParticle != null) PlayParticle(attackEvent.baseGO);
            //Play the aanimation for the attack
            if(PlayAnimation != null) PlayAnimation(attackEvent.baseGO);

            if (attackEvent.baseGO.tag == "Player")
            {
                //Play sound
                //Run Animation?
                //Particle Effect?

            }
            else if (attackEvent.baseGO.tag == "Creature")
            {
                //Play sound
                //Run Animation?
                //Particle Effect?
            }
            else { Debug.LogError("DamageListener - The target object does not match any tags registered to take damage"); }
        }
    }
}
