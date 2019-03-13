using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //The date the unit has
    [SerializeField] private UnitData data;
    public UnitData Data { get => data;}
    //The componenets that the unit has
    [SerializeField] private List<Ability> abilities;

    // Start is called before the first frame update
    void Start()
    {
        //We loop through the abilities list and instantiate a unique instance of the ability so that if there are 2 of the same enemy type that they
        //dont share the same data but are unique instances
        for (int i = 0; i < abilities.Count; i++)
        {
            abilities[i] = Object.Instantiate(abilities[i]);
        }
//at the start of each unit component we run through all the components the object has and initializes what ever it needs
        foreach(Ability comp in abilities)
        {
            comp.Init(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Each update cycle we run through each components think funtion to do thier calculations
        foreach (Ability comp in abilities)
        {
            comp.Think();
        }

    }
}
