using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WeslaneDialogue : MonoBehaviour
{

    public float DialogueRange;
    public LayerMask PlayerLayer;
    // Start is called before the first frame update
    public bool playerHit;
    public DialogueSettings dialogueSettingsChamado;
    

    //vai armazenar localmente as frases das sentenças do outro script para depois então passar para o método
    //que vai mostrar as frases chamado getTexts
    private List<string> sentenças = new List<string>();

    void Awake()
    {
        getNPCInfo();
    }
    void Start()
    {
        foreach (string sentenca in sentenças)
        {
            Debug.Log(sentenca+",");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit == true)
        {
            ControleDialogo.instance.falar(sentenças.ToArray());

        }
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            ControleDialogo.instance.proximaFala();
        }
        //se o player estiver perto e o diálogo não estiver sendo mostrado
        if(playerHit == true && ControleDialogo.instance.getIsShowing() != true)
        {
            ControleDialogo.instance.infoBox.SetActive(true);

        }else
        {
            ControleDialogo.instance.infoBox.SetActive(false);
        }
        
    }
    
    // é usado pela física
    void FixedUpdate()
    {
        showDialogue();
    }


    void showDialogue()
    {     
        Collider2D hit = Physics2D.OverlapCircle(transform.position, DialogueRange, PlayerLayer);                                         
        //criando um colisor via código
        //transform.position é a posição do objeto que tem esse script
        //DialogueRange é a distancia que o colisor vai ter
        //PlayerFase1Layer é a layer que é detectada pelo colisor neste caso somente
        //o player está na layer Fase1

        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            //acessa a classe controeDiálogo, instaciado, e desativa dialogueBoxObj que é a chamada na classe para a janela de diálogo
            //dentro da unity e seta como falso
        }
    
    }

    void getNPCInfo()
    {   
        //esse for vai a quantidade de falas que tiver
        //pqp eu passei 1 hora pq eu errei esse for maldito, sempre tenha cuidado com loops
        for(int i = 0; i < dialogueSettingsChamado.ListaDeSentenças.Count;i++)
        {
                sentenças.Add(dialogueSettingsChamado.ListaDeSentenças[i].sentence.portuguese);
                //pega da classe dialogueSettings na lista de sentenças(i) e pega a sentença em portugues e adiciona a essa outra
                //lista de sentençasLocal 
        }
    }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, DialogueRange);

        }

 }
