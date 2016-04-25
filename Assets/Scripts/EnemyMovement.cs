using UnityEngine;
using System.Collections;

public class EnemyMovement: MonoBehaviour {

    NavMeshAgent _navMeshAgent;
    GameObject _playerGameObject;

    public int playerHealth = 100;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

   void Update()
    {
        _navMeshAgent.SetDestination(_playerGameObject.transform.position);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("UGH I'M DEAD");
            Damage();
        }
    }

    void Damage()
    {
        playerHealth -= 10;
        Debug.Log(playerHealth);
    }
}
