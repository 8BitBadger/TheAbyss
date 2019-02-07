using UnityEngine;

namespace AiLogic
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(StateController controller);
    }
}