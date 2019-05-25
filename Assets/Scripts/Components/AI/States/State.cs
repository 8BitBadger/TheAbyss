using UnityEngine;
using Comps;

[CreateAssetMenu(menuName = "Comps/AI/State")]
    public class State : ScriptableObject
    {
        public Action[] actions;
        public Transition[] transitions;

        public void UpdateState(AI controller)
        {
            DoActions(controller);
            CheckTransitions(controller);
        }

        private void DoActions(AI controller)
        {
            //Go through the ctions list and do thier respective actions
            for (int i = 0; i < actions.Length; i++)
            {
                //If the actions variables are null we do nothing
                if (actions[i] != null)
                {
                    actions[i].Act(controller);
                }
            }
        }

        private void CheckTransitions(AI controller)
        {
            //Go throuhg the transitions list (decisions list) ad check the respective functions returns
            for (int i = 0; i < transitions.Length; i++)
            {
                //If the decision variable is empty we do nothing
                if (transitions[i].decision != null)
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
    }

