using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ProjectOnGround : MonoBehaviour
{
    private Quaternion savedRotation;

    // called before rendering the object        
    void OnWillRenderObject()
    {
        savedRotation = transform.rotation;
        var eulers = transform.rotation.eulerAngles;
        //transform.rotation = Quaternion.Euler(Constants.Isometric.PerspectiveAngle, eulers.y, eulers.z);
    }

    //called right after rendering the object
    void OnRenderObject()
    {
        transform.rotation = savedRotation;
    }

}
