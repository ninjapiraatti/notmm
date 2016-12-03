using UnityEngine;
using Assets.states;
using Assets.interfaces;

public class EnemyNormal : MonoBehaviour {


	bool isActive = false;
	bool hearsPlayer;
	bool seesPlayer;
	float distanceToPlayer;
	public GameObject player;
	float someScale;
	public float speed = -2f;
	public float speedY;
	public bool facingRight = false;
	public GameObject projectile;

	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public EnemyNormalChaseState chaseState;
	[HideInInspector] public EnemyNormalAlertState alertState;
	[HideInInspector] public EnemyNormalPatrolState patrolState;
	//[HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;

	private void Awake()
	{
			chaseState = new EnemyNormalChaseState (this);
			alertState = new EnemyNormalAlertState (this);
			patrolState = new EnemyNormalPatrolState (this);

			//navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	// Use this for initialization
	void Start () {
		someScale = transform.localScale.x;
		currentState = patrolState;
		isActive = true;
		speed = -1f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		speedY = GetComponent<Rigidbody2D>().velocity.y;
	}

	public void Flip () {
		facingRight = !facingRight;
		someScale *= -1;
		speed = -speed;
		transform.localScale = new Vector2(someScale, transform.localScale.y);
	}
	void Update () {
		if (currentState != null) {
			currentState.UpdateState ();
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
  	currentState.OnTriggerEnter2D (other);
  }

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("verticalwall")) {
			Flip();
		}
	}

	public void Fire () {
		if(!facingRight) {
			GameObject projectileClone = (GameObject)Instantiate(projectile, new Vector2 (this.transform.position.x+2, this.transform.position.y+0.6f), Quaternion.identity);
			Vector3 dir = new Vector3(1f,0.5f,0f);
			projectileClone.GetComponent<Rigidbody2D>().AddForce(dir*700);
		}
		else {
			GameObject projectileClone = (GameObject)Instantiate(projectile, new Vector2 (this.transform.position.x-2, this.transform.position.y+0.6f), Quaternion.identity);
			Vector3 dir = new Vector3(-1f,0.5f,0f);
			projectileClone.GetComponent<Rigidbody2D>().AddForce(dir*700);
		}
	}
}
