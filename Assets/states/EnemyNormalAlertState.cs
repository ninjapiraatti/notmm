using UnityEngine;
using System.Collections;

public class EnemyNormalAlertState : IEnemyState

{
  private readonly EnemyNormal enemy;
  private float searchTimer;

  public EnemyNormalAlertState (EnemyNormal EnemyNormalVariable)
  {
    enemy = EnemyNormalVariable;
  }

  public void UpdateState()
  {
    Look ();
    Search ();
  }

  public void OnTriggerEnter2D (Collider2D other)
  {

  }

  public void OnCollisionEnter2D(Collision2D coll)
  {

  }

  public void ToPatrolState()
  {
    enemy.currentState = enemy.patrolState;
    searchTimer = 0f;
  }

  public void ToAlertState()
  {
    Debug.Log ("Can't transition to same state");
  }

  public void ToChaseState()
  {
    enemy.currentState = enemy.chaseState;
    searchTimer = 0f;
  }

  private void Look()
  {

  }

  private void Search()
  {

  }


}
