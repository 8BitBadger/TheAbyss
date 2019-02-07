using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RotationData))]
public class RotationEditor : Editor
{
    float oldBaseSpeed = 0;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RotationData data = (RotationData)target;

        if (oldBaseSpeed != data.baseSpeed)
        {
            oldBaseSpeed = data.baseSpeed;
            data.speed = oldBaseSpeed;
        }
    }
}

