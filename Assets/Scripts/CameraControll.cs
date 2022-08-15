using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform target;
    public float minHeight, maxHeight, minWide, maxWide;
   


    //smooth camera
    [Range(0, 10)]
    public float smoothness;
    public Vector3 offset;

    

    private void LateUpdate()
    {
        if (target == null)
            return;
        Vector3 desirePosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothness * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.position = new Vector3(Mathf.Clamp(smoothedPosition.x, minWide, maxWide), Mathf.Clamp(smoothedPosition.y, minHeight, maxHeight), transform.position.z);
        
    }

    public void UpdatePlayer(GameObject _target)
    {
        target = _target.transform;
    }
}
