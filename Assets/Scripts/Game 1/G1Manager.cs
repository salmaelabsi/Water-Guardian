using UnityEngine;
using UnityEngine.SceneManagement;

public class G1Manager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;

    [SerializeField] int totalPipes = 0;
    [SerializeField] int correctedPipes = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void CorrectMove()
    {
        correctedPipes ++;
        //Debug.Log("Correct Move");

        if (correctedPipes == totalPipes)
        {
            //Debug.Log("You Win!");
            G1MenuManager.instance.WinScreen();
            gameObject.SetActive(false);
            UnlockNewLevel();
        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel",PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
//Code by Salma Elabsi