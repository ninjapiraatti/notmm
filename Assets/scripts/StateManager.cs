using UnityEngine;
using Assets.states;
using Assets.interfaces;

public class StateManager : MonoBehaviour {
	private IStateBase activeState;
	// Use this for initialization
	void Start () {
		activeState = new BeginState(this);
		//Debug.Log("This object is of type: " + activeState);
	}

	// Update is called once per frame
	void Update () {
		if (activeState != null) {
			activeState.StateUpdate();
		}
	}
	public void SwitchState (IStateBase newState) {
		activeState = newState;
	}
}
