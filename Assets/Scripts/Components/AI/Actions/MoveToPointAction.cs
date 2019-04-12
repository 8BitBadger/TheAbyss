using UnityEngine;

[CreateAssetMenu(menuName = "Components/AI/Actions/Move To Last Seen Point")]
public class MoveToPointAction : Action
{
    Vector2 normalizedDir;

    public override void Act(StateController controller)
    {
        MoveToPoint(controller);
    }

    private void MoveToPoint(StateController controller)
    {
        normalizedDir = (controller.targetLastPosition - controller.rb2d.position).normalized;

        controller.rb2d.velocity = new Vector2(Mathf.Lerp(0, normalizedDir.x * controller.Data.speed, 0.8f), Mathf.Lerp(0, normalizedDir.y * controller.Data.speed, 0.8f));
    }
}
