using UnityEngine;

    [CreateAssetMenu(menuName = "Components/AI/Actions/Attack")]
    public class AttackAction : Action
    {
        float timeSinceLastAttack;
        //TODO: Need to set this to the value in the units data
        float attackInterval = 5;

        public override void Act(StateController controller)
        {
            //TODO: Make it so sprite is showing in the general direction of the player

            Attack(controller);
        }

        private void Attack(StateController controller)
        {
            if ((Time.time - timeSinceLastAttack) > attackInterval)
            {
                //controller.data.chaseTarget.gameObject.GetComponent<EventCbSystem.PlayerLogic>().TakeDamage(1);
                //controller.timeSinceLastAttack = Time.time;
            }
        }
    }
