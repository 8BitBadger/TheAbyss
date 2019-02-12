using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //The date the unit has
    [SerializeField] private UnitData data;
    public UnitData Data { get => data;}
    //The componenets that the unit has
    public List<Component> components;



    // Start is called before the first frame update
    void Start()
    {
        //at the start of each unit component we run through all the components the object has and initializes what ever it needs
        foreach(Component comp in components)
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
