using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public AudioSource soundEffect;

    public void StartDialogue()
    {
        FindObjectOfType<Dialogue>().OpenDialogue(messages, actors, soundEffect);
    }
}

[System.Serializable]
public class Message
{
    public int actorID;
    public string message;

    public Message(int actorID, string message){
        this.actorID= actorID;
        this.message = message;
    }
}

[System.Serializable]
public class Actor 
{
    public string name;

    public Actor(string name)
    {
        this.name = name;
    }
}