using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public GameObject  levelwon;
  
    public float timetochange = 29f;
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



    // Start is called before the first frame update
    void Start()
    {
              
        portalCount = 0.0f;
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
        if(portalCount <2)
            leveltimetext.text = (Mathf.Round (timeInMinute) + ":" + Mathf.Round(timeinSeconds)).ToString();

        //To show the time on screen 
        if (portalCount < 1)
        {
            timetext.text = Mathf.Round(starttime).ToString();
            //Will start the timer
            starttime -= Time.deltaTime;
        }
       
        //Check if the timer has reached to zero
        if(starttime<=0)
        {
            
            //As the timer is zero now it will trigger between true and false
            swapPlayer = !swapPlayer;
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
            normalplayer.GetComponent<Player2>().ActiveInScene(true);
        } else {
            hellworld.SetActive(true);
            normalworld.SetActive(false);
            hellplayer.GetComponent<Player1>().ActiveInScene(true);
        }
        //Player1.Instance.ActiveInScene(swapPlayer);
        //Player2.Instance.ActiveInScene(swapPlayer);

        //Reset the timer
        starttime = timetochange;
    }


    public void PortalReached(float triggerCount)
    {
        portalCount += triggerCount;
        Debug.Log(portalCount);
        
    }
    
}
