using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : NPC
{
    public RectTransform fadeImage;
    public AudioSource bgMusic;
    public AudioSource endMusic;
    public AudioSource endChord;


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
        Debug.Log("The house has been entered");
        fadeImage.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        createNewDialogueTrigger();
        bgMusic.Stop();
        endMusic.Play();
        //Application.Quit();
        StartCoroutine(TheEnd());
    }

    void createNewDialogueTrigger()
    {
        //trigger.StartDialogue();
        trigger = null;
        Destroy(gameObject.GetComponent<DialogueTrigger>());
        DialogueTrigger newDialogue = gameObject.AddComponent<DialogueTrigger>();
        newDialogue.messages = new Message[7];
        newDialogue.messages[0] = new Message(0, "Mom!! Dad!! I found them!!");
        newDialogue.messages[1] = new Message(1, "Good job, honey. The movers are waiting outside, did you forget anything else?");
        newDialogue.messages[2] = new Message(0, "Nope, I think I'm ready!");
        newDialogue.messages[3] = new Message(2, "I've got the keys. Kiddo, could you turn off that light for me?");
        newDialogue.messages[4] = new Message(0, "Sure!");
        newDialogue.messages[5] = new Message(2, "Ok... how about we all say goodbye together. Ready? One... two..... three........");
        newDialogue.messages[6] = new Message(3, "GOODBYE!!!");
        newDialogue.actors = new Actor[4];
        newDialogue.actors[0] = new Actor("Luca");
        newDialogue.actors[1] = new Actor("Mom");
        newDialogue.actors[2] = new Actor("Dad");
        newDialogue.actors[3] = new Actor("Luca, Mom, & Dad");
        newDialogue.soundEffect = gameObject.GetComponent<AudioSource>();

        trigger = newDialogue;
        newDialogue.StartDialogue();
    }

    IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Waiting for dialogue to end...");
        yield return new WaitUntil(() => Dialogue.isActive == false);
        Debug.Log("Dialogue has ended! Closing app.");

        endChord.Play();
        yield return new WaitForSeconds(6f);

        SceneManager.LoadScene(1,LoadSceneMode.Single);
        //GameOver.gameOver = true;

    }

}
