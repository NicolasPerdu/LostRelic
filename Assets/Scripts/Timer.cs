using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public GameObject  levelwon;
    public Animator wonclip;
  
    public float timetochange = 29f;
    private float timeInMinute = 5f;
    private float timeinSeconds ;
    private float secondsInMinute = 59f;
    private float starttime;
    public Text timetext;
    public Text leveltimetext;
    private int portalCount = 0; 

    private bool swapPlayer;//To determine whether to swap the player or not



    // Start is called before the first frame update
    void Start()
    {
        portalCount = 0;
        levelwon.SetActive(false);
        starttime = timetochange;
        swapPlayer = false;//It will not start the swap until its false
        timeinSeconds = secondsInMinute;
    }

    // Update is called once per frame
    void Update()
    {   
        
        timeinSeconds -=Time.deltaTime;
        if (timeinSeconds <= 0)
        {
            timeInMinute -= 1;
            timeinSeconds = secondsInMinute;

        }
        
        
        leveltimetext.text = (Mathf.Round (timeInMinute) + ":" + Mathf.Round(timeinSeconds)).ToString();

        //To show the time on screen
           timetext.text =Mathf.Round (starttime).ToString();
        
        //Use the timer when none of the player has reached the portal
        if(portalCount<=0)
            starttime -= Time.deltaTime;
        //Check if the timer has reached to zero
        if(starttime<=0 )
        {
            SetBoolToSwap();

        }
        if(portalCount==2)
        {
            //Active levelwon image when both players has reached the portals
            levelwon.SetActive(true);
            wonclip.Play("LevelWin");
            StartCoroutine(RestartLevel());
            
            
        }
        

    }
    void SetBoolToSwap()
    {
        //As the timer is zero now it will trigger between true and false
        swapPlayer = !swapPlayer;
        ChangePlayer();
    }

    

    void ChangePlayer()
    {
        //Passing the bool to both player script via the public method in those script
        Player1.Instance.ActiveInScene(swapPlayer);
        Player2.Instance.ActiveInScene(swapPlayer);
        //Reset the timer
        if(portalCount!=1)
            starttime = timetochange;
    }


    public void PortalReached(int triggerCount)
    {
        portalCount += triggerCount;
        Debug.Log(portalCount);
        if (portalCount == 1)
        {
            SetBoolToSwap();
            //To disable the swap timer when one player has reached the portal  
            timetext.enabled = false;

        }
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(0);
    }
    
}
