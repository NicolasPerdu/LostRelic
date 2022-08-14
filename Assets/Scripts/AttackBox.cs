using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    [SerializeField] private int weaponDamage;
    public GameObject effect;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagable>(out var damagable))
        {
            damagable.TakeDamage(weaponDamage);
            
        }

        if (collision.gameObject.TryGetComponent<IDestroyable>(out  var destroyable))
        {
            destroyable.OnPlayerAttack();
            Instantiate(effect, collision.gameObject.transform.position, collision.gameObject.transform.rotation); 
        }

       
    }
}
