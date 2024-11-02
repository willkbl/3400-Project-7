using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController controller;
    Animator animator;
    Vector3 input, moveDirection;

    public float moveSpeed = 10;
    public float jumpHeight = 4.01f;
    public float gravity = 60.2f;
    public float airControl = 10f;

    public AudioClip jumpSound;
    AudioSource footstepsSource;
    public float footstepsVolume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        footstepsSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        input *= moveSpeed;

        if (controller.isGrounded)
        {
            moveDirection = input;
            moveDirection.y = 0.0f;

        }
        else
        {
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        footstepsSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        if ((moveHorizontal > 0.1 || moveVertical > 0.1) && controller.isGrounded)
        {
            footstepsSource.volume = footstepsVolume;
        } else
        {
            footstepsSource.volume = 0;
        }

        /*
        if (!LevelManager.isGameOver && transform.position.y < -3) //if player has fallen off edge
        {
            FindObjectOfType<LevelManager>().LevelLost(); //lose the game (restart the level)
        }
        */
    }
}
