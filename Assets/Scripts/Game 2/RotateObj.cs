using UnityEngine;

public class RotateObj : MonoBehaviour
{
    private Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;
    private Collider2D col;

    public BarFill barFillScript; // Reference to the BarFill script

    // Start is called before the first frame update
    private void Start()
    {
        myCam = Camera.main;
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);

        if (!barFillScript.IsFilled()) // Only rotate if the bar is not filled
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (col == Physics2D.OverlapPoint(mousePos))
                {
                    screenPos = myCam.WorldToScreenPoint(transform.position);
                    Vector3 v3 = Input.mousePosition - screenPos;

                    // Calculate angleOffset based on the direction of the knob's rotation
                    angleOffset = (Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg - transform.eulerAngles.z + 360f) % 360f;
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (col == Physics2D.OverlapPoint(mousePos))
                {
                    Vector3 v3 = Input.mousePosition - screenPos;
                    float angle = (Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg - angleOffset + 360f) % 360f;

                    // Update the knob's rotation with the corrected angle
                    transform.eulerAngles = new Vector3(0, 0, angle);

                    // Update the slider value in the BarFill script
                    float normalizedRotation = angle / 360f;
                    barFillScript.UpdateSliderValue(normalizedRotation);
                }
            }
        }
    }
}
//Code by Salma Elabsi