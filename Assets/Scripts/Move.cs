using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    public float sensitivity;
    float mouseSpeedX = 1;
    float mouseSpeedY = 1;
    float xRotation = 0;
    float yRotation = 0;
    CharacterController controller;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
           

        }
        turner = Input.GetAxis("Mouse X") * sensitivity;
        looker = -Input.GetAxis("Mouse Y") * sensitivity;
        
        if (turner != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(0, turner, 0);
        }
        if (looker != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(looker, 0, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("x "+Input.mousePosition.x);
            Debug.Log("y "+Input.mousePosition.y);
            Debug.Log("z "+Input.mousePosition.z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.eulerAngles += worldPosition;

        }
        yRotation = -Mathf.Clamp(Input.GetAxis("Mouse Y") * mouseSpeedY, -80f, 80f);
        xRotation = Input.GetAxis("Mouse X") * mouseSpeedX;

        //Apply to camera and player
        //Camera.main.transform.eulerAngles += new Vector3(yRotation, 0f, 0f);
        transform.eulerAngles += new Vector3(0f, xRotation, 0f);
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
