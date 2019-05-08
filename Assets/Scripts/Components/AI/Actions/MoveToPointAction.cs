using UnityEngine;
using Comps;

[CreateAssetMenu(menuName = "Comps/AI/Actions/Move To Last Seen Point")]
    public class MoveToPointAction : Action
    {
        Vector2 normalizedDir;

        public override void Act(AI controller)
        {
            MoveToPoint(controller);
        }

        private void MoveToPoint(AI controller)
        {
            normalizedDir = (controller.targetLastPosition - controller.rb2d.position).normalized;
            controller.rb2d.MovePosition(Vector2.Lerp(controller.rb2d.position, controller.targetLastPosition, controller.GetComponent<Stats>().moveSpeed.Value * Time.deltaTime));
        }
    }
