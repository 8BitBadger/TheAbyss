using UnityEngine;
namespace AiLogic
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Run")]
    public class RunAction : Action
    {
        Vector2 normalizedDir;

        public override void Act(StateController controller)
        {
            Run(controller);
        }

        private void Run(StateController controller)
        {
            normalizedDir = (new Vector2(controller.data.chaseTarget.position.x, controller.data.chaseTarget.position.y) - controller.rb2d.position).normalized;

            controller.rb2d.velocity = new Vector2(Mathf.Lerp(0, normalizedDir.x * controller.data.speed, 0.8f), Mathf.Lerp(0, normalizedDir.y * controller.data.speed, 0.8f));
        }
    }
}