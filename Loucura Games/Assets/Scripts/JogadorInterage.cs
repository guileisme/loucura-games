using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorInterage : MonoBehaviour
{
    public bool EstaInteragindo { get; set;}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interaction"))
        {
            EstaInteragindo = true;
        }
        else
        {
            EstaInteragindo = false;
        } 
    }
}
