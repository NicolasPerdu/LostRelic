using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMovePlayer1 : MonoBehaviour
{
    public Player1 player;

    public void MoveAgain()
    {
        player.canMove = true;
    }

    public void AttackEnemy()
    {
        player.attackBox.SetActive(true);
    }

    public void AttackDisabled()
    {
        player.attackBox.SetActive(false);
    }

   /*private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Enemy>().Die();
    }*/
}
