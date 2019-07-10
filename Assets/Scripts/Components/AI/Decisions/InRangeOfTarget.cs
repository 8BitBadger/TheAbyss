using UnityEngine;
using GameComponents;

[CreateAssetMenu(menuName = "GameComponents/AI/Decisions/In range of target")]
    public class InRangeOfTarget : Decision
    {
        public float range;

        public override bool Decide(AI controller)
        {
            return InRange(controller);
        }

        private bool InRange(AI controller)
        {
            if (Vector2.Distance(controller.rb2d.position, controller.target.position) < range)
            {
                return true;
            }

            return false;
        }
    }

