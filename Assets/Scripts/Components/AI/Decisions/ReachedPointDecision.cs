using GameComponents;
using UnityEngine;

[CreateAssetMenu(menuName = "GameComponents/AI/Decisions/Reached Point")]
public class ReachedPointDecision : Decision
{
    bool firstLoop = true;
    float lastTimeMoved;
    Vector3 lastPosition;
    Vector3 lastSeenPoint;

    public override bool Decide(AI controller)
    {
        if (firstLoop)
        {
            firstLoop = false;
            lastTimeMoved = Time.time;
            lastPosition = controller.gameObject.transform.position;
        }
        return ReachedPoint(controller);
    }

    private bool ReachedPoint(AI controller)
    {
        if (Vector2.Distance(controller.rb2d.position, lastSeenPoint) < 0.4f)
        {
            return true;
        }

        if ((Time.time - lastTimeMoved) > 3)
        {
            if (Vector2.Distance(lastPosition, controller.gameObject.transform.position) < 0.1f)
            {
                firstLoop = true;
                return true;
            }
            lastTimeMoved = Time.time;
            lastPosition = controller.gameObject.transform.position;
        }

        return false;
    }
}

