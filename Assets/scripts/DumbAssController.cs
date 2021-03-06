﻿using UnityEngine;
using System.Collections;

public class DumbAssController : MonoBehaviour {

	public float maxSpeed = 10f;
	float maxJumpSpeed = 400f;
	bool facingRight = true;
	bool grounded = true;
	bool canHurt = true;
	public float someScale;
	public float speed;
	public float speedY;
	public Transform top_left;
 	public Transform bottom_right;
 	public LayerMask ground_layers;
	public bool canShoot = false;
	public GameObject projectile;
	public bool damaged = false;
	public AudioSource[] sounds;
	public AudioSource shootSound;
 	public AudioSource damageSound;
	public AudioSource dieSound;
	public AudioSource teleportSound;
	public SpriteRenderer renderer;
	public SpriteRenderer renderer2;
	Animator anim;

	// Use this for initialization
	void Start () {
		someScale = transform.localScale.x;
		anim = GetComponent<Animator>();
		sounds = GetComponents<AudioSource>();
 		shootSound = sounds[0];
 		damageSound = sounds[1];
		dieSound = sounds[2];
		teleportSound = sounds[3];
	}

	// Update is called once per frame
	void FixedUpdate () {
		speed = Input.GetAxis ("Horizontal");
		speedY = Input.GetAxis ("Vertical");
		anim.SetFloat("speed", Mathf.Abs(speed));
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		if (speed > 0 && !facingRight) {
			Flip();
		} else if (speed < 0 && facingRight) {
			Flip();
		}
		if (Input.GetButtonDown("Fire1") && (canShoot)) {
			Fire();
		}
		grounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, ground_layers);
	}

	void Update () {
		if (speedY > 0 && grounded == true) {
			grounded = false;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, maxJumpSpeed));
			//GetComponent<Rigidbody2D>().velocity = new Vector2(0, maxJumpSpeed);
		}
		if(transform.position.y < -50) {
			Die();
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("deadly") && canHurt == true) {
			Hurt();
		}
		if (other.gameObject.CompareTag ("teleport")) {
			transform.position = new Vector3(22f, -9f, 0);
			teleportSound.Play();
		}
	}

	void Hurt () {
		if(!damaged) {
			transform.localScale = new Vector2(someScale, 0.5f);
			damaged = true;
			damageSound.Play();
			StartCoroutine(Blink());
		} else {
			Die();
		}
	}

	IEnumerator Blink () {
		canHurt = false;
		renderer.color = new Color(255f, 255f, 255f, 0.5f);
		renderer2.color = new Color(255f, 255f, 255f, 0.5f);
		yield return new WaitForSeconds(3);
		canHurt = true;
		renderer.color = new Color(255f, 255f, 255f, 1f);
		renderer2.color = new Color(255f, 255f, 255f, 1f);
	}

	void Die () {
		Destroy(gameObject);
		Application.LoadLevel(Application.loadedLevel);
	}

	void Flip () {
		facingRight = !facingRight;
		someScale *= -1;
		transform.localScale = new Vector2(someScale, transform.localScale.y);
	}

	void Fire () {
		canShoot = false;
		Debug.Log(canShoot);
		shootSound.Play();
		if(facingRight) {
			GameObject projectileClone = (GameObject)Instantiate(projectile, new Vector2 (this.transform.position.x+1, this.transform.position.y), Quaternion.identity);
			Vector3 dir = Vector3.right;
			projectileClone.GetComponent<Rigidbody2D>().AddForce(dir*1000);
		}
		else {
			GameObject projectileClone = (GameObject)Instantiate(projectile, new Vector2 (this.transform.position.x-1, this.transform.position.y), Quaternion.identity);
			Vector3 dir = Vector3.left;
			projectileClone.GetComponent<Rigidbody2D>().AddForce(dir*1000);
		}
	}

}
