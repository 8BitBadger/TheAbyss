using UnityEngine;

namespace AiLogic
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Reached Point")]
    public class ReachedPointDecision : Decision
    {
        bool firstLoop = true;

        public override bool Decide(StateController controller)
        {
            if (firstLoop)
            {
                firstLoop = false;
                controller.data.lastTimeMoved = Time.time;
                controller.data.lastPosition = controller.transform.position;
            }
            return ReachedPoint(controller);
        }

        private bool ReachedPoint(StateController controller)
        {
            if (Vector2.Distance(controller.rb2d.position, controller.data.lastSeenPoint) < 0.4f)
            {
                return true;
            }

            if ((Time.time - controller.data.lastTimeMoved) > 3)
            {
                if (Vector2.Distance(controller.data.lastPosition, controller.transform.position) < 0.1f)
                {
                    firstLoop = true;
                    return true;
                }
                controller.data.lastTimeMoved = Time.time;
                controller.data.lastPosition = controller.transform.position;
            }

            return false;
        }
    }
}
