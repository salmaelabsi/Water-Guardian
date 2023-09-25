using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public AchievementDatabase database;
    public AchievementNotifController notifController;
    public MyAchievements achievementToShow;

    public void ShowNotification()
    {
        Achievement a = database.achievements[(int)achievementToShow]; //to show the notif at the correct index
        notifController.ShowNotification(a);
    }
}
//Code by Salma Elabsi