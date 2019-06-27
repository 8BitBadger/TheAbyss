using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CameraData", menuName = "Create new camera data")]
public class CameraData : ScriptableObject
{
    //The smoothness of the camera movement
    public float smoothSpeed = .125f;
    //The offset of the camera to the target
    public Vector3 offset = new Vector3(0f, 0f, -10f);
}

//testing