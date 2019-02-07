using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AiLogic
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Scan")]
    public class ScanDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            bool noEnemyInSight = Scan(controller);
            return noEnemyInSight;
        }

        private bool Scan(StateController controller)
        {
            //controller.transform.Rotate(0, controller.stats.searchTurnSpeed * Time.deltaTime, 0);
            //return controller.CheckIfCountDownElapsed(controller.stats.searchDuration);
            //just put this in as a place holder
            return false;
        }
    }
}
