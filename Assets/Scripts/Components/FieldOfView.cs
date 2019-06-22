using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetLayer;
    public LayerMask obstacleLayer;

    void FindVissibleTarget()
    {
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetLayer);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Vector2 dirToTarget = ((targetsInViewRadius[i].transform.position - transform.position).normalized);
            if(Vector2.Angle (transform.forward, dirToTarget)< viewAngle /2)
            {
               if(!Physics2D.Linecast(transform.position, targetsInViewRadius[i].transform.position, obstacleLayer)) 
               {
                   //TODO: Add code to do what happens after target is seen
               }
            }
        }
    }
    public Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
}