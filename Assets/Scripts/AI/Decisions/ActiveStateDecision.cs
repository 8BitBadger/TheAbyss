using UnityEngine;

namespace AiLogic
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/ActiveState")]
    public class ActiveStateDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            bool chaseTargetIsActive = controller.data.chaseTarget.gameObject.activeSelf;
            return chaseTargetIsActive;
        }
    }
}