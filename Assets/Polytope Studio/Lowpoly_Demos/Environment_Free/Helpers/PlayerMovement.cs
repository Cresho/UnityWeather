using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody rb;
    public CapsuleCollider capsule;
    public RainScript rainScript;

    public float speed = 5;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;
    void Update()
    {
        isGrounded = Physics.Raycast(rb.worldCenterOfMass, -Vector3.up, (capsule.height / 2) + .5f, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(speed * Time.deltaTime * move);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            rainScript.RainIntensity = 5f;
            Debug.Log(rainScript.RainIntensity);
        }

        if(Input.GetKeyDown(KeyCode.RightAlt))
        {
            rainScript.RainIntensity = 0f;
            Debug.Log(rainScript.RainIntensity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}