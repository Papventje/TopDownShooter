﻿using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	void Start () {
        Destroy(gameObject, 2f);
	}
	
}