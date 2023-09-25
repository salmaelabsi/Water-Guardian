using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) //in built method in unity used to detect triggers
    {
        if (other.CompareTag("Ground")) //if the game object/the collider has a tag "Ground"
        {
            #region smoke effect
            GameObject smokeEffect =  ObjectPooling.instance.GetPooledObject("SmokeEffect");
            smokeEffect.transform.position = transform.position;
            smokeEffect.SetActive(true);
            smokeEffect.GetComponent<Animator>().Play("SmokeEffect", -1, 0);
            #endregion

            #region reward

            int r = Random.Range(0, 4);
            if (r == 2)
            {
                GameObject fishReward = ObjectPooling.instance.GetPooledObject("FishReward");
                fishReward.transform.position = transform.position;
                fishReward.SetActive(true);
            }
            #endregion

            //Debug.Log("Collided with ground");

            MenuManager.instance.IncreaseScore();

            gameObject.SetActive(false); //the game object (enemy) on which the script is attached. enemy is destroyed when it hits the ground 

        }
    }
}

//to detect a trigger, a game object must have a rigid body attached to it
//Code by Salma Elabsi