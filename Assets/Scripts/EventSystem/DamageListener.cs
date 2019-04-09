using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallback
{
    public class DamageListener : MonoBehaviour
    {
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

       void OnDamaged(DamageEvent damage)
        {
            Debug.Log(damage.UnitGO.name + "got damaged by " + damage.DamagerGO.name );
        }
    }
}
