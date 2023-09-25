using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private AudioClip pickup; //, drop;
    [SerializeField] private AudioSource soundFX, bgMusicSource;

    private bool dragging, placed;
    private Vector2 offset, originalPos;
    private PuzzleSlot _slot;

    public void Initialize(PuzzleSlot slot) {
        _renderer.sprite = slot.Renderer.sprite;
        _slot = slot;  
    }

    private void Awake()
    {
        originalPos = transform.position;
    }

    void Update()
    {
        if (placed) return;
        if (!dragging) return;

        var mousePos  = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos - offset;
    }

    void OnMouseDown()
    {
        dragging = true;
        soundFX.PlayOneShot(pickup);

        offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp() //if we leave the piece it returns to its place
    {
        if (Vector2.Distance(transform.position, _slot.transform.position) < 3)
        {
            transform.position = _slot.transform.position;
            _slot.Placed();
            placed = true;
        }
        else
        {
            transform.position = originalPos;
            //soundFX.PlayOneShot(drop);
            dragging = false;
        }
    }

    Vector2 GetMousePos()
    {

        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
//Code by Salma Elabsi