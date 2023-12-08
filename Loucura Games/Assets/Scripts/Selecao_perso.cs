using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Selecao_perso : MonoBehaviour
{
    public Animator axoloteanim, cachorroanim;
    public Image axoloteImage, cachorroImage;
    public int CharacterIndex;
    private AudioSource som;
    private Color cor;
    // Start is called before the first frame update
    void Start()
    {
        CharacterIndex = 1;
        som = GetComponent<AudioSource>();
        cor = cachorroImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CharacterIndex = 1;
            som.Play();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CharacterIndex = 2;
            som.Play();
        }
        if  (CharacterIndex == 1)
        {
            axoloteImage.color = cor;
            cachorroImage.color = Color.white;
            cachorroanim.SetBool("Press", true);
            axoloteanim.SetBool("Press", false);
        }
        else if (CharacterIndex == 2)
        {
            cachorroImage.color = cor;
            axoloteImage.color = Color.white;
            cachorroanim.SetBool("Press", false);
            axoloteanim.SetBool("Press", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            FindObjectOfType<GameManager>().CharacterIndex = CharacterIndex;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }        
    }
    void PlaySound()
    {
        if(!som.isPlaying)
        {
            som.Play();
        }
    }
}
