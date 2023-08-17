using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenGuard : NPC
{
    public GameObject gardenGate;
    
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
        Debug.Log("The garden gate has been unlocked!");
        gardenGate.GetComponent<BoxCollider2D>().enabled = false;
        gardenGate.GetComponentInChildren<SpriteRenderer>().enabled = false;
        createNewDialogueTrigger();
        FindObjectOfType<Achievement>().achievementGet("You opened the garden gate!");
    }

    void createNewDialogueTrigger()
    {
        //trigger.StartDialogue();
        trigger = null;
        Destroy(gameObject.GetComponent<DialogueTrigger>());
        DialogueTrigger newDialogue = gameObject.AddComponent<DialogueTrigger>();
        newDialogue.messages = new Message[1];
        newDialogue.messages[0] = new Message(0, "Wow!! A beach ball!! And on a perfect day like this!!");
        newDialogue.actors = new Actor[1];
        newDialogue.actors[0] = new Actor("Garden Guard");
        newDialogue.soundEffect = gameObject.GetComponent<AudioSource>();

        trigger = newDialogue;
        newDialogue.StartDialogue();
    }

    

}
