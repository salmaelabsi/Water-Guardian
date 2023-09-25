using UnityEngine;

public class DeactivateWithTime : MonoBehaviour
{
    [SerializeField] private float time = 1.1f;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = time;
            gameObject.SetActive(false);
        }
    }
}
//Code by Salma Elabsi