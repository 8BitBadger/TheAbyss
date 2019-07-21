using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallback
{
    public class DeathListener : MonoBehaviour
    {
        public event Action<GameObject> PlaySound;
        //Play the particle for the death event
        public event Action<GameObject> PlayParticle;
        //Play the death animation for the object
        public event Action<GameObject> PlayAnimation;

        // Start is called before the first frame update
        void Start()
        {
            DeathEvent.RegisterListener(OnDeath);
        }

        void OnDestroy()
        {
            DeathEvent.UnregisterListener(OnDeath);
        }

        void OnDeath(DeathEvent deathEvent)
        {
            //Play the soundfor the attack
            if (PlaySound != null) PlaySound(deathEvent.baseGO);
            //Playt the particle for the attack
            if (PlayParticle != null) PlayParticle(deathEvent.baseGO);
            //Play the aanimation for the attack
            if (PlayAnimation != null) PlayAnimation(deathEvent.baseGO);

            //Play death sound
            //Play particle animation
            //If it's the player end the game
            Debug.Log("Alerted about death: " + deathEvent.baseGO.name);
            Destroy(deathEvent.baseGO);
        }
    }
}