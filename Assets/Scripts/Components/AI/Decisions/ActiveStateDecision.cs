using UnityEngine;
using GameComponents;

[CreateAssetMenu(menuName = "GameComponents/AI/Decisions/ActiveState")]
    public class ActiveStateDecision : Decision
    {
        public override bool Decide(AI controller)
        {
            bool chaseTargetIsActive = controller.target.gameObject.activeSelf;
            return chaseTargetIsActive;
        }
    }
