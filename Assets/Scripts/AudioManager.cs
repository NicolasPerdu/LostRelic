using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] bgm;
    public AudioSource[] sfx;

    public void PlayBGM(int musicToPlay)
    {
        /*
        if (!bgm[musicToPlay].isPlaying)
        {
            StopMusic();

            if (musicToPlay < bgm.Length)
            {
                bgm[musicToPlay].Play();
            }
        }*/
        if (musicToPlay < bgm.Length)
        {
            bgm[musicToPlay].Play();
        }
    }

    public void PlaySFX(int soundToPlay)
    {
        if (soundToPlay < sfx.Length)
        {
            sfx[soundToPlay].Play();
        }
    }

}
