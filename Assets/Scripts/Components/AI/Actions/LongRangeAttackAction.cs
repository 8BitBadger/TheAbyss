using UnityEngine;

namespace AiLogic
{
    [CreateAssetMenu(menuName = "Components/AI/Actions/Long Range Attack")]
    public class LongRangeAttackAction : Action
    {
        public GameObject projectile;

        public override void Act(StateController controller)
        {

            Attack(controller);
        }

        private void Attack(StateController controller)
        {
            /*
            if ((Time.time - controller.timeSinceLastAttack) > controller.data.attackInterval)
            {
                GameObject tempProjectile = Instantiate(projectile, controller.transform.position, Quaternion.identity);

                ProjectileLogic.Projectile tempMovement = tempProjectile.GetComponent<ProjectileLogic.Projectile>();

                Physics2D.IgnoreCollision(tempProjectile.GetComponent<Rigidbody2D>().GetComponent<Collider2D>(), controller.GetComponent<Collider2D>());

                tempMovement.Target = controller.data.chaseTarget.transform;

                controller.timeSinceLastAttack = Time.time;
            }
            */
        }
        
    }
    
}