using UnityEngine;
using System.Collections;

public class EnemyAlertState : IEnemyState

{
  private readonly EnemyBoss enemy;
  private float searchTimer;

  public EnemyAlertState (EnemyBoss statePatternEnemy)
  {
    enemy = statePatternEnemy;
  }

  public void UpdateState()
  {
    Look ();
    Search ();
  }

  public void OnTriggerEnter (Collider other)
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
