using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PhysicsObject
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float rayCastLenght;
    [SerializeField] private Vector2 rayCastOffest;
    [SerializeField] private LayerMask rayCastLayerMask, whatIsWall;
    [SerializeField] private int enemyCollisiondamage;
    [SerializeField] private int health;
    private int direction=1;
    private RaycastHit2D rightLedgeRayCastHit;
    private RaycastHit2D leftLedgeRayCastHit;
    private RaycastHit2D rightWallRayCastHit;
    private RaycastHit2D leftWallRayCastHit;
    public GameObject deathEffect, spider, lightEnemy;
    private CapsuleCollider2D capsuleCollider;
    private bool isWallRight, changeDir;
    public Transform wallRight;
    

    public int EnemyCollisiondamage { get => enemyCollisiondamage; set => enemyCollisiondamage = value; }
    public int Health { get => health; set => health = value; }

    // Start is called before the first frame update
    void Start()
    {
        changeDir = true;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetVelocity.x < -0.1)
        {
            transform.localScale = new Vector3(1, transform.localScale.y);
        }
        else if (targetVelocity.x > 0.1)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y);
        }

        targetVelocity = new Vector2(horizontalSpeed *direction, 0);
        //Olteanu was here(checking right)
        isWallRight = Physics2D.OverlapCircle(wallRight.position, .1f, whatIsWall);
        
        //check right ledge
        rightLedgeRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffest.x, transform.position.y+rayCastOffest.y),Vector2.down, rayCastLenght);
        Debug.DrawRay(new Vector2(transform.position.x + rayCastOffest.x, transform.position.y + rayCastOffest.y), Vector2.down * rayCastLenght, Color.red);
        if (rightLedgeRayCastHit.collider == null) 
        {
            direction = -1;
            //transform.localScale = new Vector2(1, 1);
        }
        rightWallRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x , transform.position.y + rayCastOffest.y), Vector2.right, rayCastLenght,rayCastLayerMask);
        if (rightWallRayCastHit.collider != null)
        {
            direction = -1;
            //transform.localScale = new Vector2(1, 1);
        }

        leftWallRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + rayCastOffest.y), Vector2.left, rayCastLenght, rayCastLayerMask);
        if (leftWallRayCastHit.collider != null)
        {
            direction = 1;
            //transform.localScale = new Vector2(-1, 1);

        }

        //check left ledge
        leftLedgeRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x - rayCastOffest.x, transform.position.y + rayCastOffest.y), Vector2.down, rayCastLenght);
        Debug.DrawRay(new Vector2(transform.position.x - rayCastOffest.x, transform.position.y + rayCastOffest.y), Vector2.down * rayCastLenght, Color.red);
        if (leftLedgeRayCastHit.collider == null)
        {
            direction = 1;

        }

        //Olteanu was here(This is a raycast to check a wall masklayer, is changing direction, with a bool)
        if (isWallRight)
        {
            if (changeDir)
            {
                direction = -1;
                transform.localScale = new Vector2(-1, 1);
                changeDir = false;
                targetVelocity = new Vector2(horizontalSpeed * direction, 0);
            }
            else
            {
                direction = 1;
                transform.localScale = Vector2.one;
                changeDir = true;
                targetVelocity = new Vector2(horizontalSpeed * direction, 0);
            }
        }
    }


    //Olteanu was here(here the death effect is added to enemy when die,
    //i call this function in AttackBox,is like a update that AttackBox,
    //every time AttackBox is active, will call this function.
    //If is called in Update , this function will not work)
    public void Die()
    {
        if (Health <= 0)
        {
            spider.SetActive(false);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            lightEnemy.SetActive(false);
            capsuleCollider.enabled = false;
            Destroy(gameObject,5f);
            
        }
    }

    //Olteanu was here( i change player search with player tag)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player1"))
        {
            collision.collider.GetComponent<Player1Health>().PlayerHurt(enemyCollisiondamage);
            direction = -direction;
            
        }

        if (collision.collider.CompareTag("Player2"))
        {
            collision.collider.GetComponent<Player2Health>().PlayerHurt(enemyCollisiondamage);
            direction = -direction;

        }
    }

    //Olteanu was here(Visual draw to see the right Transform point)
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(wallRight.position, .1f);
    }

}
