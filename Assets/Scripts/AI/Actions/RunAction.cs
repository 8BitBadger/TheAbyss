using UnityEngine;
namespace AiLogic
{
    [CreateAssetMenu(menuName = "Components/AI/Actions/Run")]
    public class RunAction : Action
    {
        Vector2 normalizedDir;

        public override void Act(StateController controller)
        {
            Run(controller);
        }

        private void Run(StateController controller)
        {
            normalizedDir = (new Vector2(controller.target.position.x, controller.target.position.y) - controller.rb2d.position).normalized;

            controller.rb2d.velocity = new Vector2(Mathf.Lerp(0, normalizedDir.x * controller.Data.speed, 0.8f), Mathf.Lerp(0, normalizedDir.y * controller.Data.speed, 0.8f));
        }
    }
}