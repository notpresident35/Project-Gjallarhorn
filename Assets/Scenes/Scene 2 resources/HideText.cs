using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideText : MonoBehaviour
{
    public bool visible;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(visible);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toggleVisibility(){
        if (visible){visible = false;}
        else {visible = true;}
        gameObject.SetActive(visible);
    }
}
