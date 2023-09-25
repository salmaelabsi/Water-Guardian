using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class G3SoundManager : MonoBehaviour
{
    public static G3SoundManager instance;
    [SerializeField] private AudioClip click, sprinkler, win, bgMusic;
    [SerializeField] private AudioSource soundFX, bgMusicSource;

    void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void PlayMusic()
    {
        bgMusicSource.Play();
    }

    public void PlayClick()
    {
        soundFX.PlayOneShot(click);
    }

    public void PlaySprinkler()
    {
        soundFX.PlayOneShot(sprinkler);
    }

    public void PlayWin()
    {
        soundFX.PlayOneShot(win);
    }
}
//Code by Salma Elabsi