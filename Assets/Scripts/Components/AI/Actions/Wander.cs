using GameComponents;
using UnityEngine;

[CreateAssetMenu(menuName = "GameComponents/AI/Actions/Wander")]
public class Wander : Action
{
    public override void Act(AI controller)
    {
        Wandering(controller);
    }

    private void Wandering(AI controller)
    {
        if(Vector2.Distance(controller.rb2d.position, controller.wanderPoint) < .2f)
        {
           controller.wanderPoint = GetWanderPoint.NewPoint(controller); 
        }
        Vector2 normalizedDir = (controller.wanderPoint - controller.rb2d.position).normalized;
        controller.rb2d.MovePosition(controller.rb2d.position + normalizedDir * controller.GetComponent<Stats>().moveSpeed.Value * Time.deltaTime);
    }
}

