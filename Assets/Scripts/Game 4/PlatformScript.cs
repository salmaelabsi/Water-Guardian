using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float boundY = 6f;

    public bool isBreakable, isSpiked, isPlatform;

    private Animator anim;

    void Awake()
    {
        if (isBreakable)
        {
            anim = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        //Keep moving up
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        // Deactive objects that move out of screen
        if (temp.y >= boundY)
        {
            gameObject.SetActive(false);
        }
    }

    public void BreakableDeactivate()  //the platform disappears
    {
        Invoke(nameof(DeactivateGameObject), 0.3f);
    }

    void DeactivateGameObject()
    {
        G4SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.CompareTag("Player"))
        {
            // if player drops on spike platform then game over and restart
            if (isSpiked)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                //G4SoundManager.instance.GameOverSound();
                //game over screen
                Destroy(gameObject);
                G4GameManager.instance.GameOver();
            }
        }

    } // on trigger enter


    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            // Break animation start when lands on breakable platform
            if (isBreakable)
            {
                G4SoundManager.instance.LandSound();
                anim.Play("Break");
            }

            // if platform then play sound
            if (isPlatform)
            {
                G4SoundManager.instance.LandSound();
            }
        }
    }
}
//Code by Salma Elabsi