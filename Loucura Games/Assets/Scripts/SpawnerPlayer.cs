using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SpawnerPlayer : MonoBehaviour
{
    public GameObject[] Player;
    public GameObject scenePlayer; //Objeto criado para o jogador que vai aparecer na cena 
    public int playerIndex; //index do jogador


    void Awake()
    {
        playerIndex = FindObjectOfType<GameManager>().CharacterIndex - 1;
        scenePlayer = Instantiate(Player[playerIndex], transform.position, transform.rotation);
    }

}
