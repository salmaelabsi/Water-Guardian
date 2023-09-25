using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject breakablePlatform;

    public float platformspawnTimer = 2f;
    private float currentPlatformSpawnTimer;

    public float minX = -1.6f, maxX = 1.6f;

    private int platformSpawnCount;

    // Start is called before the first frame update
    void Start()
    {
        currentPlatformSpawnTimer = platformspawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        currentPlatformSpawnTimer += Time.deltaTime;

        if (currentPlatformSpawnTimer >= platformspawnTimer)
        {
            platformSpawnCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX); // Assign a horizontal position of platform within screen limits

            GameObject newPlatform = null;

            if (platformSpawnCount <= 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity); //if less than or equal to 2 platforms spawn a normal platform
            }
            else if (platformSpawnCount == 3)
            {
                //50-50 chance
                if (Random.Range(0f, 2f) > 1.0f)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);  //create normal platform
                }
                else
                {   
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);  //create platforms of spike type
                }
            }
            else if (platformSpawnCount == 4)
            {
                if (Random.Range(0, 2) > 1.0f)  //50-50 chance
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);  //create normal platform
                }
                else
                {   
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);  //create platforms of breakable type
                    newPlatform.GetComponent<PlatformScript>().BreakableDeactivate(); // Call the BreakableDeactivate() method
                }
                platformSpawnCount = 0;
            }

            if (newPlatform)
            {
                newPlatform.transform.parent = transform;  //align below parent
            }

            currentPlatformSpawnTimer = 0f;  //reset spawn time
        }
    }
}
//Code by Salma Elabsi