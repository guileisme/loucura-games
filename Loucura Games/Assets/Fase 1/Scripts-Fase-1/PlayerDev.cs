using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDev : MonoBehaviour
{

// Variáveis e atributos

    // O uso do serialized permite que a variável seja acessada no inspector da unity
    [SerializeField] private float velocidade; //velocidade do player
    [SerializeField] private float velocidadeCorrida; //velocidade de corrida do player
    private float velocidadeInicial; //velocidade inicial (armazenamento de info)
    private Rigidbody2D rig; //rig = corpo rigido do player 
    private Vector2 direction; //direção do movimento
    private bool isRunning; //verifica se o player está correndo para usar no PlayerAnimations
    private bool isRolling;//verifica se o player está rolando para usar no PlayerAnimations



// Propriedades

    //propriedade para acessar em outras classes
    // por ser uma propriedade ele não aparece no console da unity, mas pode ser acessado por outros scripts       

    public bool _isRolling 
    { 
        get => isRolling;
        set => isRolling = value;
    }

    public Vector2 _direction 
    {   
        get => direction;
        set => direction = value; 
    }
    
    public bool _isRunning 
    { 
        get => isRunning;
        set => isRunning = value;
    }


//Metodo Start (called before the first frame update)
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); //pega o corpo rigido do player
        velocidadeInicial = velocidade; //armazena a velocidade inicial do player
    }

//Metodo Update (called once per frame)
    void Update()
    {

        onInput(); //chama a função de input
        onRun(); //chama a função de correr
        onRoll();
        

    }
//Metodo FixedUpdate (called once per frame; coisas relacionadas a física utiliza o fixedupdate para ser mais preciso)
    private void FixedUpdate() 
    {

        onMove();               
    }
    



    #region Movement

        void onMove() 
        {
            //movimenta o player
            //move o corpo a uma direção, com uma velocidade e um tempo
            //pega a posição dele e soma a um vetor de direção
            rig.MovePosition(rig.position + direction * velocidade * Time.fixedDeltaTime);
        }


        void onRun()
        {
            if(Input.GetKeyDown(KeyCode.LeftShift)) //se apertar o botão de correr
            {
                velocidade = velocidadeCorrida; //a velocidade do player é alterada para a velocidade de corrida
                isRunning = true; //o player está correndo para PlayerAnimator
            }

             if(Input.GetKeyUp(KeyCode.LeftShift)) //se soltar o botão de correr
            {
                velocidade = velocidadeInicial; //a velocidade do player é alterada para a velocidade inicial
                isRunning = false; //o player não está correndo para o PlayerAnimator
            }

            if(Input.GetKeyDown(KeyCode.L)){
                    velocidade = velocidadeCorrida *3;
                    isRunning = true;
                }
            if(Input.GetKeyUp(KeyCode.L)){
                    velocidade = velocidadeInicial;
                    isRunning = false;
                }     

        }
        

        //função de input para movimento captar as teclas apertadas
        void onInput()
        {   
                //armazena a direção do movimento ao apertar os botões direcionais
                direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;        
        }


        void onRoll()
        {
            if(Input.GetMouseButtonDown(1)) //se apertar o botão de rolar
            {
                isRolling = true;
                velocidade = velocidadeCorrida +2;
            }
            //para o isRolling, para que o player não fique rolando infinitamente
            //uma vez que se true ele vai para o PlayerAnimations e lá ele altera o trigger para chamar a ativação
            // que por sua vez no unity possue um exit time, e logo após o exit time ele volta para o idle
            // ou seja só é ativado com o trigger e desativado com o exit time
            
            if(Input.GetMouseButtonUp(1)) //se soltar o botão de rolar 

            {
                isRolling = false;
                velocidade = velocidadeInicial;
            }
        }



    #endregion 


}
