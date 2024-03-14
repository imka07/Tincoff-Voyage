using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private Marker attachedMarker;

    public void Initialize(Marker marker)
    {
        attachedMarker = marker;
    }


  
    public void SetSize(float newSize)
    {
        transform.localScale = new Vector3(newSize, newSize, newSize);
    }

    public void ResetSize(float resetSize)
    {
        SetSize(resetSize);
    }

    public void SetRotation(float newRotation)
    {
        transform.localEulerAngles = new Vector3(transform.rotation.x, newRotation, transform.rotation.z);
        
    }

}



