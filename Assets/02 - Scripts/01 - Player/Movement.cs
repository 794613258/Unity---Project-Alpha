using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float speed = 6.0f;
    public float rotSpeed = 90.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // let the gameObject fall down
        //gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if(Input.GetKey(KeyCode.Z))
            {
                moveDirection += this.transform.forward;
            }
            if(Input.GetKey(KeyCode.Q))
            {
                moveDirection -= this.transform.right;
            }
            if(Input.GetKey(KeyCode.S))
            {
                moveDirection -= this.transform.forward;
            }
            if(Input.GetKey(KeyCode.D))
            {
                moveDirection += this.transform.right;
            }


            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
        //transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0);
        //moveDirection.y += 1;
        //this.gameObject.transform.LookAt(this.transform.position + moveDirection * Time.deltaTime);
    }
}
