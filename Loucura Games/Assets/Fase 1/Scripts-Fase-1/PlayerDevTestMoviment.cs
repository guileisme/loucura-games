using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDevTestMoviment : MonoBehaviour
{

    public float velocidade;
    private Rigidbody2D rig; //rig = corpo rigido do player 
    private Vector2 direction; //direção do movimento

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); //pega o corpo rigido do player
    }

    // Update is called once per frame
    void Update()
    {
        //armazena a direção do movimento ao apertar os botões direcionais
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    //coisas relacionadas a física utiliza o fixedupdate
    private void FixedUpdate()
    {
        //movimenta o player
        //move o corpo a uma direção, com uma velocidade e um tempo
        //pega a posição dele e soma a um vetor de direção
        rig.MovePosition(rig.position + direction * velocidade * Time.fixedDeltaTime);
    }
}
