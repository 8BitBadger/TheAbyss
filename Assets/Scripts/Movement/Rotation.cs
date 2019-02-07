using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    //The data asset for this module
    public RotationData data;

    private void OnEnable()
    {
    }

    public void Rotate(Vector3 _target)
    {
        //Set the target position to rotate to
        data.target = _target;
    }

    private void FixedUpdate()
    {
        if (data.rotate != false)
        {
            // Get Angle in Radians
            float angleRad = Mathf.Atan2(data.target.y - transform.position.y, data.target.x - transform.position.x);
            // Get Angle in Degrees
            float angleDeg = (180 / Mathf.PI) * angleRad;
            // Rotate Object while lerping the movement by the speed of the object
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angleDeg + 90), data.speed * Time.deltaTime);
        }
    }
}
