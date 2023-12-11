using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class deathCollider : MonoBehaviour
{
    Vector2 spawnPoint;
    public gameOver gameOverScreen;

    void Start()
    {
        spawnPoint = transform.position;    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("deathTag"))
        {
            Die();
            gameOverScreen.gameObject.SetActive(true);
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

    public void gameOver()
    {
        gameOverScreen.Setup();
    }
}
