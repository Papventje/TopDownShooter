using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public int currentHealth = 60;

    void Start()
    {
        if(currentHealth != 60)
        {
            currentHealth = 60;
        }
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            currentHealth = currentHealth - 20;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Laser"))
        {
            Destroy(gameObject);
        }
    }
}
