using UnityEngine;
using Comps;

namespace AiLogic
    {
        [CreateAssetMenu(menuName = "Comps/AI/Actions/Run")]
        public class RunAction : Action
        {
            Vector2 normalizedDir;

            public override void Act(AI controller)
            {
                Run(controller);
            }

            private void Run(AI controller)
            {
                //Swung the position of the target and the unit around to make the movement calculation away from the unit itself
                normalizedDir = (new Vector2(controller.target.position.x, controller.target.position.y) - controller.rb2d.position).normalized;

            controller.rb2d.MovePosition(controller.rb2d.position + normalizedDir * controller.GetComponent<Stats>().moveSpeed.Value * Time.deltaTime);
            }
        }
    }
