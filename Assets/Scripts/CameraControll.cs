using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform target;
    public float minHeight, maxHeight, minWide, maxWide;
    private Vector2 lastPos;


    //smooth camera
    [Range(0, 10)]
    public float smoothness;
    public Vector3 offset;

   /* private void Start()
    {
        if (target is null)
        {
            target = FindObjectOfType<Player1>().transform;
        }
        lastPos = transform.position;
    }
   */
    private void Update()
    {

        Vector3 desirePosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothness * Time.deltaTime);
        transform.position = smoothedPosition;


        transform.position = new Vector3(Mathf.Clamp(smoothedPosition.x, minWide, maxWide), Mathf.Clamp(smoothedPosition.y, minHeight, maxHeight), transform.position.z);
        lastPos = transform.position;
    }

    public void UpdatePlayer(GameObject _target)
    {
        target = _target.transform;
    }
}
