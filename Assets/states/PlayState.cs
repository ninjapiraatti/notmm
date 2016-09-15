using UnityEngine;
using Assets.interfaces;

namespace Assets.states {

	public class PlayState : IStateBase {

		private StateManager manager;
		public PlayState (StateManager managerRef) {

			manager = managerRef;
			Debug.Log("Constructing playstate");
		}
		public void StateUpdate() {
			if (Input.GetKeyUp (KeyCode.Space)) {
				manager.SwitchState (new WonState (manager));
			}
		}
		public void ShowIt() {

		}
	}
}
