/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using System.Collections.Generic;

//this script creates spawning enemies in the game; helps improve game performance and efficiency

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    public ObjectPoolItems[] itemsToPool;   //this array stores items' references: prefabs, names etc
    private List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }

        pooledObjects = new List<GameObject>();

        foreach (ObjectPoolItems item in itemsToPool)
        {
            for (int i = 0; i < item.poolAmount; i++)
            {
                GameObject obj = Instantiate(item.poolObj);     //we instantiate with respect to poolObj. pool object has prefab assigned to it
                obj.name =  item.name;
                obj.transform.parent = this.transform;
                obj.SetActive(false);       //shouldn't be active at the start of the game
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string name)
    {  //this method returns a game object

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy == false && pooledObjects[i].name == name)
            {
                return pooledObjects[i];
            }
        }

        foreach (ObjectPoolItems item in itemsToPool)
        {
            if (item.poolObj.name == name)
            {
                GameObject obj = Instantiate(item.poolObj);
                obj.name = item.name;
                obj.transform.parent = this.transform;
                obj.SetActive(false);
                pooledObjects.Add(obj);

                return obj;
            }
        }

        return null;
    }
}

[System.Serializable]
public class ObjectPoolItems
{
    public string name;
    public int poolAmount;
    public GameObject poolObj;
    public bool shouldExpand;
}
//Code by Salma Elabsi