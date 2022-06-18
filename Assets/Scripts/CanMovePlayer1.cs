using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMovePlayer1 : MonoBehaviour
{
    public Player1 player;

    public void MoveAgain()
    {
        player.canAttack = true;
    }

    public void AttackEnemy()
    {
        player.attackBox.SetActive(true);
    }

    public void AttackDisabled()
    {
        player.attackBox.SetActive(false);
    }

    public void LeftFoot()
    {
        FindObjectOfType<AudioManager>().PlaySFX(3);
    }
    public void RightFoot()
    {
        FindObjectOfType<AudioManager>().PlaySFX(4);
    }

    public void HumanHitSound()
    {
        FindObjectOfType<AudioManager>().PlaySFX(6);
    }

    public void TheImpact()
    {
        FindObjectOfType<AudioManager>().PlaySFX(7);
    }
   /*private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Enemy>().Die();
    }*/
}
