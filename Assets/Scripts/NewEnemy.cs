using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
   
    public float speed = 3f;
    public GameObject spider,deathEffect,lightEnemy;
    public GameObject startpoint;
    public GameObject endpoint;
    private float distance;
    private float dir = -3f;
    private float lastdistance;
    public int collisiondamage = 20;
    public float health;
    private float xbound = 25;

    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        
        
        spider.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
      distance = Vector2.Distance(this.transform.position, endpoint.transform.position);
        lastdistance= Vector2.Distance(this.transform.position, startpoint.transform.position);
       
        transform.Translate(Vector2.left* speed * Time.deltaTime);
      if (distance <= 3.00f )
        {
            speed =dir;
            transform.localScale = new Vector3(-1, transform.localScale.y);
            
        }
        else if( lastdistance <= 3.00f)
        {

            speed =-dir;
            transform.localScale = new Vector3(1, transform.localScale.y);
        }

        

    }

    void Die()
    {
        if(health<=0)
        {
            spider.SetActive(false);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            lightEnemy.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            speed = -speed;
            transform.localScale = new Vector3((-1) * transform.localScale.x, transform.localScale.y);

        }
        if(collision.collider.CompareTag("Enemy"))
        {
            speed = -speed;
            transform.localScale = new Vector3((-1) * transform.localScale.x, transform.localScale.y);

        }



        if (collision.collider.CompareTag("Player"))
        {
            speed = -speed;
            transform.localScale = new Vector3((-1)*transform.localScale.x, transform.localScale.y);
            collision.collider.GetComponent<HealthController>().PlayerHurt(collisiondamage);
        }
    }
    






}
