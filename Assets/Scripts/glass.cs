using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour,IDestroyable
{
     

    public void OnPlayerAttack()
    {
        Destroy(gameObject);
    }
}
