using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G4SoundManager : MonoBehaviour
{
    public static G4SoundManager instance;

    [SerializeField] private AudioSource soundFX;

    [SerializeField] private AudioClip click, landClip, deathClip, iceBreakClip, gameOverClip;

    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlayClick()
    {
        soundFX.PlayOneShot(click);
    }

    public void LandSound()
    {
        soundFX.PlayOneShot(landClip);
    }

    public void IceBreakSound()
    {
        soundFX.PlayOneShot(iceBreakClip);
    }

    public void DeathSound()
    {
        soundFX.PlayOneShot(deathClip);
    }

    public void GameOverSound()
    {
        soundFX.PlayOneShot(gameOverClip);
    }
}
//Code by Salma Elabsi