using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class G4GameManager : MonoBehaviour
{
    public static G4GameManager instance;

    public bool gameOver = false;
    public MyAchievements winAchievement;

    [SerializeField] private GameObject menuScreen, gameOverScreen;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void PlayButton()
    {
        G4SoundManager.instance.PlayClick();
        menuScreen.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;
        G4SoundManager.instance.GameOverSound();
        gameOverScreen.SetActive(true);
        UnlockNewLevel();
        NotificationManager.Instance.ShowAchievementNotification(winAchievement);
    }

    public void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
//Code by Salma Elabsi