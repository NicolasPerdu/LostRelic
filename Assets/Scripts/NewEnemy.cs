using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour,IDamagable
{
   
    public float speed = 3f;
    public GameObject spider,deathEffect,lightEnemy;
  
    public int collisiondamage = 20;
    public float health;
   

    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        health = 100;
        
        spider.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
     
        transform.Translate(Vector2.left* speed * Time.deltaTime);
        Die();
             

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
              
            
           if(collision.gameObject.GetComponent<PlayerController>()._anim.GetCurrentAnimatorStateInfo(0).IsName("Player Attack"))
           {
                Debug.Log("Hit");
                health -= 50;
            }
            
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }
}
