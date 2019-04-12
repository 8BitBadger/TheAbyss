using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComponentSystem
{
    public class ComponentManager : MonoBehaviour
    {
        public List<Component> components;

        void Start()
        {
            //We loop through the abilities list and instantiate a unique instance of the ability so that if there are 2 of the same enemy type that they
            //dont share the same data but are unique instances
            for (int i = 0; i < components.Count; i++)
            {
                components[i] = Object.Instantiate(components[i]);
            }
            //at the start of each unit component we run through all the components the object has and initializes what ever it needs
            foreach (Component comp in components)
            {
                comp.Init(gameObject);
            }

        }

        // Update is called once per frame
        void Update()
        {
            //Each update cycle we run through each components think funtion to do thier calculations
            foreach (Component comp in components)
            {
                comp.Think();
            }
        }
    }
}

