using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2D : MonoBehaviour
{

    public float maxY, minY;
    public GameObject[] enemy;
    public int numberOfEnemies;
    public float spawnTime;

    private int currentEnemies;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies >= numberOfEnemies)
        {
            int enemies = FindObjectsOfType<Slime_Walk>().Length;
            if (enemies <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void SpawnEnemy()
    {
        bool positionX = Random.Range(0, 2) == 0 ? true : false;
        Vector2 spawnPosition;
        spawnPosition.y = transform.position.y + Random.Range(minY, maxY);
        if (positionX)
        {
            spawnPosition = new Vector2(transform.position.x + 10, spawnPosition.y);
        }
        else
        {
            spawnPosition = new Vector2(transform.position.x - 10, spawnPosition.y);
        }
        Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPosition, Quaternion.identity);
        currentEnemies++;
        if (currentEnemies < numberOfEnemies)
        {
            Invoke("SpawnEnemy", spawnTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")
        )
        {
            GetComponent<BoxCollider2D>().enabled = false;
            SpawnEnemy();
        }
    }
}
