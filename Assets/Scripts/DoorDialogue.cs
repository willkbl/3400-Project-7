using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDialogue : MonoBehaviour
{
    public AudioClip dialogue;
    public Boolean dialoguePlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Door") && !dialoguePlayed)
            {
                AudioSource.PlayClipAtPoint(dialogue, transform.position);
                dialoguePlayed = true;
            }
        }
    }
}
