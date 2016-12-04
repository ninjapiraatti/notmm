using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Collider2D>().enabled = false;
		InvokeRepeating("Activate", 0.1F, 10F);
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.CompareTag ("deadly")) {
			//Make the banhammer rotate
		}
		if(transform.position.y < -50) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Destroy(gameObject);
		}
	}

	void Activate () {
		gameObject.GetComponent<Collider2D>().enabled = true;
	}
}
