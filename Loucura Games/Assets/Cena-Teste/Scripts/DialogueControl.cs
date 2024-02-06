using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;



    void Start()
    {
        dialogueObj.SetActive(false);
    }
    public void Speech(Sprite p, string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        speechText.text = txt[0];
        actorNameText.text = actorName;
        index = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("PularDialogo"))
        {
            NextSentence();
        }       
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {   
            //ainda há textos
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = sentences[index];
            }
            else //lido quando acaba
            {
                index = 0;
                End();
            }
        }
    }
    public void End()
    {
        dialogueObj.SetActive(false);
    }
}
