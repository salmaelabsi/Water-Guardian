using UnityEngine;

public class G1SoundManager : MonoBehaviour
{
    public static G1SoundManager instance;
    [SerializeField] private AudioClip click, win, bgMusic;
    [SerializeField] private AudioSource soundFX, bgMusicSource;

    void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void PlayClick()
    {
        soundFX.PlayOneShot(click);
    }

    public void PlayWin()
    {
        soundFX.PlayOneShot(win);
    }

    public void PlayMusic()
    {
        bgMusicSource.Play();
    }
}
//Code by Salma Elabsi