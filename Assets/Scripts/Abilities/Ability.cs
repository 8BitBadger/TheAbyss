using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    //The init with no game object needed, I know I'm going to need this at some point I just know it
    public abstract void Init(GameObject _obj);

    //Where we call the functions that need to run every frame my version of update()
    public abstract void Think();
}
