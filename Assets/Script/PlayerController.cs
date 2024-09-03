using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;

    public VariableJoystick joy;
    public Animator animator;
    
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gm = FindObjectOfType<GameManager>();
        gm.EndGame();

    }

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //float xInput = Input.GetAxis("Horizontal"); // a키도 된다. 
        //float zInput = Input.GetAxis("Vertical");


        float xInput =joy.Horizontal; // a키도 된다. 
        float zInput = joy.Vertical;

        if(xInput == 0 && zInput == 0)
        {
            animator.SetBool("isPressed", false);
        }
        else
        {
            animator.SetBool("isPressed", true);
        }

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVel = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVel; 
      

        /*if(Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0, 0);
        } */
    }
}
