using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarFill : MonoBehaviour
{
    public Slider slider; // Reference to the UI Slider component
    public SpriteRenderer[] pipeRenderers; // Reference to the child pipes' SpriteRenderers

    private bool isFilled = false; // Track if the bar is filled

    public void UpdateSliderValue(float normalizedValue)
    {
        if (!isFilled) // Only update if the bar is not filled
        {
            slider.value = normalizedValue;
            //Debug.Log("Normalized Value: " + normalizedValue);

            // Check if the value is close to 1 (filled)
            if (normalizedValue >= 0.97f && normalizedValue <= 0.99f)
            {
                isFilled = true;
                Debug.Log("YOU WON");

                // Change the sorting order of child pipes to sorting Order 4
                foreach (SpriteRenderer pipeRenderer in pipeRenderers)
                {
                    pipeRenderer.sortingOrder = 4; // Change to your desired sorting layer
                }

                G2MenuManager.instance.WinScreen();
                //gameObject.SetActive(false);
                UnlockNewLevel();
            }
        }
    }

    public bool IsFilled()
    {
        return isFilled;
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