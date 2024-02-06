using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;
    private bool left;
    private bool onRadious;


    public LayerMask playerLayer;

    private DialogueControl dc;

    private void OnTriggerExit2D(Collider2D collision)
    {
        left = true;
        onRadious = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        left = false;
        onRadious = true;
    }

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Interaction") && onRadious)
        {
            Interact();
        }
    }
    void FixedUpdate()
    {
        if (left)
        {
            dc.End();
            left = false;
        }
    }

    public void Interact()
    {
        dc.Speech(profile, speechTxt, actorName);
    }
}
