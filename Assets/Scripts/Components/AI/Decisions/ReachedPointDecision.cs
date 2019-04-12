using UnityEngine;

namespace AiLogic
{
    [CreateAssetMenu(menuName = "Components/AI/Decisions/Reached Point")]
    public class ReachedPointDecision : Decision
    {
        bool firstLoop = true;
        float lastTimeMoved;
        Vector3 lastPosition;
        Vector3 lastSeenPoint;

        public override bool Decide(StateController controller)
        {
            if (firstLoop)
            {
                firstLoop = false;
                lastTimeMoved = Time.time;
                lastPosition = controller.Obj.transform.position;
            }
            return ReachedPoint(controller);
        }

        private bool ReachedPoint(StateController controller)
        {
            if (Vector2.Distance(controller.rb2d.position, lastSeenPoint) < 0.4f)
            {
                return true;
            }

            if ((Time.time - lastTimeMoved) > 3)
            {
                if (Vector2.Distance(lastPosition, controller.Obj.transform.position) < 0.1f)
                {
                    firstLoop = true;
                    return true;
                }
                lastTimeMoved = Time.time;
                lastPosition = controller.Obj.transform.position;
            }

            return false;
        }
    }
}
