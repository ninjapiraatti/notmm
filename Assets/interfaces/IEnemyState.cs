using UnityEngine;
using System.Collections;
using Assets.states;
using Assets.interfaces;

public interface IEnemyState
{

    void UpdateState();

    void OnTriggerEnter2D (Collider2D other);

    void OnCollisionEnter2D (Collision2D other);

    void ToPatrolState();

    void ToAlertState();

    void ToChaseState();
}
