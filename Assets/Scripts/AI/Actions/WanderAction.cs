using UnityEngine;

namespace AiLogic
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Wander")]
    public class WanderAction : Action
    {
        Vector2 normalizedDir;

        public override void Act(StateController controller)
        {
            Wander(controller);
        }

        private void Wander(StateController controller)
        {
            if (Vector2.Distance(controller.rb2d.position, controller.data.randomWanderPoint) < 0.4f || controller.data.randomWanderPoint == Vector2.zero)
            {
                bool validPath = false;

                normalizedDir = Vector2.zero;

                Vector2 newPatrolPoint;

                while (!validPath)
                {
                    newPatrolPoint = new Vector2(Mathf.RoundToInt(Random.Range(-(controller.data.wanderDistance + 1), controller.data.wanderDistance) + controller.transform.position.x), Mathf.RoundToInt(Random.Range(-(controller.data.wanderDistance + 1), controller.data.wanderDistance) + controller.transform.position.y));

                    if (!Physics2D.Linecast(controller.rb2d.position, newPatrolPoint, controller.data.obstacleMask))
                    {
                        validPath = true;
                        controller.data.randomWanderPoint = newPatrolPoint;
                    }
                }

            }
            else
            {
                normalizedDir = (controller.data.randomWanderPoint - controller.rb2d.position).normalized;

                controller.rb2d.velocity = new Vector2(Mathf.Lerp(0, normalizedDir.x * controller.data.speed, 0.8f), Mathf.Lerp(0, normalizedDir.y * controller.data.speed, 0.8f));
            }
        }
    }
}

