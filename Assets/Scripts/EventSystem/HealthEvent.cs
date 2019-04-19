using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EventCallback
{
    public class HealthEvent : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Die();
            }
        }

        void Die()
        {
            // I am dying for some reason.

            DamageEvent deathEventInfo = new DamageEvent();
            //dei.Description = "Unit " + gameObject.name + " has died.";
            deathEventInfo.baseGO = gameObject;
            deathEventInfo.FireEvent();

            Destroy(gameObject);
        }
    }
}
