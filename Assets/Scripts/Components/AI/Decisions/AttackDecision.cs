//using UnityEngine;

//    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Attack")]
//    public class AttackDecision : Decision
//    {
//        public override bool Decide(StateController controller)
//        {
//            return Attack(controller);
//        }

//        private bool Attack(StateController controller)
//        {
//            if (Vector2.Distance(controller.data.chaseTarget.position, controller.rb2d.position) <= controller.data.attackRange)
//            {
//                controller.rb2d.velocity = Vector2.zero;
//                return true;
//            }

//            return false;
//        }
//    }
