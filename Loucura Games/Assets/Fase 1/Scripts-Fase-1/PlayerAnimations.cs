using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{//classe para controlar as animações do player;

    private PlayerDev playerDev;  //referencia para o script PlayerDev
    private Animator animator; //referencia para o animator do player
    // Animator = classe que controla as animações, animator = nome dessa variável dentro do código, como sabe que é o
    // animator do player? Porque este script está no player, então ele pega o animator do player
    void Start()
    {
        playerDev = GetComponent<PlayerDev>(); //pega o script PlayerDev e usa ele para pegar o "direction" do player
        // usa o direction do playerDev para pegar a direção do movimento
    
        animator = GetComponent<Animator>(); //pega o Animator Unity do player e guarda na variável animator 
    }

    // Update is called once per frame
    void Update()
    {
        isMoving(); 
        isRunning();
        SetPlayerDirection(); 

    }
  
  
    #region Animation

    private void isMoving() //verifica se o player está se movendo
    {
        if (playerDev._direction.sqrMagnitude > 0  ) //se for maior que 0, o player está se movendo, 
        //o sqrMagnitude limita entre 0 a 1, se for maior q zero significa que ele está se movendo
        {
            if(playerDev._isRolling) 
            //colocado neste local pois sómente será ativado caso o player esteja se movimentando
            { 
                animator.SetTrigger("rolltrigger");
            }
            else
            {
                animator.SetInteger("transition",1); //seta a animação de andar
            }
            
        }
        else 
        {
            animator.SetInteger("transition",0);
        }
    }

    private void SetPlayerDirection(){
        if (playerDev._direction.x >0)// se a direção do playerDev for para x>0 ou seja x positivo significa que ele está indo para a direita
        {
            transform.eulerAngles = new Vector2(0,0); //muda a rotação do player para 0,0 , 0 em x , e 0 em y

        }else if(playerDev._direction.x < 0)// significa que o jogador esta indo para a esquerda pois o x do direction do playerDev ewstá negativo
        {
            transform.eulerAngles = new Vector2(0,180); //muda a rotação do player para 0,180 , 0 em x , e 180 em y
        }
    }


    private void isRunning() //verifica se o player está correndo
    {
        if (playerDev._isRunning) //se o playerDev estiver correndo
        {
            animator.SetInteger("transition",2); //seta a animação de correr
        }
        
    }


    #endregion
}
