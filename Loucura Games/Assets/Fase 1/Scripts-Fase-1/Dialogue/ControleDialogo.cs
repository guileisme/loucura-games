using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.FullSerializer.Internal;

public class ControleDialogo : MonoBehaviour
{

    [Header("Componentes")]
    public GameObject dialogueBoxObj; // Janela do diálogo
    public Image profileSprite; // Imagem do perfil do falador
    public Text speechText; // Texto do diálogo
    public Text actorNameText; // Nome do actor
    public GameObject infoBox; // Janela de informações

    [Header("Configurações")]
   public float velocidadeDeDigitacao; //velocidade da fala

    //variáveis de controle
    private bool isShowing; // Verifica se está visível o diálogo
    private int index; // quantidade de sentenças index das sentenças
    private string[] sentences; // Array de sentenças
    public static ControleDialogo instance; // Instância do diálogo
    private string[] CurrentActorName; // Array de nomes dos atores
    private Sprite[] CurrentActorProfile; // Array de perfis dos atores
    


    // awake é chamado antes de qualquer start
    void Awake()
    {
        instance = this;    
    }
    void Start()
    {
         
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
       
        foreach (char letter in sentences[index].ToCharArray())
        {
            //a cada repetição ele vai adicionar uma letra no speechText
            speechText.text += letter;
            //espera um tempo para adicionar a próxima letra
            yield return new WaitForSeconds(velocidadeDeDigitacao);
        }
    }

    //metodo para pular para proxima fala

    public void proximaFala()
    {
        if(speechText.text == sentences[index])
        { 
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                actorNameText.text = CurrentActorName[index];
                profileSprite.sprite = CurrentActorProfile[index]; 
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                actorNameText.text = "";
                index = 0;
                dialogueBoxObj.SetActive(false);
                this.sentences = null;
                isShowing = false;
            }
        
            
        }
        
    }

    //metodo para falar

    public void falar(string[] txt, string[] actorNames, Sprite[] actorProfile)
    {
        //se o npc estiver falando não deve conseguir chamar o speech novamente
        
        if(!isShowing){

            //ativa a janela do diálogo
            dialogueBoxObj.SetActive(true);
            //ativa a variável de controle para impedir que o jogador chame o diálogo novamente

            //pega a fala passada como parametro e atrela a variável sentences que é um array
            sentences = txt;
            CurrentActorName = actorNames;
            CurrentActorProfile = actorProfile;
            actorNameText.text = CurrentActorName[index];
            profileSprite.sprite = CurrentActorProfile[index]; 
            //chama o método para escrever a fala
            StartCoroutine(TypeSentence());

            isShowing = true;

        }

    }

    public void esconder(){
        dialogueBoxObj.SetActive(false);
        isShowing = false;
        //resetar o texto
        speechText.text = "";

    }


    public bool getIsShowing()
    {
        return isShowing;
    }


}
