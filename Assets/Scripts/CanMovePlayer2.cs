using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMovePlayer2 : MonoBehaviour
{
    public Player2 player;

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
}
