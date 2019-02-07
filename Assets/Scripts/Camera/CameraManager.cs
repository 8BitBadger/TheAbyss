using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CameraData data;
   
    public void SetTarget(Transform _target)
    {
        //Set the target foir the camera to follow
        data.target = _target;
    }

    private void FixedUpdate()
    {
        //Sets the desired position of the camera with the offset worked in
        Vector3 desiredPosition = data.target.position + data.offset;
        //We then smooth the position of the camera using vector3 lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, data.smoothSpeed);
        //Finnaly we set the transforms position to the smoothed position
        transform.position = smoothedPosition;
    }
}

