using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public DialogueTrigger trigger;
    protected bool questProgress;
    protected bool alreadyCompleted;
    
    [SerializeField]
    public GameObject questObject;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player") == true){
            if(questObject != null && collision.gameObject.GetComponent<GrabObjects>().grabbedObject == questObject)
            {
                // call quest complete function 
                questProgress = true;

            } else {
                trigger.StartDialogue();
            }
        }
    }

}
