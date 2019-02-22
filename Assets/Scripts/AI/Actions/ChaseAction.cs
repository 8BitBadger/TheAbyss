//using UnityEngine;


//    [CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
//    public class ChaseAction : Action
//    {
//        [HideInInspector]
//        public Vector2 normalizedDir;

//        public override void Act(StateController controller)
//        {
//            Chase(controller);
//        }

//        private void Chase(StateController controller)
//        {
//            normalizedDir = (new Vector2(controller.Data.chaseTarget.position.x, controller.Data.chaseTarget.position.y) - controller.rb2d.position).normalized;
//            controller.rb2d.velocity = new Vector2(Mathf.Lerp(0, normalizedDir.x * controller.Data.speed, 0.8f), Mathf.Lerp(0, normalizedDir.y * controller.Data.speed, 0.8f));
//        }
//    }