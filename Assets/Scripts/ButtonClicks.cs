using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicks : MonoBehaviour
{
    public static ButtonClicks instance;

    [SerializeField] private AudioClip click;
    [SerializeField] private AudioSource soundFX;

    void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void PlayClick()
    {
        soundFX.PlayOneShot(click);
    }
}
//Code by Salma Elabsi