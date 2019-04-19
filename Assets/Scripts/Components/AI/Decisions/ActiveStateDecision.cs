using UnityEngine;
using Comps;

[CreateAssetMenu(menuName = "Comps/AI/Decisions/ActiveState")]
    public class ActiveStateDecision : Decision
    {
        public override bool Decide(AI controller)
        {
            bool chaseTargetIsActive = controller.target.gameObject.activeSelf;
            return chaseTargetIsActive;
        }
    }
