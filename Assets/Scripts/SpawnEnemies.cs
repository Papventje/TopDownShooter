using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

    public GameObject[] enemies;
    public int amount;
    public int spawnAmount = 12;
    private Vector3 spawnPoint;

	void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        amount = enemies.Length;

            if (amount != spawnAmount)
            {
                InvokeRepeating("SpawnEnemy", 1, 4f);
            }

            

        }

    void IncreaseEnemies()
    {
        spawnAmount += 4;
    }

    void SpawnEnemy()
    {
        spawnPoint.x = Random.Range(-20, 20);
        spawnPoint.y = 3/4;
        spawnPoint.z = Random.Range(-20, 20);

        Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length - 1)], spawnPoint, Quaternion.identity);
        CancelInvoke();
    }

    
}
