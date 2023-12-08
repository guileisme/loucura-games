using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpawnerPlayer;

public class PlayerCamera : MonoBehaviour
{
    public Transform followTarget; //vari�vel que vai definir qual objeto ser� seguido pela c�mera
    public CinemachineVirtualCamera virtualCamera; //a c�mera que vai ser criada
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Update()
    {
        player1 = GameObject.Find("Player(Clone)");
        player2 = GameObject.Find("Heroi2(Clone)");
        if (player1 != null)
        {       
            followTarget = player1.transform;
            virtualCamera.LookAt = followTarget;
            virtualCamera.Follow = followTarget;
        }

        else if (player2 != null)
        {
            followTarget = player2.transform;
            virtualCamera.LookAt = followTarget;
            virtualCamera.Follow = followTarget;
        }
    }
}