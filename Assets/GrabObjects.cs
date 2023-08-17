using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
   
    public AudioSource pickUpAudio;
    public AudioSource dropAudio;
    
    [SerializeField]
    public GameObject grabbedObject;
   

    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    
    private int layerIndex;
    private float rayDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects"); // storing Objects layer as an int (probably 6) for performance
        grabbedObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);


        // DEBUG
        if(hitInfo.collider != null){
            //Debug.Log("We hit the object.");
        }

        // if there is a collider hit by the raycast and the hit object is on the Objects layer...
        if(hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            // grab the object
            if(Input.GetMouseButtonDown(0) && grabbedObject == null && !hitInfo.collider.gameObject.CompareTag("Switch"))
            {
                grabbedObject = hitInfo.collider.gameObject;
                //grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(this.transform);
                grabbedObject.GetComponent<BoxCollider2D>().isTrigger = true; // so that carried objects don't collide with anything
                pickUpAudio.Play();                
            }

            // if the object is tagged Switch...
            else if(Input.GetMouseButtonDown(0) && hitInfo.collider.gameObject.CompareTag("Switch")) 
            {
                hitInfo.collider.GetComponent<SprinklerFaucet>().turnOffSprinklers();
                Debug.Log("Turned off the sprinklers!!");
            }
        }
        // release the object (only when not in dialogue)
        else if(Input.GetMouseButtonDown(0) && grabbedObject != null && Dialogue.isActive == false)
        {
            //grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.transform.position = rayPoint.position;
            grabbedObject.transform.SetParent(null);
            grabbedObject.GetComponent<BoxCollider2D>().isTrigger = false;
            grabbedObject = null;
            dropAudio.Play();
        }
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}
