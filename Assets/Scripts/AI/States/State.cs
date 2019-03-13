using UnityEngine;


    [CreateAssetMenu(menuName = "Components/AI/State")]
    public class State : ScriptableObject
    {
    //TODO Need to make an error message that if there are no transitions or actions but the element is still set to 1 in the inspector the game throws error must disallow or check for elements before starting
        public Action[] actions;
        public Transition[] transitions;

        public void UpdateState(StateController controller)
        {
            DoActions(controller);
            CheckTransitions(controller);
        }

        private void DoActions(StateController controller)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Act(controller);
            }
        }

        private void CheckTransitions(StateController controller)
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                bool decisionSucceeded = transitions[i].decision.Decide(controller);

                if (decisionSucceeded)
                {
                    controller.TransitionToState(transitions[i].trueState);
                }
                else
                {
                    controller.TransitionToState(transitions[i].falseState);
                }
            }
        }
    }
