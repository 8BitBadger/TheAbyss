using UnityEngine;
using Comps;
using EventCallback;

[CreateAssetMenu(menuName = "Comps/AI/Actions/Attack")]
    public class AttackAction : Action
    {
        float attackTimer;

        public override void Act(AI controller)
        {
            //TODO: Make it so sprite is showing in the general direction of the player

            Attack(controller);
        }

        private void Attack(AI controller)
        {
            if ((Time.time - attackTimer) > controller.GetComponent<Stats>().attackSpeed.Value)
            {

            AttackEvent attackEventInfo = new AttackEvent();
            attackEventInfo.baseGO = controller.gameObject;

            attackEventInfo.FireEvent();
            //controller.data.chaseTarget.gameObject.GetComponent<EventCbSystem.PlayerLogic>().TakeDamage(1);
            //controller.timeSinceLastAttack = Time.time;
            attackTimer = Time.time;
            }
        }
   }

