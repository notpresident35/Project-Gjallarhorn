using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMove = Input.GetAxis ("Vertical") * 10f;
        float horizontalMove = Input.GetAxis ("Horizontal") * 10f;
        transform.Translate (horizontalMove * Time.deltaTime, verticalMove * Time.deltaTime, 0);
    }
}
