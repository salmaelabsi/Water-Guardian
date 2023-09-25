using UnityEngine;
using UnityEngine.SocialPlatforms;

public class G2MenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip click, win, water;
    [SerializeField] private AudioSource soundFX;

    public static G2MenuManager instance;
    
    public bool gameOver = false;
    public MyAchievements winAchievement;

    [SerializeField] private GameObject menu, winScreen;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void Playbutton()
    {
        PlayClick();
        menu.SetActive(false);
    }

    public void WinScreen()
    {
        PlayWin();
        gameOver = true;
        winScreen.SetActive(true);
        NotificationManager.Instance.ShowAchievementNotification(winAchievement);
    }

    public void PlayClick()
    {
        soundFX.PlayOneShot(click);
    }

    public void PlayWin()
    {
        soundFX.PlayOneShot(water);
        soundFX.PlayOneShot(win);
    }
}
//Code by Salma Elabsi