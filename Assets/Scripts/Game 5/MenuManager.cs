using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public bool gameOver = false;

    [SerializeField] private Text rewardText, scoreText, gameOverScoretxt, gameOverRewardtxt;
    [SerializeField] private GameObject gameMenu, menu, gameOverMenu;

    private int currentReward, currentScore;
    public MyAchievements winAchievement;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "" + 0;
        rewardText.text = "" + 0;
    }

    public void IncreaseReward()
    {
        currentReward++;
        rewardText.text = "" + currentReward;
    }

    public void IncreaseScore()
    {
        currentScore++;
        scoreText.text = "" + currentScore;
    }

    public void Playbutton()
    {
        G5SoundManager.instance.PlayClick();
        menu.SetActive(false);
        gameMenu.SetActive(true);
        Player.instance.StartMoving = true;
    }

    public void GameOver()
    {
        G5SoundManager.instance.PlayLoss();
        gameOver = true;
        gameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        gameOverScoretxt.text = "Score (Gol):" + currentScore;
        gameOverRewardtxt.text = "Fish (Balik): " + currentReward;
        NotificationManager.Instance.ShowAchievementNotification(winAchievement);
    }

}
//Code by Salma Elabsi