using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggPart : MonoBehaviour
{
    double buffer = 0, timeMax; 
    // Start is called before the first frame update
    void Start()
    {
        timeMax = Random.Range(0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(buffer > timeMax) {
            Destroy(gameObject);
        }
        buffer = buffer + Time.deltaTime;
    }
}
