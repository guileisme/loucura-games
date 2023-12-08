using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Selecao_perso : MonoBehaviour
{
    public Animator axoloteanim, cachorroanim;
    public Image axoloteImage, cachorroImage;
    private int personagem;
    private AudioSource som;
    private Color cor;
    // Start is called before the first frame update
    void Start()
    {
        personagem = 1;
        som = GetComponent<AudioSource>();
        cor = cachorroImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            personagem = 1;
            som.Play();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            personagem = 2;
            som.Play();
        }
        if (personagem == 1)
        {
            axoloteImage.color = cor;
            cachorroImage.color = Color.white;
            cachorroanim.SetBool("Press", true);
            axoloteanim.SetBool("Press", false);
        }
        else if (personagem == 2)
        {
            cachorroImage.color = cor;
            axoloteImage.color = Color.white;
            cachorroanim.SetBool("Press", false);
            axoloteanim.SetBool("Press", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
