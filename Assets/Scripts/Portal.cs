using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private float triggerCount = 1.00f;
    private Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            timer.PortalReached(triggerCount);
            Debug.Log("Hit Player!");
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            timer.PortalReached(triggerCount);
            Debug.Log("Hit Player!");
        }
    }

}
