using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public AchievementDatabase database;
    public AchievementNotifController notifController;

    private static NotificationManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static NotificationManager Instance
    {
        get { return instance; }
    }

    public void ShowAchievementNotification(MyAchievements achievementToShow)
    {
        Achievement a = database.achievements[(int)achievementToShow];
        notifController.ShowNotification(a);
    }
}
//Code by Salma Elabsi