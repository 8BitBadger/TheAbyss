using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallback
{
    public class AttackListener : MonoBehaviour
    {
        //The reference to the game manager game object
        GameObject gameManager;
        //Handles the playing of sounds and music for the game
        SoundManager soundManager;
        //Handles the particles for the game
        ParticleManager particleManager;
        // Start is called before the first frame update

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

            AttackEvent.RegisterListener(On_Attack);
        }

        private void OnDestroy()
        {
            AttackEvent.UnregisterListener(On_Attack);
        }

        private void On_Attack(AttackEvent attackEvent)
        {
            //Play the attack sound
            soundManager.playSound(attackEvent.baseGO);
        }
    }
}
