using UnityEngine;
using Assets.interfaces;

namespace Assets.states {

	public class LostState : IStateBase {

		private StateManager manager;
		public LostState (StateManager managerRef) {

			manager = managerRef;
			Debug.Log("Constructing loststate");
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
