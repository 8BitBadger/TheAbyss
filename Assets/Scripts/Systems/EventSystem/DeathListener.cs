using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallback
{
    public class DeathListener : MonoBehaviour
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

            DeathEvent.RegisterListener(On_Died);
        }

        void OnDestroy()
        {
            DeathEvent.UnregisterListener(On_Died);
        }

        void On_Died(DeathEvent deathEvent)
        {
            //Play death sound
            //Play particle animation
            //If it's the player end the game
            Debug.Log("Alerted about death: " + deathEvent.baseGO.name);
            Destroy(deathEvent.baseGO);
        }
    }
}