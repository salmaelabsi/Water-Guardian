using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class G3GameManager : MonoBehaviour
{
    public static G3GameManager instance;
    [SerializeField] private GameObject menu, winScreen;

    public bool gameOver = false;

    public static string currentTool = "none";

    private int plantedSunflowers = 0;
    public MyAchievements winAchievement;

    private void Awake()
    { if (instance == null) instance = this; }

    public void Playbutton()
    {
        G3SoundManager.instance.PlayClick();
        menu.SetActive(false);
    }
   
    public void PlantSunflower()         // Called when a sunflower is planted
    {
        plantedSunflowers++;

        if (plantedSunflowers == 3)
        {
            //G3SoundManager.instance.PlayWin();
            WinScreen();        // Display the win screen when 3 sunflowers are planted
        }
    }

    public void WinScreen()
    {
        G3SoundManager.instance.PlayWin();
        gameOver = true;
        winScreen.SetActive(true);
        UnlockNewLevel();
        NotificationManager.Instance.ShowAchievementNotification(winAchievement);
    }

    void UnlockNewLevel()
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