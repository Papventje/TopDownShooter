using UnityEngine;
using System.Collections;

public class SpawnAmmo : MonoBehaviour {

    public GameObject[] ammoBox;
    public int ammoAmount;
    private Vector3 ammoSpawnPoint;

    void Update () {
        ammoBox = GameObject.FindGameObjectsWithTag("Ammo");
        ammoAmount = ammoBox.Length;

        if (ammoAmount != 2)
        {
            InvokeRepeating("Ammo", 5, 10f);
        }

    }

    void Ammo()
    {
        ammoSpawnPoint.x = Random.Range(-20, 20);
        ammoSpawnPoint.y = 1 / 2;
        ammoSpawnPoint.z = Random.Range(-20, 20);

        Instantiate(ammoBox[UnityEngine.Random.Range(0, ammoBox.Length - 1)], ammoSpawnPoint, Quaternion.identity);
        CancelInvoke();
    }

}
