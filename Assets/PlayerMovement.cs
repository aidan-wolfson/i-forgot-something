using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    static bool movementDisabled;
    public Rigidbody2D rb;
    public AudioSource stepAudio;

    private Vector2 moveDir;

    // Update is called once per frame
    void Update()
    {
        if(Dialogue.isActive == true || movementDisabled == true){
            rb.velocity = Vector2.zero;
            return;
            // do nothing if character is in conversation
        } 

        

        // Processing Inputs
        ProcessInput();

        // Check to see if user would like to exit the application
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver.gameOver = true;
        }
    }

    void FixedUpdate()
    {
        if(Dialogue.isActive == true || movementDisabled == true){
            return;
            // do nothing if character is in conversation
        }
        // Physics Calculations
        Move(); 
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // get either 0 or 1 returned
        float moveY = Input.GetAxisRaw("Vertical"); 

        // if moveX == -1 (moving left), face left
        if (moveX == -1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        } else if (moveX == 1) {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        } else if (moveY == -1) {
            //transform.rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
        } else if (moveY == 1) {
            //transform.rotation = Quaternion.Euler(transform.rotation.x, 270, transform.rotation.z);
        }


        moveDir = new Vector2(moveX, moveY).normalized; // TODO come back to this 
        
        // if moving, play step sound effect
        if(moveDir != Vector2.zero && stepAudio.isPlaying == false)
        {
            stepAudio.Play();
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}
