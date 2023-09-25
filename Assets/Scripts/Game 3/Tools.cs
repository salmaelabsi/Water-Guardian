using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public Transform cursorObj;

    void OnMouseDown()  //when the object is clicked
    {
        G3GameManager.currentTool = gameObject.name switch
        {
            //if the object we clicked on is called seeds
            "seeds" => "seeds",//the current object we are on is seeds
            "sprinkler1" => "sprinkler1",
            "sprinkler2" => "sprinkler2",
            "sprinkler3" => "sprinkler3",
            _ => "none",
        };
        cursorObj.transform.position = transform.position;  //take the position of cursor and attach it to the position of the object we clicked on (whatever the script is attached to)
        
        //Debug.Log(G3GameManager.currentTool);
    }
}
//Code by Salma Elabsi