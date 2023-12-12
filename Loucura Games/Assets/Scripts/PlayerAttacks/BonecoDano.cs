using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonecoDano : MonoBehaviour
{
    [SerializeField] private int vida = 10;
    [SerializeField] private Animator anime;
    [SerializeField] private int dano = 1;

    void Start()
    {
    }

    void Update()
    {
    }

    public void ReduzirVida(int dano)
{
    vida -= dano; // Atualiza a vida para vida - dano

    if (vida <= 0)
    {
        vida = 10;
        anime.SetInteger("health", 10);
    }
    else
    {
        anime.SetBool("reset", false);

        if (vida <= 8 && vida > 5)
        {
            anime.SetInteger("health", vida);
        }
        else if (vida <= 5 && vida > 2)
        {
            anime.SetInteger("health", vida);
        }
        else if (vida <= 2 && vida > 0)
        {
            anime.SetInteger("health", vida);
        }
    }

    Debug.Log("Vida: " + vida+ " Dano: " + dano);
}


    void OnTriggerEnter2D(Collider2D other )
            {
                if (other.gameObject.CompareTag("swordtag") )
                {
                    ReduzirVida(dano); // Aqui, passamos o dano como parâmetro
                }
                else if(other.gameObject.CompareTag("swordtag2"))
                {
                    ReduzirVida(dano); // Aqui, passamos o dano como parâmetro
                }
                else if(other.gameObject.CompareTag("swordtag3"))
                {
                    ReduzirVida(dano*2); // Aqui, passamos o dano como parâmetro
                }
            }

    

    public void SetDano(int dano)
    {
        this.dano = dano;
    }
}
