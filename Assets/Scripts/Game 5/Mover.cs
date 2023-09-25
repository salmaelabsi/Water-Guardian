using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform will update once every second not every frame
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
//Code by Salma Elabsi