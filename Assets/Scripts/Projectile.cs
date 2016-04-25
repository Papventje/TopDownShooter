using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    private float _speed = 3;

	void Update () {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
	}

    void Start()
    {
        Destroy(gameObject, 2f);
    }
    public void SetSpeed(float value)
    {
        _speed = value;
    }

   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Wall"))
        {
            _speed = 0;
        }
    }
}
