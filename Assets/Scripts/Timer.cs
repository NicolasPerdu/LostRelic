using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject[] player;
    public float timetochange = 5;
    private float starttime;
    public Text timetext;

    // Start is called before the first frame update
    void Start()
    {
        starttime = timetochange;
    }

    // Update is called once per frame
    void Update()
    {
        timetext.text =Mathf.Round (starttime).ToString();
        
         starttime -= Time.deltaTime;
        if(starttime<=0)
        {
            if(player[0].activeInHierarchy)
            {
                player[0].SetActive(false);
                player[1].SetActive(true);

            }
            else if (player[1].activeInHierarchy)
            {
                player[1].SetActive(false);
                player[0].SetActive(true);

            }
            starttime = timetochange;


        }
    }
    
}
