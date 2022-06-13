using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private int triggerCount = 1;
    private Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            timer.PortalReached(triggerCount);
            Debug.Log("Hit Player!");
        }
    }

}
