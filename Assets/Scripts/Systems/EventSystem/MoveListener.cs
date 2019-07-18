using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameComponents;

namespace EventCallback
{
    public class MoveListener : MonoBehaviour
    {
        //The reference to the game manager game object
        GameObject gameManager;
        //Handles the playing of sounds and music for the game
        SoundManager soundManager;
        //Handles the particles for the game
        ParticleManager particleManager;

        private void Start()
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

            MoveEvent.RegisterListener(OnMove);
        }

        private void OnDestroy()
        {
            MoveEvent.UnregisterListener(OnMove);
        }

        private void OnMove(MoveEvent moveEvent)
        {
            //Play the attack sound
            //soundManager.playSound(attackEvent.baseGO);

                    if (moveEvent.baseGO.tag == "Player")
                    {
                        //Play sound
                        //Run Animation?
                        //Particle Effect?
                    }
                    else if (moveEvent.baseGO.tag == "Creature")
                    {
                        //Play sound
                        //Run Animation?
                        //Particle Effect?
                    }
                    else { Debug.LogError("DamageListener - The target object does not match any tags registered to take damage"); }
        }
    }
}
