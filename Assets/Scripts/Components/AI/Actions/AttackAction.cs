using UnityEngine;
using Comps;
using EventCallback;

[CreateAssetMenu(menuName = "Comps/AI/Actions/Attack")]
    public class AttackAction : Action
    {
        float timeSinceLastAttack;
        //TODO: Need to set this to the value in the units data
        float attackInterval = 5;

        public override void Act(AI controller)
        {
            //TODO: Make it so sprite is showing in the general direction of the player

            Attack(controller);
        }

        private void Attack(AI controller)
        {
            if ((Time.time - timeSinceLastAttack) > attackInterval)
            {

            AttackEvent attackEventInfo = new AttackEvent();
            attackEventInfo.baseGO = controller.gameObject;
            attackEventInfo.FireEvent();
                //controller.data.chaseTarget.gameObject.GetComponent<EventCbSystem.PlayerLogic>().TakeDamage(1);
                //controller.timeSinceLastAttack = Time.time;
            }
        }
   }

