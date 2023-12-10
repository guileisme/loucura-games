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
    

    public LayerMask playerLayer;

    private DialogueControl dc;

    private void OnTriggerExit2D(Collider2D collision)
    {
       left = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        left = false;
    }

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
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
        dc.Speech(profile,speechTxt,actorName);
    }
}
