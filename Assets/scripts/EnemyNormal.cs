using UnityEngine;
using System.Collections;

public class EnemyNormal : MonoBehaviour {

	public float maxSpeed = 10f;
	float maxJumpSpeed = 400f;
	bool facingRight = true;
	bool grounded = true;
	public float someScale;
	public float speed;
	public float speedY;
	public Transform top_left;
 	public Transform bottom_right;
 	public LayerMask ground_layers;
	public bool canShoot = false;
	public GameObject projectile;
	Animator anim;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
	}

	void Update () {
	}

	void Flip () {
		facingRight = !facingRight;
		someScale *= -1;
		transform.localScale = new Vector2(someScale, transform.localScale.y);
	}

	void Fire () {
		canShoot = false;
		Debug.Log(canShoot);
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
