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
            //Access the health ability of the UnitGO and reduce the life
            //Access the sound manager and play needed sound for the damage
            Debug.Log(damage.UnitGO.name + " got damaged by " + damage.DamagerGO.name );
            //damage.UnitGO.GetComponent<Unit>
        }
    }
}
