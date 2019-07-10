using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //The smoothness of the camera movement
    [Range(0, 1)]
    public float smoothSpeed;
    [HideInInspector]
    //The offset of the camera to the target
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    private Transform target = null;

    public void SetTarget(Transform _target)
    {
        //Set the target foir the camera to follow
        target = _target;
    }

    private void FixedUpdate()
    {        //Sets the desired position of the camera with the offset worked in
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition;
        //We then smooth the position of the camera using vector3 lerp
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //Finnaly we set the transforms position to the smoothed position
        transform.position = smoothedPosition;
    }
}

