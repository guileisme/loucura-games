using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine;

public class Slime_Walk : MonoBehaviour
{   
    private Animator MobAnim;
    [SerializeField] private NavMeshAgent agent;
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        MobAnim = GetComponent<Animator>(); // Initialize MobAnim
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);
        if(Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            if (MobAnim != null)
            {
                MobAnim.SetBool("attack", true);
            }
        }
        else
        {
            agent.isStopped = false;
            if (MobAnim != null)
            {
                MobAnim.SetBool("attack", false);
            }
        }
        float positionX = player.transform.position.x - transform.position.x;
        if (positionX < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (positionX > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
}