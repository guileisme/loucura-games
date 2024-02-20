using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float attackRange = 0.5f;
    public void Attack()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(AttackPoint.position, attackRange, playerLayer);
        if(hitPlayer != null)
        {
            //setar dano no player
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}