using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;

    [SerializeField] private AudioClip correct;
    [SerializeField] private AudioSource soundFX;

    public void Placed() {
        soundFX.PlayOneShot(correct);
    }
}
//Code by Salma Elabsi