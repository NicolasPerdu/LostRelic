using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int collisionDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player1"))
        {
            collision.collider.GetComponent<Player1Health>().PlayerHurt(collisionDamage);

        }
        if (collision.collider.CompareTag("Player2"))
        {
            collision.collider.GetComponent<Player2Health>().PlayerHurt(collisionDamage);

        }

    }
}
