using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif



public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Escape ))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseScreen.SetActive(true);
        
    }

    public void ResumeGame()
    {
        
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;

    }
    public void QuitPressed()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif



    }
}
