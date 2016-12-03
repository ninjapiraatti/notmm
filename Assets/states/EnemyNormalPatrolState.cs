using UnityEngine;
using System.Collections;
using Assets.states;
using Assets.interfaces;

public class EnemyNormalPatrolState : IEnemyState

{
  private readonly EnemyNormal enemy;
  private int nextWayPoint;

  public EnemyNormalPatrolState (EnemyNormal EnemyNormalVariable)
  {
    enemy = EnemyNormalVariable;
  }

  public void UpdateState()
  {
    Look ();
    Patrol ();
  }

  public void OnTriggerEnter2D (Collider2D other) {
    if (other.gameObject.CompareTag ("Player")) {
			ToAlertState ();
      Debug.Log ("Going to ALERT");
		}
  }

  public void OnCollisionEnter2D(Collision2D coll)
  {

  }

  public void ToPatrolState()
  {
    Debug.Log ("Can't transition to same state");
  }

  public void ToAlertState()
  {
    //enemy.currentState = enemy.alertState;
    //Debug.Log ("Going to ALERT");
    enemy.Fire();
  }

  public void ToChaseState()
  {
    enemy.currentState = enemy.chaseState;
  }

  private void Look()
  {

  }

  void Patrol ()
  {
		enemy.GetComponent<Rigidbody2D>().velocity = new Vector2 (enemy.speed, enemy.speedY);
  }
}
