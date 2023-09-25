using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantControl : MonoBehaviour
{
    public Sprite soil;
    public Sprite sunFlower1;
    public Sprite sunFlower2;

    public float growTime = 0;  //unique for each obj the script is attached to

    public Transform waterDroplets;

    public string watered = "n";

    // Reference to the GameManager to control the win condition
    private G3GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Find and store the GameManager instance
        gameManager = FindObjectOfType<G3GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().sprite == sunFlower1)  //check to see if the current image is sunflower 1
        {
            growTime += Time.deltaTime;  //then start the growing timer
        }

        if (growTime > 3) //after 3 seconds have elapsed
        {
            if (watered == "y")
            {
                GetComponent<SpriteRenderer>().sprite = sunFlower2;   //change the object/image to sunflower 2
                gameManager.PlantSunflower();        // Notify the GameManager that a sunflower has been planted
            }
            else {
                growTime = 0;
                GetComponent<SpriteRenderer>().sprite = soil;
            }
        }
    }

    void OnMouseDown()  //when the object is clicked
    {
        Debug.Log("clicked on soil");

        if ((G3GameManager.currentTool == "seeds") && (GetComponent<SpriteRenderer>().sprite == soil))
        {
            GetComponent<SpriteRenderer>().sprite = sunFlower1;
        }

        if (G3GameManager.currentTool == "sprinkler1"|| G3GameManager.currentTool == "sprinkler2"|| G3GameManager.currentTool == "sprinkler3")
        {
            G3SoundManager.instance.PlaySprinkler();
            waterDroplets.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
            watered = "y";
        }
    }
}

//Code by Salma Elabsi
