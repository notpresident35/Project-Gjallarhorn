using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStuffs : MonoBehaviour
{
    #region scene singleton
    private static SceneStuffs _instance;

    public static SceneStuffs SceneInstance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(SceneInstance);
    }
    #endregion

    // just handles scene switching for now
    void Update()
    {
        HandleSceneSwitching();
    }

    // CONTROLS: -> , <- , R
    // next scene, last scene, reload scene
    void HandleSceneSwitching()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;

        // next scene
        if (Input.GetKeyDown(KeyCode.RightArrow) && SceneManager.sceneCountInBuildSettings != currScene + 1)
        {
            currScene++;
            SceneManager.LoadScene(currScene);
            AudioStuffs.AudioInstance.SwapTrack(currScene);
        }

        // last scene
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currScene != 0)
        {
            currScene--;
            SceneManager.LoadScene(currScene);
            AudioStuffs.AudioInstance.SwapTrack(currScene);
        }

        // reload scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            AudioStuffs.AudioInstance.ResetAudio();
        }

    }
}
