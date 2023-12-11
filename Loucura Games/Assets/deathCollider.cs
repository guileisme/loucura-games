using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class deathCollider : MonoBehaviour
{
    Vector2 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position;    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("deathTag"))
        {
            Die();
        }
    }

    public void Respawn()
    {
        transform.position = spawnPoint;
    }

    private void Die()
    {
        Respawn();
    }
}
