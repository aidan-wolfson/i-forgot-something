using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCredits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndCreds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EndCreds()
    {
        Debug.Log("Credits are playing!");
        yield return new WaitForSeconds(22f);
        Debug.Log("Closing the game...");
        yield return new WaitForSeconds(3f);

        GameOver.gameOver = true;
    }
}
