using UnityEngine;

[CreateAssetMenu(menuName = "Components/AI/Actions/Move to target")]
public class MoveToTarget : Action
{
    Vector2 normalizedDir;

    public override void Act(StateController controller)
    {
        MoveToPoint(controller);
    }

    private void MoveToPoint(StateController controller)
    {
        if (Vector2.Distance(controller.rb2d.position, controller.target.position) > 1.0f)
        {
            normalizedDir = (new Vector2(controller.target.position.x, controller.target.position.y) - controller.rb2d.position).normalized;
            controller.rb2d.MovePosition(controller.rb2d.position + normalizedDir * controller.Data.speed * Time.deltaTime);
        }
    }
}
