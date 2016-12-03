using UnityEngine;
using System.Collections;
using Assets.states;
using Assets.interfaces;

public class EnemyChaseState : IEnemyState

{

  private readonly EnemyBoss enemy;

  public EnemyChaseState (EnemyBoss EnemyBossVariable)
  {
    enemy = EnemyBossVariable;
  }

  public void UpdateState()
  {
    Look ();
    Chase ();
  }

  public void OnTriggerEnter2D (Collider2D other)
  {

  }

  public void OnCollisionEnter2D(Collision2D coll)
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
