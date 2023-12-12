using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{   
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;
    bool atuando;
    

    public LayerMask playerLayer;

    private DialogueControl dc;
    private JogadorInterage _jogadorInterage;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }
    public void Interact()
    {   
        dc.Speech(profile,speechTxt,actorName);
    }
}
