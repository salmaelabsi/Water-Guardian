using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    
    public static BackgroundMusic instance;

    private void Awake()
    {
        if (instance == null)
        {
            // This is the first instance, make it the singleton and play the music.
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Another instance exists, destroy this one.
            Destroy(gameObject);
        }

        // Subscribe to the sceneLoaded event to handle scene changes.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event when the object is destroyed.
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check the scene name when a new scene is loaded.
        if (scene.name == "Game 1" || scene.name == "Game 2" || scene.name == "Game 3" || scene.name == "Game 4" || scene.name == "Game 5")
        {
            BackgroundMusic.instance.GetComponent<AudioSource>().Pause();
        }
        /*else
        {
            BackgroundMusic.instance.GetComponent<AudioSource>().Play();
        }*/
    }

    
}
//Code by Salma Elabsi