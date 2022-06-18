using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    double delay = 5, buffer = 0;
    public GameObject bul;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        buffer = buffer + Time.deltaTime;
        if (buffer > delay) {
            GameObject go = Instantiate(bul, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            go.transform.SetParent(transform);
            Vector2 vec = new Vector2(-1, 1);
            go.GetComponent<Rigidbody2D>().AddForce(vec.normalized * 6, ForceMode2D.Impulse);

            // GameObject go = GameObject.Instantiate(bul, new Vector3(transform.parent.position.x - 10, transform.parent.position.y, 0), Quaternion.identity);
            // go.GetComponent<Rigidbody2D>().AddForce(Vector2.one.normalized * 10, ForceMode2D.Impulse);

            buffer = 0;
        }
    }
}
