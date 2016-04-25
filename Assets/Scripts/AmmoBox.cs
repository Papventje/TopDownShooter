using UnityEngine;
using System.Collections;

public class AmmoBox : MonoBehaviour {

    public float speed = 3;

	void Update () {
        //transform.Translate(Vector3.down * speed * Time.deltaTime);	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            speed = 0;
            Debug.Log("hit the floor");
        }
    }
}
