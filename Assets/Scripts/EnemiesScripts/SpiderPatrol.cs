using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPatrol : MonoBehaviour
{
    public bool changeDir;
    [SerializeField] private float patrolspeed;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundpoint;
    private readonly float radius = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        changeDir = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangeMovementDirection();

    }

    private void Move()
    {
        transform.Translate(patrolspeed * Time.deltaTime * Vector2.left);
    }

    private void ChangeMovementDirection()
    {
        if (changeDir)
        {
            transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
            patrolspeed *= (-1);
            changeDir = false;
        }
       
    }

    private void FixedUpdate()
    {
        changeDir = Physics2D.OverlapCircle(groundpoint.position, radius, groundMask);
    }
}
