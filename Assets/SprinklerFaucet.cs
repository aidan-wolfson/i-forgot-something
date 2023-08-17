using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerFaucet : MonoBehaviour
{
    Sprinkler[] sprinklers;
    public GameObject squirrel;
    
    
    // Start is called before the first frame update
    void Start()
    {
        sprinklers = FindObjectsOfType<Sprinkler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOffSprinklers()
    {
        for(int i = 0; i < sprinklers.Length; i++)
        {
            sprinklers[i].turnOffWater();
            sprinklers[i].GetComponentInChildren<Animator>().SetBool("isSpraying", false);
            sprinklers[i].GetComponent<AudioSource>().Stop();
        }
        squirrel.SetActive(false);
        FindObjectOfType<Achievement>().achievementGet("You turned off the sprinklers!");
    }
}
