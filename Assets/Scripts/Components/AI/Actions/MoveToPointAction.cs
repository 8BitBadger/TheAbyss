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

            //controller.rb2d.velocity = new Vector2(Mathf.Lerp(0, normalizedDir.x * controller.speed, 0.8f), Mathf.Lerp(0, normalizedDir.y * controller.speed, 0.8f));
            //NOTE: Test to see if it works
            controller.rb2d.MovePosition(Vector2.Lerp(controller.rb2d.position, controller.targetLastPosition, controller.speed * Time.deltaTime));
            // controller.rb2d.MovePosition(controller.rb2d.position + normalizedDir * controller.speed * Time.deltaTime);
        }
    }
