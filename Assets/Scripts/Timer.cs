using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public GameObject  levelwon;
  
    public float timetochange;
    private float timeInMinute = 5f;
    private float timeinSeconds ;
    private float secondsInMinute = 59f;
    private float starttime;
    public Text timetext;
    public Text leveltimetext;
    private float portalCount = 0.0f;
    public GameObject hellworld;
    public GameObject normalworld;
    public GameObject hellplayer;
    public GameObject normalplayer;
    

    private bool swapPlayer;//To determine whether to swap the player or not

    void Start()
    {    
        portalCount = 0.0f;
        levelwon.SetActive(false);
        starttime = timetochange;
        swapPlayer = false;
        timeinSeconds = secondsInMinute;
    }

    void Update()
    {   
        timeinSeconds -=Time.deltaTime;
        if (timeinSeconds <= 0)
        {
            timeInMinute -= 1;
            timeinSeconds = secondsInMinute;

        }

        leveltimetext.text = (Mathf.Round (timeInMinute) + ":" + Mathf.Round(timeinSeconds)).ToString();

        timetext.text = Mathf.Round(starttime).ToString();
        starttime -= Time.deltaTime;
       
        if(starttime<=0)
        {
            swapPlayer = !swapPlayer;
            starttime = timetochange;
            ChangePlayer();
        }

        if(portalCount>=2)
        {
            levelwon.SetActive(true);
        }
        if(portalCount==1)
        {
            starttime = 0;
            portalCount = 1.5f;
        }
    }

    

    void ChangePlayer()
    {
        if (swapPlayer) {
            hellworld.SetActive(false);
            normalworld.SetActive(true);
            normalplayer.GetComponent<PlayerController>().ActiveInScene(true);
        } else {
            hellworld.SetActive(true);
            normalworld.SetActive(false);
            hellplayer.GetComponent<PlayerController>().ActiveInScene(true);
        }
    }


    public void PortalReached(float triggerCount)
    {
        portalCount += triggerCount;
        Debug.Log(portalCount);
    }
    
}
