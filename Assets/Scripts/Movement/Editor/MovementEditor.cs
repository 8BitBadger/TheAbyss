using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MovementData))]
public class MovementEditor : Editor
{
    float oldBaseSpeed = 0;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MovementData data = (MovementData)target;

        if (oldBaseSpeed != data.baseSpeed)
        {
            oldBaseSpeed = data.baseSpeed;
            data.speed = oldBaseSpeed;
        }
    }
}
