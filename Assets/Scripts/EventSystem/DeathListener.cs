using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallback
{
    public class DeathListener : MonoBehaviour
    {
        void Start()
        {
            DeathEvent.RegisterListener(OnDied);
        }

        void OnDestroy()
        {
            DeathEvent.UnregisterListener(OnDied);
        }

        void OnDied(DeathEvent death)
        {
            Debug.Log("Alerted about death: " + death.UnitGO.name);
        }
    }
}