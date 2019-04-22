using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallback
{
    public class AttackListener : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AttackEvent.RegisterListener(On_Attack);
        }
        private void OnDestroy()
        {
            AttackEvent.UnregisterListener(On_Attack);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void On_Attack(AttackEvent attackEvent)
        {

        }

    }
}
