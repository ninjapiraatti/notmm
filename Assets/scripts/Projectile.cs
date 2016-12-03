using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (gameObject.CompareTag ("deadly")) {
			//Make the banhammer rotate
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		Destroy(gameObject);
	}
}
