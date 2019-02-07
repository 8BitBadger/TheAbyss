using UnityEngine;

namespace AiLogic
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
    public class AttackAction : Action
    {
        public override void Act(StateController controller)
        {
            //TODO: Make it so sprite is showing in the general direction of the player

            Attack(controller);
        }

        private void Attack(StateController controller)
        {
            if ((Time.time - controller.timeSinceLastAttack) > controller.data.attackInterval)
            {
                //controller.data.chaseTarget.gameObject.GetComponent<EventCbSystem.PlayerLogic>().TakeDamage(1);
                //controller.timeSinceLastAttack = Time.time;
            }
        }
    }
}