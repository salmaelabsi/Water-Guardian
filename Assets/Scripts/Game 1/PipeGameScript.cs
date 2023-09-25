using UnityEngine;

public class PipeGameScript : MonoBehaviour
{
    float[] rotations =  {0, 90, 180, 270};

    [SerializeField] public float[] correctRotation;
    [SerializeField] bool isPlaced = false;

    int possibleRots = 1;

    G1Manager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<G1Manager>();
    }

    private void Start()
    {
        possibleRots = correctRotation.Length;

        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (possibleRots > 1)
        {
            if ((   transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1]) && isPlaced == false)
            {
                isPlaced = true;
                gameManager.CorrectMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0])
            {
                isPlaced = true;
                gameManager.CorrectMove();
            }
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));
        if (possibleRots > 1)
        {
            if ((transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1]) && isPlaced == false)
            {
                isPlaced = true;
                gameManager.CorrectMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
            }
        }
        else
        {
            if ((transform.eulerAngles.z == correctRotation[0]) && isPlaced == false)
            {
                isPlaced = true;
                gameManager.CorrectMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
            }
        }
    }
}
//Code by Salma Elabsi