using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject[] player;
    public float timetochange = 5f;
    private float timeInMinute = 5f;
    private float timeinSeconds ;
    private float secondsInMinute = 59f;
    private float starttime;
    public Text timetext;
    public Text leveltimetext;

    // Start is called before the first frame update
    void Start()
    {
        starttime = timetochange;
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

            ChangePlayer();

        }

    }

    

    void ChangePlayer()
    {
        //Check which player is active and then disable that active one and enable the other one
        if (player[0].activeInHierarchy)
        {
            player[0].SetActive(false);
            player[1].SetActive(true);

        }
        else if (player[1].activeInHierarchy)
        {
            player[1].SetActive(false);
            player[0].SetActive(true);

        }
        //Reset the timer
        starttime = timetochange;
    }
    
}
