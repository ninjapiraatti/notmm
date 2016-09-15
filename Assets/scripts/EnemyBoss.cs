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

	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public EnemyChaseState chaseState;
	[HideInInspector] public EnemyAlertState alertState;
	[HideInInspector] public EnemyPatrolState patrolState;
	[HideInInspector] public NavMeshAgent navMeshAgent;

	private void Awake()
	{
			chaseState = new EnemyChaseState (this);
			alertState = new EnemyAlertState (this);
			patrolState = new EnemyPatrolState (this);

			navMeshAgent = GetComponent<NavMeshAgent> ();
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

	public void Flip () {
		facingRight = !facingRight;
		someScale *= -1;
		transform.localScale = new Vector2(someScale, transform.localScale.y);
	}
	void Update () {
		if (currentState != null) {
			currentState.UpdateState ();
		}
	}
}
