using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Player1") {
            if(col.gameObject.GetComponent<Player1>()._anim.GetCurrentAnimatorStateInfo(0).IsName("Player Attack")) {
                Destroy(gameObject);
            }
        } else if (col.gameObject.name == "Player2") {
            if (col.gameObject.GetComponent<Player2>()._anim.GetCurrentAnimatorStateInfo(0).IsName("Player Attack")) {
                Destroy(gameObject);
            }
        }
    }
}
