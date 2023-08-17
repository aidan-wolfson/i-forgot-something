using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Achievement : MonoBehaviour
{
    public TextMeshProUGUI achievementText;
    public RectTransform textTransform;
    public AudioSource achievementSound;
    
    
    // Start is called before the first frame update
    void Start()
    {
        textTransform.transform.localScale = Vector3.zero;
    }

    public void achievementGet(string message)
    {
        StartCoroutine(Achieve(message));
    }

    IEnumerator Achieve(string message)
    {
        achievementSound.Play();
        achievementText.text = message;
        textTransform.LeanScale(Vector3.one, 0.6f).setEaseInOutBounce();
        yield return new WaitForSeconds(6f);
        textTransform.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
    }
}
