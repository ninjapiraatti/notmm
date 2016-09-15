using UnityEngine;
using System.Collections;
using Assets.states;
using Assets.interfaces;

public class EnemyChaseState : IEnemyState

{

  private readonly EnemyBoss enemy;


  public EnemyChaseState (EnemyBoss statePatternEnemy)
  {
    enemy = statePatternEnemy;
  }

  public void UpdateState()
  {
    Look ();
    Chase ();
  }

  public void OnTriggerEnter (Collider other)
  {

  }

  public void ToPatrolState()
  {

  }

  public void ToAlertState()
  {
    enemy.currentState = enemy.alertState;
  }

  public void ToChaseState()
  {

  }

  private void Look()
  {

  }

  private void Chase()
  {

  }
}
