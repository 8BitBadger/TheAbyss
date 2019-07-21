using GameComponents;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace EventCallback
{
    public class DamageListener : MonoBehaviour
    {
        //The reference to the game manager game object
        GameObject gameManager;
        //Handles the playing of sounds and music for the game
        SoundManager soundManager;
        //Handles the particles for the game
        ParticleManager particleManager;
        //The action for playing a sound from the sound manager
        public event Action<GameObject> PlaySound;
        //Play the particle for the death event
        public event Action<GameObject> PlayParticle;
        //Play the death animation for the object
        public event Action<GameObject> PlayAnimation;
        

        // Start is called before the first frame update
        void Start()
        {
            DamageEvent.RegisterListener(OnDamaged);
        }

        // Update is called once per frame
        void OnDestroy()
        {
            DamageEvent.UnregisterListener(OnDamaged);
        }

        private void OnDamaged(DamageEvent damageEvent)
        {
            //Play the soundfor the attack
            if (PlaySound != null) PlaySound(damageEvent.baseGO);
            //Playt the particle for the attack
            if (PlayParticle != null) PlayParticle(damageEvent.baseGO);
            //Play the aanimation for the attack
            if (PlayAnimation != null) PlayAnimation(damageEvent.baseGO);

            Debug.Log("DamageListener - Damage Listener called by " + damageEvent.baseGO.name + " Tag(" + damageEvent.baseGO.tag + ")");
            //Check if the target object has the health script attached
            if (damageEvent.targetGO.GetComponent<Health>())
            {
                if (damageEvent.baseGO.GetComponent<Stats>())
                {
                    //Set the scripts that are about to be used, makes it easier to be used
                    Health health = damageEvent.targetGO.GetComponent<Health>();
                    Stats stats = damageEvent.baseGO.GetComponent<Stats>();

                    if (damageEvent.baseGO.tag == "Player")
                    {
                        //Play sound
                        //Run Animation?
                        //Particle Effect?
                        health.TakeDamage(stats.damage.Value);
                    }
                    else if (damageEvent.baseGO.tag == "Creature")
                    {
                        //Play sound
                        //Run Animation?
                        //Particle Effect?
                        health.TakeDamage(stats.damage.Value);

                        //NOTE veru inaficiant, fix later
                        if (damageEvent.targetGO.tag == "Crystal")
                        {
                            //gain health? level up?
                        }
                    }
                    else { Debug.LogError("DamageListener - The target object does not match any tags registered to take damage"); }

                    if (damageEvent.targetGO.tag == "Creature")
                    {
                        //Set the attacker to 
                        damageEvent.targetGO.GetComponent<AI>().target = damageEvent.baseGO.transform;
                        damageEvent.targetGO.GetComponent<AI>().attacker = damageEvent.baseGO;
                    }
                }
                else { Debug.LogError("DamageListener - The target object does not have a Stats script on it"); }
            }
            else { Debug.LogError("DamageListener - The target object does not have a Health script on it"); }
        }
    }
}
