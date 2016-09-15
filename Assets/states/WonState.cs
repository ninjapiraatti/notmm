using UnityEngine;
using Assets.interfaces;

namespace Assets.states {

	public class WonState : IStateBase {

		private StateManager manager;
		public WonState (StateManager managerRef) {

			manager = managerRef;
			Debug.Log("Constructing wonstate");
		}
		public void StateUpdate() {
			if (Input.GetKeyUp (KeyCode.Space)) {
				manager.SwitchState (new BeginState (manager));
			}
		}
		public void ShowIt() {

		}
	}
}
