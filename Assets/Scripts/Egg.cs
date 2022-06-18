using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    double delay = 5, buffer = 0;
    public GameObject spider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Player1") {
            if (col.gameObject.GetComponent<Player1>()._anim.GetCurrentAnimatorStateInfo(0).IsName("Player Attack")) {
                Destroy(gameObject);
            }
        } else if (col.gameObject.name == "Player2") {
            if (col.gameObject.GetComponent<Player2>()._anim.GetCurrentAnimatorStateInfo(0).IsName("Player Attack")) {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        buffer = buffer + Time.deltaTime;

        if (buffer > delay) {

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;

            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            
            GameObject go = Instantiate(spider, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            go.transform.SetParent(transform);
            //Vector2 vec = new Vector2(-1, 1);
            //go.GetComponent<Rigidbody2D>().AddForce(vec.normalized * 8, ForceMode2D.Impulse);

            // GameObject go = GameObject.Instantiate(bul, new Vector3(transform.parent.position.x - 10, transform.parent.position.y, 0), Quaternion.identity);
            // go.GetComponent<Rigidbody2D>().AddForce(Vector2.one.normalized * 10, ForceMode2D.Impulse);

            buffer = 0;
        }
    }
}
