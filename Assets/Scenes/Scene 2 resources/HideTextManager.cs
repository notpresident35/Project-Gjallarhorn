using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTextManager : MonoBehaviour
{
    public List<HideText> texts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h")){
            foreach (var t in texts)
            {
                t.toggleVisibility();
            }
        }
    }

    // private void toggleVisibility(){
    //     if (visible){visible = false;}
    //     else {visible = true;}
    //     gameObject.SetActive(visible);
    // }
}
