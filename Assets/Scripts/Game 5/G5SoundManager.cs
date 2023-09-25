using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G5SoundManager : MonoBehaviour
{
    public static G5SoundManager instance;
    [SerializeField] private AudioClip click, reward, loss, bgMusic;
    [SerializeField] private AudioSource soundFX, bgMusicSource;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) { instance = this; }  
    }

    public void PlayClick()
    {
        soundFX.PlayOneShot(click);
    }

    public void PlayReward()
    {
        soundFX.PlayOneShot(reward);
    }

    public void PlayLoss()
    {
        soundFX.PlayOneShot(loss);
    }

    public void PlayMusic()
    {
        bgMusicSource.Play();
    }
}
//Code by Salma Elabsi