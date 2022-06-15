using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    [SerializeField] private int weaponDamage;
    public ParticleSystem hiteffect;
    

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
        if (collision.gameObject.GetComponent<Enemy>()) //FindObjectOfType<Enemy>().gameObject)
        {
            Vector3 spawnpos = new Vector3(transform.position.x, transform.position.y - 0.5f, 0f);
            ParticleSystem hitparticle = Instantiate(hiteffect, spawnpos, Quaternion.identity);
            collision.gameObject.GetComponent<Enemy>().Health -= weaponDamage + Player1.Instance.AttackPower ;
            Destroy(hitparticle, hitparticle.main.duration);
            
        }
    }

    
}
