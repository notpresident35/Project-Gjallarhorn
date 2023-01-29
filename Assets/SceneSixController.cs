using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSixController : MonoBehaviour
{

    private float MoveSpeed = 7.75f;
    private float MinX = -12.5f;
    private float MaxX = 12.5f;
    private float MinY = -7f;
    private float MaxY = 7f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > MinX)
        {
            moveDir += Vector3.left;
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < MaxX)
        {
            moveDir += Vector3.right;
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && transform.position.y < MaxY)
        {
            moveDir += Vector3.up;
        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && transform.position.y > MinY)
        {
            moveDir += Vector3.down;
        }
        transform.Translate (moveDir.normalized * MoveSpeed * Time.deltaTime);
    }
}
