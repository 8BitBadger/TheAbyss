using UnityEngine;

namespace AiLogic
{
    [CreateAssetMenu(menuName = "Components/AI/Decisions/ActiveState")]
    public class ActiveStateDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            bool chaseTargetIsActive = controller.target.gameObject.activeSelf;
            return chaseTargetIsActive;
        }
    }
}