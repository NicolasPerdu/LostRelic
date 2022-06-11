using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Player1 player;
    public BoxCollider2D boundsBox;
    private float halfHeight, halfWidth;
    [Range(0, 10)]
    public float smoothness;
    public Transform target;
    public Vector3 offset;

    //parallax
    //public Transform target;





    private void Start()
    {
        player = FindObjectOfType<Player1>();
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
        target = player.transform;
        //lastPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 desirePosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothness * Time.deltaTime);
            transform.position = smoothedPosition;


            transform.position = new Vector3(
                Mathf.Clamp(smoothedPosition.x, boundsBox.bounds.min.x + halfWidth, boundsBox.bounds.max.x - halfWidth),
                Mathf.Clamp(smoothedPosition.y, boundsBox.bounds.min.y + halfHeight, boundsBox.bounds.max.y - halfHeight),
                transform.position.z);
        }
    }
}
