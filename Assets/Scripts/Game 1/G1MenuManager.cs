using UnityEngine;
using UnityEngine.SocialPlatforms;

public class G1MenuManager : MonoBehaviour
{
    public MyAchievements winAchievement;
    public static G1MenuManager instance;

    public bool gameOver = false;

    [SerializeField] private GameObject menu, winScreen;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Playbutton()
    {
        G1SoundManager.instance.PlayClick();
        menu.SetActive(false);
    }

    public void WinScreen()
    {
        G1SoundManager.instance.PlayWin();
        gameOver = true;
        menu.SetActive(false);
        winScreen.SetActive(true);
        // Show the achievement notification when the player wins the level
        NotificationManager.Instance.ShowAchievementNotification(winAchievement);
    }
}
//Code by Salma Elabsi