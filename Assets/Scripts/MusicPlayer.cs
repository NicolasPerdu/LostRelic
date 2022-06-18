using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public int musicToPlay;
    public bool musicStarted;

    private void Start()
    {
        musicStarted = false;
    }

    private void Update()
    {
        if (!musicStarted)
        {
            musicStarted = true;
            FindObjectOfType<AudioManager>().PlayBGM(musicToPlay);
        }
    }
}
