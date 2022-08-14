using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPatrol : MonoBehaviour
{
    public bool canflip;
    [SerializeField] private float patrolspeed;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundpoint;
    private float radius = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        canflip = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();

    }

    private void Move()
    {
        transform.Translate(Vector2.left * patrolspeed * Time.deltaTime);
    }

    private void Flip()
    {
        if (canflip)
        {
            transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
            patrolspeed *= (-1);
            canflip = false;
        }
       
    }

    private void FixedUpdate()
    {
        canflip = Physics2D.OverlapCircle(groundpoint.position, radius, groundMask);
    }
}
