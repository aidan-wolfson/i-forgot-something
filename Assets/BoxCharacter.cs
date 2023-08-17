using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCharacter : NPC
{
    public GameObject boxObject;
    public GameObject lostToy;

    // Start is called before the first frame update
    void Start()
    {
        questProgress = false;
        alreadyCompleted = false;
        boxObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(questProgress && !alreadyCompleted)
        {
            questComplete();
            alreadyCompleted = true;
            questProgress = false;
        }
    }

    void questComplete()
    {
        Debug.Log("The garden gate has been unlocked!");
        //trigger.StartDialogue();
        createNewDialogueTrigger();
        boxObject.SetActive(true);
        lostToy.SetActive(false);
        gameObject.SetActive(false);
        FindObjectOfType<Achievement>().achievementGet("You found Boxo and Mr. Bearington! Time to go home!");
    }

        void createNewDialogueTrigger()
    {
        //trigger.StartDialogue();
        trigger = null;
        Destroy(gameObject.GetComponent<DialogueTrigger>());
        DialogueTrigger newDialogue = gameObject.AddComponent<DialogueTrigger>();
        newDialogue.messages = new Message[1];
        newDialogue.messages[0] = new Message(0, "Is that Mr. Bearington? Ok... If you're both going... I'll go too. We'll go together.");
        newDialogue.actors = new Actor[1];
        newDialogue.actors[0] = new Actor("Moving Box");
        newDialogue.soundEffect = gameObject.GetComponent<AudioSource>();

        trigger = newDialogue;
        newDialogue.StartDialogue();
    }
}
