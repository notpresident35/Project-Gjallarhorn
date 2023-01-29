using UnityEngine;

public class TextDisabler : MonoBehaviour
{
    void Update ()
    {
        if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2))
        {
            gameObject.SetActive (false);
        }
    }
}
