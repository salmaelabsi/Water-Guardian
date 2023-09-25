using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()  //this method makes level buttons stay locked until the player wins the previous level
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);  //the first level stays unlocked

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void SceneLoad(int SceneIndex)
    {
        ButtonClicks.instance.PlayClick();

        if (SceneIndex == SceneManager.GetSceneByName("GamePlay").buildIndex && G4GameManager.instance.gameOver) //10?
        {
            SceneManager.LoadScene("Game 4");
        }
        else
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }
}
//Code by Salma Elabsi