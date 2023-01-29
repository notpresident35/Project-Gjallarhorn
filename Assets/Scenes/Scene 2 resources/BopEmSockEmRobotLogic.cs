using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BopEmSockEmRobotLogic : MonoBehaviour
{
    public enum direction{left, right};
    public direction facingTowards;
    public float startPosition;
    public AudioSource deathSource;
    private Quaternion origRotation;
    public string moveLeftKey;
    public string moveRightKey;
    bool resetting = false;
    [SerializeField] GameObject tutorialText;

    void Start()
    {        
        origRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.facingTowards == direction.right && Input.GetKeyDown(moveRightKey)){
            this.GetComponent<Rigidbody2D>().AddForce(
                Vector2.right * 4, ForceMode2D.Impulse
            );
            if (tutorialText.activeInHierarchy)
            {
                tutorialText.SetActive (false);
            }
        } else if (this.facingTowards == direction.left && Input.GetKeyDown(moveLeftKey)){
            this.GetComponent<Rigidbody2D>().AddForce(
                Vector2.left * 4, ForceMode2D.Impulse
            );
            if (tutorialText.activeInHierarchy)
            {
                tutorialText.SetActive (false);
            }
        }
        if ((transform.position.y < -7f || Mathf.Abs(transform.position.x) > 13f) && !resetting) {
            resetting = true;
            if (!deathSource.isPlaying)
            {
                deathSource.Play ();
            }
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.rotation = origRotation;
        gameObject.transform.position = new Vector3 (startPosition, 1.0f, 0.0f);
        GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
        GetComponent<Rigidbody2D> ().angularVelocity = 0.0f;
        resetting = false;
    }
}
