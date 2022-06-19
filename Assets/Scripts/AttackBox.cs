using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    [SerializeField] private int weaponDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //FindObjectOfType<Enemy>().gameObject)
        {
            //collision.gameObject.GetComponent<Enemy>().Health -= weaponDamage + Player1.Instance.AttackPower ;
            //collision.gameObject.GetComponent<Enemy>().Die(); 
            collision.gameObject.GetComponent<NewEnemy>().health -= weaponDamage;
            
        }

    }
}
