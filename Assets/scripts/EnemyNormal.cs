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
	public bool facingRight = true;

	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public EnemyNormalChaseState chaseState;
	[HideInInspector] public EnemyNormalAlertState alertState;
	[HideInInspector] public EnemyNormalPatrolState patrolState;
	[HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;

	private void Awake()
	{
			chaseState = new EnemyNormalChaseState (this);
			alertState = new EnemyNormalAlertState (this);
			patrolState = new EnemyNormalPatrolState (this);

			navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
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
		someScale *= 1;
		transform.localScale = new Vector2(someScale, transform.localScale.y);
	}
	void Update () {
		if (currentState != null) {
			currentState.UpdateState ();
		}
	}
}
