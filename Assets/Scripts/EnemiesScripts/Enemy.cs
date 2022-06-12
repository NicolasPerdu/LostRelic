using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PhysicsObject
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float rayCastLenght;
    [SerializeField] private Vector2 rayCastOffest;
    [SerializeField] private LayerMask rayCastLayerMask;
    [SerializeField] private int enemyCollisiondamage;
    [SerializeField] private int health;
    private int direction=1;
    private RaycastHit2D rightLedgeRayCastHit;
    private RaycastHit2D leftLedgeRayCastHit;
    private RaycastHit2D rightWallRayCastHit;
    private RaycastHit2D leftWallRayCastHit;

    public int EnemyCollisiondamage { get => enemyCollisiondamage; set => enemyCollisiondamage = value; }
    public int Health { get => health; set => health = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(horizontalSpeed *direction, 0);

        //check right ledge
        rightLedgeRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffest.x, transform.position.y+rayCastOffest.y),Vector2.down, rayCastLenght);
        Debug.DrawRay(new Vector2(transform.position.x + rayCastOffest.x, transform.position.y + rayCastOffest.y), Vector2.down * rayCastLenght, Color.red);
        if (rightLedgeRayCastHit.collider == null) 
        {
            direction = -1;
        }
        rightWallRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x , transform.position.y + rayCastOffest.y), Vector2.right, rayCastLenght,rayCastLayerMask);
        if (rightWallRayCastHit.collider != null)
        {
            direction = -1;
        }

        leftWallRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + rayCastOffest.y), Vector2.left, rayCastLenght, rayCastLayerMask);
        if (leftWallRayCastHit.collider != null)
        {
            direction = 1;

        }

        //check left ledge
        leftLedgeRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x - rayCastOffest.x, transform.position.y + rayCastOffest.y), Vector2.down, rayCastLenght);
        Debug.DrawRay(new Vector2(transform.position.x - rayCastOffest.x, transform.position.y + rayCastOffest.y), Vector2.down * rayCastLenght, Color.red);
        if (leftLedgeRayCastHit.collider == null)
        {
            direction = 1;

        }

        Die();
    }

    private void Die()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Player1.Instance.gameObject)
        {
            Player1Hurt(EnemyCollisiondamage);
        }
        else if(collision.gameObject == Player2.Instance.gameObject)
        {
            Player2Hurt(EnemyCollisiondamage);
        }

    }*/


    //Olteanu was here( i change player searc with player tag)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerHealth>().Health -= EnemyCollisiondamage;
            
        }
        

    }

   /*private static void Player1Hurt(int damage)
    {
        
        Player1.Instance.Health -= damage;
        Player1.Instance.UpdateUI();
       
    }
    private static void Player2Hurt(int damage)
    {

        Player2.Instance.Health -= damage;
        Player2.Instance.UpdateUI();

    }*/

}
