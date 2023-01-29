using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    Color32 Purple = new Color32(205, 140, 187, 255);
    Color32 White = new Color32(255, 255, 255, 255);

    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Random.Range(0.0f, 1.0f) < 0.5 ? Purple : White;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * Time.deltaTime;
            transform.position += Vector3.down * 0.2f * Time.deltaTime;
        }

        if (16.0f <= transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
