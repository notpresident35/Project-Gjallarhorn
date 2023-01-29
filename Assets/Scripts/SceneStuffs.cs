using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStuffs : MonoBehaviour
{
    #region singleton
    private static SceneStuffs _instance;

    public static SceneStuffs Instance { get { return _instance; } }
    

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

        DontDestroyOnLoad(Instance);
    }
    #endregion

    void Update()
    {
        HandleSceneSwitching();
    }

    void HandleSceneSwitching()
    {
        // next scene
        if (Input.GetKeyDown(KeyCode.L) && SceneManager.sceneCountInBuildSettings != SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // last scene
        if (Input.GetKeyDown(KeyCode.J) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
