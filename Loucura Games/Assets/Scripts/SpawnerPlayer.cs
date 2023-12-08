using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour
{
    public GameObject[] Player;

    void Awake(){
        int index = FindObjectOfType<GameManager>().CharacterIndex-1;
        Instantiate(Player[index], transform.position, transform.rotation);
    }

}
