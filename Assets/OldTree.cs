using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldTree : NPC
{
    public GameObject branchGate;
    
    // Start is called before the first frame update
    void Start()
    {
        questProgress = false;
        alreadyCompleted = false;
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
        Debug.Log("The branch gate has been unlocked!");
        branchGate.GetComponent<BoxCollider2D>().enabled = false;
        branchGate.GetComponentInChildren<SpriteRenderer>().enabled = false;
        createNewDialogueTrigger();
        FindObjectOfType<Achievement>().achievementGet("You passed the old tree!");
    }

    void createNewDialogueTrigger()
    {
        //trigger.StartDialogue();
        trigger = null;
        Destroy(gameObject.GetComponent<DialogueTrigger>());
        DialogueTrigger newDialogue = gameObject.AddComponent<DialogueTrigger>();
        newDialogue.messages = new Message[2];
        newDialogue.messages[0] = new Message(0, "Well would you look at that... what a beautiful acorn... the sight of it fills me with determination... and a bit of perspective...");
        newDialogue.messages[1] = new Message(0, "Go, and finish this adventure, little Luca... I hope to see you again someday... to see how much you've grown... and hear all your new stories...");
        newDialogue.actors = new Actor[1];
        newDialogue.actors[0] = new Actor("The Old Tree");
        newDialogue.soundEffect = gameObject.GetComponent<AudioSource>();

        trigger = newDialogue;
        newDialogue.StartDialogue();
    }

}
