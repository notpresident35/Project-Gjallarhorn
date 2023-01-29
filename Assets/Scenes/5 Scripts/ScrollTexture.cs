using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public Material scrollableMaterial;
    public Vector2 direction = new Vector2(1, 0);
    public float speed = 2.0f;


    private Vector2 currentOffset;

    void Start()
    {
        currentOffset = scrollableMaterial.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        currentOffset += direction * speed * Time.deltaTime;
        scrollableMaterial.SetTextureOffset("_MainTex", currentOffset);
    }
}
