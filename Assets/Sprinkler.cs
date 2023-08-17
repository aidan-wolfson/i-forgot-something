using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkler : MonoBehaviour
{
    [SerializeField]
    public BoxCollider2D water;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOffWater()
    {
        water.enabled = false;
        // switch animation
    }
}
