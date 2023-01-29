using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BopEmSockEmRobotLogic : MonoBehaviour
{
    public enum direction{left, right};
    public direction facingTowards;
    public float startPosition;
    public AudioSource audio;
    private Quaternion origRotation;
    public string moveLeftKey;
    public string moveRightKey;
    // Start is called before the first frame update
    void Start()
    {        
        origRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")){
            Debug.Log("[Scene 2]: Reset key pressed");
            gameObject.transform.rotation = origRotation;
            gameObject.transform.position = new Vector3(startPosition, 1.0f, 0.0f);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
        }
        if (this.facingTowards == direction.right && Input.GetKeyDown(moveRightKey)){
            this.GetComponent<Rigidbody2D>().AddForce(
                Vector2.right * 4, ForceMode2D.Impulse
            );
        } else if (this.facingTowards == direction.left && Input.GetKeyDown(moveLeftKey)){
            this.GetComponent<Rigidbody2D>().AddForce(
                Vector2.left * 4, ForceMode2D.Impulse
            );
        }
        if (gameObject.transform.position[1] < -10 && gameObject.transform.position[1] > -11){
            audio.Play();
        }
    }
}
