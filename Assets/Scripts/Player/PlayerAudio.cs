using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource playerSourse;
    [SerializeField] AudioSource soundsSourse;
    [SerializeField] AudioClip itemUp;

    private void Start()
    {
        GameManager.OnGamePause += SoundOff;
        GameManager.OnGameResume += SoundOn;
        playerSourse.Pause();
    }

    private void OnDestroy()
    {
        GameManager.OnGamePause -= SoundOff;
        GameManager.OnGameResume -= SoundOn;
    }
    private void SoundOff()
    {
        playerSourse.volume = 0;
    }

    private void SoundOn()
    {
        playerSourse.volume = 1;
    }

    public void PlayItemUpSound()
    {
        soundsSourse.PlayOneShot(itemUp);
    }

    public void PlaySound(AudioClip clip)
    {
        soundsSourse.PlayOneShot(clip);
    }

    public void PlayerWalk()
    {
        if(playerSourse.isPlaying == false || playerSourse.pitch != 1)
        {
            playerSourse.pitch = 1;
            playerSourse.UnPause();
        }
    }

    public void PlayerRun()
    {
        if (playerSourse.isPlaying == false || playerSourse.pitch != 1.5f)
        {
            playerSourse.pitch = 1.5f;
            playerSourse.UnPause();
        }
    }

    public void PlayerStop()
    {
        if (playerSourse.isPlaying == true)
        {
            playerSourse.Pause();
        }
    }
}
