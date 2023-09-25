using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class AchievementNotifController : MonoBehaviour
{
    [SerializeField] Text achievementTitleLabel;

    private Animator nAnimator;

    private void Awake()
    {
        nAnimator = GetComponent<Animator>();
    }

    public void ShowNotification(Achievement achievement)
    {
        achievementTitleLabel.text = achievement.name;
        nAnimator.SetTrigger("Appear");
    }
}
//Code by Salma Elabsi