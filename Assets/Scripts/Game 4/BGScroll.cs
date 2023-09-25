using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed = 0.3f;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    //Scroll the background
    void Scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");

        offset.y += Time.deltaTime * scrollSpeed;  //Keep scrolling the background

        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset); 

    }
}
//Code by Salma Elabsi