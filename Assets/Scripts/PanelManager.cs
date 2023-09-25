using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject popUpPanel;

    // Function to open the pop-up panel
    public void OpenPanel()
    {
        popUpPanel.SetActive(true);
    }

    // Function to close the pop-up panel
    public void ClosePanel()
    {
        popUpPanel.SetActive(false);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ExitApp()
    {
        Debug.Log("has quit game");
        Application.Quit();
    }

}
//Code by Salma Elabsi