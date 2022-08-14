using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamagable
{
    public int health;
    public GameObject spider, deathEffect, patrolLight;

  


    void Awake()
    {
        health = 100;

        spider.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    private void Die()
    {
        
        if (health <= 0)
            {
                spider.SetActive(false);
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                patrolLight.SetActive(false);
                Destroy(this.gameObject);
            }
    }

  

}
