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

        // Start is called before the first frame update
        void Start()
        {
            if (GameObject.FindGameObjectWithTag("GameManager") != null)
            {
                //Seth the refernce to the game manager gmae object
                gameManager = GameObject.FindGameObjectWithTag("GameManager");
            }
            else
            {
                Debug.LogError("AttackListener - GameManager object does not exist");
            }
            //Find the game manager game object and then check if it has the sound manager component attached and if it does we set it to the local variable
            if (gameManager.GetComponent<SoundManager>() != null)
            {
                soundManager = gameManager.GetComponent<SoundManager>();
            }
            else
            {
                Debug.LogError("AttackListener - SoundManager script not attached to GameManager game object");
            }
            //Find the game manager game object and then check if it has the sound manager component attached and if it does we set it to the local variable
            if (gameManager.GetComponent<ParticleManager>() != null)
            {
                particleManager = gameManager.GetComponent<ParticleManager>();
            }
            else
            {
                Debug.LogError("AttackListener - ParticleManager script not attached to GameManager game object");
            }

            DamageEvent.RegisterListener(On_Damaged);
        }

        // Update is called once per frame
        void OnDestroy()
        {
            DamageEvent.UnregisterListener(On_Damaged);
        }

        private void On_Damaged(DamageEvent damageEvent)
        {
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
                        if(damageEvent.targetGO.tag == "Crystal")
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
