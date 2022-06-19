using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int collisionDamage;
    // Start is called before the first frame update
    void Start()
    {
        collisionDamage = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<HealthController>().PlayerHurt(collisionDamage);

        }
    }
}
