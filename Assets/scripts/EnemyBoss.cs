using UnityEngine;
using Assets.states;
using Assets.interfaces;

public class EnemyBoss : MonoBehaviour {

	bool isActive = false;
	bool hearsPlayer;
	bool seesPlayer;
	float distanceToPlayer;
	public GameObject player;
	float someScale;
	public float speed = -2f;
	public bool facingRight = true;
	public Animator anim;
	public GameObject projectile;
	public Transform myTransform;

	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public EnemyChaseState chaseState;
	[HideInInspector] public EnemyAlertState alertState;
	[HideInInspector] public EnemyPatrolState patrolState;
	[HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;

	private void Awake()
	{
			chaseState = new EnemyChaseState (this);
			alertState = new EnemyAlertState (this);
			patrolState = new EnemyPatrolState (this);

			navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	// Enemy boss starts inactive.
	// Use this for initialization
	void Start () {
		someScale = transform.localScale.x;
		anim = GetComponent<Animator>();
		currentState = patrolState;
		isActive = true;
	}

	// Update is called once per frame
	void FixedUpdate () {

	}

	private void OnTriggerEnter2D(Collider2D other) {
  	currentState.OnTriggerEnter2D (other);
  }

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("verticalwall")) {
			Flip();
		}
		if (other.gameObject.CompareTag ("projectile")) {

		}
	}

	public void Fire () {
		//shootSound.Play();
		float projectileAngleX = -1F;
		float projectileAngleY = 0F;
		for (int i = 0; i<6; i++) {
			GameObject projectileClone = (GameObject)Instantiate(projectile, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
			Vector3 dir = Quaternion.AngleAxis(i*35, Vector3.forward) * Vector3.right;
			projectileClone.GetComponent<Rigidbody2D>().AddForce(dir*1000);
		}
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
}
