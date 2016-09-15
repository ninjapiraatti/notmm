using UnityEngine;
using System.Collections;
using Assets.states;
using Assets.interfaces;

public class EnemyPatrolState : IEnemyState

{
  private readonly EnemyBoss enemy;
  private int nextWayPoint;

  public EnemyPatrolState (EnemyBoss statePatternEnemy)
  {
    enemy = statePatternEnemy;
  }

  public void UpdateState()
  {
    Look ();
    Patrol ();
  }

  public void OnTriggerEnter (Collider other)
  {
    if (other.gameObject.CompareTag ("Player")) {
			ToAlertState ();
		}
  }

  public void ToPatrolState()
  {
    Debug.Log ("Can't transition to same state");
  }

  public void ToAlertState()
  {
    enemy.currentState = enemy.alertState;
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
		enemy.anim.SetFloat("speed", Mathf.Abs(enemy.speed));
		enemy.GetComponent<Rigidbody2D>().velocity = new Vector2 (enemy.speed, 0);
		if (enemy.speed > 0 && !enemy.facingRight) {
			enemy.Flip();
		} else if (enemy.speed < 0 && enemy.facingRight) {
			enemy.Flip();
		}
  }
}
