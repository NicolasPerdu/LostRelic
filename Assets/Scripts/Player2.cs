using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed = 15f;
   
   


    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * movement * Time.deltaTime * speed);

        
        
    }
}
