using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  
    public float timetochange = 29f;
    private float timeInMinute = 5f;
    private float timeinSeconds ;
    private float secondsInMinute = 59f;
    private float starttime;
    public Text timetext;
    public Text leveltimetext;

    private bool swapPlayer;//To determine whether to swap the player or not



    // Start is called before the first frame update
    void Start()
    {
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
        
        //Will start the timer
         starttime -= Time.deltaTime;
        //Check if the timer has reached to zero
        if(starttime<=0)
        {
            //As the timer is zero now it will trigger between true and false
            swapPlayer = !swapPlayer;
            ChangePlayer();

        }

    }

    

    void ChangePlayer()
    {
        //Passing the bool to both player script via the public method in those script
        Player1.Instance.ActiveInScene(swapPlayer);
        Player2.Instance.ActiveInScene(swapPlayer);
        //Reset the timer
        starttime = timetochange;
    }
    
}
