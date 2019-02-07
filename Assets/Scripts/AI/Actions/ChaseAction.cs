using UnityEngine;

namespace AiLogic
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
    public class ChaseAction : Action
    {
        [HideInInspector]
        public Vector2 normalizedDir;

        public override void Act(StateController controller)
        {
            controller.data.randomWanderPoint = Vector2.zero;
            Chase(controller);
        }

        private void Chase(StateController controller)
        {
            normalizedDir = (new Vector2(controller.data.chaseTarget.position.x, controller.data.chaseTarget.position.y) - controller.rb2d.position).normalized;
            controller.rb2d.velocity = new Vector2(Mathf.Lerp(0, normalizedDir.x * controller.data.speed, 0.8f), Mathf.Lerp(0, normalizedDir.y * controller.data.speed, 0.8f));
        }
    }
}