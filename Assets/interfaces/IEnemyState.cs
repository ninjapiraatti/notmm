using UnityEngine;
using System.Collections;
using Assets.states;
using Assets.interfaces;

public interface IEnemyState
{

    void UpdateState();

    void OnTriggerEnter (Collider other);

    void ToPatrolState();

    void ToAlertState();

    void ToChaseState();
}
