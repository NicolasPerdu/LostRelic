using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveIntro : MonoBehaviour
{
    public IntroductionPlayer player;

    public void MoveAgain()
    {
        player.canMove = true;
    }
}
