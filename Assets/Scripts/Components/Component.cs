using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Component : ScriptableObject
{
    //The init with no game object needed, I know I'm going to need this at some point I just know it
    public abstract void Init(GameObject _obj);
    //The initializer for the component class, we pas the parent object into it
    //public abstract void Init(GameObject _obj);
    //The overide of the init funtion
    //public abstract void Init(GameObject _obj, GameObject _target);

    //Where we call the functions that need to run every frame my version of update()
    public abstract void Think();
}
