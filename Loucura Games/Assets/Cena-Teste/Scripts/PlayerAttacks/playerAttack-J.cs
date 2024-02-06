using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
   

    void Start()
    {
        // Obtém o componente Animator do objeto
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Verifica se a tecla J foi pressionada
        if (Input.GetKeyDown(KeyCode.J))
        {
            // Define o parâmetro "attackJ" como true no Animator
            animator.SetBool("attackJ", true);
            
        }
        else
        {
            // Define o parâmetro "attackJ" como false no Animator
            animator.SetBool("attackJ", false);
        }

        // Verifica se a tecla K foi pressionada
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Define o parâmetro "attackK" como true no Animator
            animator.SetBool("attackK", true);
            
        }
        else
        {
            // Define o parâmetro "attackK" como false no Animator
            animator.SetBool("attackK", false);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Define o parâmetro "attackK" como true no Animator
            animator.SetBool("attackL", true);
            
        }
        else
        {
            // Define o parâmetro "attackK" como false no Animator
            animator.SetBool("attackL", false);
        }
    }
 
   
}
