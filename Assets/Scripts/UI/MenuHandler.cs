using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
    using UnityEditor;
#endif
using UnityEngine.SceneManagement;


public class MenuHandler : MonoBehaviour
{
    public GameObject  creditImage;

    public void StartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        
    }

    public void QuitPressed()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
                              
        
       
    }


    public void CreditsPressed()
    {
        //Active the image that have credit names
        creditImage.SetActive(true);
        StartCoroutine(FadeImage());
    }


    IEnumerator FadeImage()
    {
        yield return new WaitForSeconds(5.00f);
        //After 5 seconds disable the image 
        creditImage.SetActive(false);
    }
    
}
