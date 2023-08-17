using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : NPC
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(questProgress && !alreadyCompleted)
        {
            questComplete();
            alreadyCompleted = true;
            questProgress = false;
            FindObjectOfType<Achievement>().achievementGet("You helped the squirrel!");
        }
    }

    void questComplete()
    {
        //trigger.StartDialogue();
    }

}
