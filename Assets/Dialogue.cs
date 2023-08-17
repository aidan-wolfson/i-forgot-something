using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
public TextMeshProUGUI textComponent;
public TextMeshProUGUI actorNameComponent;
public RectTransform backgroundBox;
public RectTransform tutorialText;
public string[] lines;
public float textSpeed;
public static bool isActive = false;
Message[] currentMessages;
Actor[] currentActors;
AudioSource currentAudioSource;

private int index;
private string currentActorName;

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
        StartCoroutine(TutorialText());
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            // getting to next line or skipping to full line on click
            if(textComponent.text == currentMessages[index].message){
                NextLine();
            }
            else{
                StopAllCoroutines();
                textComponent.text = currentMessages[index].message;
            }
        }
    }

    public void OpenDialogue(Message[] messages, Actor[] actors, AudioSource soundEffect)
    {
        currentMessages = messages;
        currentActors = actors;
        currentAudioSource = soundEffect;
        index = 0;
        isActive = true;
        textComponent.text = string.Empty;
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo(); // scale the dialogue box nicely
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        actorNameComponent.text = currentActors[currentMessages[index].actorID].name; // grab the current actors name 
        
        // type each character 1 by 1
        foreach (char c in currentMessages[index].message.ToCharArray())
        {
            textComponent.text += c;
            if(currentAudioSource != null && currentAudioSource.isPlaying == false)
            {
                currentAudioSource.Play();
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < currentMessages.Length - 1)
        {
            // move to next line and reset current message & actor name (in case different)
            index++;
            textComponent.text = string.Empty;
            actorNameComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else {
            //gameObject.SetActive(false);
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
    }

    IEnumerator TutorialText()
    {
        yield return new WaitForSeconds(8f);
        tutorialText.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
    }
}
