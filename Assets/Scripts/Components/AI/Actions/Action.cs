using GameComponents;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract void Act(AI controller);
}