using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        } else
        {
            Load();
        }

        UpdateImage();
        AudioListener.pause = muted;
    }

    public void OnbuttonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateImage();
    }

    private void UpdateImage()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else { 
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Load () {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save ()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}

//Code by Salma Elabsi