using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDev : MonoBehaviour
{

    [SerializeField] private float velocidade; // O uso do serialized permite que a variável seja acessada no inspector da unity
    [SerializeField] private float velocidadeCorrida;
    private float velocidadeInicial;

    private Rigidbody2D rig; //rig = corpo rigido do player 
    private Vector2 direction; //direção do movimento
    
    public Vector2 _direction 
    {   //propriedade para acessar a direção do movimento, apesar de ser um vetor, é uma propriedade
        // por ser uma propriedade ele não aparece no console da unity, mas pode ser acessado por outros scripts       
        //  how to use the getter and setter methods

            get => direction;
            set => direction = value; 
    }
    
    
    private bool isRunning; //verifica se o player está correndo

    public bool _isRunning 
    {   // por ser uma propriedade ele não aparece no console da unity, mas pode ser acessado por outros scripts
        get => isRunning;
        set => isRunning = value;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); //pega o corpo rigido do player
        velocidadeInicial = velocidade; //armazena a velocidade inicial do player
    }

    void Update()
    {   // Update is called once per frame

        onInput(); //chama a função de input
        onRun(); //chama a função de correr

    }

    private void FixedUpdate()  //chamado a cada frame, mas é mais preciso que o update porque é chamado a cada frame de física
    {                           //coisas relacionadas a física utiliza o fixedupdate
    
        onMove();               //chama a função de movimento

    }



    #region Movement

        void onMove()
        {
            //movimenta o player
            //move o corpo a uma direção, com uma velocidade e um tempo
            //pega a posição dele e soma a um vetor de direção
            rig.MovePosition(rig.position + _direction * velocidade * Time.fixedDeltaTime);
        }

        void onRun()
        {
            if(Input.GetKeyDown(KeyCode.LeftShift)) //se apertar o botão de correr
            {
                velocidade = velocidadeCorrida; //a velocidade do player é alterada para a velocidade de corrida
                isRunning = true; //o player está correndo
            }

             if(Input.GetKeyUp(KeyCode.LeftShift)) //se soltar o botão de correr
            {
                velocidade = velocidadeInicial; //a velocidade do player é alterada para a velocidade inicial
                isRunning = false; //o player não está correndo
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

        void onInput()
        {   
                //armazena a direção do movimento ao apertar os botões direcionais
                _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        
        }

    #endregion 


}
