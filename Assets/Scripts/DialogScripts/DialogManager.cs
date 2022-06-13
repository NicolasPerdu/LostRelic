using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public Image actorImage;
    public Text actorName;
    public Text messageText;
    //will be used to animate our dialogbox
    public RectTransform backgroundBox;
    public static bool isActive = false;


    private Message[] currentMessages;
    private Actor[] currentActors;
    private int activeMessage = 0;

    //used to display messages
    public void OpenDialogue(Message[] messages,Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started conv" + messages.Length);
        DisplayMessage();
    }

    private void DisplayMessage() 
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.actorImage;
    }

    private void NextMessage() 
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length) 
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation ended");
            isActive = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //left alt is configured for the moment
        if (Input.GetButtonDown("Fire2")) 
        {
            NextMessage();
        }
    }
}
