using UnityEngine;
using Comps;

[CreateAssetMenu(menuName = "Comps/AI/Actions/Chase")]
public class ChaseAction : Action
{
    [HideInInspector]
    public Vector2 normalizedDir;

    public override void Act(AI controller)
    {
        Chase(controller);
    }

    private void Chase(AI controller)
    {
        normalizedDir = (new Vector2(controller.target.position.x, controller.target.position.y) - controller.rb2d.position).normalized;
        controller.rb2d.MovePosition(controller.rb2d.position + normalizedDir * controller.speed * Time.deltaTime);
    }
}
